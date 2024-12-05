namespace LiveView.Forms
{
    partial class SyncronView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pMain;
	    private System.Windows.Forms.GroupBox gbCameras;
	    private System.Windows.Forms.ContextMenuStrip cmsMenu;
	    private System.Windows.Forms.Button btnPlay;
	    private System.Windows.Forms.Button btnStepNext;
	    private System.Windows.Forms.Button btnStepBack;
	    private System.Windows.Forms.Button btnPause;
	    private System.Windows.Forms.ToolStripMenuItem tsmiChangeCameraTo;
	    private System.Windows.Forms.NumericUpDown nudImageMinute;
	    private System.Windows.Forms.NumericUpDown nudImageHour;
	    private System.Windows.Forms.DateTimePicker dtpImageDate;
	    private System.Windows.Forms.NumericUpDown nudImageSecond;
	    private System.Windows.Forms.CheckBox chkOsd;
	    private System.Windows.Forms.TrackBar tbSpeed;
	    private System.Windows.Forms.Label lblSpeed;
	    private System.Windows.Forms.Button btnGoto;
	    private System.Windows.Forms.Label lblImageSecond;
	    private System.Windows.Forms.Label lblImageMinute;
	    private System.Windows.Forms.Label lblImageHour;
	    private System.Windows.Forms.GroupBox gbControls;
	    private AxVIDEOCONTROL4Lib.AxVideoTimeline  axVideoTimeline4;
	    private AxVIDEOCONTROL4Lib.AxVideoTimeline  axVideoTimeline3;
	    private AxVIDEOCONTROL4Lib.AxVideoTimeline  axVideoTimeline2;
	    private AxVIDEOCONTROL4Lib.AxVideoTimeline  axVideoTimeline1;
	    private AxVIDEOCONTROL4Lib.AxVideoPicture  axVideoPicture3;
	    private AxVIDEOCONTROL4Lib.AxVideoPicture  axVideoPicture4;
	    private AxVIDEOCONTROL4Lib.AxVideoPicture  axVideoPicture2;
	    private AxVIDEOCONTROL4Lib.AxVideoPicture  axVideoPicture1;

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
            components = new System.ComponentModel.Container();
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(SyncronView));
            pMain = new System.Windows.Forms.Panel();
            gbControls = new System.Windows.Forms.GroupBox();
            lblSpeed = new System.Windows.Forms.Label();
            tbSpeed = new System.Windows.Forms.TrackBar();
            dtpImageDate = new System.Windows.Forms.DateTimePicker();
            nudImageHour = new System.Windows.Forms.NumericUpDown();
            btnGoto = new System.Windows.Forms.Button();
            lblImageSecond = new System.Windows.Forms.Label();
            nudImageMinute = new System.Windows.Forms.NumericUpDown();
            lblImageMinute = new System.Windows.Forms.Label();
            nudImageSecond = new System.Windows.Forms.NumericUpDown();
            lblImageHour = new System.Windows.Forms.Label();
            chkOsd = new System.Windows.Forms.CheckBox();
            btnStepBack = new System.Windows.Forms.Button();
            btnPause = new System.Windows.Forms.Button();
            btnStepNext = new System.Windows.Forms.Button();
            btnPlay = new System.Windows.Forms.Button();
            gbCameras = new System.Windows.Forms.GroupBox();
            axVideoTimeline4 = new AxVIDEOCONTROL4Lib.AxVideoTimeline();
            axVideoTimeline3 = new AxVIDEOCONTROL4Lib.AxVideoTimeline();
            axVideoTimeline2 = new AxVIDEOCONTROL4Lib.AxVideoTimeline();
            axVideoTimeline1 = new AxVIDEOCONTROL4Lib.AxVideoTimeline();
            axVideoPicture3 = new AxVIDEOCONTROL4Lib.AxVideoPicture();
            axVideoPicture4 = new AxVIDEOCONTROL4Lib.AxVideoPicture();
            axVideoPicture2 = new AxVIDEOCONTROL4Lib.AxVideoPicture();
            axVideoPicture1 = new AxVIDEOCONTROL4Lib.AxVideoPicture();
            cmsMenu = new System.Windows.Forms.ContextMenuStrip(components);
            tsmiChangeCameraTo = new System.Windows.Forms.ToolStripMenuItem();
            pMain.SuspendLayout();
            gbControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbSpeed).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudImageHour).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudImageMinute).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudImageSecond).BeginInit();
            gbCameras.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)axVideoTimeline4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)axVideoTimeline3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)axVideoTimeline2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)axVideoTimeline1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)axVideoPicture3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)axVideoPicture4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)axVideoPicture2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)axVideoPicture1).BeginInit();
            cmsMenu.SuspendLayout();
            SuspendLayout();
            // 
            // pMain
            // 
            pMain.Controls.Add(gbControls);
            pMain.Controls.Add(gbCameras);
            pMain.Dock = System.Windows.Forms.DockStyle.Fill;
            pMain.Location = new System.Drawing.Point(0, 0);
            pMain.Name = "pMain";
            pMain.Size = new System.Drawing.Size(782, 660);
            pMain.TabIndex = 0;
            // 
            // gbControls
            // 
            gbControls.Controls.Add(lblSpeed);
            gbControls.Controls.Add(tbSpeed);
            gbControls.Controls.Add(dtpImageDate);
            gbControls.Controls.Add(nudImageHour);
            gbControls.Controls.Add(btnGoto);
            gbControls.Controls.Add(lblImageSecond);
            gbControls.Controls.Add(nudImageMinute);
            gbControls.Controls.Add(lblImageMinute);
            gbControls.Controls.Add(nudImageSecond);
            gbControls.Controls.Add(lblImageHour);
            gbControls.Controls.Add(chkOsd);
            gbControls.Controls.Add(btnStepBack);
            gbControls.Controls.Add(btnPause);
            gbControls.Controls.Add(btnStepNext);
            gbControls.Controls.Add(btnPlay);
            gbControls.Dock = System.Windows.Forms.DockStyle.Bottom;
            gbControls.Location = new System.Drawing.Point(0, 560);
            gbControls.Name = "gbControls";
            gbControls.Size = new System.Drawing.Size(782, 100);
            gbControls.TabIndex = 2;
            gbControls.TabStop = false;
            gbControls.Text = "Controls";
            // 
            // lblSpeed
            // 
            lblSpeed.AutoSize = true;
            lblSpeed.Location = new System.Drawing.Point(728, 26);
            lblSpeed.Name = "lblSpeed";
            lblSpeed.Size = new System.Drawing.Size(39, 15);
            lblSpeed.TabIndex = 30;
            lblSpeed.Text = "Speed";
            // 
            // tbSpeed
            // 
            tbSpeed.Location = new System.Drawing.Point(731, 42);
            tbSpeed.Maximum = 500;
            tbSpeed.Name = "tbSpeed";
            tbSpeed.Orientation = System.Windows.Forms.Orientation.Vertical;
            tbSpeed.Size = new System.Drawing.Size(45, 48);
            tbSpeed.TabIndex = 29;
            tbSpeed.Value = 500;
            tbSpeed.Scroll += TbSpeed_Scroll;
            // 
            // dtpImageDate
            // 
            dtpImageDate.Location = new System.Drawing.Point(12, 68);
            dtpImageDate.Name = "dtpImageDate";
            dtpImageDate.Size = new System.Drawing.Size(135, 23);
            dtpImageDate.TabIndex = 15;
            // 
            // nudImageHour
            // 
            nudImageHour.Location = new System.Drawing.Point(156, 67);
            nudImageHour.Maximum = new decimal(new int[] { 23, 0, 0, 0 });
            nudImageHour.Name = "nudImageHour";
            nudImageHour.Size = new System.Drawing.Size(49, 23);
            nudImageHour.TabIndex = 16;
            // 
            // btnGoto
            // 
            btnGoto.Location = new System.Drawing.Point(393, 65);
            btnGoto.Name = "btnGoto";
            btnGoto.Size = new System.Drawing.Size(75, 23);
            btnGoto.TabIndex = 31;
            btnGoto.Text = "Go to";
            btnGoto.UseVisualStyleBackColor = true;
            btnGoto.Click += BtnGoto_Click;
            // 
            // lblImageSecond
            // 
            lblImageSecond.AutoSize = true;
            lblImageSecond.Location = new System.Drawing.Point(360, 73);
            lblImageSecond.Name = "lblImageSecond";
            lblImageSecond.Size = new System.Drawing.Size(12, 15);
            lblImageSecond.TabIndex = 34;
            lblImageSecond.Text = "s";
            // 
            // nudImageMinute
            // 
            nudImageMinute.Location = new System.Drawing.Point(227, 67);
            nudImageMinute.Maximum = new decimal(new int[] { 59, 0, 0, 0 });
            nudImageMinute.Name = "nudImageMinute";
            nudImageMinute.Size = new System.Drawing.Size(50, 23);
            nudImageMinute.TabIndex = 17;
            // 
            // lblImageMinute
            // 
            lblImageMinute.AutoSize = true;
            lblImageMinute.Location = new System.Drawing.Point(283, 73);
            lblImageMinute.Name = "lblImageMinute";
            lblImageMinute.Size = new System.Drawing.Size(18, 15);
            lblImageMinute.TabIndex = 33;
            lblImageMinute.Text = "m";
            // 
            // nudImageSecond
            // 
            nudImageSecond.Location = new System.Drawing.Point(304, 67);
            nudImageSecond.Maximum = new decimal(new int[] { 59, 0, 0, 0 });
            nudImageSecond.Name = "nudImageSecond";
            nudImageSecond.Size = new System.Drawing.Size(50, 23);
            nudImageSecond.TabIndex = 18;
            // 
            // lblImageHour
            // 
            lblImageHour.AutoSize = true;
            lblImageHour.Location = new System.Drawing.Point(207, 73);
            lblImageHour.Name = "lblImageHour";
            lblImageHour.Size = new System.Drawing.Size(14, 15);
            lblImageHour.TabIndex = 32;
            lblImageHour.Text = "h";
            // 
            // chkOsd
            // 
            chkOsd.AutoSize = true;
            chkOsd.Location = new System.Drawing.Point(156, 26);
            chkOsd.Name = "chkOsd";
            chkOsd.Size = new System.Drawing.Size(49, 19);
            chkOsd.TabIndex = 19;
            chkOsd.Text = "OSD";
            chkOsd.UseVisualStyleBackColor = true;
            // 
            // btnStepBack
            // 
            btnStepBack.Image = Properties.Resources.step_back;
            btnStepBack.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            btnStepBack.Location = new System.Drawing.Point(12, 26);
            btnStepBack.Name = "btnStepBack";
            btnStepBack.Size = new System.Drawing.Size(30, 30);
            btnStepBack.TabIndex = 7;
            btnStepBack.UseVisualStyleBackColor = true;
            btnStepBack.Click += BtnStepBack_Click;
            // 
            // btnPause
            // 
            btnPause.Image = Properties.Resources.pause;
            btnPause.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            btnPause.Location = new System.Drawing.Point(48, 26);
            btnPause.Name = "btnPause";
            btnPause.Size = new System.Drawing.Size(30, 30);
            btnPause.TabIndex = 6;
            btnPause.UseVisualStyleBackColor = true;
            btnPause.Click += BtnPause_Click;
            // 
            // btnStepNext
            // 
            btnStepNext.Image = Properties.Resources.step_next;
            btnStepNext.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            btnStepNext.Location = new System.Drawing.Point(120, 26);
            btnStepNext.Name = "btnStepNext";
            btnStepNext.Size = new System.Drawing.Size(30, 30);
            btnStepNext.TabIndex = 8;
            btnStepNext.UseVisualStyleBackColor = true;
            btnStepNext.Click += BtnStepNext_Click;
            // 
            // btnPlay
            // 
            btnPlay.Image = Properties.Resources.play;
            btnPlay.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            btnPlay.Location = new System.Drawing.Point(84, 26);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new System.Drawing.Size(30, 30);
            btnPlay.TabIndex = 9;
            btnPlay.UseVisualStyleBackColor = true;
            btnPlay.Click += BtnPlay_Click;
            // 
            // gbCameras
            // 
            gbCameras.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            gbCameras.Controls.Add(axVideoTimeline4);
            gbCameras.Controls.Add(axVideoTimeline3);
            gbCameras.Controls.Add(axVideoTimeline2);
            gbCameras.Controls.Add(axVideoTimeline1);
            gbCameras.Controls.Add(axVideoPicture3);
            gbCameras.Controls.Add(axVideoPicture4);
            gbCameras.Controls.Add(axVideoPicture2);
            gbCameras.Controls.Add(axVideoPicture1);
            gbCameras.Location = new System.Drawing.Point(0, 0);
            gbCameras.Name = "gbCameras";
            gbCameras.Size = new System.Drawing.Size(782, 554);
            gbCameras.TabIndex = 1;
            gbCameras.TabStop = false;
            gbCameras.Text = "Cameras";
            // 
            // axVideoTimeline4
            // 
            axVideoTimeline4.Enabled = true;
            axVideoTimeline4.Location = new System.Drawing.Point(393, 498);
            axVideoTimeline4.Name = "axVideoTimeline4";
            axVideoTimeline4.OcxState = (System.Windows.Forms.AxHost.State)resources.GetObject("axVideoTimeline4.OcxState");
            axVideoTimeline4.Size = new System.Drawing.Size(383, 50);
            axVideoTimeline4.TabIndex = 14;
            // 
            // axVideoTimeline3
            // 
            axVideoTimeline3.Enabled = true;
            axVideoTimeline3.Location = new System.Drawing.Point(393, 228);
            axVideoTimeline3.Name = "axVideoTimeline3";
            axVideoTimeline3.OcxState = (System.Windows.Forms.AxHost.State)resources.GetObject("axVideoTimeline3.OcxState");
            axVideoTimeline3.Size = new System.Drawing.Size(383, 50);
            axVideoTimeline3.TabIndex = 13;
            // 
            // axVideoTimeline2
            // 
            axVideoTimeline2.Enabled = true;
            axVideoTimeline2.Location = new System.Drawing.Point(5, 498);
            axVideoTimeline2.Name = "axVideoTimeline2";
            axVideoTimeline2.OcxState = (System.Windows.Forms.AxHost.State)resources.GetObject("axVideoTimeline2.OcxState");
            axVideoTimeline2.Size = new System.Drawing.Size(383, 50);
            axVideoTimeline2.TabIndex = 12;
            // 
            // axVideoTimeline1
            // 
            axVideoTimeline1.Enabled = true;
            axVideoTimeline1.Location = new System.Drawing.Point(5, 228);
            axVideoTimeline1.Name = "axVideoTimeline1";
            axVideoTimeline1.OcxState = (System.Windows.Forms.AxHost.State)resources.GetObject("axVideoTimeline1.OcxState");
            axVideoTimeline1.Size = new System.Drawing.Size(383, 50);
            axVideoTimeline1.TabIndex = 11;
            // 
            // axVideoPicture3
            // 
            axVideoPicture3.Enabled = true;
            axVideoPicture3.Location = new System.Drawing.Point(393, 13);
            axVideoPicture3.Name = "axVideoPicture3";
            axVideoPicture3.OcxState = (System.Windows.Forms.AxHost.State)resources.GetObject("axVideoPicture3.OcxState");
            axVideoPicture3.Size = new System.Drawing.Size(383, 210);
            axVideoPicture3.TabIndex = 3;
            // 
            // axVideoPicture4
            // 
            axVideoPicture4.Enabled = true;
            axVideoPicture4.Location = new System.Drawing.Point(393, 283);
            axVideoPicture4.Name = "axVideoPicture4";
            axVideoPicture4.OcxState = (System.Windows.Forms.AxHost.State)resources.GetObject("axVideoPicture4.OcxState");
            axVideoPicture4.Size = new System.Drawing.Size(383, 210);
            axVideoPicture4.TabIndex = 2;
            // 
            // axVideoPicture2
            // 
            axVideoPicture2.Enabled = true;
            axVideoPicture2.Location = new System.Drawing.Point(5, 283);
            axVideoPicture2.Name = "axVideoPicture2";
            axVideoPicture2.OcxState = (System.Windows.Forms.AxHost.State)resources.GetObject("axVideoPicture2.OcxState");
            axVideoPicture2.Size = new System.Drawing.Size(383, 210);
            axVideoPicture2.TabIndex = 1;
            // 
            // axVideoPicture1
            // 
            axVideoPicture1.Enabled = true;
            axVideoPicture1.Location = new System.Drawing.Point(5, 13);
            axVideoPicture1.Name = "axVideoPicture1";
            axVideoPicture1.OcxState = (System.Windows.Forms.AxHost.State)resources.GetObject("axVideoPicture1.OcxState");
            axVideoPicture1.Size = new System.Drawing.Size(383, 210);
            axVideoPicture1.TabIndex = 0;
            // 
            // cmsMenu
            // 
            cmsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { tsmiChangeCameraTo });
            cmsMenu.Name = "contextMenuStrip1";
            cmsMenu.Size = new System.Drawing.Size(184, 26);
            // 
            // tsmiChangeCameraTo
            // 
            tsmiChangeCameraTo.Name = "tsmiChangeCameraTo";
            tsmiChangeCameraTo.Size = new System.Drawing.Size(183, 22);
            tsmiChangeCameraTo.Text = "Change camera to ...";
            tsmiChangeCameraTo.Click += TsmiChangeCameraTo_Click;
            // 
            // SyncronView
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(782, 660);
            Controls.Add(pMain);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "SyncronView";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Syncron view";
            pMain.ResumeLayout(false);
            gbControls.ResumeLayout(false);
            gbControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tbSpeed).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudImageHour).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudImageMinute).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudImageSecond).EndInit();
            gbCameras.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)axVideoTimeline4).EndInit();
            ((System.ComponentModel.ISupportInitialize)axVideoTimeline3).EndInit();
            ((System.ComponentModel.ISupportInitialize)axVideoTimeline2).EndInit();
            ((System.ComponentModel.ISupportInitialize)axVideoTimeline1).EndInit();
            ((System.ComponentModel.ISupportInitialize)axVideoPicture3).EndInit();
            ((System.ComponentModel.ISupportInitialize)axVideoPicture4).EndInit();
            ((System.ComponentModel.ISupportInitialize)axVideoPicture2).EndInit();
            ((System.ComponentModel.ISupportInitialize)axVideoPicture1).EndInit();
            cmsMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
    }
}