
namespace WeldIdentify
{
    partial class frmSelect
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbb2D = new System.Windows.Forms.ComboBox();
            this.cbb3DRegis = new System.Windows.Forms.ComboBox();
            this.cbbRobot = new System.Windows.Forms.ComboBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.cbb3DRecog = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "2D视觉软件";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "3D配准视觉软件";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(62, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "机器人控制软件";
            // 
            // cbb2D
            // 
            this.cbb2D.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb2D.FormattingEnabled = true;
            this.cbb2D.Items.AddRange(new object[] {
            "Camera2DTest",
            "BCVWeldTrack"});
            this.cbb2D.Location = new System.Drawing.Point(185, 36);
            this.cbb2D.Name = "cbb2D";
            this.cbb2D.Size = new System.Drawing.Size(121, 20);
            this.cbb2D.TabIndex = 3;
            this.cbb2D.SelectedIndexChanged += new System.EventHandler(this.cbb2D_SelectedIndexChanged);
            // 
            // cbb3DRegis
            // 
            this.cbb3DRegis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb3DRegis.FormattingEnabled = true;
            this.cbb3DRegis.Items.AddRange(new object[] {
            "CareraRegisTest",
            "3DPreciseLocate"});
            this.cbb3DRegis.Location = new System.Drawing.Point(185, 75);
            this.cbb3DRegis.Name = "cbb3DRegis";
            this.cbb3DRegis.Size = new System.Drawing.Size(121, 20);
            this.cbb3DRegis.TabIndex = 4;
            this.cbb3DRegis.SelectedIndexChanged += new System.EventHandler(this.cbb3DRegis_SelectedIndexChanged);
            // 
            // cbbRobot
            // 
            this.cbbRobot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbRobot.FormattingEnabled = true;
            this.cbbRobot.Items.AddRange(new object[] {
            "RobotControlTest",
            "CypWeld"});
            this.cbbRobot.Location = new System.Drawing.Point(185, 146);
            this.cbbRobot.Name = "cbbRobot";
            this.cbbRobot.Size = new System.Drawing.Size(121, 20);
            this.cbbRobot.TabIndex = 5;
            this.cbbRobot.SelectedIndexChanged += new System.EventHandler(this.cbbRobot_SelectedIndexChanged);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(231, 182);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // cbb3DRecog
            // 
            this.cbb3DRecog.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb3DRecog.FormattingEnabled = true;
            this.cbb3DRecog.Items.AddRange(new object[] {
            "CareraRecogTest",
            "TracerStudio"});
            this.cbb3DRecog.Location = new System.Drawing.Point(185, 110);
            this.cbb3DRecog.Name = "cbb3DRecog";
            this.cbb3DRecog.Size = new System.Drawing.Size(121, 20);
            this.cbb3DRecog.TabIndex = 8;
            this.cbb3DRecog.SelectedIndexChanged += new System.EventHandler(this.cbb3DRecog_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(62, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "3D识别视觉软件";
            // 
            // frmSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 236);
            this.Controls.Add(this.cbb3DRecog);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cbbRobot);
            this.Controls.Add(this.cbb3DRegis);
            this.Controls.Add(this.cbb2D);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmSelect";
            this.Text = "frmSelect";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbb2D;
        private System.Windows.Forms.ComboBox cbb3DRegis;
        private System.Windows.Forms.ComboBox cbbRobot;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ComboBox cbb3DRecog;
        private System.Windows.Forms.Label label4;
    }
}