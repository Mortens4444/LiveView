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
            kbd300aSimulator2 = new Mtf.Controls.Kbd300ASimulator();
            ((System.ComponentModel.ISupportInitialize)kbd300aSimulator2).BeginInit();
            SuspendLayout();
            // 
            // kbd300aSimulator2
            // 
            kbd300aSimulator2.BackgroundPaintDebounceIntervalInMs = 0;
            kbd300aSimulator2.Dock = System.Windows.Forms.DockStyle.Fill;
            kbd300aSimulator2.Image = (System.Drawing.Image)resources.GetObject("kbd300aSimulator2.Image");
            kbd300aSimulator2.Location = new System.Drawing.Point(0, 0);
            kbd300aSimulator2.Name = "kbd300aSimulator2";
            kbd300aSimulator2.OriginalSize = new System.Drawing.Size(673, 427);
            kbd300aSimulator2.PaintDebounceIntervalInMs = 0;
            kbd300aSimulator2.PipeName = "KBD300A_Pipe";
            kbd300aSimulator2.RepositioningAndResizingControlsOnResize = true;
            kbd300aSimulator2.ResizeDebounceIntervalInMs = 0;
            kbd300aSimulator2.Shift = false;
            kbd300aSimulator2.ShowPaintErrors = false;
            kbd300aSimulator2.ShowResizeErrors = false;
            kbd300aSimulator2.Size = new System.Drawing.Size(673, 427);
            kbd300aSimulator2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            kbd300aSimulator2.TabIndex = 0;
            kbd300aSimulator2.TabStop = false;
            // 
            // KBD300ASimulator
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(673, 427);
            Controls.Add(kbd300aSimulator2);
            Name = "KBD300ASimulator";
            Text = "KBD300ASimulator";
            ((System.ComponentModel.ISupportInitialize)kbd300aSimulator2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Mtf.Controls.Kbd300ASimulator kbd300aSimulator1;
        private Mtf.Controls.Kbd300ASimulator kbd300aSimulator2;
    }
}