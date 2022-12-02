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
        private Camera3D cam3d;
        private RobotControl robot;

        public frmWeldIdentify()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void frmWeldIdentify_Load(object sender, EventArgs e)
        {
            timerUpdate2D.Tick += new EventHandler(timerUpdate2D_Tick);  //绑定事件
            timerUpdate2D.Interval = 200;
            timerUpdate3D.Tick += new EventHandler(timerUpdate3D_Tick);  //绑定事件
            timerUpdate3D.Interval = 200;
            timerUpdateRobot.Tick += new EventHandler(timerUpdateRobot_Tick);  //绑定事件
            timerUpdateRobot.Interval = 200;

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
                        cam2d = null;
                        break;
                    }
            }
            switch (frmS.cam3dSoftware)
            {
                case "3DPreciseLocate":
                    {
                        cam3d = new CareraChishine();
                        break;
                    }
                default:
                    {
                        cam3d = null;
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
                        robot = null;
                        break;
                    }
            }

            //初始化视觉软件及机器人控制软件
            OpenVisionSoftware(cam2d, ref panel2D);
            OpenVisionSoftware(cam3d, ref panel3D);
            //OpenRobotControl(robot,ref panelRobot);
        }

        private void frmWeldIdentify_FormClosed(object sender, FormClosedEventArgs e)
        {
            Thread.Sleep(100);

            //关闭视觉软件及机器人控制软件
            CloseVisionSoftware(cam2d);
            CloseVisionSoftware(cam3d);
            CloseRobotControl(robot);
        }

        void timerUpdate2D_Tick(object sender, EventArgs e)
        {
            if (cam2d.handle != IntPtr.Zero)
            {
                Thread t = new Thread(() => ResizeWindow(cam2d.handle));
                t.Start();  //开线程刷新第三方窗体大小
                Thread.Sleep(50); //略加延时
                timerUpdate2D.Stop();  //停止定时器
            }
        }

        void timerUpdate3D_Tick(object sender, EventArgs e)
        {
            if (cam3d.handle != IntPtr.Zero)
            {
                Thread t = new Thread(() => ResizeWindow(cam3d.handle));
                t.Start();  //开线程刷新第三方窗体大小
                Thread.Sleep(50); //略加延时
                timerUpdate2D.Stop();  //停止定时器
            }
        }

        void timerUpdateRobot_Tick(object sender, EventArgs e)
        {
            if (robot.handle != IntPtr.Zero)
            {
                Thread t = new Thread(() => ResizeWindow(robot.handle));
                t.Start();  //开线程刷新第三方窗体大小
                Thread.Sleep(50); //略加延时
                timerUpdate2D.Stop();  //停止定时器
            }
        }

        public void ResizeWindow(IntPtr handle)
        {
            ShowWindow(handle, 0);  //先将窗口隐藏
            ShowWindow(handle, 3);  //再将窗口最大化，可以让第三方窗口自适应容器的大小
        }

        //2D和3D视觉软件嵌入显示
        private void OpenVisionSoftware(CameraBase cam, ref Panel p)
        {
            try
            {
                cam.InitCameraSoftware();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            if (cam.handle == IntPtr.Zero)
            {
                MessageBox.Show($"Not Find {cam.frmName}Form!");
            }
            Thread.Sleep(500);

            RemoveWindowBorder(cam.handle);  //移除边框
            SetParent(cam.handle, p.Handle); //嵌入父容器
            ShowWindowAsync(cam.handle, 3);   //显示
        }

        //机器人控制软件嵌入显示
        private void OpenRobotControl(RobotControl robot, ref Panel p)
        {
            try
            {
                robot.InitRobot();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            if (robot.handle == IntPtr.Zero)
            {
                MessageBox.Show($"Not Find {robot.frmName}Form!");
            }
            Thread.Sleep(500);

            RemoveWindowBorder(robot.handle);  //移除边框
            SetParent(robot.handle, p.Handle); //嵌入父容器
            ShowWindowAsync(robot.handle, 3);   //显示
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

        //关闭视觉软件
        private void CloseVisionSoftware(CameraBase cam)
        {
            if (cam!=null)
            {
                try
                {
                    cam.CloseCamera();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
        }

        //关闭机器人控制软件
        private void CloseRobotControl(RobotControl robot)
        {
            if (robot != null)
            {
                try
                {
                    robot.CloseRobot();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
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

        private void panel2D_SizeChanged(object sender, EventArgs e)
        {
            timerUpdate2D.Start();
        }

        private void panel3D_SizeChanged(object sender, EventArgs e)
        {
            timerUpdate3D.Start();
        }

        private void panelRobot_SizeChanged(object sender, EventArgs e)
        {
            timerUpdateRobot.Start();
        }
    }
}
