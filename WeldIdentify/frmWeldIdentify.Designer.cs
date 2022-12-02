
namespace WeldIdentify
{
    partial class frmWeldIdentify
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panelControl = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.相机设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.重连2D相机ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.重连3D相机ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.d相机参数设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.d相机参数设置ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.Log = new System.Windows.Forms.TextBox();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.panel3DRegis = new System.Windows.Forms.Panel();
            this.panel2D = new System.Windows.Forms.Panel();
            this.panelRobot = new System.Windows.Forms.Panel();
            this.panelMid = new System.Windows.Forms.Panel();
            this.panel3DRecog = new System.Windows.Forms.Panel();
            this.timerUpdateFrm = new System.Windows.Forms.Timer(this.components);
            this.button9 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button10 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.button13 = new System.Windows.Forms.Button();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panelControl.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panelLeft.SuspendLayout();
            this.panelMid.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button7.ForeColor = System.Drawing.Color.White;
            this.button7.Location = new System.Drawing.Point(6, 20);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(67, 42);
            this.button7.TabIndex = 9;
            this.button7.Text = "焊缝起点寻位";
            this.button7.UseVisualStyleBackColor = false;
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button8.ForeColor = System.Drawing.Color.White;
            this.button8.Location = new System.Drawing.Point(79, 20);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(67, 42);
            this.button8.TabIndex = 9;
            this.button8.Text = "开始跟踪";
            this.button8.UseVisualStyleBackColor = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button9);
            this.groupBox4.Controls.Add(this.button8);
            this.groupBox4.Controls.Add(this.button7);
            this.groupBox4.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox4.Location = new System.Drawing.Point(0, 310);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(224, 100);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "2D相机焊缝跟踪";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(6, 20);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(67, 42);
            this.button2.TabIndex = 1;
            this.button2.Text = "读取工件CAD点云";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(79, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(67, 42);
            this.button1.TabIndex = 2;
            this.button1.Text = "获取工件当前点云";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.ForeColor = System.Drawing.SystemColors.Window;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "ICP",
            "NDT"});
            this.comboBox1.Location = new System.Drawing.Point(6, 90);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(67, 20);
            this.comboBox1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "配准算法：";
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(79, 68);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(67, 42);
            this.button4.TabIndex = 6;
            this.button4.Text = "点云配准";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Location = new System.Drawing.Point(152, 68);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(67, 42);
            this.button5.TabIndex = 7;
            this.button5.Text = "传入矩阵";
            this.button5.UseVisualStyleBackColor = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button5);
            this.groupBox3.Controls.Add(this.button4);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.comboBox1);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox3.Location = new System.Drawing.Point(0, 28);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(224, 119);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "3D相机焊缝识别";
            // 
            // panelControl
            // 
            this.panelControl.Controls.Add(this.groupBox1);
            this.panelControl.Controls.Add(this.menuStrip1);
            this.panelControl.Controls.Add(this.Log);
            this.panelControl.Controls.Add(this.groupBox3);
            this.panelControl.Controls.Add(this.groupBox4);
            this.panelControl.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelControl.Location = new System.Drawing.Point(1610, 0);
            this.panelControl.Name = "panelControl";
            this.panelControl.Size = new System.Drawing.Size(224, 900);
            this.panelControl.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.相机设置ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(224, 25);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 相机设置ToolStripMenuItem
            // 
            this.相机设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.重连2D相机ToolStripMenuItem,
            this.重连3D相机ToolStripMenuItem,
            this.d相机参数设置ToolStripMenuItem,
            this.d相机参数设置ToolStripMenuItem1});
            this.相机设置ToolStripMenuItem.Name = "相机设置ToolStripMenuItem";
            this.相机设置ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.相机设置ToolStripMenuItem.Text = "相机设置";
            // 
            // 重连2D相机ToolStripMenuItem
            // 
            this.重连2D相机ToolStripMenuItem.Name = "重连2D相机ToolStripMenuItem";
            this.重连2D相机ToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.重连2D相机ToolStripMenuItem.Text = "重连2D相机";
            // 
            // 重连3D相机ToolStripMenuItem
            // 
            this.重连3D相机ToolStripMenuItem.Name = "重连3D相机ToolStripMenuItem";
            this.重连3D相机ToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.重连3D相机ToolStripMenuItem.Text = "重连3D相机";
            // 
            // d相机参数设置ToolStripMenuItem
            // 
            this.d相机参数设置ToolStripMenuItem.Name = "d相机参数设置ToolStripMenuItem";
            this.d相机参数设置ToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.d相机参数设置ToolStripMenuItem.Text = "2D相机参数设置";
            // 
            // d相机参数设置ToolStripMenuItem1
            // 
            this.d相机参数设置ToolStripMenuItem1.Name = "d相机参数设置ToolStripMenuItem1";
            this.d相机参数设置ToolStripMenuItem1.Size = new System.Drawing.Size(164, 22);
            this.d相机参数设置ToolStripMenuItem1.Text = "3D相机参数设置";
            // 
            // Log
            // 
            this.Log.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Log.ForeColor = System.Drawing.SystemColors.Control;
            this.Log.Location = new System.Drawing.Point(0, 450);
            this.Log.Multiline = true;
            this.Log.Name = "Log";
            this.Log.Size = new System.Drawing.Size(224, 450);
            this.Log.TabIndex = 6;
            // 
            // panelLeft
            // 
            this.panelLeft.Controls.Add(this.panel3DRegis);
            this.panelLeft.Controls.Add(this.panel2D);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(800, 900);
            this.panelLeft.TabIndex = 7;
            // 
            // panel3DRegis
            // 
            this.panel3DRegis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3DRegis.Location = new System.Drawing.Point(0, 0);
            this.panel3DRegis.Name = "panel3DRegis";
            this.panel3DRegis.Size = new System.Drawing.Size(800, 450);
            this.panel3DRegis.TabIndex = 2;
            // 
            // panel2D
            // 
            this.panel2D.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2D.Location = new System.Drawing.Point(0, 450);
            this.panel2D.Name = "panel2D";
            this.panel2D.Size = new System.Drawing.Size(800, 450);
            this.panel2D.TabIndex = 1;
            // 
            // panelRobot
            // 
            this.panelRobot.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelRobot.Location = new System.Drawing.Point(0, 450);
            this.panelRobot.Name = "panelRobot";
            this.panelRobot.Size = new System.Drawing.Size(810, 450);
            this.panelRobot.TabIndex = 0;
            // 
            // panelMid
            // 
            this.panelMid.Controls.Add(this.panel3DRecog);
            this.panelMid.Controls.Add(this.panelRobot);
            this.panelMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMid.Location = new System.Drawing.Point(800, 0);
            this.panelMid.Name = "panelMid";
            this.panelMid.Size = new System.Drawing.Size(810, 900);
            this.panelMid.TabIndex = 8;
            // 
            // panel3DRecog
            // 
            this.panel3DRecog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3DRecog.Location = new System.Drawing.Point(0, 0);
            this.panel3DRecog.Name = "panel3DRecog";
            this.panel3DRecog.Size = new System.Drawing.Size(810, 450);
            this.panel3DRecog.TabIndex = 1;
            this.panel3DRecog.SizeChanged += new System.EventHandler(this.panel3DRecog_SizeChanged);
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button9.ForeColor = System.Drawing.Color.White;
            this.button9.Location = new System.Drawing.Point(152, 20);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(67, 42);
            this.button9.TabIndex = 10;
            this.button9.Text = "结束跟踪";
            this.button9.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button10);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.button13);
            this.groupBox1.Controls.Add(this.comboBox3);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Location = new System.Drawing.Point(0, 155);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(224, 134);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "3D相机焊缝识别";
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button10.ForeColor = System.Drawing.Color.White;
            this.button10.Location = new System.Drawing.Point(152, 20);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(67, 42);
            this.button10.TabIndex = 8;
            this.button10.Text = "开始焊接";
            this.button10.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "焊缝模板：";
            // 
            // button13
            // 
            this.button13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button13.ForeColor = System.Drawing.Color.White;
            this.button13.Location = new System.Drawing.Point(79, 20);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(67, 42);
            this.button13.TabIndex = 5;
            this.button13.Text = "点云识别所有焊缝";
            this.button13.UseVisualStyleBackColor = false;
            // 
            // comboBox3
            // 
            this.comboBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.ForeColor = System.Drawing.Color.White;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "V型焊缝",
            "平板焊缝"});
            this.comboBox3.Location = new System.Drawing.Point(6, 42);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(67, 20);
            this.comboBox3.TabIndex = 3;
            // 
            // frmWeldIdentify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1834, 900);
            this.Controls.Add(this.panelMid);
            this.Controls.Add(this.panelControl);
            this.Controls.Add(this.panelLeft);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.Name = "frmWeldIdentify";
            this.Text = "WeldIdentifyForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmWeldIdentify_FormClosed);
            this.Load += new System.EventHandler(this.frmWeldIdentify_Load);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panelControl.ResumeLayout(false);
            this.panelControl.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelLeft.ResumeLayout(false);
            this.panelMid.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelMid;
        private System.Windows.Forms.Panel panelControl;
        private System.Windows.Forms.Panel panel2D;
        private System.Windows.Forms.Panel panel3DRegis;
        private System.Windows.Forms.Panel panel3DRecog;
        private System.Windows.Forms.Panel panelRobot;
        private System.Windows.Forms.Timer timerUpdateFrm;
        private System.Windows.Forms.TextBox Log;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 相机设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 重连2D相机ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 重连3D相机ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem d相机参数设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem d相机参数设置ToolStripMenuItem1;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.ComboBox comboBox3;
    }
}

