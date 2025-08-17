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
            components = new System.ComponentModel.Container();
            pMain = new System.Windows.Forms.Panel();
            btnImport = new System.Windows.Forms.Button();
            btnExport = new System.Windows.Forms.Button();
            tabControl = new System.Windows.Forms.TabControl();
            tpGeneral = new System.Windows.Forms.TabPage();
            cbVideoSource = new System.Windows.Forms.ComboBox();
            lblVideoSource = new System.Windows.Forms.Label();
            lblCameraName = new System.Windows.Forms.Label();
            btnSearch = new System.Windows.Forms.Button();
            nudPatternNumber = new System.Windows.Forms.NumericUpDown();
            tbCameraPassword = new Mtf.Controls.PasswordBox();
            lblCameraGUID = new System.Windows.Forms.Label();
            lblCameraPassword = new System.Windows.Forms.Label();
            lblPatternNumberAndName = new System.Windows.Forms.Label();
            tbCameraName = new System.Windows.Forms.TextBox();
            cbPatternName = new System.Windows.Forms.ComboBox();
            lblStreamId = new System.Windows.Forms.Label();
            lblCameraIpAddress = new System.Windows.Forms.Label();
            tbCameraUsername = new System.Windows.Forms.TextBox();
            cbFullscreenMode = new System.Windows.Forms.ComboBox();
            cbPresetName = new System.Windows.Forms.ComboBox();
            tbCameraGuid = new System.Windows.Forms.TextBox();
            lblHttpStream = new System.Windows.Forms.Label();
            lblPresetNumberAndName = new System.Windows.Forms.Label();
            nudStreamId = new System.Windows.Forms.NumericUpDown();
            tbCameraIpAddress = new System.Windows.Forms.TextBox();
            lblCameraUsername = new System.Windows.Forms.Label();
            lblFullscreenMode = new System.Windows.Forms.Label();
            nudPresetNumber = new System.Windows.Forms.NumericUpDown();
            tbStreamUrl = new System.Windows.Forms.TextBox();
            tpCustomCommands = new System.Windows.Forms.TabPage();
            lvCameraFunctions = new Mtf.Controls.MtfListView();
            chCameraFunction = new System.Windows.Forms.ColumnHeader();
            chCameraFunctionCallback = new System.Windows.Forms.ColumnHeader();
            chCameraFunctionCallbackParameters = new System.Windows.Forms.ColumnHeader();
            contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(components);
            tsmiDeleteCameraFunction = new System.Windows.Forms.ToolStripMenuItem();
            btnAdd = new System.Windows.Forms.Button();
            lblCameraFunctionCallbackParameters = new System.Windows.Forms.Label();
            tbCameraFunctionCallbackParameters = new System.Windows.Forms.TextBox();
            lblCameraFunctionCallback = new System.Windows.Forms.Label();
            lblCameraFunctionType = new System.Windows.Forms.Label();
            tbCameraFunctionCallback = new System.Windows.Forms.TextBox();
            cbCameraFunctionType = new System.Windows.Forms.ComboBox();
            btnClose = new System.Windows.Forms.Button();
            btnSave = new System.Windows.Forms.Button();
            saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            openFileDialog = new System.Windows.Forms.OpenFileDialog();
            tpStreamUrl = new System.Windows.Forms.TabPage();
            pbStreamUrl = new System.Windows.Forms.PictureBox();
            pMain.SuspendLayout();
            tabControl.SuspendLayout();
            tpGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudPatternNumber).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudStreamId).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudPresetNumber).BeginInit();
            tpCustomCommands.SuspendLayout();
            contextMenuStrip.SuspendLayout();
            tpStreamUrl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbStreamUrl).BeginInit();
            SuspendLayout();
            // 
            // pMain
            // 
            pMain.Controls.Add(btnImport);
            pMain.Controls.Add(btnExport);
            pMain.Controls.Add(tabControl);
            pMain.Controls.Add(btnClose);
            pMain.Controls.Add(btnSave);
            pMain.Dock = System.Windows.Forms.DockStyle.Fill;
            pMain.Location = new System.Drawing.Point(0, 0);
            pMain.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pMain.Name = "pMain";
            pMain.Size = new System.Drawing.Size(904, 458);
            pMain.TabIndex = 1;
            // 
            // btnImport
            // 
            btnImport.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btnImport.Location = new System.Drawing.Point(7, 423);
            btnImport.Name = "btnImport";
            btnImport.Size = new System.Drawing.Size(75, 23);
            btnImport.TabIndex = 29;
            btnImport.Text = "Import";
            btnImport.UseVisualStyleBackColor = true;
            btnImport.Click += BtnImport_Click;
            // 
            // btnExport
            // 
            btnExport.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btnExport.Location = new System.Drawing.Point(88, 423);
            btnExport.Name = "btnExport";
            btnExport.Size = new System.Drawing.Size(75, 23);
            btnExport.TabIndex = 28;
            btnExport.Text = "Export";
            btnExport.UseVisualStyleBackColor = true;
            btnExport.Click += BtnExport_Click;
            // 
            // tabControl
            // 
            tabControl.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tabControl.Controls.Add(tpGeneral);
            tabControl.Controls.Add(tpCustomCommands);
            tabControl.Controls.Add(tpStreamUrl);
            tabControl.Location = new System.Drawing.Point(3, 3);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new System.Drawing.Size(898, 414);
            tabControl.TabIndex = 27;
            // 
            // tpGeneral
            // 
            tpGeneral.Controls.Add(cbVideoSource);
            tpGeneral.Controls.Add(lblVideoSource);
            tpGeneral.Controls.Add(lblCameraName);
            tpGeneral.Controls.Add(btnSearch);
            tpGeneral.Controls.Add(nudPatternNumber);
            tpGeneral.Controls.Add(tbCameraPassword);
            tpGeneral.Controls.Add(lblCameraGUID);
            tpGeneral.Controls.Add(lblCameraPassword);
            tpGeneral.Controls.Add(lblPatternNumberAndName);
            tpGeneral.Controls.Add(tbCameraName);
            tpGeneral.Controls.Add(cbPatternName);
            tpGeneral.Controls.Add(lblStreamId);
            tpGeneral.Controls.Add(lblCameraIpAddress);
            tpGeneral.Controls.Add(tbCameraUsername);
            tpGeneral.Controls.Add(cbFullscreenMode);
            tpGeneral.Controls.Add(cbPresetName);
            tpGeneral.Controls.Add(tbCameraGuid);
            tpGeneral.Controls.Add(lblHttpStream);
            tpGeneral.Controls.Add(lblPresetNumberAndName);
            tpGeneral.Controls.Add(nudStreamId);
            tpGeneral.Controls.Add(tbCameraIpAddress);
            tpGeneral.Controls.Add(lblCameraUsername);
            tpGeneral.Controls.Add(lblFullscreenMode);
            tpGeneral.Controls.Add(nudPresetNumber);
            tpGeneral.Controls.Add(tbStreamUrl);
            tpGeneral.Location = new System.Drawing.Point(4, 24);
            tpGeneral.Name = "tpGeneral";
            tpGeneral.Padding = new System.Windows.Forms.Padding(3);
            tpGeneral.Size = new System.Drawing.Size(890, 386);
            tpGeneral.TabIndex = 0;
            tpGeneral.Text = "General";
            tpGeneral.UseVisualStyleBackColor = true;
            // 
            // cbVideoSource
            // 
            cbVideoSource.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            cbVideoSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbVideoSource.FormattingEnabled = true;
            cbVideoSource.Location = new System.Drawing.Point(152, 277);
            cbVideoSource.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cbVideoSource.MaxLength = 50;
            cbVideoSource.Name = "cbVideoSource";
            cbVideoSource.Size = new System.Drawing.Size(731, 23);
            cbVideoSource.TabIndex = 28;
            // 
            // lblVideoSource
            // 
            lblVideoSource.AutoSize = true;
            lblVideoSource.Location = new System.Drawing.Point(7, 280);
            lblVideoSource.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblVideoSource.Name = "lblVideoSource";
            lblVideoSource.Size = new System.Drawing.Size(75, 15);
            lblVideoSource.TabIndex = 27;
            lblVideoSource.Text = "Video source";
            // 
            // lblCameraName
            // 
            lblCameraName.AutoSize = true;
            lblCameraName.Location = new System.Drawing.Point(7, 13);
            lblCameraName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblCameraName.Name = "lblCameraName";
            lblCameraName.Size = new System.Drawing.Size(81, 15);
            lblCameraName.TabIndex = 0;
            lblCameraName.Text = "Camera name";
            // 
            // btnSearch
            // 
            btnSearch.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnSearch.Image = Properties.Resources.magnifier;
            btnSearch.Location = new System.Drawing.Point(858, 187);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new System.Drawing.Size(25, 25);
            btnSearch.TabIndex = 26;
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += BtnSearch_Click;
            // 
            // nudPatternNumber
            // 
            nudPatternNumber.Location = new System.Drawing.Point(152, 249);
            nudPatternNumber.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            nudPatternNumber.Maximum = new decimal(new int[] { 15, 0, 0, 0 });
            nudPatternNumber.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudPatternNumber.Name = "nudPatternNumber";
            nudPatternNumber.Size = new System.Drawing.Size(44, 23);
            nudPatternNumber.TabIndex = 20;
            nudPatternNumber.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // tbCameraPassword
            // 
            tbCameraPassword.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tbCameraPassword.Location = new System.Drawing.Point(152, 112);
            tbCameraPassword.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tbCameraPassword.MaxLength = 200;
            tbCameraPassword.Name = "tbCameraPassword";
            tbCameraPassword.Password = "";
            tbCameraPassword.PasswordChar = '*';
            tbCameraPassword.ShowRealPasswordLength = false;
            tbCameraPassword.Size = new System.Drawing.Size(731, 23);
            tbCameraPassword.TabIndex = 9;
            // 
            // lblCameraGUID
            // 
            lblCameraGUID.AutoSize = true;
            lblCameraGUID.Location = new System.Drawing.Point(7, 39);
            lblCameraGUID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblCameraGUID.Name = "lblCameraGUID";
            lblCameraGUID.Size = new System.Drawing.Size(34, 15);
            lblCameraGUID.TabIndex = 2;
            lblCameraGUID.Text = "GUID";
            // 
            // lblCameraPassword
            // 
            lblCameraPassword.AutoSize = true;
            lblCameraPassword.Location = new System.Drawing.Point(7, 115);
            lblCameraPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblCameraPassword.Name = "lblCameraPassword";
            lblCameraPassword.Size = new System.Drawing.Size(57, 15);
            lblCameraPassword.TabIndex = 8;
            lblCameraPassword.Text = "Password";
            // 
            // lblPatternNumberAndName
            // 
            lblPatternNumberAndName.AutoSize = true;
            lblPatternNumberAndName.Location = new System.Drawing.Point(7, 251);
            lblPatternNumberAndName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblPatternNumberAndName.Name = "lblPatternNumberAndName";
            lblPatternNumberAndName.Size = new System.Drawing.Size(126, 15);
            lblPatternNumberAndName.TabIndex = 19;
            lblPatternNumberAndName.Text = "Pattern number, name";
            // 
            // tbCameraName
            // 
            tbCameraName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tbCameraName.Location = new System.Drawing.Point(152, 11);
            tbCameraName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tbCameraName.MaxLength = 200;
            tbCameraName.Name = "tbCameraName";
            tbCameraName.Size = new System.Drawing.Size(731, 23);
            tbCameraName.TabIndex = 25;
            // 
            // cbPatternName
            // 
            cbPatternName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            cbPatternName.FormattingEnabled = true;
            cbPatternName.Location = new System.Drawing.Point(203, 248);
            cbPatternName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cbPatternName.MaxLength = 50;
            cbPatternName.Name = "cbPatternName";
            cbPatternName.Size = new System.Drawing.Size(680, 23);
            cbPatternName.TabIndex = 21;
            // 
            // lblStreamId
            // 
            lblStreamId.AutoSize = true;
            lblStreamId.Location = new System.Drawing.Point(7, 140);
            lblStreamId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblStreamId.Name = "lblStreamId";
            lblStreamId.Size = new System.Drawing.Size(58, 15);
            lblStreamId.TabIndex = 10;
            lblStreamId.Text = "Stream ID";
            // 
            // lblCameraIpAddress
            // 
            lblCameraIpAddress.AutoSize = true;
            lblCameraIpAddress.Location = new System.Drawing.Point(7, 64);
            lblCameraIpAddress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblCameraIpAddress.Name = "lblCameraIpAddress";
            lblCameraIpAddress.Size = new System.Drawing.Size(60, 15);
            lblCameraIpAddress.TabIndex = 4;
            lblCameraIpAddress.Text = "IP address";
            // 
            // tbCameraUsername
            // 
            tbCameraUsername.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tbCameraUsername.Location = new System.Drawing.Point(152, 86);
            tbCameraUsername.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tbCameraUsername.MaxLength = 200;
            tbCameraUsername.Name = "tbCameraUsername";
            tbCameraUsername.Size = new System.Drawing.Size(731, 23);
            tbCameraUsername.TabIndex = 7;
            // 
            // cbFullscreenMode
            // 
            cbFullscreenMode.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            cbFullscreenMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbFullscreenMode.FormattingEnabled = true;
            cbFullscreenMode.Location = new System.Drawing.Point(152, 162);
            cbFullscreenMode.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cbFullscreenMode.Name = "cbFullscreenMode";
            cbFullscreenMode.Size = new System.Drawing.Size(731, 23);
            cbFullscreenMode.TabIndex = 13;
            // 
            // cbPresetName
            // 
            cbPresetName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            cbPresetName.FormattingEnabled = true;
            cbPresetName.Location = new System.Drawing.Point(203, 222);
            cbPresetName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cbPresetName.MaxLength = 50;
            cbPresetName.Name = "cbPresetName";
            cbPresetName.Size = new System.Drawing.Size(680, 23);
            cbPresetName.TabIndex = 18;
            // 
            // tbCameraGuid
            // 
            tbCameraGuid.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tbCameraGuid.Location = new System.Drawing.Point(152, 36);
            tbCameraGuid.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tbCameraGuid.MaxLength = 200;
            tbCameraGuid.Name = "tbCameraGuid";
            tbCameraGuid.ReadOnly = true;
            tbCameraGuid.Size = new System.Drawing.Size(731, 23);
            tbCameraGuid.TabIndex = 24;
            // 
            // lblHttpStream
            // 
            lblHttpStream.AutoSize = true;
            lblHttpStream.Location = new System.Drawing.Point(7, 191);
            lblHttpStream.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblHttpStream.Name = "lblHttpStream";
            lblHttpStream.Size = new System.Drawing.Size(68, 15);
            lblHttpStream.TabIndex = 14;
            lblHttpStream.Text = "Stream URL";
            // 
            // lblPresetNumberAndName
            // 
            lblPresetNumberAndName.AutoSize = true;
            lblPresetNumberAndName.Location = new System.Drawing.Point(7, 226);
            lblPresetNumberAndName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblPresetNumberAndName.Name = "lblPresetNumberAndName";
            lblPresetNumberAndName.Size = new System.Drawing.Size(120, 15);
            lblPresetNumberAndName.TabIndex = 16;
            lblPresetNumberAndName.Text = "Preset number, name";
            // 
            // nudStreamId
            // 
            nudStreamId.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            nudStreamId.Location = new System.Drawing.Point(152, 138);
            nudStreamId.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            nudStreamId.Name = "nudStreamId";
            nudStreamId.Size = new System.Drawing.Size(731, 23);
            nudStreamId.TabIndex = 11;
            nudStreamId.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // tbCameraIpAddress
            // 
            tbCameraIpAddress.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tbCameraIpAddress.Location = new System.Drawing.Point(152, 61);
            tbCameraIpAddress.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tbCameraIpAddress.MaxLength = 200;
            tbCameraIpAddress.Name = "tbCameraIpAddress";
            tbCameraIpAddress.Size = new System.Drawing.Size(731, 23);
            tbCameraIpAddress.TabIndex = 5;
            // 
            // lblCameraUsername
            // 
            lblCameraUsername.AutoSize = true;
            lblCameraUsername.Location = new System.Drawing.Point(7, 90);
            lblCameraUsername.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblCameraUsername.Name = "lblCameraUsername";
            lblCameraUsername.Size = new System.Drawing.Size(60, 15);
            lblCameraUsername.TabIndex = 6;
            lblCameraUsername.Text = "Username";
            // 
            // lblFullscreenMode
            // 
            lblFullscreenMode.AutoSize = true;
            lblFullscreenMode.Location = new System.Drawing.Point(7, 166);
            lblFullscreenMode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblFullscreenMode.Name = "lblFullscreenMode";
            lblFullscreenMode.Size = new System.Drawing.Size(94, 15);
            lblFullscreenMode.TabIndex = 12;
            lblFullscreenMode.Text = "Fullscreen mode";
            // 
            // nudPresetNumber
            // 
            nudPresetNumber.Location = new System.Drawing.Point(152, 223);
            nudPresetNumber.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            nudPresetNumber.Maximum = new decimal(new int[] { 99, 0, 0, 0 });
            nudPresetNumber.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudPresetNumber.Name = "nudPresetNumber";
            nudPresetNumber.Size = new System.Drawing.Size(44, 23);
            nudPresetNumber.TabIndex = 17;
            nudPresetNumber.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // tbStreamUrl
            // 
            tbStreamUrl.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tbStreamUrl.Location = new System.Drawing.Point(152, 188);
            tbStreamUrl.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tbStreamUrl.MaxLength = 200;
            tbStreamUrl.Name = "tbStreamUrl";
            tbStreamUrl.Size = new System.Drawing.Size(704, 23);
            tbStreamUrl.TabIndex = 15;
            tbStreamUrl.TextChanged += TbStreamUrl_TextChanged;
            // 
            // tpCustomCommands
            // 
            tpCustomCommands.Controls.Add(lvCameraFunctions);
            tpCustomCommands.Controls.Add(btnAdd);
            tpCustomCommands.Controls.Add(lblCameraFunctionCallbackParameters);
            tpCustomCommands.Controls.Add(tbCameraFunctionCallbackParameters);
            tpCustomCommands.Controls.Add(lblCameraFunctionCallback);
            tpCustomCommands.Controls.Add(lblCameraFunctionType);
            tpCustomCommands.Controls.Add(tbCameraFunctionCallback);
            tpCustomCommands.Controls.Add(cbCameraFunctionType);
            tpCustomCommands.Location = new System.Drawing.Point(4, 24);
            tpCustomCommands.Name = "tpCustomCommands";
            tpCustomCommands.Padding = new System.Windows.Forms.Padding(3);
            tpCustomCommands.Size = new System.Drawing.Size(890, 386);
            tpCustomCommands.TabIndex = 1;
            tpCustomCommands.Text = "Custom commands";
            tpCustomCommands.UseVisualStyleBackColor = true;
            // 
            // lvCameraFunctions
            // 
            lvCameraFunctions.AlternatingColorEven = System.Drawing.Color.LightBlue;
            lvCameraFunctions.AlternatingColorOdd = System.Drawing.SystemColors.Window;
            lvCameraFunctions.AlternatingColorsAreInUse = true;
            lvCameraFunctions.AlternatingPairColorEven = System.Drawing.Color.LightSeaGreen;
            lvCameraFunctions.AlternatingPairColorOdd = System.Drawing.Color.CadetBlue;
            lvCameraFunctions.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            lvCameraFunctions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { chCameraFunction, chCameraFunctionCallback, chCameraFunctionCallbackParameters });
            lvCameraFunctions.CompactView = false;
            lvCameraFunctions.ContextMenuStrip = contextMenuStrip;
            lvCameraFunctions.EnsureLastItemIsVisible = false;
            lvCameraFunctions.FirstItemIsGray = false;
            lvCameraFunctions.FullRowSelect = true;
            lvCameraFunctions.Location = new System.Drawing.Point(6, 107);
            lvCameraFunctions.Name = "lvCameraFunctions";
            lvCameraFunctions.OwnerDraw = true;
            lvCameraFunctions.ReadonlyCheckboxes = false;
            lvCameraFunctions.SameItemsColorEven = System.Drawing.Color.DarkOrange;
            lvCameraFunctions.SameItemsColorOdd = System.Drawing.Color.LightSalmon;
            lvCameraFunctions.Size = new System.Drawing.Size(878, 273);
            lvCameraFunctions.TabIndex = 29;
            lvCameraFunctions.UseCompatibleStateImageBehavior = false;
            lvCameraFunctions.View = System.Windows.Forms.View.Details;
            // 
            // chCameraFunction
            // 
            chCameraFunction.Text = "Camera function";
            chCameraFunction.Width = 150;
            // 
            // chCameraFunctionCallback
            // 
            chCameraFunctionCallback.Text = "Camera function callback";
            chCameraFunctionCallback.Width = 500;
            // 
            // chCameraFunctionCallbackParameters
            // 
            chCameraFunctionCallbackParameters.Text = "Camera function callback parameters";
            chCameraFunctionCallbackParameters.Width = 300;
            // 
            // contextMenuStrip
            // 
            contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { tsmiDeleteCameraFunction });
            contextMenuStrip.Name = "contextMenuStrip";
            contextMenuStrip.Size = new System.Drawing.Size(108, 26);
            // 
            // tsmiDeleteCameraFunction
            // 
            tsmiDeleteCameraFunction.Name = "tsmiDeleteCameraFunction";
            tsmiDeleteCameraFunction.Size = new System.Drawing.Size(107, 22);
            tsmiDeleteCameraFunction.Text = "Delete";
            tsmiDeleteCameraFunction.Click += TsmiDeleteCameraFunction_Click;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnAdd.Location = new System.Drawing.Point(798, 75);
            btnAdd.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new System.Drawing.Size(88, 27);
            btnAdd.TabIndex = 28;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += BtnAdd_Click;
            // 
            // lblCameraFunctionCallbackParameters
            // 
            lblCameraFunctionCallbackParameters.AutoSize = true;
            lblCameraFunctionCallbackParameters.Location = new System.Drawing.Point(6, 60);
            lblCameraFunctionCallbackParameters.Name = "lblCameraFunctionCallbackParameters";
            lblCameraFunctionCallbackParameters.Size = new System.Drawing.Size(345, 15);
            lblCameraFunctionCallbackParameters.TabIndex = 5;
            lblCameraFunctionCallbackParameters.Text = "Camera function callback parameters (separated by semicolons)";
            // 
            // tbCameraFunctionCallbackParameters
            // 
            tbCameraFunctionCallbackParameters.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tbCameraFunctionCallbackParameters.Location = new System.Drawing.Point(6, 78);
            tbCameraFunctionCallbackParameters.Name = "tbCameraFunctionCallbackParameters";
            tbCameraFunctionCallbackParameters.Size = new System.Drawing.Size(790, 23);
            tbCameraFunctionCallbackParameters.TabIndex = 4;
            // 
            // lblCameraFunctionCallback
            // 
            lblCameraFunctionCallback.AutoSize = true;
            lblCameraFunctionCallback.Location = new System.Drawing.Point(268, 14);
            lblCameraFunctionCallback.Name = "lblCameraFunctionCallback";
            lblCameraFunctionCallback.Size = new System.Drawing.Size(142, 15);
            lblCameraFunctionCallback.TabIndex = 3;
            lblCameraFunctionCallback.Text = "Camera function callback";
            // 
            // lblCameraFunctionType
            // 
            lblCameraFunctionType.AutoSize = true;
            lblCameraFunctionType.Location = new System.Drawing.Point(6, 14);
            lblCameraFunctionType.Name = "lblCameraFunctionType";
            lblCameraFunctionType.Size = new System.Drawing.Size(96, 15);
            lblCameraFunctionType.TabIndex = 2;
            lblCameraFunctionType.Text = "Camera function";
            // 
            // tbCameraFunctionCallback
            // 
            tbCameraFunctionCallback.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tbCameraFunctionCallback.Location = new System.Drawing.Point(268, 32);
            tbCameraFunctionCallback.Name = "tbCameraFunctionCallback";
            tbCameraFunctionCallback.Size = new System.Drawing.Size(616, 23);
            tbCameraFunctionCallback.TabIndex = 1;
            // 
            // cbCameraFunctionType
            // 
            cbCameraFunctionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbCameraFunctionType.FormattingEnabled = true;
            cbCameraFunctionType.Location = new System.Drawing.Point(6, 32);
            cbCameraFunctionType.Name = "cbCameraFunctionType";
            cbCameraFunctionType.Size = new System.Drawing.Size(256, 23);
            cbCameraFunctionType.TabIndex = 0;
            // 
            // btnClose
            // 
            btnClose.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            btnClose.Location = new System.Drawing.Point(809, 423);
            btnClose.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnClose.Name = "btnClose";
            btnClose.Size = new System.Drawing.Size(88, 27);
            btnClose.TabIndex = 23;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += BtnClose_Click;
            // 
            // btnSave
            // 
            btnSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnSave.Location = new System.Drawing.Point(715, 423);
            btnSave.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(88, 27);
            btnSave.TabIndex = 22;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += BtnSave_Click;
            // 
            // tpStreamUrl
            // 
            tpStreamUrl.Controls.Add(pbStreamUrl);
            tpStreamUrl.Location = new System.Drawing.Point(4, 24);
            tpStreamUrl.Name = "tpStreamUrl";
            tpStreamUrl.Padding = new System.Windows.Forms.Padding(3);
            tpStreamUrl.Size = new System.Drawing.Size(890, 386);
            tpStreamUrl.TabIndex = 2;
            tpStreamUrl.Text = "Stream URL";
            tpStreamUrl.UseVisualStyleBackColor = true;
            // 
            // pbStreamUrl
            // 
            pbStreamUrl.Dock = System.Windows.Forms.DockStyle.Fill;
            pbStreamUrl.Location = new System.Drawing.Point(3, 3);
            pbStreamUrl.Name = "pbStreamUrl";
            pbStreamUrl.Size = new System.Drawing.Size(884, 380);
            pbStreamUrl.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pbStreamUrl.TabIndex = 30;
            pbStreamUrl.TabStop = false;
            // 
            // CameraProperties
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(904, 458);
            Controls.Add(pMain);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "CameraProperties";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Camera properties";
            Shown += CameraProperties_Shown;
            pMain.ResumeLayout(false);
            tabControl.ResumeLayout(false);
            tpGeneral.ResumeLayout(false);
            tpGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudPatternNumber).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudStreamId).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudPresetNumber).EndInit();
            tpCustomCommands.ResumeLayout(false);
            tpCustomCommands.PerformLayout();
            contextMenuStrip.ResumeLayout(false);
            tpStreamUrl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbStreamUrl).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pMain;
        private System.Windows.Forms.TextBox tbStreamUrl;
        private System.Windows.Forms.Label lblHttpStream;
        private System.Windows.Forms.ComboBox cbPatternName;
        private System.Windows.Forms.NumericUpDown nudPatternNumber;
        private System.Windows.Forms.Label lblPatternNumberAndName;
        private System.Windows.Forms.ComboBox cbPresetName;
        private System.Windows.Forms.NumericUpDown nudPresetNumber;
        private System.Windows.Forms.Label lblPresetNumberAndName;
        private System.Windows.Forms.ComboBox cbFullscreenMode;
        private System.Windows.Forms.Label lblFullscreenMode;
        private System.Windows.Forms.NumericUpDown nudStreamId;
        private System.Windows.Forms.Label lblStreamId;
        private Mtf.Controls.PasswordBox tbCameraPassword;
        private System.Windows.Forms.Label lblCameraPassword;
        private System.Windows.Forms.TextBox tbCameraUsername;
        private System.Windows.Forms.Label lblCameraUsername;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblCameraName;
        private System.Windows.Forms.TextBox tbCameraIpAddress;
        private System.Windows.Forms.Label lblCameraIpAddress;
        private System.Windows.Forms.Label lblCameraGUID;
        private System.Windows.Forms.TextBox tbCameraName;
        private System.Windows.Forms.TextBox tbCameraGuid;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tpGeneral;
        private System.Windows.Forms.TabPage tpCustomCommands;
        private System.Windows.Forms.ComboBox cbCameraFunctionType;
        private System.Windows.Forms.Label lblCameraFunctionCallback;
        private System.Windows.Forms.Label lblCameraFunctionType;
        private System.Windows.Forms.TextBox tbCameraFunctionCallback;
        private System.Windows.Forms.Label lblCameraFunctionCallbackParameters;
        private System.Windows.Forms.TextBox tbCameraFunctionCallbackParameters;
        private System.Windows.Forms.Button btnAdd;
        private Mtf.Controls.MtfListView lvCameraFunctions;
        private System.Windows.Forms.ColumnHeader chCameraFunction;
        private System.Windows.Forms.ColumnHeader chCameraFunctionCallback;
        private System.Windows.Forms.ColumnHeader chCameraFunctionCallbackParameters;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeleteCameraFunction;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ComboBox cbVideoSource;
        private System.Windows.Forms.Label lblVideoSource;
        private System.Windows.Forms.TabPage tpStreamUrl;
        private System.Windows.Forms.PictureBox pbStreamUrl;
    }
}