namespace Sequence.Forms
{
    partial class Camera
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(Camera));
            axVideoPlayerWindow = new Mtf.Controls.x86.AxVideoPlayerWindow();
            SuspendLayout();
            // 
            // axVideoPlayerWindow
            // 
            axVideoPlayerWindow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            axVideoPlayerWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            axVideoPlayerWindow.Location = new System.Drawing.Point(0, 0);
            axVideoPlayerWindow.Name = "axVideoPlayerWindow";
            axVideoPlayerWindow.OverlayFont = (System.Drawing.Font)resources.GetObject("axVideoPlayerWindow.OverlayFont");
            axVideoPlayerWindow.OverlayLocation = new System.Drawing.Point(10, 10);
            axVideoPlayerWindow.OverlayText = "";
            axVideoPlayerWindow.Size = new System.Drawing.Size(800, 450);
            axVideoPlayerWindow.TabIndex = 0;
            // 
            // Camera
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(axVideoPlayerWindow);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Camera";
            ShowIcon = false;
            StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            Text = "FullScreenCamera";
            TopMost = true;
            FormClosing += Camera_FormClosing;
            Load += Camera_Load;
            Shown += Camera_Shown;
            ResumeLayout(false);
        }

        #endregion

        private Mtf.Controls.x86.AxVideoPlayerWindow axVideoPlayerWindow;
    }
}