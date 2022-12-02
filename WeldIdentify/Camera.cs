using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.IO;
using System.Threading;

using PclSharp;
using PclSharp.IO;
using PclSharp.Common;
using PclSharp.Registration;

namespace WeldIdentify
{

    public abstract class CameraBase
    {
        private const int GWL_STYLE = (-16);
        [DllImport("USER32.DLL")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll", EntryPoint = "GetWindowLong", CharSet = CharSet.Auto)]
        public static extern long GetWindowLong(IntPtr hWnd, int nIndex);

        //与进程有关的变量
        public string method;
        public string proName;
        public string frmName;
        public IntPtr handle = new IntPtr(0);
        public long oriWindowLong;
        
        //与socket有关的变量
        public static Socket socket;
        public string ip;
        public int port;

        //对外接口 初始化视觉软件
        public void InitCameraSoftware()
        {
            openProcess();
            findHandle();
            initSocket();
        }

        //开启视觉软件进程
        private void openProcess()
        {
            Process[] proArr = Process.GetProcessesByName(proName);
            if (proArr.Length == 0)
            {
                Process pro = new Process();
                string path = Directory.GetCurrentDirectory();
                path += $@"\{method}\{proName}.exe";
                pro.StartInfo.FileName = path;
                pro.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                pro.Start();
            }
        }

        //查找进程句柄
        private void findHandle()
        {
            for (int i = 0; i < 30; i++)
            {
                handle = FindWindow(null, frmName);
                if (handle != IntPtr.Zero)
                {
                    oriWindowLong = GetWindowLong(handle, GWL_STYLE);
                    break;
                }
                else
                {
                    Thread.Sleep(100);
                }
            }
        }

        //初始化socket
        private void initSocket()
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, 3000);
            socket.Connect(new IPEndPoint(IPAddress.Parse(ip), port));
        }

        //对外接口 关闭视觉软件
        public void CloseCamera()
        {
            closeSocket();
            killProcess();
        }

        private void closeSocket()
        {
            if (socket.Connected==true)
            {
                socket.Close();
            }
        }
        
        private void killProcess()
        {
            Process[] proArr = Process.GetProcessesByName(proName);
            if (proArr.Length > 0)
            {
                proArr[0].Kill();
            }
        }

        //对外接口 初始化相机对象指针 重连相机用
        public abstract void InitCamera();
    }

    public abstract class Camera2D: CameraBase
    {
        
    }

    public class CareraBCW500 : Camera2D
    {
        public CareraBCW500()
        {
            method = "2D";
            proName = "BCVWeldTrack";
            frmName = "BCVWeldTrackMainForm";
            ip = "127.0.0.1";
            port = 5020;
        }

        public override void InitCamera()
        {
            throw new NotImplementedException();
        }

        
    }

    public abstract class Camera3D : CameraBase
    {
        public PointCloudOfXYZ pcCAD;
        public PointCloudOfXYZ pcCur;

        //配准算法
        private IterativeClosestPoint<PointCloudOfXYZ, PointCloudOfXYZ> icp;
        private TransformationEstimationPointToPlane<PointCloudOfXYZ, PointCloudOfXYZ> te;

        public abstract void GetCADPointCloud();//读取CAD点云
        public abstract void GetCurPointCloud();//获取当前点云
        public void PointCloudRegis()
        {

        }
    }

    public class CareraChishine : Camera3D
    {
        public CareraChishine()
        {
            method = "3D";
            proName = "BCV3DEyeInHand";
            frmName = "BCV3DEyeInHand";
            ip = "127.0.0.1";
            port = 5212;
        }

        public override void InitCamera()
        {
            throw new NotImplementedException();
        }

        public override void GetCADPointCloud()
        {
            
        }

        public override void GetCurPointCloud()
        {
            
        }
    }
}
