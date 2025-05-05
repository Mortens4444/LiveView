using System;

namespace LiveView.Forms
{
    partial class GeneralOptionsForm
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
            folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            tabControl = new System.Windows.Forms.TabControl();
            tpGeneral = new System.Windows.Forms.TabPage();
            pMain = new System.Windows.Forms.Panel();
            cbAutoLoadedTemplate = new System.Windows.Forms.ComboBox();
            lblAutoLoadedTemplate = new System.Windows.Forms.Label();
            chkOpenControlCenterWhenProgramStarts = new System.Windows.Forms.CheckBox();
            chkOpenMotionPopupWhenProgramStarts = new System.Windows.Forms.CheckBox();
            lblMinutes2 = new System.Windows.Forms.Label();
            nudRestartTemplate = new System.Windows.Forms.NumericUpDown();
            lblRestartTemplateAfterEvery = new System.Windows.Forms.Label();
            cbUsers = new System.Windows.Forms.ComboBox();
            lblAutoLogin = new System.Windows.Forms.Label();
            tpDatabaseOptions = new System.Windows.Forms.TabPage();
            btnGenerateConfigFile = new System.Windows.Forms.Button();
            lblWorkstationId = new System.Windows.Forms.Label();
            tbWorkstationId = new System.Windows.Forms.TextBox();
            lblApplicationName = new System.Windows.Forms.Label();
            tbApplicationName = new System.Windows.Forms.TextBox();
            chkPooling = new System.Windows.Forms.CheckBox();
            chkEncrypt = new System.Windows.Forms.CheckBox();
            lblConnectionTimeout = new System.Windows.Forms.Label();
            nudConnectionTimeout = new System.Windows.Forms.NumericUpDown();
            lblPassword = new System.Windows.Forms.Label();
            tbPassword = new System.Windows.Forms.TextBox();
            chkIntegratedSecurity = new System.Windows.Forms.CheckBox();
            tbDatabaseFolder = new System.Windows.Forms.TextBox();
            tbDatabaseUsage = new System.Windows.Forms.TextBox();
            btnChangeDatabaseDirectory = new System.Windows.Forms.Button();
            lblUsage = new System.Windows.Forms.Label();
            lblDatabaseName = new System.Windows.Forms.Label();
            tbDatabaseName = new System.Windows.Forms.TextBox();
            lblUsername = new System.Windows.Forms.Label();
            tbUsername = new System.Windows.Forms.TextBox();
            lblDataSource = new System.Windows.Forms.Label();
            tbDataSource = new System.Windows.Forms.TextBox();
            tpLogging = new System.Windows.Forms.TabPage();
            rbVerboseLogEveryEvents = new System.Windows.Forms.RadioButton();
            lblMinutes = new System.Windows.Forms.Label();
            rbVerboseLogOnlyErrors = new System.Windows.Forms.RadioButton();
            nudStatisticMessageAfterEveryMinutes = new System.Windows.Forms.NumericUpDown();
            chkVerboseDebugLogging = new System.Windows.Forms.CheckBox();
            lblStatisticMessageAfterEvery = new System.Windows.Forms.Label();
            tpVideo = new System.Windows.Forms.TabPage();
            lblFps = new System.Windows.Forms.Label();
            nudFPS = new System.Windows.Forms.NumericUpDown();
            lblSeconds = new System.Windows.Forms.Label();
            nudMaximumTimeToWaitForNewPicture = new System.Windows.Forms.NumericUpDown();
            lblMaximumTimeToWaitForNewPicture = new System.Windows.Forms.Label();
            lblMilliseconds3 = new System.Windows.Forms.Label();
            nudMaximumDeflectionBetweenLiveViewAndRecorder = new System.Windows.Forms.NumericUpDown();
            lblMaximumDeflectionBetweenLiveViewAndRecorder = new System.Windows.Forms.Label();
            lblMilliseconds2 = new System.Windows.Forms.Label();
            lblMilliseconds = new System.Windows.Forms.Label();
            nudTimeBetweenCheckVideoServers = new System.Windows.Forms.NumericUpDown();
            lblTimeBetweenCheckVideoServers = new System.Windows.Forms.Label();
            nudMaximumTimeToWaitForAVideoServerIs = new System.Windows.Forms.NumericUpDown();
            lblMaximumTimeToWaitForAVideoServerIs = new System.Windows.Forms.Label();
            chkDeblock = new System.Windows.Forms.CheckBox();
            chkThreading = new System.Windows.Forms.CheckBox();
            chkReduceSequenceUsageOfNetworkAndCPU = new System.Windows.Forms.CheckBox();
            chkCloseSequenceApplicationOnFullScreenDisplayDevice = new System.Windows.Forms.CheckBox();
            chkLiveView = new System.Windows.Forms.CheckBox();
            gbNoSignalImage = new System.Windows.Forms.GroupBox();
            pbStatus = new Mtf.Controls.MtfPictureBox();
            chkUseCustomNoSignalImage = new System.Windows.Forms.CheckBox();
            pbNoSignalImage = new Mtf.Controls.MtfPictureBox();
            btnNoSignalImageBrowse = new System.Windows.Forms.Button();
            tpSerialOptions = new System.Windows.Forms.TabPage();
            lblWatchdogPort = new System.Windows.Forms.Label();
            cbWatchdogPort = new System.Windows.Forms.ComboBox();
            lblKBD300ACOMPort = new System.Windows.Forms.Label();
            cbKBD300ACOMPort = new System.Windows.Forms.ComboBox();
            btnStandard = new System.Windows.Forms.Button();
            btnDefault = new System.Windows.Forms.Button();
            btnClose = new System.Windows.Forms.Button();
            btnSave = new System.Windows.Forms.Button();
            saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            tabControl.SuspendLayout();
            tpGeneral.SuspendLayout();
            pMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudRestartTemplate).BeginInit();
            tpDatabaseOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudConnectionTimeout).BeginInit();
            tpLogging.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudStatisticMessageAfterEveryMinutes).BeginInit();
            tpVideo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudFPS).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudMaximumTimeToWaitForNewPicture).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudMaximumDeflectionBetweenLiveViewAndRecorder).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudTimeBetweenCheckVideoServers).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudMaximumTimeToWaitForAVideoServerIs).BeginInit();
            gbNoSignalImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbStatus).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbNoSignalImage).BeginInit();
            tpSerialOptions.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tabControl.Controls.Add(tpGeneral);
            tabControl.Controls.Add(tpDatabaseOptions);
            tabControl.Controls.Add(tpLogging);
            tabControl.Controls.Add(tpVideo);
            tabControl.Controls.Add(tpSerialOptions);
            tabControl.Location = new System.Drawing.Point(0, 0);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new System.Drawing.Size(655, 465);
            tabControl.TabIndex = 2;
            // 
            // tpGeneral
            // 
            tpGeneral.Controls.Add(pMain);
            tpGeneral.Location = new System.Drawing.Point(4, 24);
            tpGeneral.Name = "tpGeneral";
            tpGeneral.Padding = new System.Windows.Forms.Padding(3);
            tpGeneral.Size = new System.Drawing.Size(647, 437);
            tpGeneral.TabIndex = 0;
            tpGeneral.Text = "General";
            tpGeneral.UseVisualStyleBackColor = true;
            // 
            // pMain
            // 
            pMain.Controls.Add(cbAutoLoadedTemplate);
            pMain.Controls.Add(lblAutoLoadedTemplate);
            pMain.Controls.Add(chkOpenControlCenterWhenProgramStarts);
            pMain.Controls.Add(chkOpenMotionPopupWhenProgramStarts);
            pMain.Controls.Add(lblMinutes2);
            pMain.Controls.Add(nudRestartTemplate);
            pMain.Controls.Add(lblRestartTemplateAfterEvery);
            pMain.Controls.Add(cbUsers);
            pMain.Controls.Add(lblAutoLogin);
            pMain.Dock = System.Windows.Forms.DockStyle.Fill;
            pMain.Location = new System.Drawing.Point(3, 3);
            pMain.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pMain.Name = "pMain";
            pMain.Size = new System.Drawing.Size(641, 431);
            pMain.TabIndex = 2;
            // 
            // cbAutoLoadedTemplate
            // 
            cbAutoLoadedTemplate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbAutoLoadedTemplate.FormattingEnabled = true;
            cbAutoLoadedTemplate.Location = new System.Drawing.Point(444, 134);
            cbAutoLoadedTemplate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cbAutoLoadedTemplate.Name = "cbAutoLoadedTemplate";
            cbAutoLoadedTemplate.Size = new System.Drawing.Size(193, 23);
            cbAutoLoadedTemplate.TabIndex = 26;
            // 
            // lblAutoLoadedTemplate
            // 
            lblAutoLoadedTemplate.AutoSize = true;
            lblAutoLoadedTemplate.Location = new System.Drawing.Point(6, 137);
            lblAutoLoadedTemplate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblAutoLoadedTemplate.Name = "lblAutoLoadedTemplate";
            lblAutoLoadedTemplate.Size = new System.Drawing.Size(122, 15);
            lblAutoLoadedTemplate.TabIndex = 25;
            lblAutoLoadedTemplate.Text = "Auto loaded template";
            // 
            // chkOpenControlCenterWhenProgramStarts
            // 
            chkOpenControlCenterWhenProgramStarts.AutoSize = true;
            chkOpenControlCenterWhenProgramStarts.Location = new System.Drawing.Point(6, 17);
            chkOpenControlCenterWhenProgramStarts.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chkOpenControlCenterWhenProgramStarts.Name = "chkOpenControlCenterWhenProgramStarts";
            chkOpenControlCenterWhenProgramStarts.Size = new System.Drawing.Size(248, 19);
            chkOpenControlCenterWhenProgramStarts.TabIndex = 24;
            chkOpenControlCenterWhenProgramStarts.Text = "Open Control Center when program starts";
            chkOpenControlCenterWhenProgramStarts.UseVisualStyleBackColor = true;
            // 
            // chkOpenMotionPopupWhenProgramStarts
            // 
            chkOpenMotionPopupWhenProgramStarts.AutoSize = true;
            chkOpenMotionPopupWhenProgramStarts.Location = new System.Drawing.Point(6, 42);
            chkOpenMotionPopupWhenProgramStarts.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chkOpenMotionPopupWhenProgramStarts.Name = "chkOpenMotionPopupWhenProgramStarts";
            chkOpenMotionPopupWhenProgramStarts.Size = new System.Drawing.Size(247, 19);
            chkOpenMotionPopupWhenProgramStarts.TabIndex = 1;
            chkOpenMotionPopupWhenProgramStarts.Text = "Open Motion Popup when program starts";
            chkOpenMotionPopupWhenProgramStarts.UseVisualStyleBackColor = true;
            // 
            // lblMinutes2
            // 
            lblMinutes2.AutoSize = true;
            lblMinutes2.Location = new System.Drawing.Point(575, 75);
            lblMinutes2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblMinutes2.Name = "lblMinutes2";
            lblMinutes2.Size = new System.Drawing.Size(58, 15);
            lblMinutes2.TabIndex = 23;
            lblMinutes2.Text = "minute(s)";
            // 
            // nudRestartTemplate
            // 
            nudRestartTemplate.Location = new System.Drawing.Point(492, 72);
            nudRestartTemplate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            nudRestartTemplate.Maximum = new decimal(new int[] { 35791, 0, 0, 0 });
            nudRestartTemplate.Name = "nudRestartTemplate";
            nudRestartTemplate.Size = new System.Drawing.Size(82, 23);
            nudRestartTemplate.TabIndex = 22;
            // 
            // lblRestartTemplateAfterEvery
            // 
            lblRestartTemplateAfterEvery.AutoSize = true;
            lblRestartTemplateAfterEvery.Location = new System.Drawing.Point(6, 75);
            lblRestartTemplateAfterEvery.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblRestartTemplateAfterEvery.Name = "lblRestartTemplateAfterEvery";
            lblRestartTemplateAfterEvery.Size = new System.Drawing.Size(325, 15);
            lblRestartTemplateAfterEvery.TabIndex = 21;
            lblRestartTemplateAfterEvery.Text = "Restart Template after every (0 means do not restart sampes)";
            // 
            // cbUsers
            // 
            cbUsers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbUsers.FormattingEnabled = true;
            cbUsers.Location = new System.Drawing.Point(444, 105);
            cbUsers.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cbUsers.Name = "cbUsers";
            cbUsers.Size = new System.Drawing.Size(193, 23);
            cbUsers.TabIndex = 14;
            // 
            // lblAutoLogin
            // 
            lblAutoLogin.AutoSize = true;
            lblAutoLogin.Location = new System.Drawing.Point(6, 108);
            lblAutoLogin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblAutoLogin.Name = "lblAutoLogin";
            lblAutoLogin.Size = new System.Drawing.Size(63, 15);
            lblAutoLogin.TabIndex = 12;
            lblAutoLogin.Text = "Auto login";
            // 
            // tpDatabaseOptions
            // 
            tpDatabaseOptions.Controls.Add(btnGenerateConfigFile);
            tpDatabaseOptions.Controls.Add(lblWorkstationId);
            tpDatabaseOptions.Controls.Add(tbWorkstationId);
            tpDatabaseOptions.Controls.Add(lblApplicationName);
            tpDatabaseOptions.Controls.Add(tbApplicationName);
            tpDatabaseOptions.Controls.Add(chkPooling);
            tpDatabaseOptions.Controls.Add(chkEncrypt);
            tpDatabaseOptions.Controls.Add(lblConnectionTimeout);
            tpDatabaseOptions.Controls.Add(nudConnectionTimeout);
            tpDatabaseOptions.Controls.Add(lblPassword);
            tpDatabaseOptions.Controls.Add(tbPassword);
            tpDatabaseOptions.Controls.Add(chkIntegratedSecurity);
            tpDatabaseOptions.Controls.Add(tbDatabaseFolder);
            tpDatabaseOptions.Controls.Add(tbDatabaseUsage);
            tpDatabaseOptions.Controls.Add(btnChangeDatabaseDirectory);
            tpDatabaseOptions.Controls.Add(lblUsage);
            tpDatabaseOptions.Controls.Add(lblDatabaseName);
            tpDatabaseOptions.Controls.Add(tbDatabaseName);
            tpDatabaseOptions.Controls.Add(lblUsername);
            tpDatabaseOptions.Controls.Add(tbUsername);
            tpDatabaseOptions.Controls.Add(lblDataSource);
            tpDatabaseOptions.Controls.Add(tbDataSource);
            tpDatabaseOptions.Location = new System.Drawing.Point(4, 24);
            tpDatabaseOptions.Name = "tpDatabaseOptions";
            tpDatabaseOptions.Padding = new System.Windows.Forms.Padding(3);
            tpDatabaseOptions.Size = new System.Drawing.Size(647, 437);
            tpDatabaseOptions.TabIndex = 1;
            tpDatabaseOptions.Text = "Database";
            tpDatabaseOptions.UseVisualStyleBackColor = true;
            // 
            // btnGenerateConfigFile
            // 
            btnGenerateConfigFile.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btnGenerateConfigFile.Location = new System.Drawing.Point(8, 408);
            btnGenerateConfigFile.Name = "btnGenerateConfigFile";
            btnGenerateConfigFile.Size = new System.Drawing.Size(244, 23);
            btnGenerateConfigFile.TabIndex = 25;
            btnGenerateConfigFile.Text = "Generate config files";
            btnGenerateConfigFile.UseVisualStyleBackColor = true;
            btnGenerateConfigFile.Click += BtnGenerateConfigFile_Click;
            // 
            // lblWorkstationId
            // 
            lblWorkstationId.AutoSize = true;
            lblWorkstationId.BackColor = System.Drawing.Color.Transparent;
            lblWorkstationId.Location = new System.Drawing.Point(331, 163);
            lblWorkstationId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblWorkstationId.Name = "lblWorkstationId";
            lblWorkstationId.Size = new System.Drawing.Size(85, 15);
            lblWorkstationId.TabIndex = 23;
            lblWorkstationId.Text = "Workstation ID";
            lblWorkstationId.Visible = false;
            // 
            // tbWorkstationId
            // 
            tbWorkstationId.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tbWorkstationId.Location = new System.Drawing.Point(330, 183);
            tbWorkstationId.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tbWorkstationId.Name = "tbWorkstationId";
            tbWorkstationId.Size = new System.Drawing.Size(308, 23);
            tbWorkstationId.TabIndex = 24;
            tbWorkstationId.Visible = false;
            // 
            // lblApplicationName
            // 
            lblApplicationName.AutoSize = true;
            lblApplicationName.BackColor = System.Drawing.Color.Transparent;
            lblApplicationName.Location = new System.Drawing.Point(331, 106);
            lblApplicationName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblApplicationName.Name = "lblApplicationName";
            lblApplicationName.Size = new System.Drawing.Size(101, 15);
            lblApplicationName.TabIndex = 21;
            lblApplicationName.Text = "Application name";
            lblApplicationName.Visible = false;
            // 
            // tbApplicationName
            // 
            tbApplicationName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tbApplicationName.Location = new System.Drawing.Point(331, 129);
            tbApplicationName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tbApplicationName.Name = "tbApplicationName";
            tbApplicationName.Size = new System.Drawing.Size(307, 23);
            tbApplicationName.TabIndex = 22;
            tbApplicationName.Visible = false;
            // 
            // chkPooling
            // 
            chkPooling.AutoSize = true;
            chkPooling.Location = new System.Drawing.Point(498, 72);
            chkPooling.Name = "chkPooling";
            chkPooling.Size = new System.Drawing.Size(67, 19);
            chkPooling.TabIndex = 20;
            chkPooling.Text = "Pooling";
            chkPooling.UseVisualStyleBackColor = true;
            // 
            // chkEncrypt
            // 
            chkEncrypt.AutoSize = true;
            chkEncrypt.Location = new System.Drawing.Point(331, 72);
            chkEncrypt.Name = "chkEncrypt";
            chkEncrypt.Size = new System.Drawing.Size(66, 19);
            chkEncrypt.TabIndex = 19;
            chkEncrypt.Text = "Encrypt";
            chkEncrypt.UseVisualStyleBackColor = true;
            // 
            // lblConnectionTimeout
            // 
            lblConnectionTimeout.AutoSize = true;
            lblConnectionTimeout.Location = new System.Drawing.Point(8, 186);
            lblConnectionTimeout.Name = "lblConnectionTimeout";
            lblConnectionTimeout.Size = new System.Drawing.Size(114, 15);
            lblConnectionTimeout.TabIndex = 18;
            lblConnectionTimeout.Text = "Connection timeout";
            // 
            // nudConnectionTimeout
            // 
            nudConnectionTimeout.Location = new System.Drawing.Point(174, 184);
            nudConnectionTimeout.Maximum = new decimal(new int[] { int.MaxValue, 0, 0, 0 });
            nudConnectionTimeout.Minimum = new decimal(new int[] { int.MinValue, 0, 0, int.MinValue });
            nudConnectionTimeout.Name = "nudConnectionTimeout";
            nudConnectionTimeout.Size = new System.Drawing.Size(149, 23);
            nudConnectionTimeout.TabIndex = 17;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.BackColor = System.Drawing.Color.Transparent;
            lblPassword.Location = new System.Drawing.Point(7, 158);
            lblPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new System.Drawing.Size(57, 15);
            lblPassword.TabIndex = 15;
            lblPassword.Text = "Password";
            // 
            // tbPassword
            // 
            tbPassword.Location = new System.Drawing.Point(174, 155);
            tbPassword.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tbPassword.Name = "tbPassword";
            tbPassword.PasswordChar = '*';
            tbPassword.Size = new System.Drawing.Size(149, 23);
            tbPassword.TabIndex = 16;
            // 
            // chkIntegratedSecurity
            // 
            chkIntegratedSecurity.AutoSize = true;
            chkIntegratedSecurity.Location = new System.Drawing.Point(8, 102);
            chkIntegratedSecurity.Name = "chkIntegratedSecurity";
            chkIntegratedSecurity.Size = new System.Drawing.Size(124, 19);
            chkIntegratedSecurity.TabIndex = 14;
            chkIntegratedSecurity.Text = "Integrated security";
            chkIntegratedSecurity.UseVisualStyleBackColor = true;
            chkIntegratedSecurity.CheckedChanged += ChkIntegratedSecurity_CheckedChanged;
            // 
            // tbDatabaseFolder
            // 
            tbDatabaseFolder.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tbDatabaseFolder.Location = new System.Drawing.Point(7, 246);
            tbDatabaseFolder.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tbDatabaseFolder.Name = "tbDatabaseFolder";
            tbDatabaseFolder.PasswordChar = '*';
            tbDatabaseFolder.ReadOnly = true;
            tbDatabaseFolder.Size = new System.Drawing.Size(631, 23);
            tbDatabaseFolder.TabIndex = 13;
            tbDatabaseFolder.Visible = false;
            // 
            // tbDatabaseUsage
            // 
            tbDatabaseUsage.Location = new System.Drawing.Point(174, 68);
            tbDatabaseUsage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tbDatabaseUsage.Name = "tbDatabaseUsage";
            tbDatabaseUsage.ReadOnly = true;
            tbDatabaseUsage.Size = new System.Drawing.Size(149, 23);
            tbDatabaseUsage.TabIndex = 1;
            tbDatabaseUsage.TabStop = false;
            // 
            // btnChangeDatabaseDirectory
            // 
            btnChangeDatabaseDirectory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnChangeDatabaseDirectory.Location = new System.Drawing.Point(7, 213);
            btnChangeDatabaseDirectory.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnChangeDatabaseDirectory.Name = "btnChangeDatabaseDirectory";
            btnChangeDatabaseDirectory.Size = new System.Drawing.Size(316, 27);
            btnChangeDatabaseDirectory.TabIndex = 12;
            btnChangeDatabaseDirectory.Text = "Change databases folder";
            btnChangeDatabaseDirectory.UseVisualStyleBackColor = true;
            btnChangeDatabaseDirectory.Visible = false;
            btnChangeDatabaseDirectory.Click += BtnChangeDatabaseDirectory_Click;
            // 
            // lblUsage
            // 
            lblUsage.AutoSize = true;
            lblUsage.BackColor = System.Drawing.Color.Transparent;
            lblUsage.Location = new System.Drawing.Point(7, 71);
            lblUsage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblUsage.Name = "lblUsage";
            lblUsage.Size = new System.Drawing.Size(39, 15);
            lblUsage.TabIndex = 0;
            lblUsage.Text = "Usage";
            // 
            // lblDatabaseName
            // 
            lblDatabaseName.AutoSize = true;
            lblDatabaseName.BackColor = System.Drawing.Color.Transparent;
            lblDatabaseName.Location = new System.Drawing.Point(7, 38);
            lblDatabaseName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblDatabaseName.Name = "lblDatabaseName";
            lblDatabaseName.Size = new System.Drawing.Size(88, 15);
            lblDatabaseName.TabIndex = 2;
            lblDatabaseName.Text = "Database name";
            // 
            // tbDatabaseName
            // 
            tbDatabaseName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tbDatabaseName.Location = new System.Drawing.Point(174, 35);
            tbDatabaseName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tbDatabaseName.Name = "tbDatabaseName";
            tbDatabaseName.Size = new System.Drawing.Size(464, 23);
            tbDatabaseName.TabIndex = 3;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.BackColor = System.Drawing.Color.Transparent;
            lblUsername.Location = new System.Drawing.Point(7, 129);
            lblUsername.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new System.Drawing.Size(60, 15);
            lblUsername.TabIndex = 4;
            lblUsername.Text = "Username";
            // 
            // tbUsername
            // 
            tbUsername.Location = new System.Drawing.Point(174, 126);
            tbUsername.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tbUsername.Name = "tbUsername";
            tbUsername.Size = new System.Drawing.Size(149, 23);
            tbUsername.TabIndex = 5;
            // 
            // lblDataSource
            // 
            lblDataSource.AutoSize = true;
            lblDataSource.BackColor = System.Drawing.Color.Transparent;
            lblDataSource.Location = new System.Drawing.Point(7, 9);
            lblDataSource.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblDataSource.Name = "lblDataSource";
            lblDataSource.Size = new System.Drawing.Size(70, 15);
            lblDataSource.TabIndex = 8;
            lblDataSource.Text = "Data Source";
            // 
            // tbDataSource
            // 
            tbDataSource.Location = new System.Drawing.Point(174, 6);
            tbDataSource.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tbDataSource.Name = "tbDataSource";
            tbDataSource.ReadOnly = true;
            tbDataSource.Size = new System.Drawing.Size(464, 23);
            tbDataSource.TabIndex = 9;
            tbDataSource.Text = "127.0.0.1";
            // 
            // tpLogging
            // 
            tpLogging.Controls.Add(rbVerboseLogEveryEvents);
            tpLogging.Controls.Add(lblMinutes);
            tpLogging.Controls.Add(rbVerboseLogOnlyErrors);
            tpLogging.Controls.Add(nudStatisticMessageAfterEveryMinutes);
            tpLogging.Controls.Add(chkVerboseDebugLogging);
            tpLogging.Controls.Add(lblStatisticMessageAfterEvery);
            tpLogging.Location = new System.Drawing.Point(4, 24);
            tpLogging.Name = "tpLogging";
            tpLogging.Size = new System.Drawing.Size(647, 437);
            tpLogging.TabIndex = 2;
            tpLogging.Text = "Logging";
            tpLogging.UseVisualStyleBackColor = true;
            // 
            // rbVerboseLogEveryEvents
            // 
            rbVerboseLogEveryEvents.AutoSize = true;
            rbVerboseLogEveryEvents.Enabled = false;
            rbVerboseLogEveryEvents.Location = new System.Drawing.Point(30, 70);
            rbVerboseLogEveryEvents.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            rbVerboseLogEveryEvents.Name = "rbVerboseLogEveryEvents";
            rbVerboseLogEveryEvents.Size = new System.Drawing.Size(154, 19);
            rbVerboseLogEveryEvents.TabIndex = 2;
            rbVerboseLogEveryEvents.Text = "Verbose log every events";
            rbVerboseLogEveryEvents.UseVisualStyleBackColor = true;
            // 
            // lblMinutes
            // 
            lblMinutes.AutoSize = true;
            lblMinutes.Location = new System.Drawing.Point(305, 125);
            lblMinutes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblMinutes.Name = "lblMinutes";
            lblMinutes.Size = new System.Drawing.Size(58, 15);
            lblMinutes.TabIndex = 14;
            lblMinutes.Text = "minute(s)";
            // 
            // rbVerboseLogOnlyErrors
            // 
            rbVerboseLogOnlyErrors.AutoSize = true;
            rbVerboseLogOnlyErrors.Checked = true;
            rbVerboseLogOnlyErrors.Enabled = false;
            rbVerboseLogOnlyErrors.Location = new System.Drawing.Point(30, 44);
            rbVerboseLogOnlyErrors.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            rbVerboseLogOnlyErrors.Name = "rbVerboseLogOnlyErrors";
            rbVerboseLogOnlyErrors.Size = new System.Drawing.Size(145, 19);
            rbVerboseLogOnlyErrors.TabIndex = 1;
            rbVerboseLogOnlyErrors.TabStop = true;
            rbVerboseLogOnlyErrors.Text = "Verbose log only errors";
            rbVerboseLogOnlyErrors.UseVisualStyleBackColor = true;
            // 
            // nudStatisticMessageAfterEveryMinutes
            // 
            nudStatisticMessageAfterEveryMinutes.Location = new System.Drawing.Point(215, 123);
            nudStatisticMessageAfterEveryMinutes.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            nudStatisticMessageAfterEveryMinutes.Maximum = new decimal(new int[] { 35791, 0, 0, 0 });
            nudStatisticMessageAfterEveryMinutes.Name = "nudStatisticMessageAfterEveryMinutes";
            nudStatisticMessageAfterEveryMinutes.Size = new System.Drawing.Size(82, 23);
            nudStatisticMessageAfterEveryMinutes.TabIndex = 13;
            nudStatisticMessageAfterEveryMinutes.Value = new decimal(new int[] { 1440, 0, 0, 0 });
            // 
            // chkVerboseDebugLogging
            // 
            chkVerboseDebugLogging.AutoSize = true;
            chkVerboseDebugLogging.Location = new System.Drawing.Point(9, 18);
            chkVerboseDebugLogging.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chkVerboseDebugLogging.Name = "chkVerboseDebugLogging";
            chkVerboseDebugLogging.Size = new System.Drawing.Size(148, 19);
            chkVerboseDebugLogging.TabIndex = 0;
            chkVerboseDebugLogging.Text = "Verbose debug logging";
            chkVerboseDebugLogging.UseVisualStyleBackColor = true;
            // 
            // lblStatisticMessageAfterEvery
            // 
            lblStatisticMessageAfterEvery.AutoSize = true;
            lblStatisticMessageAfterEvery.Location = new System.Drawing.Point(9, 125);
            lblStatisticMessageAfterEvery.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblStatisticMessageAfterEvery.Name = "lblStatisticMessageAfterEvery";
            lblStatisticMessageAfterEvery.Size = new System.Drawing.Size(158, 15);
            lblStatisticMessageAfterEvery.TabIndex = 12;
            lblStatisticMessageAfterEvery.Text = "Statistic message after every ";
            // 
            // tpVideo
            // 
            tpVideo.Controls.Add(lblFps);
            tpVideo.Controls.Add(nudFPS);
            tpVideo.Controls.Add(lblSeconds);
            tpVideo.Controls.Add(nudMaximumTimeToWaitForNewPicture);
            tpVideo.Controls.Add(lblMaximumTimeToWaitForNewPicture);
            tpVideo.Controls.Add(lblMilliseconds3);
            tpVideo.Controls.Add(nudMaximumDeflectionBetweenLiveViewAndRecorder);
            tpVideo.Controls.Add(lblMaximumDeflectionBetweenLiveViewAndRecorder);
            tpVideo.Controls.Add(lblMilliseconds2);
            tpVideo.Controls.Add(lblMilliseconds);
            tpVideo.Controls.Add(nudTimeBetweenCheckVideoServers);
            tpVideo.Controls.Add(lblTimeBetweenCheckVideoServers);
            tpVideo.Controls.Add(nudMaximumTimeToWaitForAVideoServerIs);
            tpVideo.Controls.Add(lblMaximumTimeToWaitForAVideoServerIs);
            tpVideo.Controls.Add(chkDeblock);
            tpVideo.Controls.Add(chkThreading);
            tpVideo.Controls.Add(chkReduceSequenceUsageOfNetworkAndCPU);
            tpVideo.Controls.Add(chkCloseSequenceApplicationOnFullScreenDisplayDevice);
            tpVideo.Controls.Add(chkLiveView);
            tpVideo.Controls.Add(gbNoSignalImage);
            tpVideo.Location = new System.Drawing.Point(4, 24);
            tpVideo.Name = "tpVideo";
            tpVideo.Size = new System.Drawing.Size(647, 437);
            tpVideo.TabIndex = 3;
            tpVideo.Text = "Video";
            tpVideo.UseVisualStyleBackColor = true;
            // 
            // lblFps
            // 
            lblFps.AutoSize = true;
            lblFps.Location = new System.Drawing.Point(3, 111);
            lblFps.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblFps.Name = "lblFps";
            lblFps.Size = new System.Drawing.Size(26, 15);
            lblFps.TabIndex = 47;
            lblFps.Text = "FPS";
            // 
            // nudFPS
            // 
            nudFPS.Location = new System.Drawing.Point(295, 109);
            nudFPS.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            nudFPS.Maximum = new decimal(new int[] { 25, 0, 0, 0 });
            nudFPS.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudFPS.Name = "nudFPS";
            nudFPS.Size = new System.Drawing.Size(82, 23);
            nudFPS.TabIndex = 48;
            nudFPS.Value = new decimal(new int[] { 25, 0, 0, 0 });
            // 
            // lblSeconds
            // 
            lblSeconds.AutoSize = true;
            lblSeconds.Location = new System.Drawing.Point(385, 86);
            lblSeconds.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblSeconds.Name = "lblSeconds";
            lblSeconds.Size = new System.Drawing.Size(58, 15);
            lblSeconds.TabIndex = 46;
            lblSeconds.Text = "second(s)";
            // 
            // nudMaximumTimeToWaitForNewPicture
            // 
            nudMaximumTimeToWaitForNewPicture.Location = new System.Drawing.Point(295, 84);
            nudMaximumTimeToWaitForNewPicture.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            nudMaximumTimeToWaitForNewPicture.Maximum = new decimal(new int[] { 600, 0, 0, 0 });
            nudMaximumTimeToWaitForNewPicture.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudMaximumTimeToWaitForNewPicture.Name = "nudMaximumTimeToWaitForNewPicture";
            nudMaximumTimeToWaitForNewPicture.Size = new System.Drawing.Size(82, 23);
            nudMaximumTimeToWaitForNewPicture.TabIndex = 45;
            nudMaximumTimeToWaitForNewPicture.Value = new decimal(new int[] { 300, 0, 0, 0 });
            // 
            // lblMaximumTimeToWaitForNewPicture
            // 
            lblMaximumTimeToWaitForNewPicture.AutoSize = true;
            lblMaximumTimeToWaitForNewPicture.Location = new System.Drawing.Point(2, 86);
            lblMaximumTimeToWaitForNewPicture.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblMaximumTimeToWaitForNewPicture.Name = "lblMaximumTimeToWaitForNewPicture";
            lblMaximumTimeToWaitForNewPicture.Size = new System.Drawing.Size(210, 15);
            lblMaximumTimeToWaitForNewPicture.TabIndex = 44;
            lblMaximumTimeToWaitForNewPicture.Text = "Maximum time to wait for new picture";
            // 
            // lblMilliseconds3
            // 
            lblMilliseconds3.AutoSize = true;
            lblMilliseconds3.Location = new System.Drawing.Point(385, 61);
            lblMilliseconds3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblMilliseconds3.Name = "lblMilliseconds3";
            lblMilliseconds3.Size = new System.Drawing.Size(81, 15);
            lblMilliseconds3.TabIndex = 43;
            lblMilliseconds3.Text = "millisecond(s)";
            // 
            // nudMaximumDeflectionBetweenLiveViewAndRecorder
            // 
            nudMaximumDeflectionBetweenLiveViewAndRecorder.Location = new System.Drawing.Point(295, 59);
            nudMaximumDeflectionBetweenLiveViewAndRecorder.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            nudMaximumDeflectionBetweenLiveViewAndRecorder.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            nudMaximumDeflectionBetweenLiveViewAndRecorder.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            nudMaximumDeflectionBetweenLiveViewAndRecorder.Name = "nudMaximumDeflectionBetweenLiveViewAndRecorder";
            nudMaximumDeflectionBetweenLiveViewAndRecorder.Size = new System.Drawing.Size(82, 23);
            nudMaximumDeflectionBetweenLiveViewAndRecorder.TabIndex = 42;
            nudMaximumDeflectionBetweenLiveViewAndRecorder.Value = new decimal(new int[] { 5000, 0, 0, 0 });
            // 
            // lblMaximumDeflectionBetweenLiveViewAndRecorder
            // 
            lblMaximumDeflectionBetweenLiveViewAndRecorder.AutoSize = true;
            lblMaximumDeflectionBetweenLiveViewAndRecorder.Location = new System.Drawing.Point(2, 61);
            lblMaximumDeflectionBetweenLiveViewAndRecorder.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblMaximumDeflectionBetweenLiveViewAndRecorder.Name = "lblMaximumDeflectionBetweenLiveViewAndRecorder";
            lblMaximumDeflectionBetweenLiveViewAndRecorder.Size = new System.Drawing.Size(283, 15);
            lblMaximumDeflectionBetweenLiveViewAndRecorder.TabIndex = 41;
            lblMaximumDeflectionBetweenLiveViewAndRecorder.Text = "Maximum deflection between live view and recorder";
            // 
            // lblMilliseconds2
            // 
            lblMilliseconds2.AutoSize = true;
            lblMilliseconds2.Location = new System.Drawing.Point(385, 36);
            lblMilliseconds2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblMilliseconds2.Name = "lblMilliseconds2";
            lblMilliseconds2.Size = new System.Drawing.Size(81, 15);
            lblMilliseconds2.TabIndex = 40;
            lblMilliseconds2.Text = "millisecond(s)";
            // 
            // lblMilliseconds
            // 
            lblMilliseconds.AutoSize = true;
            lblMilliseconds.Location = new System.Drawing.Point(385, 11);
            lblMilliseconds.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblMilliseconds.Name = "lblMilliseconds";
            lblMilliseconds.Size = new System.Drawing.Size(81, 15);
            lblMilliseconds.TabIndex = 37;
            lblMilliseconds.Text = "millisecond(s)";
            // 
            // nudTimeBetweenCheckVideoServers
            // 
            nudTimeBetweenCheckVideoServers.Location = new System.Drawing.Point(295, 9);
            nudTimeBetweenCheckVideoServers.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            nudTimeBetweenCheckVideoServers.Maximum = new decimal(new int[] { 600000, 0, 0, 0 });
            nudTimeBetweenCheckVideoServers.Minimum = new decimal(new int[] { 1000, 0, 0, 0 });
            nudTimeBetweenCheckVideoServers.Name = "nudTimeBetweenCheckVideoServers";
            nudTimeBetweenCheckVideoServers.Size = new System.Drawing.Size(82, 23);
            nudTimeBetweenCheckVideoServers.TabIndex = 36;
            nudTimeBetweenCheckVideoServers.Value = new decimal(new int[] { 3000, 0, 0, 0 });
            // 
            // lblTimeBetweenCheckVideoServers
            // 
            lblTimeBetweenCheckVideoServers.AutoSize = true;
            lblTimeBetweenCheckVideoServers.Location = new System.Drawing.Point(3, 11);
            lblTimeBetweenCheckVideoServers.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblTimeBetweenCheckVideoServers.Name = "lblTimeBetweenCheckVideoServers";
            lblTimeBetweenCheckVideoServers.Size = new System.Drawing.Size(187, 15);
            lblTimeBetweenCheckVideoServers.TabIndex = 35;
            lblTimeBetweenCheckVideoServers.Text = "Time between check video servers";
            // 
            // nudMaximumTimeToWaitForAVideoServerIs
            // 
            nudMaximumTimeToWaitForAVideoServerIs.Location = new System.Drawing.Point(295, 34);
            nudMaximumTimeToWaitForAVideoServerIs.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            nudMaximumTimeToWaitForAVideoServerIs.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            nudMaximumTimeToWaitForAVideoServerIs.Minimum = new decimal(new int[] { 100, 0, 0, 0 });
            nudMaximumTimeToWaitForAVideoServerIs.Name = "nudMaximumTimeToWaitForAVideoServerIs";
            nudMaximumTimeToWaitForAVideoServerIs.Size = new System.Drawing.Size(82, 23);
            nudMaximumTimeToWaitForAVideoServerIs.TabIndex = 39;
            nudMaximumTimeToWaitForAVideoServerIs.Value = new decimal(new int[] { 5000, 0, 0, 0 });
            // 
            // lblMaximumTimeToWaitForAVideoServerIs
            // 
            lblMaximumTimeToWaitForAVideoServerIs.AutoSize = true;
            lblMaximumTimeToWaitForAVideoServerIs.Location = new System.Drawing.Point(3, 36);
            lblMaximumTimeToWaitForAVideoServerIs.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblMaximumTimeToWaitForAVideoServerIs.Name = "lblMaximumTimeToWaitForAVideoServerIs";
            lblMaximumTimeToWaitForAVideoServerIs.Size = new System.Drawing.Size(231, 15);
            lblMaximumTimeToWaitForAVideoServerIs.TabIndex = 38;
            lblMaximumTimeToWaitForAVideoServerIs.Text = "Maximum time to wait for a video server is";
            // 
            // chkDeblock
            // 
            chkDeblock.AutoSize = true;
            chkDeblock.Location = new System.Drawing.Point(4, 192);
            chkDeblock.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chkDeblock.Name = "chkDeblock";
            chkDeblock.Size = new System.Drawing.Size(69, 19);
            chkDeblock.TabIndex = 34;
            chkDeblock.Text = "Deblock";
            chkDeblock.UseVisualStyleBackColor = true;
            // 
            // chkThreading
            // 
            chkThreading.AutoSize = true;
            chkThreading.Checked = true;
            chkThreading.CheckState = System.Windows.Forms.CheckState.Checked;
            chkThreading.Location = new System.Drawing.Point(4, 167);
            chkThreading.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chkThreading.Name = "chkThreading";
            chkThreading.Size = new System.Drawing.Size(80, 19);
            chkThreading.TabIndex = 33;
            chkThreading.Text = "Threading";
            chkThreading.UseVisualStyleBackColor = true;
            // 
            // chkReduceSequenceUsageOfNetworkAndCPU
            // 
            chkReduceSequenceUsageOfNetworkAndCPU.AutoSize = true;
            chkReduceSequenceUsageOfNetworkAndCPU.Location = new System.Drawing.Point(224, 167);
            chkReduceSequenceUsageOfNetworkAndCPU.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chkReduceSequenceUsageOfNetworkAndCPU.Name = "chkReduceSequenceUsageOfNetworkAndCPU";
            chkReduceSequenceUsageOfNetworkAndCPU.Size = new System.Drawing.Size(194, 19);
            chkReduceSequenceUsageOfNetworkAndCPU.TabIndex = 32;
            chkReduceSequenceUsageOfNetworkAndCPU.Text = "Reduce network and CPU usage";
            chkReduceSequenceUsageOfNetworkAndCPU.UseVisualStyleBackColor = true;
            // 
            // chkCloseSequenceApplicationOnFullScreenDisplayDevice
            // 
            chkCloseSequenceApplicationOnFullScreenDisplayDevice.AutoSize = true;
            chkCloseSequenceApplicationOnFullScreenDisplayDevice.Location = new System.Drawing.Point(224, 142);
            chkCloseSequenceApplicationOnFullScreenDisplayDevice.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chkCloseSequenceApplicationOnFullScreenDisplayDevice.Name = "chkCloseSequenceApplicationOnFullScreenDisplayDevice";
            chkCloseSequenceApplicationOnFullScreenDisplayDevice.Size = new System.Drawing.Size(318, 19);
            chkCloseSequenceApplicationOnFullScreenDisplayDevice.TabIndex = 28;
            chkCloseSequenceApplicationOnFullScreenDisplayDevice.Text = "Close sequence application on fullscreen display device";
            chkCloseSequenceApplicationOnFullScreenDisplayDevice.UseVisualStyleBackColor = true;
            // 
            // chkLiveView
            // 
            chkLiveView.AutoSize = true;
            chkLiveView.Location = new System.Drawing.Point(4, 142);
            chkLiveView.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chkLiveView.Name = "chkLiveView";
            chkLiveView.Size = new System.Drawing.Size(143, 19);
            chkLiveView.TabIndex = 25;
            chkLiveView.Text = "LiveView on fullscreen";
            chkLiveView.UseVisualStyleBackColor = true;
            // 
            // gbNoSignalImage
            // 
            gbNoSignalImage.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            gbNoSignalImage.Controls.Add(pbStatus);
            gbNoSignalImage.Controls.Add(chkUseCustomNoSignalImage);
            gbNoSignalImage.Controls.Add(pbNoSignalImage);
            gbNoSignalImage.Controls.Add(btnNoSignalImageBrowse);
            gbNoSignalImage.Location = new System.Drawing.Point(3, 217);
            gbNoSignalImage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbNoSignalImage.Name = "gbNoSignalImage";
            gbNoSignalImage.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbNoSignalImage.Size = new System.Drawing.Size(635, 208);
            gbNoSignalImage.TabIndex = 4;
            gbNoSignalImage.TabStop = false;
            gbNoSignalImage.Text = " ";
            // 
            // pbStatus
            // 
            pbStatus.BackgroundPaintDebounceIntervalInMs = 0;
            pbStatus.Location = new System.Drawing.Point(9, 7);
            pbStatus.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pbStatus.Name = "pbStatus";
            pbStatus.OriginalSize = new System.Drawing.Size(100, 50);
            pbStatus.PaintDebounceIntervalInMs = 0;
            pbStatus.RepositioningAndResizingControlsOnResize = false;
            pbStatus.ResizeDebounceIntervalInMs = 0;
            pbStatus.ShowPaintErrors = false;
            pbStatus.ShowResizeErrors = false;
            pbStatus.Size = new System.Drawing.Size(12, 12);
            pbStatus.TabIndex = 10;
            pbStatus.TabStop = false;
            pbStatus.Visible = false;
            // 
            // chkUseCustomNoSignalImage
            // 
            chkUseCustomNoSignalImage.AutoSize = true;
            chkUseCustomNoSignalImage.Location = new System.Drawing.Point(30, 1);
            chkUseCustomNoSignalImage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chkUseCustomNoSignalImage.Name = "chkUseCustomNoSignalImage";
            chkUseCustomNoSignalImage.Size = new System.Drawing.Size(216, 19);
            chkUseCustomNoSignalImage.TabIndex = 0;
            chkUseCustomNoSignalImage.Text = "\"No signal or no connection\" image";
            chkUseCustomNoSignalImage.UseVisualStyleBackColor = true;
            // 
            // pbNoSignalImage
            // 
            pbNoSignalImage.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            pbNoSignalImage.BackColor = System.Drawing.SystemColors.AppWorkspace;
            pbNoSignalImage.BackgroundPaintDebounceIntervalInMs = 0;
            pbNoSignalImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            pbNoSignalImage.Location = new System.Drawing.Point(8, 40);
            pbNoSignalImage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pbNoSignalImage.Name = "pbNoSignalImage";
            pbNoSignalImage.OriginalSize = new System.Drawing.Size(100, 50);
            pbNoSignalImage.PaintDebounceIntervalInMs = 0;
            pbNoSignalImage.RepositioningAndResizingControlsOnResize = false;
            pbNoSignalImage.ResizeDebounceIntervalInMs = 0;
            pbNoSignalImage.ShowPaintErrors = false;
            pbNoSignalImage.ShowResizeErrors = false;
            pbNoSignalImage.Size = new System.Drawing.Size(627, 162);
            pbNoSignalImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pbNoSignalImage.TabIndex = 19;
            pbNoSignalImage.TabStop = false;
            // 
            // btnNoSignalImageBrowse
            // 
            btnNoSignalImageBrowse.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnNoSignalImageBrowse.Enabled = false;
            btnNoSignalImageBrowse.Location = new System.Drawing.Point(544, 11);
            btnNoSignalImageBrowse.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnNoSignalImageBrowse.Name = "btnNoSignalImageBrowse";
            btnNoSignalImageBrowse.Size = new System.Drawing.Size(88, 27);
            btnNoSignalImageBrowse.TabIndex = 1;
            btnNoSignalImageBrowse.Text = "Browse";
            btnNoSignalImageBrowse.UseVisualStyleBackColor = true;
            // 
            // tpSerialOptions
            // 
            tpSerialOptions.Controls.Add(lblWatchdogPort);
            tpSerialOptions.Controls.Add(cbWatchdogPort);
            tpSerialOptions.Controls.Add(lblKBD300ACOMPort);
            tpSerialOptions.Controls.Add(cbKBD300ACOMPort);
            tpSerialOptions.Location = new System.Drawing.Point(4, 24);
            tpSerialOptions.Name = "tpSerialOptions";
            tpSerialOptions.Size = new System.Drawing.Size(647, 437);
            tpSerialOptions.TabIndex = 4;
            tpSerialOptions.Text = "Serial port";
            tpSerialOptions.UseVisualStyleBackColor = true;
            // 
            // lblWatchdogPort
            // 
            lblWatchdogPort.AutoSize = true;
            lblWatchdogPort.Location = new System.Drawing.Point(9, 10);
            lblWatchdogPort.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblWatchdogPort.Name = "lblWatchdogPort";
            lblWatchdogPort.Size = new System.Drawing.Size(87, 15);
            lblWatchdogPort.TabIndex = 31;
            lblWatchdogPort.Text = "Watchdog port";
            // 
            // cbWatchdogPort
            // 
            cbWatchdogPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbWatchdogPort.FormattingEnabled = true;
            cbWatchdogPort.Location = new System.Drawing.Point(9, 28);
            cbWatchdogPort.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cbWatchdogPort.Name = "cbWatchdogPort";
            cbWatchdogPort.Size = new System.Drawing.Size(193, 23);
            cbWatchdogPort.TabIndex = 30;
            // 
            // lblKBD300ACOMPort
            // 
            lblKBD300ACOMPort.AutoSize = true;
            lblKBD300ACOMPort.Location = new System.Drawing.Point(9, 63);
            lblKBD300ACOMPort.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblKBD300ACOMPort.Name = "lblKBD300ACOMPort";
            lblKBD300ACOMPort.Size = new System.Drawing.Size(111, 15);
            lblKBD300ACOMPort.TabIndex = 27;
            lblKBD300ACOMPort.Text = "KBD300A COM port";
            // 
            // cbKBD300ACOMPort
            // 
            cbKBD300ACOMPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbKBD300ACOMPort.FormattingEnabled = true;
            cbKBD300ACOMPort.Location = new System.Drawing.Point(9, 81);
            cbKBD300ACOMPort.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cbKBD300ACOMPort.Name = "cbKBD300ACOMPort";
            cbKBD300ACOMPort.Size = new System.Drawing.Size(193, 23);
            cbKBD300ACOMPort.TabIndex = 28;
            // 
            // btnStandard
            // 
            btnStandard.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btnStandard.Location = new System.Drawing.Point(134, 467);
            btnStandard.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnStandard.Name = "btnStandard";
            btnStandard.Size = new System.Drawing.Size(122, 27);
            btnStandard.TabIndex = 5;
            btnStandard.Text = "Standard";
            btnStandard.UseVisualStyleBackColor = true;
            btnStandard.Click += BtnStandard_Click;
            // 
            // btnDefault
            // 
            btnDefault.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btnDefault.Location = new System.Drawing.Point(4, 467);
            btnDefault.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnDefault.Name = "btnDefault";
            btnDefault.Size = new System.Drawing.Size(122, 27);
            btnDefault.TabIndex = 4;
            btnDefault.Text = "Default";
            btnDefault.UseVisualStyleBackColor = true;
            btnDefault.Click += BtnDefault_Click;
            // 
            // btnClose
            // 
            btnClose.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            btnClose.Location = new System.Drawing.Point(560, 467);
            btnClose.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnClose.Name = "btnClose";
            btnClose.Size = new System.Drawing.Size(88, 27);
            btnClose.TabIndex = 7;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += BtnClose_Click;
            // 
            // btnSave
            // 
            btnSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            btnSave.Location = new System.Drawing.Point(464, 467);
            btnSave.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(88, 27);
            btnSave.TabIndex = 6;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += BtnSave_Click;
            // 
            // GeneralOptionsForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(655, 501);
            Controls.Add(tabControl);
            Controls.Add(btnClose);
            Controls.Add(btnStandard);
            Controls.Add(btnDefault);
            Controls.Add(btnSave);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "GeneralOptionsForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "General options";
            Shown += GeneralOptionsForm_Shown;
            tabControl.ResumeLayout(false);
            tpGeneral.ResumeLayout(false);
            pMain.ResumeLayout(false);
            pMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudRestartTemplate).EndInit();
            tpDatabaseOptions.ResumeLayout(false);
            tpDatabaseOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudConnectionTimeout).EndInit();
            tpLogging.ResumeLayout(false);
            tpLogging.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudStatisticMessageAfterEveryMinutes).EndInit();
            tpVideo.ResumeLayout(false);
            tpVideo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudFPS).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudMaximumTimeToWaitForNewPicture).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudMaximumDeflectionBetweenLiveViewAndRecorder).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudTimeBetweenCheckVideoServers).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudMaximumTimeToWaitForAVideoServerIs).EndInit();
            gbNoSignalImage.ResumeLayout(false);
            gbNoSignalImage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbStatus).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbNoSignalImage).EndInit();
            tpSerialOptions.ResumeLayout(false);
            tpSerialOptions.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tpGeneral;
        private System.Windows.Forms.Panel pMain;
        private System.Windows.Forms.Button btnStandard;
        private System.Windows.Forms.Button btnDefault;
        private System.Windows.Forms.CheckBox chkOpenMotionPopupWhenProgramStarts;
        private System.Windows.Forms.Label lblMinutes2;
        private System.Windows.Forms.NumericUpDown nudRestartTemplate;
        private System.Windows.Forms.Label lblRestartTemplateAfterEvery;
        private System.Windows.Forms.ComboBox cbUsers;
        private System.Windows.Forms.Label lblAutoLogin;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;

/* Unmerged change from project 'LiveView (net481)'
Before:
        private System.Windows.Forms.TabPage tabPage2;
    }
After:
        private System.Windows.Forms.TabPage tpDatabaseOptions;
    }
*/
        private System.Windows.Forms.TabPage tpDatabaseOptions;
        private System.Windows.Forms.TabPage tpLogging;
        private System.Windows.Forms.TabPage tpVideo;
        private System.Windows.Forms.TabPage tpSerialOptions;
        private System.Windows.Forms.TextBox tbDatabaseUsage;
        private System.Windows.Forms.Button btnChangeDatabaseDirectory;
        private System.Windows.Forms.Label lblUsage;
        private System.Windows.Forms.Label lblDataSource;
        private System.Windows.Forms.TextBox tbDataSource;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox tbDatabaseName;
        private System.Windows.Forms.Label lblDatabaseName;
        private System.Windows.Forms.RadioButton rbVerboseLogEveryEvents;
        private System.Windows.Forms.RadioButton rbVerboseLogOnlyErrors;
        private System.Windows.Forms.CheckBox chkVerboseDebugLogging;
        private System.Windows.Forms.GroupBox gbNoSignalImage;
        private Mtf.Controls.MtfPictureBox pbStatus;
        private System.Windows.Forms.CheckBox chkUseCustomNoSignalImage;
        private Mtf.Controls.MtfPictureBox pbNoSignalImage;
        private System.Windows.Forms.Button btnNoSignalImageBrowse;
        private System.Windows.Forms.Label lblKBD300ACOMPort;
        private System.Windows.Forms.ComboBox cbKBD300ACOMPort;
        private System.Windows.Forms.CheckBox chkLiveView;
        private System.Windows.Forms.Label lblMinutes;
        private System.Windows.Forms.NumericUpDown nudStatisticMessageAfterEveryMinutes;
        private System.Windows.Forms.Label lblStatisticMessageAfterEvery;
        private System.Windows.Forms.Label lblMilliseconds2;
        private System.Windows.Forms.Label lblMilliseconds;
        private System.Windows.Forms.NumericUpDown nudTimeBetweenCheckVideoServers;
        private System.Windows.Forms.Label lblTimeBetweenCheckVideoServers;
        private System.Windows.Forms.NumericUpDown nudMaximumTimeToWaitForAVideoServerIs;
        private System.Windows.Forms.Label lblMaximumTimeToWaitForAVideoServerIs;
        private System.Windows.Forms.CheckBox chkDeblock;
        private System.Windows.Forms.CheckBox chkThreading;
        private System.Windows.Forms.CheckBox chkReduceSequenceUsageOfNetworkAndCPU;
        private System.Windows.Forms.CheckBox chkCloseSequenceApplicationOnFullScreenDisplayDevice;
        private System.Windows.Forms.Label lblMilliseconds3;
        private System.Windows.Forms.NumericUpDown nudMaximumDeflectionBetweenLiveViewAndRecorder;
        private System.Windows.Forms.Label lblMaximumDeflectionBetweenLiveViewAndRecorder;
        private System.Windows.Forms.Label lblFps;
        private System.Windows.Forms.NumericUpDown nudFPS;
        private System.Windows.Forms.Label lblSeconds;
        private System.Windows.Forms.NumericUpDown nudMaximumTimeToWaitForNewPicture;
        private System.Windows.Forms.Label lblMaximumTimeToWaitForNewPicture;
        private System.Windows.Forms.TextBox tbDatabaseFolder;
        private System.Windows.Forms.CheckBox chkIntegratedSecurity;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label lblConnectionTimeout;
        private System.Windows.Forms.NumericUpDown nudConnectionTimeout;
        private System.Windows.Forms.CheckBox chkEncrypt;
        private System.Windows.Forms.CheckBox chkPooling;
        private System.Windows.Forms.Label lblWorkstationId;
        private System.Windows.Forms.TextBox tbWorkstationId;
        private System.Windows.Forms.Label lblApplicationName;
        private System.Windows.Forms.TextBox tbApplicationName;
        private System.Windows.Forms.Button btnGenerateConfigFile;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.CheckBox chkOpenControlCenterWhenProgramStarts;
        private System.Windows.Forms.ComboBox cbAutoLoadedTemplate;
        private System.Windows.Forms.Label lblAutoLoadedTemplate;
        private System.Windows.Forms.ComboBox cbWatchdogPort;
        private System.Windows.Forms.Label lblWatchdogPort;
    }
}