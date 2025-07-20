using Database.Services;
using LiveView.Core.Services;

namespace CameraForms.Forms
{
    partial class SunellCameraWindow
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
                client?.Dispose();
                cts?.Dispose();
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(SunellCameraWindow));
            sunellVideoWindow1 = new Mtf.Controls.Video.Sunell.IPR67.SunellVideoWindow(AppConfig.GetInt32(Database.Constants.SunellCameraWindowRotateSpeed, 50));
            cmsMenu = new System.Windows.Forms.ContextMenuStrip(components);
            closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)sunellVideoWindow1).BeginInit();
            cmsMenu.SuspendLayout();
            SuspendLayout();
            // 
            // sunellVideoWindow1
            // 
            sunellVideoWindow1.BackgroundImage = (System.Drawing.Image)resources.GetObject("sunellVideoWindow1.BackgroundImage");
            sunellVideoWindow1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            sunellVideoWindow1.ContextMenuStrip = cmsMenu;
            sunellVideoWindow1.Dock = System.Windows.Forms.DockStyle.Fill;
            sunellVideoWindow1.Location = new System.Drawing.Point(0, 0);
            sunellVideoWindow1.Name = "sunellVideoWindow1";
            sunellVideoWindow1.OverlayBackgroundColor = System.Drawing.Color.White;
            sunellVideoWindow1.OverlayColor = System.Drawing.Color.White;
            sunellVideoWindow1.OverlayFont = (System.Drawing.Font)resources.GetObject("sunellVideoWindow1.OverlayFont");
            sunellVideoWindow1.OverlayLocation = new System.Drawing.Point(10, 10);
            sunellVideoWindow1.OverlayText = "";
            sunellVideoWindow1.Size = new System.Drawing.Size(634, 352);
            sunellVideoWindow1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            sunellVideoWindow1.TabIndex = 0;
            sunellVideoWindow1.TabStop = false;
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
            // SunellCameraWindow
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(634, 352);
            Controls.Add(sunellVideoWindow1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "SunellCameraWindow";
            ShowIcon = false;
            ShowInTaskbar = false;
            FormClosing += SunellCameraWindow_FormClosing;
            Load += SunellCameraWindow_Load;
            Shown += SunellCameraWindow_Shown;
            ((System.ComponentModel.ISupportInitialize)sunellVideoWindow1).EndInit();
            cmsMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Mtf.Controls.Video.Sunell.IPR67.SunellVideoWindow sunellVideoWindow1;
        private System.Windows.Forms.ContextMenuStrip cmsMenu;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
    }
}