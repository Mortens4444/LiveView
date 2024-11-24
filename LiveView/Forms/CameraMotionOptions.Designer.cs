namespace LiveView.Forms
{
    partial class CameraMotionOptions
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(CameraMotionOptions));
            lbl_MotionSensitiveness = new System.Windows.Forms.Label();
            btn_Change = new System.Windows.Forms.Button();
            p_Cameras = new System.Windows.Forms.Panel();
            gb_Cameras = new System.Windows.Forms.GroupBox();
            lv_Cameras = new Mtf.Controls.MtfListView();
            ch_0_VideoServer = new System.Windows.Forms.ColumnHeader();
            ch_1_Camera = new System.Windows.Forms.ColumnHeader();
            ch_2_MotionTrigger = new System.Windows.Forms.ColumnHeader();
            ch_3_MotionTriggerMinimumLength = new System.Windows.Forms.ColumnHeader();
            ch_4_PartnerCamera = new System.Windows.Forms.ColumnHeader();
            cms_ContextMenu = new System.Windows.Forms.ContextMenuStrip(components);
            tsmi_ClearValues = new System.Windows.Forms.ToolStripMenuItem();
            cb_PartnerServerID = new System.Windows.Forms.ComboBox();
            lbl_PartnerVideoServer = new System.Windows.Forms.Label();
            cb_PartnerVideoServer = new System.Windows.Forms.ComboBox();
            cb_PartnerCameraID = new System.Windows.Forms.ComboBox();
            cb_PartnerCamera = new System.Windows.Forms.ComboBox();
            lbl_PartnerCamera = new System.Windows.Forms.Label();
            lbl_MotionTriggerMinimumLength = new System.Windows.Forms.Label();
            nud_MotionTriggerMinimumLength = new System.Windows.Forms.NumericUpDown();
            gb_CameraOptions = new System.Windows.Forms.GroupBox();
            nud_MotionTrigger = new System.Windows.Forms.NumericUpDown();
            p_Settings = new System.Windows.Forms.Panel();
            p_Main = new System.Windows.Forms.Panel();
            p_Cameras.SuspendLayout();
            gb_Cameras.SuspendLayout();
            cms_ContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nud_MotionTriggerMinimumLength).BeginInit();
            gb_CameraOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nud_MotionTrigger).BeginInit();
            p_Settings.SuspendLayout();
            p_Main.SuspendLayout();
            SuspendLayout();
            // 
            // lbl_MotionSensitiveness
            // 
            lbl_MotionSensitiveness.AutoSize = true;
            lbl_MotionSensitiveness.Location = new System.Drawing.Point(7, 22);
            lbl_MotionSensitiveness.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_MotionSensitiveness.Name = "lbl_MotionSensitiveness";
            lbl_MotionSensitiveness.Size = new System.Drawing.Size(117, 15);
            lbl_MotionSensitiveness.TabIndex = 2;
            lbl_MotionSensitiveness.Text = "Motion sensitiveness";
            // 
            // btn_Change
            // 
            btn_Change.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btn_Change.Enabled = false;
            btn_Change.Location = new System.Drawing.Point(827, 16);
            btn_Change.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_Change.Name = "btn_Change";
            btn_Change.Size = new System.Drawing.Size(88, 27);
            btn_Change.TabIndex = 0;
            btn_Change.Text = "Change";
            btn_Change.UseVisualStyleBackColor = true;
            // 
            // p_Cameras
            // 
            p_Cameras.Controls.Add(gb_Cameras);
            p_Cameras.Dock = System.Windows.Forms.DockStyle.Fill;
            p_Cameras.Location = new System.Drawing.Point(0, 84);
            p_Cameras.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            p_Cameras.Name = "p_Cameras";
            p_Cameras.Size = new System.Drawing.Size(918, 390);
            p_Cameras.TabIndex = 1;
            // 
            // gb_Cameras
            // 
            gb_Cameras.Controls.Add(lv_Cameras);
            gb_Cameras.Dock = System.Windows.Forms.DockStyle.Fill;
            gb_Cameras.Location = new System.Drawing.Point(0, 0);
            gb_Cameras.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gb_Cameras.Name = "gb_Cameras";
            gb_Cameras.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gb_Cameras.Size = new System.Drawing.Size(918, 390);
            gb_Cameras.TabIndex = 1;
            gb_Cameras.TabStop = false;
            gb_Cameras.Text = "Cameras";
            // 
            // lv_Cameras
            // 
            lv_Cameras.AlternatingColorEven = System.Drawing.Color.LightBlue;
            lv_Cameras.AlternatingColorOdd = System.Drawing.SystemColors.Window;
            lv_Cameras.AlternatingColorsAreInUse = true;
            lv_Cameras.AlternatingPairColorEven = System.Drawing.Color.LightSeaGreen;
            lv_Cameras.AlternatingPairColorOdd = System.Drawing.Color.CadetBlue;
            lv_Cameras.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { ch_0_VideoServer, ch_1_Camera, ch_2_MotionTrigger, ch_3_MotionTriggerMinimumLength, ch_4_PartnerCamera });
            lv_Cameras.CompactView = false;
            lv_Cameras.ContextMenuStrip = cms_ContextMenu;
            lv_Cameras.Dock = System.Windows.Forms.DockStyle.Fill;
            lv_Cameras.EnsureLastItemIsVisible = false;
            lv_Cameras.FirstItemIsGray = false;
            lv_Cameras.FullRowSelect = true;
            lv_Cameras.Location = new System.Drawing.Point(4, 19);
            lv_Cameras.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            lv_Cameras.Name = "lv_Cameras";
            lv_Cameras.OwnerDraw = true;
            lv_Cameras.ReadonlyCheckboxes = false;
            lv_Cameras.SameItemsColorEven = System.Drawing.Color.DarkOrange;
            lv_Cameras.SameItemsColorOdd = System.Drawing.Color.LightSalmon;
            lv_Cameras.Size = new System.Drawing.Size(910, 368);
            lv_Cameras.TabIndex = 0;
            lv_Cameras.UseCompatibleStateImageBehavior = false;
            lv_Cameras.View = System.Windows.Forms.View.Details;
            // 
            // ch_0_VideoServer
            // 
            ch_0_VideoServer.Text = "Video server";
            ch_0_VideoServer.Width = 165;
            // 
            // ch_1_Camera
            // 
            ch_1_Camera.Text = "Camera";
            ch_1_Camera.Width = 118;
            // 
            // ch_2_MotionTrigger
            // 
            ch_2_MotionTrigger.Text = "MotionTrigger";
            ch_2_MotionTrigger.Width = 84;
            // 
            // ch_3_MotionTriggerMinimumLength
            // 
            ch_3_MotionTriggerMinimumLength.Text = "Motion trigger minimum length (seconds)";
            ch_3_MotionTriggerMinimumLength.Width = 206;
            // 
            // ch_4_PartnerCamera
            // 
            ch_4_PartnerCamera.Text = "Partner camera";
            ch_4_PartnerCamera.Width = 149;
            // 
            // cms_ContextMenu
            // 
            cms_ContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { tsmi_ClearValues });
            cms_ContextMenu.Name = "cms_ContextMenu";
            cms_ContextMenu.Size = new System.Drawing.Size(102, 26);
            // 
            // tsmi_ClearValues
            // 
            tsmi_ClearValues.Name = "tsmi_ClearValues";
            tsmi_ClearValues.Size = new System.Drawing.Size(101, 22);
            tsmi_ClearValues.Text = "Clear";
            // 
            // cb_PartnerServerID
            // 
            cb_PartnerServerID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cb_PartnerServerID.FormattingEnabled = true;
            cb_PartnerServerID.Location = new System.Drawing.Point(144, 52);
            cb_PartnerServerID.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cb_PartnerServerID.Name = "cb_PartnerServerID";
            cb_PartnerServerID.Size = new System.Drawing.Size(35, 23);
            cb_PartnerServerID.TabIndex = 10;
            cb_PartnerServerID.Visible = false;
            // 
            // lbl_PartnerVideoServer
            // 
            lbl_PartnerVideoServer.AutoSize = true;
            lbl_PartnerVideoServer.Location = new System.Drawing.Point(7, 55);
            lbl_PartnerVideoServer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_PartnerVideoServer.Name = "lbl_PartnerVideoServer";
            lbl_PartnerVideoServer.Size = new System.Drawing.Size(111, 15);
            lbl_PartnerVideoServer.TabIndex = 9;
            lbl_PartnerVideoServer.Text = "Partner video server";
            // 
            // cb_PartnerVideoServer
            // 
            cb_PartnerVideoServer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cb_PartnerVideoServer.FormattingEnabled = true;
            cb_PartnerVideoServer.Location = new System.Drawing.Point(144, 52);
            cb_PartnerVideoServer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cb_PartnerVideoServer.Name = "cb_PartnerVideoServer";
            cb_PartnerVideoServer.Size = new System.Drawing.Size(284, 23);
            cb_PartnerVideoServer.TabIndex = 8;
            // 
            // cb_PartnerCameraID
            // 
            cb_PartnerCameraID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cb_PartnerCameraID.FormattingEnabled = true;
            cb_PartnerCameraID.Location = new System.Drawing.Point(534, 52);
            cb_PartnerCameraID.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cb_PartnerCameraID.Name = "cb_PartnerCameraID";
            cb_PartnerCameraID.Size = new System.Drawing.Size(35, 23);
            cb_PartnerCameraID.TabIndex = 7;
            cb_PartnerCameraID.Visible = false;
            // 
            // cb_PartnerCamera
            // 
            cb_PartnerCamera.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            cb_PartnerCamera.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cb_PartnerCamera.FormattingEnabled = true;
            cb_PartnerCamera.Location = new System.Drawing.Point(534, 52);
            cb_PartnerCamera.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cb_PartnerCamera.Name = "cb_PartnerCamera";
            cb_PartnerCamera.Size = new System.Drawing.Size(160, 23);
            cb_PartnerCamera.TabIndex = 6;
            // 
            // lbl_PartnerCamera
            // 
            lbl_PartnerCamera.AutoSize = true;
            lbl_PartnerCamera.Location = new System.Drawing.Point(435, 55);
            lbl_PartnerCamera.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_PartnerCamera.Name = "lbl_PartnerCamera";
            lbl_PartnerCamera.Size = new System.Drawing.Size(87, 15);
            lbl_PartnerCamera.TabIndex = 5;
            lbl_PartnerCamera.Text = "Partner camera";
            // 
            // lbl_MotionTriggerMinimumLength
            // 
            lbl_MotionTriggerMinimumLength.AutoSize = true;
            lbl_MotionTriggerMinimumLength.Location = new System.Drawing.Point(410, 22);
            lbl_MotionTriggerMinimumLength.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_MotionTriggerMinimumLength.Name = "lbl_MotionTriggerMinimumLength";
            lbl_MotionTriggerMinimumLength.Size = new System.Drawing.Size(231, 15);
            lbl_MotionTriggerMinimumLength.TabIndex = 4;
            lbl_MotionTriggerMinimumLength.Text = "Motion trigger minimum length (seconds)";
            // 
            // nud_MotionTriggerMinimumLength
            // 
            nud_MotionTriggerMinimumLength.Location = new System.Drawing.Point(644, 20);
            nud_MotionTriggerMinimumLength.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            nud_MotionTriggerMinimumLength.Maximum = new decimal(new int[] { 6000, 0, 0, 0 });
            nud_MotionTriggerMinimumLength.Name = "nud_MotionTriggerMinimumLength";
            nud_MotionTriggerMinimumLength.Size = new System.Drawing.Size(51, 23);
            nud_MotionTriggerMinimumLength.TabIndex = 3;
            // 
            // gb_CameraOptions
            // 
            gb_CameraOptions.Controls.Add(cb_PartnerServerID);
            gb_CameraOptions.Controls.Add(lbl_PartnerVideoServer);
            gb_CameraOptions.Controls.Add(cb_PartnerVideoServer);
            gb_CameraOptions.Controls.Add(cb_PartnerCameraID);
            gb_CameraOptions.Controls.Add(cb_PartnerCamera);
            gb_CameraOptions.Controls.Add(lbl_PartnerCamera);
            gb_CameraOptions.Controls.Add(lbl_MotionTriggerMinimumLength);
            gb_CameraOptions.Controls.Add(nud_MotionTriggerMinimumLength);
            gb_CameraOptions.Controls.Add(lbl_MotionSensitiveness);
            gb_CameraOptions.Controls.Add(nud_MotionTrigger);
            gb_CameraOptions.Controls.Add(btn_Change);
            gb_CameraOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            gb_CameraOptions.Location = new System.Drawing.Point(0, 0);
            gb_CameraOptions.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gb_CameraOptions.Name = "gb_CameraOptions";
            gb_CameraOptions.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gb_CameraOptions.Size = new System.Drawing.Size(918, 84);
            gb_CameraOptions.TabIndex = 0;
            gb_CameraOptions.TabStop = false;
            gb_CameraOptions.Text = "Camera options";
            // 
            // nud_MotionTrigger
            // 
            nud_MotionTrigger.Location = new System.Drawing.Point(144, 20);
            nud_MotionTrigger.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            nud_MotionTrigger.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            nud_MotionTrigger.Name = "nud_MotionTrigger";
            nud_MotionTrigger.Size = new System.Drawing.Size(51, 23);
            nud_MotionTrigger.TabIndex = 1;
            nud_MotionTrigger.Value = new decimal(new int[] { 50, 0, 0, 0 });
            // 
            // p_Settings
            // 
            p_Settings.Controls.Add(gb_CameraOptions);
            p_Settings.Dock = System.Windows.Forms.DockStyle.Top;
            p_Settings.Location = new System.Drawing.Point(0, 0);
            p_Settings.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            p_Settings.Name = "p_Settings";
            p_Settings.Size = new System.Drawing.Size(918, 84);
            p_Settings.TabIndex = 0;
            // 
            // p_Main
            // 
            p_Main.Controls.Add(p_Cameras);
            p_Main.Controls.Add(p_Settings);
            p_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            p_Main.Location = new System.Drawing.Point(0, 0);
            p_Main.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            p_Main.Name = "p_Main";
            p_Main.Size = new System.Drawing.Size(918, 474);
            p_Main.TabIndex = 1;
            // 
            // CameraMotionOptions
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(918, 474);
            Controls.Add(p_Main);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "CameraMotionOptions";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Camera motion options";
            p_Cameras.ResumeLayout(false);
            gb_Cameras.ResumeLayout(false);
            cms_ContextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)nud_MotionTriggerMinimumLength).EndInit();
            gb_CameraOptions.ResumeLayout(false);
            gb_CameraOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nud_MotionTrigger).EndInit();
            p_Settings.ResumeLayout(false);
            p_Main.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lbl_MotionSensitiveness;
        private System.Windows.Forms.Button btn_Change;
        private System.Windows.Forms.Panel p_Cameras;
        private System.Windows.Forms.GroupBox gb_Cameras;
        private Mtf.Controls.MtfListView lv_Cameras;
        private System.Windows.Forms.ColumnHeader ch_0_VideoServer;
        private System.Windows.Forms.ColumnHeader ch_1_Camera;
        private System.Windows.Forms.ColumnHeader ch_2_MotionTrigger;
        private System.Windows.Forms.ColumnHeader ch_3_MotionTriggerMinimumLength;
        private System.Windows.Forms.ColumnHeader ch_4_PartnerCamera;
        private System.Windows.Forms.ContextMenuStrip cms_ContextMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmi_ClearValues;
        private System.Windows.Forms.ComboBox cb_PartnerServerID;
        private System.Windows.Forms.Label lbl_PartnerVideoServer;
        private System.Windows.Forms.ComboBox cb_PartnerVideoServer;
        private System.Windows.Forms.ComboBox cb_PartnerCameraID;
        private System.Windows.Forms.ComboBox cb_PartnerCamera;
        private System.Windows.Forms.Label lbl_PartnerCamera;
        private System.Windows.Forms.Label lbl_MotionTriggerMinimumLength;
        private System.Windows.Forms.NumericUpDown nud_MotionTriggerMinimumLength;
        private System.Windows.Forms.GroupBox gb_CameraOptions;
        private System.Windows.Forms.NumericUpDown nud_MotionTrigger;
        private System.Windows.Forms.Panel p_Settings;
        private System.Windows.Forms.Panel p_Main;
    }
}