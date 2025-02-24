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
                initializationCompleted.Dispose();
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
            fFmpegWindow = new Mtf.Controls.Video.FFmpegWindow();
            ((System.ComponentModel.ISupportInitialize)fFmpegWindow).BeginInit();
            SuspendLayout();
            // 
            // fFmpegWindow
            // 
            fFmpegWindow.BackColor = System.Drawing.Color.Black;
            fFmpegWindow.BackgroundImage = Properties.Resources.nosignal;
            fFmpegWindow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            fFmpegWindow.Codec = Mtf.Controls.Enums.Codec.mjpeg;
            fFmpegWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            fFmpegWindow.Location = new System.Drawing.Point(0, 0);
            fFmpegWindow.Name = "fFmpegWindow";
            fFmpegWindow.Size = new System.Drawing.Size(800, 450);
            fFmpegWindow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            fFmpegWindow.TabIndex = 0;
            fFmpegWindow.TabStop = false;
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
            FormClosing += VideoSourceCamera_FormClosing;
            Load += VideoSourceCamera_Load;
            Shown += VideoSourceCamera_Shown;
            ((System.ComponentModel.ISupportInitialize)fFmpegWindow).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Mtf.Controls.Video.FFmpegWindow fFmpegWindow;
    }
}