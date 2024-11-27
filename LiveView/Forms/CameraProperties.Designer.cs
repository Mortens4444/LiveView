namespace LiveView.Forms
{
    partial class CameraProperties
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(CameraProperties));
            p_Main = new System.Windows.Forms.Panel();
            gb_Properties = new System.Windows.Forms.GroupBox();
            tb_HttpStream = new System.Windows.Forms.TextBox();
            lbl_HttpStream = new System.Windows.Forms.Label();
            cb_PatternName = new System.Windows.Forms.ComboBox();
            nud_PatternNumber = new System.Windows.Forms.NumericUpDown();
            lbl_PatternNumberAndName = new System.Windows.Forms.Label();
            cb_PresetName = new System.Windows.Forms.ComboBox();
            nud_PresetNumber = new System.Windows.Forms.NumericUpDown();
            lbl_PresetNumberAndName = new System.Windows.Forms.Label();
            cb_FullscreenMode = new System.Windows.Forms.ComboBox();
            lbl_FullscreenMode = new System.Windows.Forms.Label();
            nud_StreamID = new System.Windows.Forms.NumericUpDown();
            lbl_StreamID = new System.Windows.Forms.Label();
            tb_CameraPassword = new Mtf.Controls.PasswordBox();
            lbl_CameraPassword = new System.Windows.Forms.Label();
            tb_CameraUsername = new System.Windows.Forms.TextBox();
            lbl_CameraUsername = new System.Windows.Forms.Label();
            btn_Close = new System.Windows.Forms.Button();
            btn_Save = new System.Windows.Forms.Button();
            lbl_CameraName = new System.Windows.Forms.Label();
            tb_CameraIPAddress = new System.Windows.Forms.TextBox();
            lbl_Name = new System.Windows.Forms.Label();
            lbl_CameraIPAddress = new System.Windows.Forms.Label();
            lbl_CameraGUID = new System.Windows.Forms.Label();
            lbl_GUID = new System.Windows.Forms.Label();
            p_Main.SuspendLayout();
            gb_Properties.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nud_PatternNumber).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_PresetNumber).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_StreamID).BeginInit();
            SuspendLayout();
            // 
            // p_Main
            // 
            p_Main.Controls.Add(gb_Properties);
            p_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            p_Main.Location = new System.Drawing.Point(0, 0);
            p_Main.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            p_Main.Name = "p_Main";
            p_Main.Size = new System.Drawing.Size(348, 321);
            p_Main.TabIndex = 1;
            // 
            // gb_Properties
            // 
            gb_Properties.Controls.Add(tb_HttpStream);
            gb_Properties.Controls.Add(lbl_HttpStream);
            gb_Properties.Controls.Add(cb_PatternName);
            gb_Properties.Controls.Add(nud_PatternNumber);
            gb_Properties.Controls.Add(lbl_PatternNumberAndName);
            gb_Properties.Controls.Add(cb_PresetName);
            gb_Properties.Controls.Add(nud_PresetNumber);
            gb_Properties.Controls.Add(lbl_PresetNumberAndName);
            gb_Properties.Controls.Add(cb_FullscreenMode);
            gb_Properties.Controls.Add(lbl_FullscreenMode);
            gb_Properties.Controls.Add(nud_StreamID);
            gb_Properties.Controls.Add(lbl_StreamID);
            gb_Properties.Controls.Add(tb_CameraPassword);
            gb_Properties.Controls.Add(lbl_CameraPassword);
            gb_Properties.Controls.Add(tb_CameraUsername);
            gb_Properties.Controls.Add(lbl_CameraUsername);
            gb_Properties.Controls.Add(btn_Close);
            gb_Properties.Controls.Add(btn_Save);
            gb_Properties.Controls.Add(lbl_CameraName);
            gb_Properties.Controls.Add(tb_CameraIPAddress);
            gb_Properties.Controls.Add(lbl_Name);
            gb_Properties.Controls.Add(lbl_CameraIPAddress);
            gb_Properties.Controls.Add(lbl_CameraGUID);
            gb_Properties.Controls.Add(lbl_GUID);
            gb_Properties.Dock = System.Windows.Forms.DockStyle.Fill;
            gb_Properties.Location = new System.Drawing.Point(0, 0);
            gb_Properties.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gb_Properties.Name = "gb_Properties";
            gb_Properties.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gb_Properties.Size = new System.Drawing.Size(348, 321);
            gb_Properties.TabIndex = 0;
            gb_Properties.TabStop = false;
            // 
            // tb_HttpStream
            // 
            tb_HttpStream.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tb_HttpStream.Location = new System.Drawing.Point(152, 193);
            tb_HttpStream.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tb_HttpStream.MaxLength = 200;
            tb_HttpStream.Name = "tb_HttpStream";
            tb_HttpStream.Size = new System.Drawing.Size(181, 23);
            tb_HttpStream.TabIndex = 15;
            // 
            // lbl_HttpStream
            // 
            lbl_HttpStream.AutoSize = true;
            lbl_HttpStream.Location = new System.Drawing.Point(7, 196);
            lbl_HttpStream.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_HttpStream.Name = "lbl_HttpStream";
            lbl_HttpStream.Size = new System.Drawing.Size(70, 15);
            lbl_HttpStream.TabIndex = 14;
            lbl_HttpStream.Text = "Http stream";
            // 
            // cb_PatternName
            // 
            cb_PatternName.FormattingEnabled = true;
            cb_PatternName.Location = new System.Drawing.Point(203, 253);
            cb_PatternName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cb_PatternName.MaxLength = 50;
            cb_PatternName.Name = "cb_PatternName";
            cb_PatternName.Size = new System.Drawing.Size(130, 23);
            cb_PatternName.TabIndex = 21;
            // 
            // nud_PatternNumber
            // 
            nud_PatternNumber.Location = new System.Drawing.Point(152, 254);
            nud_PatternNumber.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            nud_PatternNumber.Maximum = new decimal(new int[] { 15, 0, 0, 0 });
            nud_PatternNumber.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nud_PatternNumber.Name = "nud_PatternNumber";
            nud_PatternNumber.Size = new System.Drawing.Size(44, 23);
            nud_PatternNumber.TabIndex = 20;
            nud_PatternNumber.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lbl_PatternNumberAndName
            // 
            lbl_PatternNumberAndName.AutoSize = true;
            lbl_PatternNumberAndName.Location = new System.Drawing.Point(7, 256);
            lbl_PatternNumberAndName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_PatternNumberAndName.Name = "lbl_PatternNumberAndName";
            lbl_PatternNumberAndName.Size = new System.Drawing.Size(126, 15);
            lbl_PatternNumberAndName.TabIndex = 19;
            lbl_PatternNumberAndName.Text = "Pattern number, name";
            // 
            // cb_PresetName
            // 
            cb_PresetName.FormattingEnabled = true;
            cb_PresetName.Location = new System.Drawing.Point(203, 227);
            cb_PresetName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cb_PresetName.MaxLength = 50;
            cb_PresetName.Name = "cb_PresetName";
            cb_PresetName.Size = new System.Drawing.Size(130, 23);
            cb_PresetName.TabIndex = 18;
            // 
            // nud_PresetNumber
            // 
            nud_PresetNumber.Location = new System.Drawing.Point(152, 228);
            nud_PresetNumber.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            nud_PresetNumber.Maximum = new decimal(new int[] { 99, 0, 0, 0 });
            nud_PresetNumber.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nud_PresetNumber.Name = "nud_PresetNumber";
            nud_PresetNumber.Size = new System.Drawing.Size(44, 23);
            nud_PresetNumber.TabIndex = 17;
            nud_PresetNumber.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lbl_PresetNumberAndName
            // 
            lbl_PresetNumberAndName.AutoSize = true;
            lbl_PresetNumberAndName.Location = new System.Drawing.Point(7, 231);
            lbl_PresetNumberAndName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_PresetNumberAndName.Name = "lbl_PresetNumberAndName";
            lbl_PresetNumberAndName.Size = new System.Drawing.Size(120, 15);
            lbl_PresetNumberAndName.TabIndex = 16;
            lbl_PresetNumberAndName.Text = "Preset number, name";
            // 
            // cb_FullscreenMode
            // 
            cb_FullscreenMode.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            cb_FullscreenMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cb_FullscreenMode.FormattingEnabled = true;
            cb_FullscreenMode.Location = new System.Drawing.Point(152, 167);
            cb_FullscreenMode.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cb_FullscreenMode.Name = "cb_FullscreenMode";
            cb_FullscreenMode.Size = new System.Drawing.Size(181, 23);
            cb_FullscreenMode.TabIndex = 13;
            // 
            // lbl_FullscreenMode
            // 
            lbl_FullscreenMode.AutoSize = true;
            lbl_FullscreenMode.Location = new System.Drawing.Point(7, 171);
            lbl_FullscreenMode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_FullscreenMode.Name = "lbl_FullscreenMode";
            lbl_FullscreenMode.Size = new System.Drawing.Size(94, 15);
            lbl_FullscreenMode.TabIndex = 12;
            lbl_FullscreenMode.Text = "Fullscreen mode";
            // 
            // nud_StreamID
            // 
            nud_StreamID.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            nud_StreamID.Location = new System.Drawing.Point(152, 143);
            nud_StreamID.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            nud_StreamID.Name = "nud_StreamID";
            nud_StreamID.Size = new System.Drawing.Size(182, 23);
            nud_StreamID.TabIndex = 11;
            nud_StreamID.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lbl_StreamID
            // 
            lbl_StreamID.AutoSize = true;
            lbl_StreamID.Location = new System.Drawing.Point(7, 145);
            lbl_StreamID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_StreamID.Name = "lbl_StreamID";
            lbl_StreamID.Size = new System.Drawing.Size(58, 15);
            lbl_StreamID.TabIndex = 10;
            lbl_StreamID.Text = "Stream ID";
            // 
            // tb_CameraPassword
            // 
            tb_CameraPassword.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tb_CameraPassword.Location = new System.Drawing.Point(152, 117);
            tb_CameraPassword.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tb_CameraPassword.MaxLength = 200;
            tb_CameraPassword.Name = "tb_CameraPassword";
            tb_CameraPassword.Password = "";
            tb_CameraPassword.PasswordChar = '*';
            tb_CameraPassword.ShowRealPasswordLength = false;
            tb_CameraPassword.Size = new System.Drawing.Size(181, 23);
            tb_CameraPassword.TabIndex = 9;
            // 
            // lbl_CameraPassword
            // 
            lbl_CameraPassword.AutoSize = true;
            lbl_CameraPassword.Location = new System.Drawing.Point(7, 120);
            lbl_CameraPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_CameraPassword.Name = "lbl_CameraPassword";
            lbl_CameraPassword.Size = new System.Drawing.Size(101, 15);
            lbl_CameraPassword.TabIndex = 8;
            lbl_CameraPassword.Text = "Camera password";
            // 
            // tb_CameraUsername
            // 
            tb_CameraUsername.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tb_CameraUsername.Location = new System.Drawing.Point(152, 91);
            tb_CameraUsername.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tb_CameraUsername.MaxLength = 200;
            tb_CameraUsername.Name = "tb_CameraUsername";
            tb_CameraUsername.Size = new System.Drawing.Size(181, 23);
            tb_CameraUsername.TabIndex = 7;
            // 
            // lbl_CameraUsername
            // 
            lbl_CameraUsername.AutoSize = true;
            lbl_CameraUsername.Location = new System.Drawing.Point(7, 95);
            lbl_CameraUsername.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_CameraUsername.Name = "lbl_CameraUsername";
            lbl_CameraUsername.Size = new System.Drawing.Size(103, 15);
            lbl_CameraUsername.TabIndex = 6;
            lbl_CameraUsername.Text = "Camera username";
            // 
            // btn_Close
            // 
            btn_Close.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btn_Close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            btn_Close.Location = new System.Drawing.Point(246, 287);
            btn_Close.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_Close.Name = "btn_Close";
            btn_Close.Size = new System.Drawing.Size(88, 27);
            btn_Close.TabIndex = 23;
            btn_Close.Text = "Close";
            btn_Close.UseVisualStyleBackColor = true;
            btn_Close.Click += Btn_Close_Click;
            // 
            // btn_Save
            // 
            btn_Save.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btn_Save.Location = new System.Drawing.Point(152, 287);
            btn_Save.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_Save.Name = "btn_Save";
            btn_Save.Size = new System.Drawing.Size(88, 27);
            btn_Save.TabIndex = 22;
            btn_Save.Text = "Save";
            btn_Save.UseVisualStyleBackColor = true;
            btn_Save.Click += Btn_Save_Click;
            // 
            // lbl_CameraName
            // 
            lbl_CameraName.AutoSize = true;
            lbl_CameraName.Location = new System.Drawing.Point(7, 18);
            lbl_CameraName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_CameraName.Name = "lbl_CameraName";
            lbl_CameraName.Size = new System.Drawing.Size(81, 15);
            lbl_CameraName.TabIndex = 0;
            lbl_CameraName.Text = "Camera name";
            // 
            // tb_CameraIPAddress
            // 
            tb_CameraIPAddress.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tb_CameraIPAddress.Location = new System.Drawing.Point(152, 66);
            tb_CameraIPAddress.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tb_CameraIPAddress.MaxLength = 200;
            tb_CameraIPAddress.Name = "tb_CameraIPAddress";
            tb_CameraIPAddress.Size = new System.Drawing.Size(181, 23);
            tb_CameraIPAddress.TabIndex = 5;
            // 
            // lbl_Name
            // 
            lbl_Name.AutoSize = true;
            lbl_Name.Location = new System.Drawing.Point(148, 18);
            lbl_Name.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_Name.Name = "lbl_Name";
            lbl_Name.Size = new System.Drawing.Size(0, 15);
            lbl_Name.TabIndex = 1;
            // 
            // lbl_CameraIPAddress
            // 
            lbl_CameraIPAddress.AutoSize = true;
            lbl_CameraIPAddress.Location = new System.Drawing.Point(7, 69);
            lbl_CameraIPAddress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_CameraIPAddress.Name = "lbl_CameraIPAddress";
            lbl_CameraIPAddress.Size = new System.Drawing.Size(104, 15);
            lbl_CameraIPAddress.TabIndex = 4;
            lbl_CameraIPAddress.Text = "Camera IP address";
            // 
            // lbl_CameraGUID
            // 
            lbl_CameraGUID.AutoSize = true;
            lbl_CameraGUID.Location = new System.Drawing.Point(7, 44);
            lbl_CameraGUID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_CameraGUID.Name = "lbl_CameraGUID";
            lbl_CameraGUID.Size = new System.Drawing.Size(78, 15);
            lbl_CameraGUID.TabIndex = 2;
            lbl_CameraGUID.Text = "Camera GUID";
            // 
            // lbl_GUID
            // 
            lbl_GUID.AutoSize = true;
            lbl_GUID.Location = new System.Drawing.Point(148, 44);
            lbl_GUID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_GUID.Name = "lbl_GUID";
            lbl_GUID.Size = new System.Drawing.Size(0, 15);
            lbl_GUID.TabIndex = 3;
            // 
            // CameraProperties
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(348, 321);
            Controls.Add(p_Main);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "CameraProperties";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Camera properties";
            p_Main.ResumeLayout(false);
            gb_Properties.ResumeLayout(false);
            gb_Properties.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nud_PatternNumber).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_PresetNumber).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_StreamID).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel p_Main;
        private System.Windows.Forms.GroupBox gb_Properties;
        private System.Windows.Forms.TextBox tb_HttpStream;
        private System.Windows.Forms.Label lbl_HttpStream;
        private System.Windows.Forms.ComboBox cb_PatternName;
        private System.Windows.Forms.NumericUpDown nud_PatternNumber;
        private System.Windows.Forms.Label lbl_PatternNumberAndName;
        private System.Windows.Forms.ComboBox cb_PresetName;
        private System.Windows.Forms.NumericUpDown nud_PresetNumber;
        private System.Windows.Forms.Label lbl_PresetNumberAndName;
        private System.Windows.Forms.ComboBox cb_FullscreenMode;
        private System.Windows.Forms.Label lbl_FullscreenMode;
        private System.Windows.Forms.NumericUpDown nud_StreamID;
        private System.Windows.Forms.Label lbl_StreamID;
        private Mtf.Controls.PasswordBox tb_CameraPassword;
        private System.Windows.Forms.Label lbl_CameraPassword;
        private System.Windows.Forms.TextBox tb_CameraUsername;
        private System.Windows.Forms.Label lbl_CameraUsername;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Label lbl_CameraName;
        private System.Windows.Forms.TextBox tb_CameraIPAddress;
        private System.Windows.Forms.Label lbl_Name;
        private System.Windows.Forms.Label lbl_CameraIPAddress;
        private System.Windows.Forms.Label lbl_CameraGUID;
        private System.Windows.Forms.Label lbl_GUID;
    }
}