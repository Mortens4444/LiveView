namespace LiveView.Forms
{
    partial class DisplayDeviceIdentifier
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
            components = new System.ComponentModel.Container();
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(DisplayDeviceIdentifier));
            pictureBox1 = new System.Windows.Forms.PictureBox();
            lblDeviceName2 = new System.Windows.Forms.Label();
            lblDeviceId = new System.Windows.Forms.Label();
            lblDeviceName = new System.Windows.Forms.Label();
            lblAdapter = new System.Windows.Forms.Label();
            lblId = new System.Windows.Forms.Label();
            tCloser = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pictureBox1.Image = Properties.Resources.Sziltech;
            pictureBox1.Location = new System.Drawing.Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(312, 217);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // lblDeviceName2
            // 
            lblDeviceName2.AutoSize = true;
            lblDeviceName2.Font = (System.Drawing.Font)resources.GetObject("lblDeviceName2.Font");
            lblDeviceName2.ForeColor = System.Drawing.Color.White;
            lblDeviceName2.Location = new System.Drawing.Point(0, 257);
            lblDeviceName2.Name = "lblDeviceName2";
            lblDeviceName2.Size = new System.Drawing.Size(330, 155);
            lblDeviceName2.TabIndex = 1;
            lblDeviceName2.Text = "M-ID";
            // 
            // lblDeviceId
            // 
            lblDeviceId.AutoSize = true;
            lblDeviceId.BackColor = System.Drawing.Color.Black;
            lblDeviceId.Font = (System.Drawing.Font)resources.GetObject("lblDeviceId.Font");
            lblDeviceId.ForeColor = System.Drawing.Color.White;
            lblDeviceId.Location = new System.Drawing.Point(12, 138);
            lblDeviceId.Name = "lblDeviceId";
            lblDeviceId.Size = new System.Drawing.Size(91, 21);
            lblDeviceId.TabIndex = 2;
            lblDeviceId.Text = "Device ID: ";
            // 
            // lblDeviceName
            // 
            lblDeviceName.AutoSize = true;
            lblDeviceName.BackColor = System.Drawing.Color.Black;
            lblDeviceName.Font = (System.Drawing.Font)resources.GetObject("lblDeviceName.Font");
            lblDeviceName.ForeColor = System.Drawing.Color.White;
            lblDeviceName.Location = new System.Drawing.Point(12, 159);
            lblDeviceName.Name = "lblDeviceName";
            lblDeviceName.Size = new System.Drawing.Size(56, 21);
            lblDeviceName.TabIndex = 3;
            lblDeviceName.Text = "Name";
            // 
            // lblAdapter
            // 
            lblAdapter.AutoSize = true;
            lblAdapter.BackColor = System.Drawing.Color.Black;
            lblAdapter.Font = (System.Drawing.Font)resources.GetObject("lblAdapter.Font");
            lblAdapter.ForeColor = System.Drawing.Color.White;
            lblAdapter.Location = new System.Drawing.Point(12, 180);
            lblAdapter.Name = "lblAdapter";
            lblAdapter.Size = new System.Drawing.Size(71, 21);
            lblAdapter.TabIndex = 4;
            lblAdapter.Text = "Adapter";
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.BackColor = System.Drawing.Color.Black;
            lblId.Font = (System.Drawing.Font)resources.GetObject("lblId.Font");
            lblId.ForeColor = System.Drawing.Color.White;
            lblId.Location = new System.Drawing.Point(109, 138);
            lblId.Name = "lblId";
            lblId.Size = new System.Drawing.Size(48, 21);
            lblId.TabIndex = 5;
            lblId.Text = "M-ID";
            // 
            // tCloser
            // 
            tCloser.Tick += TCloser_Tick;
            // 
            // DisplayDeviceIdentifier
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.Black;
            ClientSize = new System.Drawing.Size(312, 457);
            Controls.Add(lblId);
            Controls.Add(lblAdapter);
            Controls.Add(lblDeviceName);
            Controls.Add(lblDeviceId);
            Controls.Add(lblDeviceName2);
            Controls.Add(pictureBox1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DisplayDeviceIdentifier";
            TopMost = true;
            Load += DisplayDeviceIdentifier_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblDeviceName2;
        private System.Windows.Forms.Label lblDeviceId;
        private System.Windows.Forms.Label lblDeviceName;
        private System.Windows.Forms.Label lblAdapter;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Timer tCloser;
    }
}