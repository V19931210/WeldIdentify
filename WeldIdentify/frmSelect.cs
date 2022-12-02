﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeldIdentify
{
    public partial class frmSelect : Form
    {
        public string cam2dSoftware;
        public string cam3dSoftware;
        public string camRobotSoftware;

        public frmSelect()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;

            cbb2D.SelectedIndex = 0;
            cbb3D.SelectedIndex = 0;
            cbbRobot.SelectedIndex = 0;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void cbb2D_SelectedIndexChanged(object sender, EventArgs e)
        {
            cam2dSoftware=cbb2D.Text;
        }

        private void cbb3D_SelectedIndexChanged(object sender, EventArgs e)
        {
            cam3dSoftware = cbb3D.Text;
        }

        private void cbbRobot_SelectedIndexChanged(object sender, EventArgs e)
        {
            camRobotSoftware = cbbRobot.Text;
        }
    }
}
