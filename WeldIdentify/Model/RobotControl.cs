using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;
using System.IO;

namespace WeldIdentify
{
    public abstract class RobotControl : VisionBase
    {
        public void InitRobot()
        {

        }

        public void CloseRobot()
        {

        }
    }

    public class RobotControlCypWeld : RobotControl
    {
        public RobotControlCypWeld()
        {
            path = @"Robot\CypWeld";
            proName = "CypWeld";
            frmName = "CypWeld  [7.0.106.0]";
            frmClassName = "TFrmCypWeld";
            ip = "127.0.0.1";
            port = 5060;
            otherProName = "BCVWeldTrack";
            reserveTime = 10000;
        }
    }

    public class RobotControlCypWeldDemo : RobotControl
    {
        public RobotControlCypWeldDemo()
        {
            path = @"Robot\CypWeld";
            proName = "CypWeld";
            frmName = "CypWeld(Demo Mode)  [7.0.106.0]";
            frmClassName = "TFrmCypWeld";
            ip = "127.0.0.1";
            port = 5060;
            otherProName = "BCVWeldTrack";
            reserveTime = 5000;
        }
    }

    public class RobotControlTest : RobotControl
    {
        public RobotControlTest()
        {
            path = @"Robot\CypWeld";
            proName = "RobotControlTest";
            frmName = "RobotControlTest";
            ip = "127.0.0.1";
            port = 5060;
        }
    }
}
