
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.相机设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.重连2D相机ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.重连3D相机ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.d相机参数设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.d相机参数设置ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.相机设置ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(847, 25);
            this.menuStrip1.TabIndex = 2;
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
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button6);
            this.groupBox3.Controls.Add(this.button5);
            this.groupBox3.Controls.Add(this.button4);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Controls.Add(this.comboBox2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.comboBox1);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox3.Location = new System.Drawing.Point(6, 337);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(400, 170);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "3D相机焊缝识别";
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button6.ForeColor = System.Drawing.Color.White;
            this.button6.Location = new System.Drawing.Point(152, 111);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(67, 42);
            this.button6.TabIndex = 8;
            this.button6.Text = "开始焊接";
            this.button6.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Location = new System.Drawing.Point(298, 20);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(67, 42);
            this.button5.TabIndex = 7;
            this.button5.Text = "传入矩阵";
            this.button5.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(225, 20);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(67, 42);
            this.button4.TabIndex = 6;
            this.button4.Text = "点云配准";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "焊缝模板：";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(79, 111);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(67, 42);
            this.button3.TabIndex = 5;
            this.button3.Text = "点云识别所有焊缝";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // comboBox2
            // 
            this.comboBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.ForeColor = System.Drawing.Color.White;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "V型焊缝",
            "平板焊缝"});
            this.comboBox2.Location = new System.Drawing.Point(6, 133);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(67, 20);
            this.comboBox2.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(152, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "配准算法：";
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.ForeColor = System.Drawing.SystemColors.Window;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "FR-ICP",
            "ICP",
            "NDT"});
            this.comboBox1.Location = new System.Drawing.Point(152, 42);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(67, 20);
            this.comboBox1.TabIndex = 3;
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
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button8);
            this.groupBox4.Controls.Add(this.button7);
            this.groupBox4.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox4.Location = new System.Drawing.Point(412, 337);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(400, 170);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "2D相机焊缝跟踪";
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button8.ForeColor = System.Drawing.Color.White;
            this.button8.Location = new System.Drawing.Point(79, 20);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(67, 42);
            this.button8.TabIndex = 9;
            this.button8.Text = "开始焊接";
            this.button8.UseVisualStyleBackColor = false;
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
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(412, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 300);
            this.panel1.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(6, 31);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(400, 300);
            this.panel2.TabIndex = 7;
            // 
            // frmWeldIdentify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(847, 525);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmWeldIdentify";
            this.Text = "WeldIdentifyForm";
            this.Load += new System.EventHandler(this.frmWeldIdentify_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 相机设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 重连2D相机ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 重连3D相机ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem d相机参数设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem d相机参数设置ToolStripMenuItem1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}

