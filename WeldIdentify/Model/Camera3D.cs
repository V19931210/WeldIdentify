using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PclSharp;
using PclSharp.IO;
using PclSharp.Common;
using PclSharp.Registration;

namespace WeldIdentify
{
    public abstract class Camera3D : VisionBase
    {

    }

    //点云配准相机类
    public abstract class Camera3DRegis : Camera3D
    {
        public PointCloudOfXYZ pcCAD;
        public PointCloudOfXYZ pcCur;

        //配准算法
        public IterativeClosestPoint<PointCloudOfXYZ, PointCloudOfXYZ> icp;
        public TransformationEstimationPointToPlane<PointCloudOfXYZ, PointCloudOfXYZ> nicp;

        //获取当前点云
        public abstract void GetCurPointCloud();
    }

    public class CareraRegisChishine : Camera3DRegis
    {
        public CareraRegisChishine()
        {
            path = @"3DRegis\preciseLocate";
            proName = "preciseLocate";
            frmName = "preciseLocate";
            ip = "127.0.0.1";
            port = 5120;
        }

        public override void GetCurPointCloud()
        {

        }
    }

    public class CareraRegisTest : Camera3DRegis
    {
        public CareraRegisTest()
        {
            path = @"3DRegis\3DPreciseLocate";
            proName = "3DPreciseLocate";
            frmName = "3DPreciseLocateForm";
            ip = "127.0.0.1";
            port = 5120;
        }

        public override void GetCurPointCloud()
        {

        }
    }

    //点云识别相机类
    public abstract class Camera3DRecog : Camera3D
    {

    }

    public class CareraRecogChishine : Camera3DRecog
    {
        public CareraRecogChishine()
        {
            path = @"3DRecog\TracerStudio\bin";
            proName = "TracerStudio";
            frmName = "TracerStudio";
            frmClassName = "Qt5QWindowIcon";
            ip = "127.0.0.1";
            port = 45000;
            reserveTime = 15000;
        }
    }

    public class CareraRecogTest : Camera3DRecog
    {
        public CareraRecogTest()
        {
            path = @"3DRecog\BCV3DEyeInHand";
            proName = "BCV3DEyeInHand";
            frmName = "BCV3DEyeInHand";
            ip = "127.0.0.1";
            port = 5212;
        }
    }
}
