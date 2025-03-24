namespace CameraForms.Forms
{
    partial class VlcCameraWindow
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(VlcCameraWindow));
            vlcWindow = new Mtf.Controls.Video.VLC.VlcWindow();
            cmsMenu = new System.Windows.Forms.ContextMenuStrip(components);
            closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)vlcWindow).BeginInit();
            cmsMenu.SuspendLayout();
            SuspendLayout();
            // 
            // vlcWindow
            // 
            vlcWindow.BackColor = System.Drawing.Color.Black;
            vlcWindow.BackgroundImage = Properties.Resources.nosignal;
            vlcWindow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            vlcWindow.ContextMenuStrip = cmsMenu;
            vlcWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            vlcWindow.Location = new System.Drawing.Point(0, 0);
            vlcWindow.MediaPlayer = null;
            vlcWindow.Name = "vlcWindow";
            vlcWindow.OverlayFont = (System.Drawing.Font)resources.GetObject("vlcWindow.OverlayFont");
            vlcWindow.OverlayLocation = new System.Drawing.Point(10, 10);
            vlcWindow.OverlayText = "";
            vlcWindow.Size = new System.Drawing.Size(800, 450);
            vlcWindow.TabIndex = 0;
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
            // VlcCameraWindow
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(vlcWindow);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "VlcCameraWindow";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            Text = "FullScreenCamera";
            TopMost = true;
            FormClosing += VlcCameraWindow_FormClosing;
            Load += VlcCameraWindow_Load;
            Shown += VlcCameraWindow_Shown;
            ((System.ComponentModel.ISupportInitialize)vlcWindow).EndInit();
            cmsMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Mtf.Controls.Video.VLC.VlcWindow vlcWindow;
        private System.Windows.Forms.ContextMenuStrip cmsMenu;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
    }
}