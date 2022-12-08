using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeldIdentify
{
    public abstract class Camera2D : VisionBase
    {
        //通讯接口
        public abstract void SendCMD();
        //焊缝起点寻位
        public abstract void FindInitWeldPoint();
        //开始跟踪
        public abstract void StartTrack();
        //结束跟踪
        public abstract void StopTrack();
    }

    public class CareraBCW500 : Camera2D
    {
        public CareraBCW500()
        {
            path = @"2D\BCVWeldTrack";
            proName = "BCVWeldTrack";
            frmName = "BCVWeldTrackMainForm";
            ip = "127.0.0.1";
            port = 5020;
            reserveTime = 2000;
        }

        public override void SendCMD()
        {

        }

        public override void FindInitWeldPoint()
        {

        }

        public override void StartTrack()
        {

        }

        public override void StopTrack()
        {

        }
    }

    public class Carera2DTest : Camera2D
    {
        public Carera2DTest()
        {
            path = @"2D\BCVWeldTrack";
            proName = "BCVWeldTrack";
            frmName = "BCVWeldTrackMainForm";
            ip = "127.0.0.1";
            port = 5020;
        }

        public override void SendCMD()
        {

        }

        public override void FindInitWeldPoint()
        {

        }

        public override void StartTrack()
        {

        }

        public override void StopTrack()
        {

        }
    }
}
