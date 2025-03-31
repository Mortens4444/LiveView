namespace CameraForms.Forms
{
    partial class VideoSourceCameraWindow
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
                frameTimer?.Dispose();
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
            cmsMenu = new System.Windows.Forms.ContextMenuStrip(components);
            closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            mtfCamera = new Mtf.Controls.MtfPictureBox();
            cmsMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)mtfCamera).BeginInit();
            SuspendLayout();
            // 
            // cmsMenu
            // 
            cmsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { closeToolStripMenuItem });
            cmsMenu.Name = "cmsMenu";
            cmsMenu.Size = new System.Drawing.Size(104, 26);
            // 
            // closeToolStripMenuItem
            // 
            closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            closeToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            closeToolStripMenuItem.Text = "Close";
            closeToolStripMenuItem.Click += CloseToolStripMenuItem_Click;
            // 
            // mtfCamera
            // 
            mtfCamera.BackgroundPaintDebounceIntervalInMs = 0;
            mtfCamera.ContextMenuStrip = cmsMenu;
            mtfCamera.Dock = System.Windows.Forms.DockStyle.Fill;
            mtfCamera.Image = Properties.Resources.nosignal;
            mtfCamera.Location = new System.Drawing.Point(0, 0);
            mtfCamera.Name = "mtfCamera";
            mtfCamera.OriginalSize = new System.Drawing.Size(0, 0);
            mtfCamera.PaintDebounceIntervalInMs = 0;
            mtfCamera.RepositioningAndResizingControlsOnResize = false;
            mtfCamera.ResizeDebounceIntervalInMs = 0;
            mtfCamera.ShowPaintErrors = false;
            mtfCamera.ShowResizeErrors = false;
            mtfCamera.Size = new System.Drawing.Size(800, 450);
            mtfCamera.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            mtfCamera.TabIndex = 1;
            mtfCamera.TabStop = false;
            // 
            // VideoSourceCameraWindow
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.Black;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(mtfCamera);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "VideoSourceCameraWindow";
            ShowIcon = false;
            ShowInTaskbar = false;
            Text = "FullScreenCamera";
            TopMost = true;
            FormClosing += VideoSourceCameraWindow_FormClosing;
            Load += VideoSourceCameraWindow_Load;
            Shown += VideoSourceCameraWindow_Shown;
            cmsMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)mtfCamera).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip cmsMenu;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private Mtf.Controls.MtfPictureBox mtfCamera;
    }
}