using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace WeldIdentify
{
    public abstract  class  RobotControl
    {
        //与进程有关的变量
        public string proName;
        public string frmName;
        public IntPtr handle = new IntPtr(0);
        public long oriWindowLong;

        //与socket有关的变量
        public static Socket socket;
        public string ip;
        public int port;

        public void InitRobot()
        {

        }

        public void CloseRobot()
        {

        }
    }

    public class RobotControlCypWeld: RobotControl
    {
        public RobotControlCypWeld()
        {
            proName = "CypWeld";
            frmName = "CypWeld";
            ip = "127.0.0.1";
            port = 5060;
        }

    }
}
