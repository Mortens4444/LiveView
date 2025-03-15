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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(SunellCameraWindow));
            sunellVideoWindow1 = new Mtf.Controls.Sunell.IPR67.SunellVideoWindow();
            ((System.ComponentModel.ISupportInitialize)sunellVideoWindow1).BeginInit();
            SuspendLayout();
            // 
            // sunellVideoWindow1
            // 
            sunellVideoWindow1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            sunellVideoWindow1.Dock = System.Windows.Forms.DockStyle.Fill;
            sunellVideoWindow1.Location = new System.Drawing.Point(0, 0);
            sunellVideoWindow1.Name = "sunellVideoWindow1";
            sunellVideoWindow1.OverlayFont = (System.Drawing.Font)resources.GetObject("sunellVideoWindow1.OverlayFont");
            sunellVideoWindow1.OverlayLocation = new System.Drawing.Point(10, 10);
            sunellVideoWindow1.OverlayText = "";
            sunellVideoWindow1.Size = new System.Drawing.Size(634, 352);
            sunellVideoWindow1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            sunellVideoWindow1.TabIndex = 0;
            sunellVideoWindow1.TabStop = false;
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
            ResumeLayout(false);
        }

        #endregion

        private Mtf.Controls.Sunell.IPR67.SunellVideoWindow sunellVideoWindow1;
    }
}