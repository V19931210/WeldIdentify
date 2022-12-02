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
        private IterativeClosestPoint<PointCloudOfXYZ, PointCloudOfXYZ> icp;
        private TransformationEstimationPointToPlane<PointCloudOfXYZ, PointCloudOfXYZ> te;

        //获取当前点云
        public abstract void GetCurPointCloud();
    }

    public class CareraRegisChishine : Camera3DRegis
    {
        public CareraRegisChishine()
        {
            method = "3DRegis";
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
            method = "3DRecog";
            proName = "BCV3DEyeInHand";
            frmName = "BCV3DEyeInHand";
            ip = "127.0.0.1";
            port = 5212;
        }
    }




}
