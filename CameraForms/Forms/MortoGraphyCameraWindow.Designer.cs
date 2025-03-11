using Mtf.Controls.Video;
using System.Windows.Forms;
using System;

namespace CameraForms.Forms
{
    partial class MortoGraphyCameraWindow
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(MortoGraphyCameraWindow));
            mortoGraphyWindow = new MortoGraphyWindow();
            ((System.ComponentModel.ISupportInitialize)mortoGraphyWindow).BeginInit();
            SuspendLayout();
            // 
            // mortoGraphyWindow
            // 
            mortoGraphyWindow.BackgroundImage = (System.Drawing.Image)resources.GetObject("mortoGraphyWindow.BackgroundImage");
            mortoGraphyWindow.BackgroundImageLayout = ImageLayout.Stretch;
            mortoGraphyWindow.Dock = DockStyle.Fill;
            mortoGraphyWindow.Location = new System.Drawing.Point(0, 0);
            mortoGraphyWindow.Name = "mortoGraphyWindow";
            mortoGraphyWindow.OverlayFont = (System.Drawing.Font)resources.GetObject("mortoGraphyWindow.OverlayFont");
            mortoGraphyWindow.OverlayLocation = new System.Drawing.Point(10, 10);
            mortoGraphyWindow.OverlayText = "";
            mortoGraphyWindow.Password = null;
            mortoGraphyWindow.Size = new System.Drawing.Size(100, 50);
            mortoGraphyWindow.SizeMode = PictureBoxSizeMode.StretchImage;
            mortoGraphyWindow.StreamType = Mtf.Controls.Enums.StreamType.Mjpeg;
            mortoGraphyWindow.TabIndex = 0;
            mortoGraphyWindow.TabStop = false;
            mortoGraphyWindow.Username = null;
            // 
            // MortoGraphyCameraWindow
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(mortoGraphyWindow);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MortoGraphyCameraWindow";
            Text = "MortoGraphyWindow";
            FormClosing += MortoGraphyWindow_FormClosing;
            Load += MortoGraphyWindow_Load;
            Shown += MortoGraphyWindow_Shown;
            ((System.ComponentModel.ISupportInitialize)mortoGraphyWindow).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Mtf.Controls.Video.MortoGraphyWindow mortoGraphyWindow;
    }
}