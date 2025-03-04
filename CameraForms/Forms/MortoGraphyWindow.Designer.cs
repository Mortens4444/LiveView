using Mtf.Controls.Video;

namespace CameraForms.Forms
{
    partial class MortoGraphyWindow
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
            mortoGraphyWindow = new Mtf.Controls.Video.MortoGraphyWindow();
            ((System.ComponentModel.ISupportInitialize)mortoGraphyWindow).BeginInit();
            SuspendLayout();
            // 
            // MortoGraphyWindow
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.nosignal;
            BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            ClientSize = new System.Drawing.Size(800, 450);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "MortoGraphyWindow";
            Text = "MortoGraphyWindow";
            FormClosing += MortoGraphyWindow_FormClosing;
            Load += MortoGraphyWindow_Load;
            Shown += MortoGraphyWindow_Shown;
            ResumeLayout(false);
        }

        #endregion

        private Mtf.Controls.Video.MortoGraphyWindow mortoGraphyWindow;
    }
}