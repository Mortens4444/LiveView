namespace CameraForms.Forms
{
    partial class FFMpegCameraWindow
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
                fullScreenCameraMessageHandler?.Dispose();
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(FFMpegCameraWindow));
            fFmpegWindow = new Mtf.Controls.Video.FFmpeg.FFmpegWindow();
            cmsMenu = new System.Windows.Forms.ContextMenuStrip(components);
            closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)fFmpegWindow).BeginInit();
            cmsMenu.SuspendLayout();
            SuspendLayout();
            // 
            // fFmpegWindow
            // 
            fFmpegWindow.BackColor = System.Drawing.Color.Black;
            fFmpegWindow.BackgroundImage = Properties.Resources.nosignal;
            fFmpegWindow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            fFmpegWindow.Codec = Mtf.Controls.Enums.Codec.mjpeg;
            fFmpegWindow.ContextMenuStrip = cmsMenu;
            fFmpegWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            fFmpegWindow.Location = new System.Drawing.Point(0, 0);
            fFmpegWindow.Name = "fFmpegWindow";
            fFmpegWindow.OverlayFont = (System.Drawing.Font)resources.GetObject("fFmpegWindow.OverlayFont");
            fFmpegWindow.OverlayLocation = new System.Drawing.Point(10, 10);
            fFmpegWindow.OverlayText = "";
            fFmpegWindow.Size = new System.Drawing.Size(800, 450);
            fFmpegWindow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            fFmpegWindow.TabIndex = 0;
            fFmpegWindow.TabStop = false;
            // 
            // cmsMenu
            // 
            cmsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { closeToolStripMenuItem });
            cmsMenu.Name = "cmsMenu";
            cmsMenu.Size = new System.Drawing.Size(181, 48);
            // 
            // closeToolStripMenuItem
            // 
            closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            closeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            closeToolStripMenuItem.Text = "Close";
            closeToolStripMenuItem.Click += CloseToolStripMenuItem_Click;
            // 
            // FFMpegCameraWindow
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(fFmpegWindow);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FFMpegCameraWindow";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            Text = "FullScreenCamera";
            TopMost = true;
            FormClosing += FFMpegCameraWindow_FormClosing;
            Load += FFMpegCameraWindow_Load;
            Shown += FFMpegCameraWindow_Shown;
            ((System.ComponentModel.ISupportInitialize)fFmpegWindow).EndInit();
            cmsMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Mtf.Controls.Video.FFmpeg.FFmpegWindow fFmpegWindow;
        private System.Windows.Forms.ContextMenuStrip cmsMenu;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
    }
}