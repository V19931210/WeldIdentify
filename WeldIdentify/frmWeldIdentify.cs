using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.IO;
using System.Net;
using System.Net.Sockets;

using PclSharp;
using PclSharp.IO;
using PclSharp.Common;
using PclSharp.Registration;

namespace WeldIdentify
{
    public partial class frmWeldIdentify : Form
    {
        [DllImport("user32.dll", EntryPoint = "ShowWindow", CharSet = CharSet.Auto)]
        private static extern int ShowWindow(IntPtr hwnd, int nCmdShow);//设置窗体属性
        [DllImport("user32.dll", EntryPoint = "GetWindowLong", CharSet = CharSet.Auto)]
        public static extern long GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll", EntryPoint = "SetWindowLong", CharSet = CharSet.Auto)]
        public static extern IntPtr SetWindowLong(IntPtr hWnd, int nIndex, long dwNewLong);
        [DllImport("user32.dll", EntryPoint = "SetParent")]
        private static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);   //将外部窗体嵌入程序
        [DllImport("user32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);
        [DllImport("user32.dll", EntryPoint = "PostMessage")]
        private static extern bool PostMessage(IntPtr hWnd, uint msg, uint wParam, uint lParam);

        //选择视觉软件及机器人控制软件的界面
        private frmSelect frmS = new frmSelect();

        //视觉软件指针 机器人控制软件指针
        private Camera2D cam2d;
        private Camera3DRegis cam3dRegis;
        private Camera3DRecog cam3dRecog;
        private RobotControl robot;

        public frmWeldIdentify()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void frmWeldIdentify_Load(object sender, EventArgs e)
        {
            timerUpdateFrm.Tick += new EventHandler(timerUpdateFrm_Tick);
            timerUpdateFrm.Interval = 200;

            frmS.ShowDialog();
            if (frmS.DialogResult != DialogResult.OK)
            {
                return;
            }

            //根据指定类型的Camera初始化视觉软件指针 todo
            switch (frmS.cam2dSoftware)
            {
                case "BCVWeldTrack":
                    {
                        cam2d = new CareraBCW500();
                        break;
                    }
                default:
                    {
                        cam2d = new Carera2DTest();
                        break;
                    }
            }
            switch (frmS.cam3dRegisSoftware)
            {
                case "3DPreciseLocate":
                    {
                        cam3dRegis = new CareraRegisChishine();
                        break;
                    }
                default:
                    {
                        cam3dRegis = new CareraRegisTest();
                        break;
                    }
            }
            switch (frmS.cam3dRecogSoftware)
            {
                case "TracerStudio":
                    {
                        cam3dRecog = new CareraRecogChishine();
                        break;
                    }
                default:
                    {
                        cam3dRecog = new CareraRecogTest();
                        break;
                    }
            }
            switch (frmS.camRobotSoftware)
            {
                case "CypWeld":
                    {
                        robot = new RobotControlCypWeld();
                        break;
                    }
                default:
                    {
                        robot = new RobotControlTest();
                        break;
                    }
            }

            //初始化视觉软件及机器人控制软件
            OpenVisionSoftware(cam2d, ref panel2D);
            //OpenVisionSoftware(cam3dRegis, ref panel3DRegis);
            OpenVisionSoftware(cam3dRecog, ref panel3DRecog);
            //OpenVisionSoftware(robot, ref panelRobot);

            OpenVisionSoftwareWithoutSocket(cam3dRegis, ref panel3DRegis);
            OpenVisionSoftwareWithoutSocket(robot, ref panelRobot);
        }

        private void frmWeldIdentify_FormClosed(object sender, FormClosedEventArgs e)
        {
            Thread.Sleep(100);

            //关闭视觉软件及机器人控制软件
            CloseVisionSoftware(cam2d);
            CloseVisionSoftware(cam3dRegis);
            CloseVisionSoftware(cam3dRecog);
            CloseVisionSoftware(robot);
        }

        void timerUpdateFrm_Tick(object sender, EventArgs e)
        {
            if (cam2d.handle != IntPtr.Zero)
            {
                Thread t = new Thread(() => ResizeWindow(cam2d.handle));
                t.Start();  //开线程刷新第三方窗体大小
                Thread.Sleep(30); //略加延时
            }
            if (cam3dRegis.handle != IntPtr.Zero)
            {
                Thread t = new Thread(() => ResizeWindow(cam3dRegis.handle));
                t.Start();
                Thread.Sleep(30);
            }
            if (cam3dRecog.handle != IntPtr.Zero)
            {
                Thread t = new Thread(() => ResizeWindow(cam3dRecog.handle));
                t.Start();
                Thread.Sleep(30);
            }
            if (robot.handle != IntPtr.Zero)
            {
                Thread t = new Thread(() => ResizeWindow(robot.handle));
                t.Start();
                Thread.Sleep(30);
            }
            timerUpdateFrm.Stop();  //停止定时器
        }

        public void ResizeWindow(IntPtr handle)
        {
            ShowWindow(handle, 0);  //先将窗口隐藏
            ShowWindow(handle, 3);  //再将窗口最大化，可以让第三方窗口自适应容器的大小
        }

        //视觉软件嵌入显示 不初始化socket
        private void OpenVisionSoftwareWithoutSocket(VisionBase soft, ref Panel p)
        {
            try
            {
                soft.InitCameraSoftwareWithoutSocket();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            if (soft.handle == IntPtr.Zero)
            {
                MessageBox.Show($"Not Find {soft.frmName}Form!");
            }
            Thread.Sleep(500);

            RemoveWindowBorder(soft.handle);  //移除边框
            SetParent(soft.handle, p.Handle); //嵌入父容器
            ShowWindowAsync(soft.handle, 3);   //显示
        }

        //视觉软件嵌入显示
        private void OpenVisionSoftware(VisionBase soft, ref Panel p)
        {
            try
            {
                soft.InitCameraSoftware();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            if (soft.handle == IntPtr.Zero)
            {
                MessageBox.Show($"Not Find {soft.frmName}Form!");
            }
            Thread.Sleep(500);

            RemoveWindowBorder(soft.handle);  //移除边框
            SetParent(soft.handle, p.Handle); //嵌入父容器
            ShowWindowAsync(soft.handle, 3);   //显示
        }

        //关闭视觉软件
        private void CloseVisionSoftware(VisionBase soft)
        {
            if (soft != null)
            {
                try
                {
                    soft.CloseCamera();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
        }

        public static void RemoveWindowBorder(IntPtr handle)
        {
            const int GWL_STYLE = (-16);
            const int WS_CAPTION = 0xC00000;
            const int WS_BORDER = 0x800000;
            const int WS_THICKFRAME = 0x00040000;
            const int WS_CHILDWINDOW = 0x40000000;

            long LStyle = GetWindowLong(handle, GWL_STYLE);

            LStyle = (LStyle & (~WS_CAPTION) & (~WS_BORDER) & (~WS_THICKFRAME)) | WS_CHILDWINDOW;
            SetWindowLong(handle, GWL_STYLE, LStyle);
        }

        //日志栏添加带时间的log
        public void AddLogWithTime(string str)
        {
            Log.AppendText(System.DateTime.Now + ": " + str + "\r\n");
        }

        //日志栏添加不带时间的log
        public void AddLog(string str)
        {
            Log.AppendText(str + "\r\n");
        }

        private void panel3DRecog_SizeChanged(object sender, EventArgs e)
        {
            timerUpdateFrm.Start();
        }

        //读取CAD点云
        public void GetCADPointCloud()
        {

        }
        //点云配准
        public void PointCloudRegis()
        {

        }

    }
}
