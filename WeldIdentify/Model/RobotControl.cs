﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

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
            proName = "CypWeld";
            frmName = "CypWeld";
            ip = "127.0.0.1";
            port = 5060;
        }
    }
}