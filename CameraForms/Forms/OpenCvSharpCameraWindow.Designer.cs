namespace CameraForms.Forms
{
    partial class OpenCvSharpCameraWindow
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(OpenCvSharpCameraWindow));
            openCvSharpVideoWindow = new Mtf.Controls.Video.OpenCvSharp.OpenCvSharpVideoWindow();
            cmsMenu = new System.Windows.Forms.ContextMenuStrip(components);
            closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)openCvSharpVideoWindow).BeginInit();
            cmsMenu.SuspendLayout();
            SuspendLayout();
            // 
            // openCvSharpVideoWindow
            // 
            openCvSharpVideoWindow.BackColor = System.Drawing.Color.Black;
            openCvSharpVideoWindow.BackgroundImage = Properties.Resources.nosignal;
            openCvSharpVideoWindow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            openCvSharpVideoWindow.ContextMenuStrip = cmsMenu;
            openCvSharpVideoWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            openCvSharpVideoWindow.Location = new System.Drawing.Point(0, 0);
            openCvSharpVideoWindow.Name = "openCvSharpVideoWindow";
            openCvSharpVideoWindow.OverlayFont = (System.Drawing.Font)resources.GetObject("openCvSharpVideoWindow.OverlayFont");
            openCvSharpVideoWindow.OverlayLocation = new System.Drawing.Point(10, 10);
            openCvSharpVideoWindow.OverlayText = "";
            openCvSharpVideoWindow.Size = new System.Drawing.Size(800, 450);
            openCvSharpVideoWindow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            openCvSharpVideoWindow.TabIndex = 0;
            openCvSharpVideoWindow.TabStop = false;
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
            // OpenCvSharpCameraWindow
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(openCvSharpVideoWindow);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "OpenCvSharpCameraWindow";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            Text = "";
            TopMost = true;
            FormClosing += OpenCvSharp_FormClosing;
            Load += OpenCvSharp_Load;
            Shown += OpenCvSharp_Shown;
            ((System.ComponentModel.ISupportInitialize)openCvSharpVideoWindow).EndInit();
            cmsMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Mtf.Controls.Video.OpenCvSharp.OpenCvSharpVideoWindow openCvSharpVideoWindow;
        private System.Windows.Forms.ContextMenuStrip cmsMenu;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
    }
}