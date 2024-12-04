namespace LiveView.Forms
{
    partial class IOPortEditor
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(IOPortEditor));
            pMain = new System.Windows.Forms.Panel();
            lblMs = new System.Windows.Forms.Label();
            nudMinTriggerTime = new System.Windows.Forms.NumericUpDown();
            lblMinTriggerTime = new System.Windows.Forms.Label();
            nudMaxSignalPerDay = new System.Windows.Forms.NumericUpDown();
            lblMaxSignalPerDay = new System.Windows.Forms.Label();
            btnClose = new System.Windows.Forms.Button();
            btnSave = new System.Windows.Forms.Button();
            tbFriendlyName = new System.Windows.Forms.TextBox();
            lblFriendlyName = new System.Windows.Forms.Label();
            pMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudMinTriggerTime).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudMaxSignalPerDay).BeginInit();
            SuspendLayout();
            // 
            // pMain
            // 
            pMain.Controls.Add(lblMs);
            pMain.Controls.Add(nudMinTriggerTime);
            pMain.Controls.Add(lblMinTriggerTime);
            pMain.Controls.Add(nudMaxSignalPerDay);
            pMain.Controls.Add(lblMaxSignalPerDay);
            pMain.Controls.Add(btnClose);
            pMain.Controls.Add(btnSave);
            pMain.Controls.Add(tbFriendlyName);
            pMain.Controls.Add(lblFriendlyName);
            pMain.Dock = System.Windows.Forms.DockStyle.Fill;
            pMain.Location = new System.Drawing.Point(0, 0);
            pMain.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pMain.Name = "pMain";
            pMain.Size = new System.Drawing.Size(341, 167);
            pMain.TabIndex = 1;
            // 
            // lblMs
            // 
            lblMs.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lblMs.AutoSize = true;
            lblMs.Location = new System.Drawing.Point(303, 102);
            lblMs.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblMs.Name = "lblMs";
            lblMs.Size = new System.Drawing.Size(23, 15);
            lblMs.TabIndex = 8;
            lblMs.Text = "ms";
            // 
            // nudMinTriggerTime
            // 
            nudMinTriggerTime.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            nudMinTriggerTime.Location = new System.Drawing.Point(212, 99);
            nudMinTriggerTime.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            nudMinTriggerTime.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            nudMinTriggerTime.Name = "nudMinTriggerTime";
            nudMinTriggerTime.Size = new System.Drawing.Size(84, 23);
            nudMinTriggerTime.TabIndex = 7;
            // 
            // lblMinTriggerTime
            // 
            lblMinTriggerTime.AutoSize = true;
            lblMinTriggerTime.Location = new System.Drawing.Point(14, 102);
            lblMinTriggerTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblMinTriggerTime.Name = "lblMinTriggerTime";
            lblMinTriggerTime.Size = new System.Drawing.Size(125, 15);
            lblMinTriggerTime.TabIndex = 6;
            lblMinTriggerTime.Text = "Minimum trigger time";
            // 
            // nudMaxSignalPerDay
            // 
            nudMaxSignalPerDay.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            nudMaxSignalPerDay.Location = new System.Drawing.Point(212, 69);
            nudMaxSignalPerDay.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            nudMaxSignalPerDay.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            nudMaxSignalPerDay.Name = "nudMaxSignalPerDay";
            nudMaxSignalPerDay.Size = new System.Drawing.Size(114, 23);
            nudMaxSignalPerDay.TabIndex = 5;
            nudMaxSignalPerDay.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // lblMaxSignalPerDay
            // 
            lblMaxSignalPerDay.AutoSize = true;
            lblMaxSignalPerDay.Location = new System.Drawing.Point(14, 72);
            lblMaxSignalPerDay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblMaxSignalPerDay.Name = "lblMaxSignalPerDay";
            lblMaxSignalPerDay.Size = new System.Drawing.Size(145, 15);
            lblMaxSignalPerDay.TabIndex = 4;
            lblMaxSignalPerDay.Text = "Maximum signals per day ";
            // 
            // btnClose
            // 
            btnClose.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            btnClose.Location = new System.Drawing.Point(239, 132);
            btnClose.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnClose.Name = "btnClose";
            btnClose.Size = new System.Drawing.Size(88, 27);
            btnClose.TabIndex = 3;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += BtnClose_Click;
            // 
            // btnSave
            // 
            btnSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            btnSave.Location = new System.Drawing.Point(145, 132);
            btnSave.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(88, 27);
            btnSave.TabIndex = 2;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += BtnSave_Click;
            // 
            // tbFriendlyName
            // 
            tbFriendlyName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tbFriendlyName.Location = new System.Drawing.Point(14, 35);
            tbFriendlyName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tbFriendlyName.Name = "tbFriendlyName";
            tbFriendlyName.Size = new System.Drawing.Size(312, 23);
            tbFriendlyName.TabIndex = 1;
            // 
            // lblFriendlyName
            // 
            lblFriendlyName.AutoSize = true;
            lblFriendlyName.Location = new System.Drawing.Point(14, 10);
            lblFriendlyName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblFriendlyName.Name = "lblFriendlyName";
            lblFriendlyName.Size = new System.Drawing.Size(82, 15);
            lblFriendlyName.TabIndex = 0;
            lblFriendlyName.Text = "Friendly name";
            // 
            // IOPortEditor
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(341, 167);
            Controls.Add(pMain);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "IOPortEditor";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Change I/O port settings";
            pMain.ResumeLayout(false);
            pMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudMinTriggerTime).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudMaxSignalPerDay).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pMain;
        private System.Windows.Forms.Label lblMs;
        private System.Windows.Forms.NumericUpDown nudMinTriggerTime;
        private System.Windows.Forms.Label lblMinTriggerTime;
        private System.Windows.Forms.NumericUpDown nudMaxSignalPerDay;
        private System.Windows.Forms.Label lblMaxSignalPerDay;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox tbFriendlyName;
        private System.Windows.Forms.Label lblFriendlyName;
    }
}