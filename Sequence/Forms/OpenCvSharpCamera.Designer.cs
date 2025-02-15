namespace Sequence.Forms
{
    partial class OpenCvSharpCamera
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
            openCvSharpVideoWindow = new Mtf.Controls.Video.OpenCvSharpVideoWindow();
            ((System.ComponentModel.ISupportInitialize)openCvSharpVideoWindow).BeginInit();
            SuspendLayout();
            // 
            // openCvSharpVideoWindow
            // 
            openCvSharpVideoWindow.BackColor = System.Drawing.Color.Black;
            openCvSharpVideoWindow.BackgroundImage = Properties.Resources.nosignal;
            openCvSharpVideoWindow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            openCvSharpVideoWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            openCvSharpVideoWindow.Location = new System.Drawing.Point(0, 0);
            openCvSharpVideoWindow.Name = "openCvSharpVideoWindow";
            openCvSharpVideoWindow.Size = new System.Drawing.Size(800, 450);
            openCvSharpVideoWindow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            openCvSharpVideoWindow.TabIndex = 0;
            openCvSharpVideoWindow.TabStop = false;
            // 
            // OpenCvSharpCamera
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(openCvSharpVideoWindow);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "OpenCvSharpCamera";
            ShowIcon = false;
            StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            Text = "FullScreenCamera";
            TopMost = true;
            FormClosing += VideoSourceCamera_FormClosing;
            Load += VideoSourceCamera_Load;
            Shown += VideoSourceCamera_Shown;
            ((System.ComponentModel.ISupportInitialize)openCvSharpVideoWindow).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Mtf.Controls.Video.OpenCvSharpVideoWindow openCvSharpVideoWindow;
    }
}