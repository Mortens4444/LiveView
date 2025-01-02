namespace CameraApp.Forms
{
    partial class FullScreenCamera
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(FullScreenCamera));
            axVideoPlayerWindow = new Mtf.Controls.x86.AxVideoPlayerWindow();
            cmsMenu = new System.Windows.Forms.ContextMenuStrip(components);
            closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            cmsMenu.SuspendLayout();
            SuspendLayout();
            // 
            // axVideoPlayerWindow
            // 
            axVideoPlayerWindow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            axVideoPlayerWindow.ContextMenuStrip = cmsMenu;
            axVideoPlayerWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            axVideoPlayerWindow.Location = new System.Drawing.Point(0, 0);
            axVideoPlayerWindow.Name = "axVideoPlayerWindow";
            axVideoPlayerWindow.OverlayFont = (System.Drawing.Font)resources.GetObject("axVideoPlayerWindow.OverlayFont");
            axVideoPlayerWindow.OverlayLocation = new System.Drawing.Point(10, 10);
            axVideoPlayerWindow.OverlayText = "";
            axVideoPlayerWindow.Size = new System.Drawing.Size(800, 450);
            axVideoPlayerWindow.TabIndex = 0;
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
            // FullScreenCamera
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(axVideoPlayerWindow);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FullScreenCamera";
            ShowIcon = false;
            Text = "FullScreenCamera";
            TopMost = true;
            Load += FullScreenCamera_Load;
            Shown += FullScreenCamera_Shown;
            cmsMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Mtf.Controls.x86.AxVideoPlayerWindow axVideoPlayerWindow;
        private System.Windows.Forms.ContextMenuStrip cmsMenu;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
    }
}