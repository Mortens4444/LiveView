namespace LiveView.Forms
{
    partial class MotionPopup
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(MotionPopup));
            pMain = new System.Windows.Forms.Panel();
            pRight = new System.Windows.Forms.Panel();
            axVideoPlayerWindow2 = new Mtf.Controls.Video.ActiveX.AxVideoPlayerWindow();
            splitter = new System.Windows.Forms.Splitter();
            pLeft = new System.Windows.Forms.Panel();
            axVideoMotion = new AxVIDEOCONTROL4Lib.AxVideoMotion();
            axVideoPlayerWindow = new Mtf.Controls.Video.ActiveX.AxVideoPlayerWindow();
            pMain.SuspendLayout();
            pRight.SuspendLayout();
            pLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)axVideoMotion).BeginInit();
            SuspendLayout();
            // 
            // pMain
            // 
            pMain.Controls.Add(pRight);
            pMain.Controls.Add(splitter);
            pMain.Controls.Add(pLeft);
            pMain.Dock = System.Windows.Forms.DockStyle.Fill;
            pMain.Location = new System.Drawing.Point(0, 0);
            pMain.Name = "pMain";
            pMain.Size = new System.Drawing.Size(1080, 549);
            pMain.TabIndex = 0;
            // 
            // pRight
            // 
            pRight.Controls.Add(axVideoPlayerWindow2);
            pRight.Dock = System.Windows.Forms.DockStyle.Fill;
            pRight.Location = new System.Drawing.Point(521, 0);
            pRight.Name = "pRight";
            pRight.Size = new System.Drawing.Size(559, 549);
            pRight.TabIndex = 19;
            // 
            // axVideoPlayerWindow2
            // 
            axVideoPlayerWindow2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            axVideoPlayerWindow2.Dock = System.Windows.Forms.DockStyle.Fill;
            axVideoPlayerWindow2.Location = new System.Drawing.Point(0, 0);
            axVideoPlayerWindow2.Name = "axVideoPlayerWindow2";
            axVideoPlayerWindow2.OverlayFont = (System.Drawing.Font)resources.GetObject("axVideoPlayerWindow2.OverlayFont");
            axVideoPlayerWindow2.OverlayLocation = new System.Drawing.Point(10, 10);
            axVideoPlayerWindow2.OverlayText = "";
            axVideoPlayerWindow2.Size = new System.Drawing.Size(559, 549);
            axVideoPlayerWindow2.TabIndex = 17;
            // 
            // splitter
            // 
            splitter.Location = new System.Drawing.Point(518, 0);
            splitter.Name = "splitter";
            splitter.Size = new System.Drawing.Size(3, 549);
            splitter.TabIndex = 18;
            splitter.TabStop = false;
            // 
            // pLeft
            // 
            pLeft.Controls.Add(axVideoMotion);
            pLeft.Controls.Add(axVideoPlayerWindow);
            pLeft.Dock = System.Windows.Forms.DockStyle.Left;
            pLeft.Location = new System.Drawing.Point(0, 0);
            pLeft.Name = "pLeft";
            pLeft.Size = new System.Drawing.Size(518, 549);
            pLeft.TabIndex = 17;
            // 
            // axVideoMotion
            // 
            axVideoMotion.Enabled = true;
            axVideoMotion.Location = new System.Drawing.Point(3, 3);
            axVideoMotion.Name = "axVideoMotion";
            axVideoMotion.OcxState = (System.Windows.Forms.AxHost.State)resources.GetObject("axVideoMotion.OcxState");
            axVideoMotion.Size = new System.Drawing.Size(100, 50);
            axVideoMotion.TabIndex = 17;
            axVideoMotion.Visible = false;
            // 
            // axVideoPlayerWindow
            // 
            axVideoPlayerWindow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            axVideoPlayerWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            axVideoPlayerWindow.Location = new System.Drawing.Point(0, 0);
            axVideoPlayerWindow.Name = "axVideoPlayerWindow";
            axVideoPlayerWindow.OverlayFont = (System.Drawing.Font)resources.GetObject("axVideoPlayerWindow.OverlayFont");
            axVideoPlayerWindow.OverlayLocation = new System.Drawing.Point(10, 10);
            axVideoPlayerWindow.OverlayText = "";
            axVideoPlayerWindow.Size = new System.Drawing.Size(518, 549);
            axVideoPlayerWindow.TabIndex = 16;
            // 
            // MotionPopup
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1080, 549);
            Controls.Add(pMain);
            Name = "MotionPopup";
            Text = "MotionPopup";
            TopMost = true;
            Shown += MotionPopup_Shown;
            pMain.ResumeLayout(false);
            pRight.ResumeLayout(false);
            pLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)axVideoMotion).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pMain;
        private System.Windows.Forms.Panel pRight;
        private System.Windows.Forms.Splitter splitter;
        private System.Windows.Forms.Panel pLeft;
        private Mtf.Controls.Video.ActiveX.AxVideoPlayerWindow axVideoPlayerWindow;
        private Mtf.Controls.Video.ActiveX.AxVideoPlayerWindow axVideoPlayerWindow2;
        private AxVIDEOCONTROL4Lib.AxVideoMotion axVideoMotion;
    }
}