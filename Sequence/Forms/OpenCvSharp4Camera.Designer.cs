namespace Sequence.Forms
{
    partial class OpenCvSharp4Camera
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
            openCvSharp4VideoWindow = new Mtf.Controls.Video.OpenCvSharp4VideoWindow();
            ((System.ComponentModel.ISupportInitialize)openCvSharp4VideoWindow).BeginInit();
            SuspendLayout();
            // 
            // openCvSharp4VideoWindow
            // 
            openCvSharp4VideoWindow.BackColor = System.Drawing.Color.Black;
            openCvSharp4VideoWindow.BackgroundImage = Properties.Resources.nosignal;
            openCvSharp4VideoWindow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            openCvSharp4VideoWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            openCvSharp4VideoWindow.Location = new System.Drawing.Point(0, 0);
            openCvSharp4VideoWindow.Name = "openCvSharp4VideoWindow";
            openCvSharp4VideoWindow.Size = new System.Drawing.Size(800, 450);
            openCvSharp4VideoWindow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            openCvSharp4VideoWindow.TabIndex = 0;
            openCvSharp4VideoWindow.TabStop = false;
            // 
            // OpenCvSharp4Camera
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(openCvSharp4VideoWindow);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "OpenCvSharp4Camera";
            ShowIcon = false;
            StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            Text = "FullScreenCamera";
            TopMost = true;
            FormClosing += VideoSourceCamera_FormClosing;
            Load += VideoSourceCamera_Load;
            Shown += VideoSourceCamera_Shown;
            ((System.ComponentModel.ISupportInitialize)openCvSharp4VideoWindow).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Mtf.Controls.Video.OpenCvSharp4VideoWindow openCvSharp4VideoWindow;
    }
}