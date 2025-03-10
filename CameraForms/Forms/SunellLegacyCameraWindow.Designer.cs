using Mtf.Controls.Sunell.IPR66;

namespace CameraForms.Forms
{
    partial class SunellLegacyCameraWindow
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(SunellLegacyCameraWindow));
            sunellVideoWindowLegacy1 = new SunellVideoWindowLegacy();
            ((System.ComponentModel.ISupportInitialize)sunellVideoWindowLegacy1).BeginInit();
            SuspendLayout();
            // 
            // sunellVideoWindowLegacy1
            // 
            sunellVideoWindowLegacy1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            sunellVideoWindowLegacy1.Dock = System.Windows.Forms.DockStyle.Fill;
            sunellVideoWindowLegacy1.Location = new System.Drawing.Point(0, 0);
            sunellVideoWindowLegacy1.Name = "sunellVideoWindowLegacy1";
            sunellVideoWindowLegacy1.OverlayFont = (System.Drawing.Font)resources.GetObject("sunellVideoWindowLegacy1.OverlayFont");
            sunellVideoWindowLegacy1.OverlayLocation = new System.Drawing.Point(10, 10);
            sunellVideoWindowLegacy1.OverlayText = "";
            sunellVideoWindowLegacy1.Size = new System.Drawing.Size(800, 450);
            sunellVideoWindowLegacy1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            sunellVideoWindowLegacy1.TabIndex = 0;
            sunellVideoWindowLegacy1.TabStop = false;
            // 
            // SunellLegacyCameraWindow
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.Black;
            BackgroundImage = Properties.Resources.nosignal;
            BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(sunellVideoWindowLegacy1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "SunellLegacyCameraWindow";
            ShowIcon = false;
            ShowInTaskbar = false;
            FormClosing += SunellLegacyCameraWindow_FormClosing;
            Load += SunellLegacyCameraWindow_Load;
            Shown += SunellLegacyCameraWindow_Shown;
            ((System.ComponentModel.ISupportInitialize)sunellVideoWindowLegacy1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Mtf.Controls.Sunell.IPR66.SunellVideoWindowLegacy sunellVideoWindowLegacy1;
    }
}