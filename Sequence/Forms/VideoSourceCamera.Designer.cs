namespace Sequence.Forms
{
    partial class VideoSourceCamera
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
            mtfCamera = new Mtf.Controls.MtfPictureBox();
            ((System.ComponentModel.ISupportInitialize)mtfCamera).BeginInit();
            SuspendLayout();
            // 
            // mtfCamera
            // 
            mtfCamera.BackColor = System.Drawing.Color.Black;
            mtfCamera.BackgroundPaintDebounceIntervalInMs = 0;
            mtfCamera.Dock = System.Windows.Forms.DockStyle.Fill;
            mtfCamera.Image = Properties.Resources.nosignal;
            mtfCamera.Location = new System.Drawing.Point(0, 0);
            mtfCamera.Name = "mtfCamera";
            mtfCamera.OriginalSize = new System.Drawing.Size(0, 0);
            mtfCamera.PaintDebounceIntervalInMs = 0;
            mtfCamera.RepositioningAndResizingControlsOnResize = false;
            mtfCamera.ResizeDebounceIntervalInMs = 0;
            mtfCamera.ShowPaintErrors = false;
            mtfCamera.ShowResizeErrors = false;
            mtfCamera.Size = new System.Drawing.Size(800, 450);
            mtfCamera.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            mtfCamera.TabIndex = 0;
            mtfCamera.TabStop = false;
            // 
            // VideoSourceCamera
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(mtfCamera);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "VideoSourceCamera";
            ShowIcon = false;
            StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            Text = "FullScreenCamera";
            TopMost = true;
            FormClosing += VideoSourceCamera_FormClosing;
            Load += VideoSourceCamera_Load;
            Shown += VideoSourceCamera_Shown;
            ((System.ComponentModel.ISupportInitialize)mtfCamera).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Mtf.Controls.MtfPictureBox mtfCamera;
    }
}