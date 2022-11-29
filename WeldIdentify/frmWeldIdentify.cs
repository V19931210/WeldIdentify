using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PclSharp;
using PclSharp.IO;
using PclSharp.Common;
using PclSharp.Registration;

namespace WeldIdentify
{
    public partial class frmWeldIdentify : Form
    {
        private PointCloudOfXYZ pcCAD;
        private PointCloudOfXYZ pc;
        private IterativeClosestPoint<PointCloudOfXYZ, PointCloudOfXYZ> icp;


        public frmWeldIdentify()
        {
            InitializeComponent();
        }

        private void frmWeldIdentify_Load(object sender, EventArgs e)
        {
            
        }
    }
}
