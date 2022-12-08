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
        private static extern int ShowWindow(IntPtr hwnd, int nCmdShow);
        [DllImport("user32.dll", EntryPoint = "GetWindowLong", CharSet = CharSet.Auto)]
        public static extern long GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll", EntryPoint = "SetWindowLong", CharSet = CharSet.Auto)]
        public static extern IntPtr SetWindowLong(IntPtr hWnd, int nIndex, long dwNewLong);
        [DllImport("user32.dll", EntryPoint = "SetParent")]
        private static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
        [DllImport("user32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);
        [DllImport("user32.dll", EntryPoint = "PostMessage")]
        private static extern bool PostMessage(IntPtr hWnd, uint msg, uint wParam, uint lParam);
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);
        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        private static extern bool SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

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

            //根据指定类型的Camera初始化视觉软件指针
            switch (frmS.camRobotSoftware)
            {
                case "CypWeld":
                    {
                        robot = new RobotControlCypWeld();
                        break;
                    }
                case "CypWeldDemo":
                    {
                        robot = new RobotControlCypWeldDemo();
                        break;
                    }
                case "RobotControlTest":
                    {
                        robot = new RobotControlTest();
                        break;
                    }
                default:
                    {
                        robot = null;
                        break;
                    }
            }
            switch (frmS.cam2dSoftware)
            {
                case "BCVWeldTrack":
                    {
                        cam2d = new CareraBCW500();
                        break;
                    }

                case "Camera2DTest":
                    {
                        cam2d = new Carera2DTest();
                        break;
                    }
                default:
                    {
                        cam2d = null;
                        break;
                    }
            }
            switch (frmS.cam3dRegisSoftware)
            {
                case "PreciseLocate":
                    {
                        cam3dRegis = new CareraRegisChishine();
                        break;
                    }
                case "CareraRegisTest":
                    {
                        cam3dRegis = new CareraRegisTest();
                        break;
                    }
                default:
                    {
                        cam3dRegis = null;
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
                case "CareraRecogTest":
                    {
                        cam3dRecog = new CareraRecogTest();
                        break;
                    }
                default:
                    {
                        cam3dRecog = null;
                        break;
                    }
            }

            //初始化视觉软件及机器人控制软件
            OpenVisionSoftware(robot, ref panelRobot, false);
            OpenVisionSoftware(cam3dRegis, ref panel3DRegis, false);
            OpenVisionSoftware(cam3dRecog, ref panel3DRecog, false);
            OpenVisionSoftware(cam2d, ref panel2D, false);

            btnShowAll_Click(this, null);
        }

        private void frmWeldIdentify_FormClosed(object sender, FormClosedEventArgs e)
        {
            Thread.Sleep(100);

            //关闭视觉软件及机器人控制软件
            CloseVisionSoftware(robot);
            CloseVisionSoftware(cam2d);
            CloseVisionSoftware(cam3dRegis);
            CloseVisionSoftware(cam3dRecog);
        }

        void timerUpdateFrm_Tick(object sender, EventArgs e)
        {
            panelOne.Size = new Size(this.Size.Width - 240, this.Size.Height - 39);
            if (cam2d != null && cam2d.handle != IntPtr.Zero)
            {
                Thread t = new Thread(() => ResizeWindow(cam2d.handle));
                t.Start();
                Thread.Sleep(30);
            }
            if (cam3dRegis != null && cam3dRegis.handle != IntPtr.Zero)
            {
                Thread t = new Thread(() => ResizeWindow(cam3dRegis.handle));
                t.Start();
                Thread.Sleep(30);
            }
            if (cam3dRecog != null && cam3dRecog.handle != IntPtr.Zero)
            {
                Thread t = new Thread(() => ResizeWindow(cam3dRecog.handle));
                t.Start();
                Thread.Sleep(30);
            }
            if (robot != null && robot.handle != IntPtr.Zero)
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

        //视觉软件嵌入显示
        private void OpenVisionSoftware(VisionBase soft, ref Panel p, bool withSocket)
        {
            try
            {
                if (soft == null)
                {
                    return;
                }

                if (withSocket)
                {
                    soft.InitCameraSoftware();
                }
                else
                {
                    soft.InitCameraSoftwareWithoutSocket();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            if (soft.handle == IntPtr.Zero)
            {
                MessageBox.Show($"Not Find {soft.frmName}!");
                return;
            }

            //预留一部分进程启动的时间
            Thread.Sleep(200);

            ShowWindow(soft.handle, 0);
            SetParent(soft.handle, p.Handle);
            Thread.Sleep(100);
            ShowWindow(soft.handle, 3);
            RemoveWindowBorder(soft.handle);

            const int HWND_TOP = 0x0;
            const int WM_COMMAND = 0x0112;
            const int WM_QT_PAINT = 0xC2DC;
            const int WM_PAINT = 0x000F;
            const int WM_SIZE = 0x0005;
            const int SWP_FRAMECHANGED = 0x0020;

            SendMessage(soft.handle, WM_COMMAND, WM_PAINT, 0);
            PostMessage(soft.handle, WM_QT_PAINT, 0, 0);
            SetWindowPos(
            soft.handle,
            HWND_TOP,
            0, // 设置偏移量,把原来窗口的菜单遮住
            0,
            (int)this.Width,
            (int)this.Height,
            SWP_FRAMECHANGED);
            SendMessage(soft.handle, WM_COMMAND, WM_SIZE, 0);
        }

        //关闭视觉软件
        private void CloseVisionSoftware(VisionBase soft)
        {
            if (soft != null)
            {
                try
                {
                    soft.CloseSoftware();
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

            long LStyle = GetWindowLong(handle, GWL_STYLE);
            LStyle &= ~0x00C00000;
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

        private void frmWeldIdentify_SizeChanged(object sender, EventArgs e)
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

        private void btnShow3DRegis_Click(object sender, EventArgs e)
        {
            if (panelOne.HasChildren)
            {
                addToPanelAll(panelOne.Controls[0].Name);
            }
            panelOne.Controls.Clear();
            panelOne.Controls.Add(panel3DRegis);
            panelAll.Visible = false;
            panelOne.Visible = true;
            timerUpdateFrm.Start();
        }

        private void btnShow3DRecog_Click(object sender, EventArgs e)
        {
            if (panelOne.HasChildren)
            {
                addToPanelAll(panelOne.Controls[0].Name);
            }
            panelOne.Controls.Add(panel3DRecog);
            panelAll.Visible = false;
            panelOne.Visible = true;
            timerUpdateFrm.Start();
        }

        private void btnShow2D_Click(object sender, EventArgs e)
        {
            if (panelOne.HasChildren)
            {
                addToPanelAll(panelOne.Controls[0].Name);
            }
            panelOne.Controls.Add(panel2D);
            panelAll.Visible = false;
            panelOne.Visible = true;
            timerUpdateFrm.Start();
        }

        private void btnShowRobot_Click(object sender, EventArgs e)
        {
            if (panelOne.HasChildren)
            {
                addToPanelAll(panelOne.Controls[0].Name);
            }
            panelOne.Controls.Add(panelRobot);
            panelAll.Visible = false;
            panelOne.Visible = true;
            timerUpdateFrm.Start();
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            //把PanelOne里的panel还原到panelAll中去
            if (panelOne.HasChildren)
            {
                addToPanelAll(panelOne.Controls[0].Name);
            }
            panelAll.Visible = true;
            panelOne.Visible = false;
            timerUpdateFrm.Start();
        }

        private void addToPanelAll(string name)
        {
            switch (name)
            {
                case "panel2D":
                    {
                        panelAll.Controls.Add(panel2D, 0, 1);
                        break;
                    }
                case "panel3DRegis":
                    {
                        panelAll.Controls.Add(panel3DRegis, 0, 0);
                        break;
                    }
                case "panel3DRecog":
                    {
                        panelAll.Controls.Add(panel3DRecog, 1, 0);
                        break;
                    }
                case "panelRobot":
                    {
                        panelAll.Controls.Add(panelRobot, 1, 1);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
    }
}
