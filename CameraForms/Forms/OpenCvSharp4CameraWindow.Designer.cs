namespace CameraForms.Forms
{
    partial class OpenCvSharp4CameraWindow
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
            components = new System.ComponentModel.Container();
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(OpenCvSharp4CameraWindow));
            openCvSharp4VideoWindow = new Mtf.Controls.Video.OpenCvSharp.OpenCvSharp4VideoWindow();
            cmsMenu = new System.Windows.Forms.ContextMenuStrip(components);
            closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)openCvSharp4VideoWindow).BeginInit();
            cmsMenu.SuspendLayout();
            SuspendLayout();
            // 
            // openCvSharp4VideoWindow
            // 
            openCvSharp4VideoWindow.BackColor = System.Drawing.Color.Black;
            openCvSharp4VideoWindow.BackgroundImage = Properties.Resources.nosignal;
            openCvSharp4VideoWindow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            openCvSharp4VideoWindow.ContextMenuStrip = cmsMenu;
            openCvSharp4VideoWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            openCvSharp4VideoWindow.Location = new System.Drawing.Point(0, 0);
            openCvSharp4VideoWindow.Name = "openCvSharp4VideoWindow";
            openCvSharp4VideoWindow.OverlayFont = (System.Drawing.Font)resources.GetObject("openCvSharp4VideoWindow.OverlayFont");
            openCvSharp4VideoWindow.OverlayLocation = new System.Drawing.Point(10, 10);
            openCvSharp4VideoWindow.OverlayText = "";
            openCvSharp4VideoWindow.Size = new System.Drawing.Size(800, 450);
            openCvSharp4VideoWindow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            openCvSharp4VideoWindow.TabIndex = 0;
            openCvSharp4VideoWindow.TabStop = false;
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
            // OpenCvSharp4CameraWindow
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(openCvSharp4VideoWindow);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "OpenCvSharp4CameraWindow";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            Text = "FullScreenCamera";
            TopMost = true;
            FormClosing += OpenCvSharp4_FormClosing;
            Load += OpenCvSharp4_Load;
            Shown += OpenCvSharp4_Shown;
            ((System.ComponentModel.ISupportInitialize)openCvSharp4VideoWindow).EndInit();
            cmsMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Mtf.Controls.Video.OpenCvSharp.OpenCvSharp4VideoWindow openCvSharp4VideoWindow;
        private System.Windows.Forms.ContextMenuStrip cmsMenu;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
    }
}