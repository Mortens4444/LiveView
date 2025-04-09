namespace LiveView.Forms
{
    partial class KBD300ASimulator
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(KBD300ASimulator));
            kbd300aSimulator = new Mtf.Controls.Kbd300ASimulator();
            ((System.ComponentModel.ISupportInitialize)kbd300aSimulator).BeginInit();
            SuspendLayout();
            // 
            // kbd300aSimulator2
            // 
            kbd300aSimulator.BackgroundPaintDebounceIntervalInMs = 0;
            kbd300aSimulator.Dock = System.Windows.Forms.DockStyle.Fill;
            kbd300aSimulator.Image = (System.Drawing.Image)resources.GetObject("kbd300aSimulator2.Image");
            kbd300aSimulator.Location = new System.Drawing.Point(0, 0);
            kbd300aSimulator.Name = "kbd300aSimulator2";
            kbd300aSimulator.OriginalSize = new System.Drawing.Size(673, 427);
            kbd300aSimulator.PaintDebounceIntervalInMs = 0;
            kbd300aSimulator.PipeName = LiveView.Core.Constants.PipeServerName;
            kbd300aSimulator.RepositioningAndResizingControlsOnResize = true;
            kbd300aSimulator.ResizeDebounceIntervalInMs = 0;
            kbd300aSimulator.Shift = false;
            kbd300aSimulator.ShowPaintErrors = false;
            kbd300aSimulator.ShowResizeErrors = false;
            kbd300aSimulator.Size = new System.Drawing.Size(673, 427);
            kbd300aSimulator.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            kbd300aSimulator.TabIndex = 0;
            kbd300aSimulator.TabStop = false;
            // 
            // KBD300ASimulator
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(673, 427);
            Controls.Add(kbd300aSimulator);
            Name = "KBD300ASimulator";
            Text = "KBD300ASimulator";
            ((System.ComponentModel.ISupportInitialize)kbd300aSimulator).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Mtf.Controls.Kbd300ASimulator kbd300aSimulator;
    }
}