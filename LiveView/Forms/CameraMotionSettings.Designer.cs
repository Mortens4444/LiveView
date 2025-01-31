namespace LiveView.Forms
{
    partial class CameraMotionSettings
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
            lblMotionSensitiveness = new System.Windows.Forms.Label();
            btnChange = new System.Windows.Forms.Button();
            pCameras = new System.Windows.Forms.Panel();
            gbCameras = new System.Windows.Forms.GroupBox();
            lvCameras = new Mtf.Controls.MtfListView();
            chVideoServer = new System.Windows.Forms.ColumnHeader();
            chCamera = new System.Windows.Forms.ColumnHeader();
            chMotionTrigger = new System.Windows.Forms.ColumnHeader();
            chMotionTriggerMinimumLength = new System.Windows.Forms.ColumnHeader();
            chPartnerCamera = new System.Windows.Forms.ColumnHeader();
            cmsContextMenu = new System.Windows.Forms.ContextMenuStrip(components);
            tsmiClearValues = new System.Windows.Forms.ToolStripMenuItem();
            lblPartnerVideoServer = new System.Windows.Forms.Label();
            cbPartnerVideoServer = new System.Windows.Forms.ComboBox();
            cbPartnerCamera = new System.Windows.Forms.ComboBox();
            lblPartnerCamera = new System.Windows.Forms.Label();
            lblMotionTriggerMinimumLength = new System.Windows.Forms.Label();
            nudMotionTriggerMinimumLength = new System.Windows.Forms.NumericUpDown();
            gbCameraOptions = new System.Windows.Forms.GroupBox();
            nudMotionTrigger = new System.Windows.Forms.NumericUpDown();
            pSettings = new System.Windows.Forms.Panel();
            pMain = new System.Windows.Forms.Panel();
            pCameras.SuspendLayout();
            gbCameras.SuspendLayout();
            cmsContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudMotionTriggerMinimumLength).BeginInit();
            gbCameraOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudMotionTrigger).BeginInit();
            pSettings.SuspendLayout();
            pMain.SuspendLayout();
            SuspendLayout();
            // 
            // lblMotionSensitiveness
            // 
            lblMotionSensitiveness.AutoSize = true;
            lblMotionSensitiveness.Location = new System.Drawing.Point(7, 22);
            lblMotionSensitiveness.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblMotionSensitiveness.Name = "lblMotionSensitiveness";
            lblMotionSensitiveness.Size = new System.Drawing.Size(117, 15);
            lblMotionSensitiveness.TabIndex = 2;
            lblMotionSensitiveness.Text = "Motion sensitiveness";
            // 
            // btnChange
            // 
            btnChange.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnChange.Enabled = false;
            btnChange.Location = new System.Drawing.Point(831, 16);
            btnChange.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnChange.Name = "btnChange";
            btnChange.Size = new System.Drawing.Size(88, 27);
            btnChange.TabIndex = 0;
            btnChange.Text = "Change";
            btnChange.UseVisualStyleBackColor = true;
            btnChange.Click += BtnChange_Click;
            // 
            // pCameras
            // 
            pCameras.Controls.Add(gbCameras);
            pCameras.Dock = System.Windows.Forms.DockStyle.Fill;
            pCameras.Location = new System.Drawing.Point(0, 84);
            pCameras.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pCameras.Name = "pCameras";
            pCameras.Size = new System.Drawing.Size(922, 390);
            pCameras.TabIndex = 1;
            // 
            // gbCameras
            // 
            gbCameras.Controls.Add(lvCameras);
            gbCameras.Dock = System.Windows.Forms.DockStyle.Fill;
            gbCameras.Location = new System.Drawing.Point(0, 0);
            gbCameras.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbCameras.Name = "gbCameras";
            gbCameras.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbCameras.Size = new System.Drawing.Size(922, 390);
            gbCameras.TabIndex = 1;
            gbCameras.TabStop = false;
            gbCameras.Text = "Cameras";
            // 
            // lvCameras
            // 
            lvCameras.AlternatingColorEven = System.Drawing.Color.LightBlue;
            lvCameras.AlternatingColorOdd = System.Drawing.SystemColors.Window;
            lvCameras.AlternatingColorsAreInUse = true;
            lvCameras.AlternatingPairColorEven = System.Drawing.Color.LightSeaGreen;
            lvCameras.AlternatingPairColorOdd = System.Drawing.Color.CadetBlue;
            lvCameras.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { chVideoServer, chCamera, chMotionTrigger, chMotionTriggerMinimumLength, chPartnerCamera });
            lvCameras.CompactView = false;
            lvCameras.ContextMenuStrip = cmsContextMenu;
            lvCameras.Dock = System.Windows.Forms.DockStyle.Fill;
            lvCameras.EnsureLastItemIsVisible = false;
            lvCameras.FirstItemIsGray = false;
            lvCameras.FullRowSelect = true;
            lvCameras.Location = new System.Drawing.Point(4, 19);
            lvCameras.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            lvCameras.Name = "lvCameras";
            lvCameras.OwnerDraw = true;
            lvCameras.ReadonlyCheckboxes = false;
            lvCameras.SameItemsColorEven = System.Drawing.Color.DarkOrange;
            lvCameras.SameItemsColorOdd = System.Drawing.Color.LightSalmon;
            lvCameras.Size = new System.Drawing.Size(914, 368);
            lvCameras.TabIndex = 0;
            lvCameras.UseCompatibleStateImageBehavior = false;
            lvCameras.View = System.Windows.Forms.View.Details;
            // 
            // chVideoServer
            // 
            chVideoServer.Text = "Video server";
            chVideoServer.Width = 165;
            // 
            // chCamera
            // 
            chCamera.Text = "Camera";
            chCamera.Width = 165;
            // 
            // chMotionTrigger
            // 
            chMotionTrigger.Text = "Motion trigger";
            chMotionTrigger.Width = 90;
            // 
            // chMotionTriggerMinimumLength
            // 
            chMotionTriggerMinimumLength.Text = "Motion trigger minimum length (seconds)";
            chMotionTriggerMinimumLength.Width = 240;
            // 
            // chPartnerCamera
            // 
            chPartnerCamera.Text = "Partner camera";
            chPartnerCamera.Width = 250;
            // 
            // cmsContextMenu
            // 
            cmsContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { tsmiClearValues });
            cmsContextMenu.Name = "cms_ContextMenu";
            cmsContextMenu.Size = new System.Drawing.Size(181, 48);
            // 
            // tsmiClearValues
            // 
            tsmiClearValues.Name = "tsmiClearValues";
            tsmiClearValues.Size = new System.Drawing.Size(180, 22);
            tsmiClearValues.Text = "Clear";
            tsmiClearValues.Click += TsmiClearValues_Click;
            // 
            // lblPartnerVideoServer
            // 
            lblPartnerVideoServer.AutoSize = true;
            lblPartnerVideoServer.Location = new System.Drawing.Point(7, 55);
            lblPartnerVideoServer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblPartnerVideoServer.Name = "lblPartnerVideoServer";
            lblPartnerVideoServer.Size = new System.Drawing.Size(111, 15);
            lblPartnerVideoServer.TabIndex = 9;
            lblPartnerVideoServer.Text = "Partner video server";
            // 
            // cbPartnerVideoServer
            // 
            cbPartnerVideoServer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbPartnerVideoServer.FormattingEnabled = true;
            cbPartnerVideoServer.Location = new System.Drawing.Point(144, 52);
            cbPartnerVideoServer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cbPartnerVideoServer.Name = "cbPartnerVideoServer";
            cbPartnerVideoServer.Size = new System.Drawing.Size(284, 23);
            cbPartnerVideoServer.TabIndex = 8;
            // 
            // cbPartnerCamera
            // 
            cbPartnerCamera.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            cbPartnerCamera.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbPartnerCamera.FormattingEnabled = true;
            cbPartnerCamera.Location = new System.Drawing.Point(534, 52);
            cbPartnerCamera.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cbPartnerCamera.Name = "cbPartnerCamera";
            cbPartnerCamera.Size = new System.Drawing.Size(164, 23);
            cbPartnerCamera.TabIndex = 6;
            // 
            // lblPartnerCamera
            // 
            lblPartnerCamera.AutoSize = true;
            lblPartnerCamera.Location = new System.Drawing.Point(435, 55);
            lblPartnerCamera.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblPartnerCamera.Name = "lblPartnerCamera";
            lblPartnerCamera.Size = new System.Drawing.Size(87, 15);
            lblPartnerCamera.TabIndex = 5;
            lblPartnerCamera.Text = "Partner camera";
            // 
            // lblMotionTriggerMinimumLength
            // 
            lblMotionTriggerMinimumLength.AutoSize = true;
            lblMotionTriggerMinimumLength.Location = new System.Drawing.Point(203, 22);
            lblMotionTriggerMinimumLength.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblMotionTriggerMinimumLength.Name = "lblMotionTriggerMinimumLength";
            lblMotionTriggerMinimumLength.Size = new System.Drawing.Size(231, 15);
            lblMotionTriggerMinimumLength.TabIndex = 4;
            lblMotionTriggerMinimumLength.Text = "Motion trigger minimum length (seconds)";
            // 
            // nudMotionTriggerMinimumLength
            // 
            nudMotionTriggerMinimumLength.Location = new System.Drawing.Point(471, 20);
            nudMotionTriggerMinimumLength.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            nudMotionTriggerMinimumLength.Maximum = new decimal(new int[] { 6000, 0, 0, 0 });
            nudMotionTriggerMinimumLength.Name = "nudMotionTriggerMinimumLength";
            nudMotionTriggerMinimumLength.Size = new System.Drawing.Size(51, 23);
            nudMotionTriggerMinimumLength.TabIndex = 3;
            // 
            // gbCameraOptions
            // 
            gbCameraOptions.Controls.Add(lblPartnerVideoServer);
            gbCameraOptions.Controls.Add(cbPartnerVideoServer);
            gbCameraOptions.Controls.Add(cbPartnerCamera);
            gbCameraOptions.Controls.Add(lblPartnerCamera);
            gbCameraOptions.Controls.Add(lblMotionTriggerMinimumLength);
            gbCameraOptions.Controls.Add(nudMotionTriggerMinimumLength);
            gbCameraOptions.Controls.Add(lblMotionSensitiveness);
            gbCameraOptions.Controls.Add(nudMotionTrigger);
            gbCameraOptions.Controls.Add(btnChange);
            gbCameraOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            gbCameraOptions.Location = new System.Drawing.Point(0, 0);
            gbCameraOptions.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbCameraOptions.Name = "gbCameraOptions";
            gbCameraOptions.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbCameraOptions.Size = new System.Drawing.Size(922, 84);
            gbCameraOptions.TabIndex = 0;
            gbCameraOptions.TabStop = false;
            gbCameraOptions.Text = "Camera options";
            // 
            // nudMotionTrigger
            // 
            nudMotionTrigger.Location = new System.Drawing.Point(144, 20);
            nudMotionTrigger.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            nudMotionTrigger.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            nudMotionTrigger.Name = "nudMotionTrigger";
            nudMotionTrigger.Size = new System.Drawing.Size(51, 23);
            nudMotionTrigger.TabIndex = 1;
            nudMotionTrigger.Value = new decimal(new int[] { 50, 0, 0, 0 });
            // 
            // pSettings
            // 
            pSettings.Controls.Add(gbCameraOptions);
            pSettings.Dock = System.Windows.Forms.DockStyle.Top;
            pSettings.Location = new System.Drawing.Point(0, 0);
            pSettings.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pSettings.Name = "pSettings";
            pSettings.Size = new System.Drawing.Size(922, 84);
            pSettings.TabIndex = 0;
            // 
            // pMain
            // 
            pMain.Controls.Add(pCameras);
            pMain.Controls.Add(pSettings);
            pMain.Dock = System.Windows.Forms.DockStyle.Fill;
            pMain.Location = new System.Drawing.Point(0, 0);
            pMain.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pMain.Name = "pMain";
            pMain.Size = new System.Drawing.Size(922, 474);
            pMain.TabIndex = 1;
            // 
            // CameraMotionSettings
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(922, 474);
            Controls.Add(pMain);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "CameraMotionSettings";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Camera motion options";
            Shown += CameraMotionOptions_Shown;
            pCameras.ResumeLayout(false);
            gbCameras.ResumeLayout(false);
            cmsContextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)nudMotionTriggerMinimumLength).EndInit();
            gbCameraOptions.ResumeLayout(false);
            gbCameraOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudMotionTrigger).EndInit();
            pSettings.ResumeLayout(false);
            pMain.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lblMotionSensitiveness;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.Panel pCameras;
        private System.Windows.Forms.GroupBox gbCameras;
        private Mtf.Controls.MtfListView lvCameras;
        private System.Windows.Forms.ColumnHeader chVideoServer;
        private System.Windows.Forms.ColumnHeader chCamera;
        private System.Windows.Forms.ColumnHeader chMotionTrigger;
        private System.Windows.Forms.ColumnHeader chMotionTriggerMinimumLength;
        private System.Windows.Forms.ColumnHeader chPartnerCamera;
        private System.Windows.Forms.ContextMenuStrip cmsContextMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmiClearValues;
        private System.Windows.Forms.Label lblPartnerVideoServer;
        private System.Windows.Forms.ComboBox cbPartnerVideoServer;
        private System.Windows.Forms.ComboBox cbPartnerCamera;
        private System.Windows.Forms.Label lblPartnerCamera;
        private System.Windows.Forms.Label lblMotionTriggerMinimumLength;
        private System.Windows.Forms.NumericUpDown nudMotionTriggerMinimumLength;
        private System.Windows.Forms.GroupBox gbCameraOptions;
        private System.Windows.Forms.NumericUpDown nudMotionTrigger;
        private System.Windows.Forms.Panel pSettings;
        private System.Windows.Forms.Panel pMain;
    }
}