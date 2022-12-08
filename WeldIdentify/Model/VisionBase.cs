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

namespace WeldIdentify
{
    public abstract class VisionBase
    {
        private const int GWL_STYLE = (-16);
        [DllImport("USER32.DLL")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll", EntryPoint = "GetWindowLong", CharSet = CharSet.Auto)]
        public static extern long GetWindowLong(IntPtr hWnd, int nIndex);

        //与进程有关的变量
        public string path;
        public string proName;
        public string frmName;
        public string frmClassName;
        public IntPtr handle = new IntPtr(0);
        public long oriWindowLong;
        public string otherProName;
        public int reserveTime = 1000;

        //与socket有关的变量
        public static Socket socket;
        public string ip;
        public int port;

        //对外接口 初始化软件
        public void InitCameraSoftware()
        {
            openProcess();
            Thread.Sleep(reserveTime);
            findHandle();
            if (otherProName != null)
            {
                killOtherProcess();
            }
            initSocket();
        }

        //对外接口 初始化软件 不初始化socket
        public void InitCameraSoftwareWithoutSocket()
        {
            openProcess();
            Thread.Sleep(reserveTime);
            findHandle();
            if (otherProName != null)
            {
                killOtherProcess();
            }
        }

        //开启软件进程
        public void openProcess()
        {
            Process[] proArr = Process.GetProcessesByName(proName);
            if (proArr.Length == 0)
            {
                Process pro = new Process();
                string path = Directory.GetCurrentDirectory();
                path += $@"\{this.path}\{proName}.exe";
                pro.StartInfo.FileName = path;
                pro.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                pro.Start();
            }
        }

        //查找进程窗口句柄 搜索15s
        public void findHandle()
        {
            for (int i = 0; i < 150; i++)
            {
                handle = FindWindow(frmClassName, frmName);
                if (handle != IntPtr.Zero)
                {
                    oriWindowLong = GetWindowLong(handle, GWL_STYLE);
                    break;
                }
                else
                {
                    Thread.Sleep(100);
                    continue;
                }
            }
        }

        //关闭相关软件
        public void killOtherProcess()
        {
            Process[] proArr = Process.GetProcessesByName(otherProName);
            if (proArr.Length != 0)
            {
                proArr[0].Kill();
            }
        }

        //初始化socket
        public void initSocket()
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, 3000);
            socket.Connect(new IPEndPoint(IPAddress.Parse(ip), port));
        }

        //对外接口 关闭软件
        public void CloseSoftware()
        {
            closeSocket();
            killProcess();
        }

        public void closeSocket()
        {
            if (socket != null)
            {
                if (socket.Connected == true)
                {
                    socket.Close();
                }
            }
        }

        public void killProcess()
        {
            Process[] proArr = Process.GetProcessesByName(proName);
            if (proArr.Length > 0)
            {
                proArr[0].Kill();
            }
        }
    }

}
