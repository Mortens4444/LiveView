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
            chkReduceSequenceUsageOfNetworkAndCPU = new System.Windows.Forms.CheckBox();
            lblFps = new System.Windows.Forms.Label();
            nudFPS = new System.Windows.Forms.NumericUpDown();
            chkDeblock = new System.Windows.Forms.CheckBox();
            chkCloseSequenceApplicationOnFullScreenDisplayDevice = new System.Windows.Forms.CheckBox();
            lblKBD300ACOMPort = new System.Windows.Forms.Label();
            cbKBD300ACOMPort = new System.Windows.Forms.ComboBox();
            chkLiveView = new System.Windows.Forms.CheckBox();
            chkThreading = new System.Windows.Forms.CheckBox();
            chkOpenMotionPopupWhenProgramStarts = new System.Windows.Forms.CheckBox();
            lblMinutes2 = new System.Windows.Forms.Label();
            nudRestartTemplate = new System.Windows.Forms.NumericUpDown();
            lblRestartTemplateAfterEvery = new System.Windows.Forms.Label();
            cbUsers = new System.Windows.Forms.ComboBox();
            lblSeconds = new System.Windows.Forms.Label();
            gbDatabaseOptions = new System.Windows.Forms.GroupBox();
            tbDatabaseUsage = new System.Windows.Forms.TextBox();
            btnChangeDatabaseDirectory = new System.Windows.Forms.Button();
            tbDatabaseFolder = new System.Windows.Forms.TextBox();
            lblUsage = new System.Windows.Forms.Label();
            lblServerPort = new System.Windows.Forms.Label();
            nudDatabasePort = new System.Windows.Forms.NumericUpDown();
            lblServerNetworkAddress = new System.Windows.Forms.Label();
            tbDatabaseServerIp = new System.Windows.Forms.TextBox();
            tbPassword = new System.Windows.Forms.TextBox();
            lblPassword = new System.Windows.Forms.Label();
            tbUsername = new System.Windows.Forms.TextBox();
            lblUsername = new System.Windows.Forms.Label();
            tbDatabaseName = new System.Windows.Forms.TextBox();
            lblDatabaseName = new System.Windows.Forms.Label();
            lblMilliseconds3 = new System.Windows.Forms.Label();
            pbStatus = new Mtf.Controls.MtfPictureBox();
            nudMaximumTimeToWaitForNewPicture = new System.Windows.Forms.NumericUpDown();
            lblMaximumTimeToWaitForNewPicture = new System.Windows.Forms.Label();
            nudMaximumDeflectionBetweenLiveViewAndRecorder = new System.Windows.Forms.NumericUpDown();
            lblMaximumDeflectionBetweenLiveViewAndRecorder = new System.Windows.Forms.Label();
            lblAutologinIfLastStatisticMessageIsEarlierThan = new System.Windows.Forms.Label();
            lblMinutes = new System.Windows.Forms.Label();
            lblMilliseconds2 = new System.Windows.Forms.Label();
            lblMilliseconds = new System.Windows.Forms.Label();
            nudStatisticMessageAfterEveryMinutes = new System.Windows.Forms.NumericUpDown();
            lblStatisticMessageAfterEvery = new System.Windows.Forms.Label();
            btnStandard = new System.Windows.Forms.Button();
            btnDefault = new System.Windows.Forms.Button();
            pMain = new System.Windows.Forms.Panel();
            gbNoSignalImage = new System.Windows.Forms.GroupBox();
            chkUseCustomNoSignalImage = new System.Windows.Forms.CheckBox();
            pbNoSignalImage = new Mtf.Controls.MtfPictureBox();
            btnNoSignalImageBrowse = new System.Windows.Forms.Button();
            gbEventLogging = new System.Windows.Forms.GroupBox();
            rbVerboseLogEveryEvents = new System.Windows.Forms.RadioButton();
            rbVerboseLogOnlyErrors = new System.Windows.Forms.RadioButton();
            chkVerboseDebugLogging = new System.Windows.Forms.CheckBox();
            gbTechnicalOptions = new System.Windows.Forms.GroupBox();
            chkUseWatchDog = new System.Windows.Forms.CheckBox();
            nudTimeBetweenCheckVideoServers = new System.Windows.Forms.NumericUpDown();
            lblTimeBetweenCheckVideoServers = new System.Windows.Forms.Label();
            nudMaximumTimeToWaitForAVideoServerIs = new System.Windows.Forms.NumericUpDown();
            lblMaximumTimeToWaitForAVideoServerIs = new System.Windows.Forms.Label();
            btnClose = new System.Windows.Forms.Button();
            btnSave = new System.Windows.Forms.Button();
            folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)nudFPS).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudRestartTemplate).BeginInit();
            gbDatabaseOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudDatabasePort).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbStatus).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudMaximumTimeToWaitForNewPicture).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudMaximumDeflectionBetweenLiveViewAndRecorder).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudStatisticMessageAfterEveryMinutes).BeginInit();
            pMain.SuspendLayout();
            gbNoSignalImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbNoSignalImage).BeginInit();
            gbEventLogging.SuspendLayout();
            gbTechnicalOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudTimeBetweenCheckVideoServers).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudMaximumTimeToWaitForAVideoServerIs).BeginInit();
            SuspendLayout();
            // 
            // chkReduceSequenceUsageOfNetworkAndCPU
            // 
            chkReduceSequenceUsageOfNetworkAndCPU.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            chkReduceSequenceUsageOfNetworkAndCPU.AutoSize = true;
            chkReduceSequenceUsageOfNetworkAndCPU.Location = new System.Drawing.Point(463, 250);
            chkReduceSequenceUsageOfNetworkAndCPU.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chkReduceSequenceUsageOfNetworkAndCPU.Name = "chkReduceSequenceUsageOfNetworkAndCPU";
            chkReduceSequenceUsageOfNetworkAndCPU.Size = new System.Drawing.Size(194, 19);
            chkReduceSequenceUsageOfNetworkAndCPU.TabIndex = 31;
            chkReduceSequenceUsageOfNetworkAndCPU.Text = "Reduce network and CPU usage";
            chkReduceSequenceUsageOfNetworkAndCPU.UseVisualStyleBackColor = true;
            // 
            // lblFps
            // 
            lblFps.AutoSize = true;
            lblFps.Location = new System.Drawing.Point(8, 273);
            lblFps.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblFps.Name = "lblFps";
            lblFps.Size = new System.Drawing.Size(26, 15);
            lblFps.TabIndex = 28;
            lblFps.Text = "FPS";
            // 
            // nudFPS
            // 
            nudFPS.Location = new System.Drawing.Point(84, 271);
            nudFPS.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            nudFPS.Maximum = new decimal(new int[] { 25, 0, 0, 0 });
            nudFPS.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudFPS.Name = "nudFPS";
            nudFPS.Size = new System.Drawing.Size(82, 23);
            nudFPS.TabIndex = 29;
            nudFPS.Value = new decimal(new int[] { 25, 0, 0, 0 });
            // 
            // chkDeblock
            // 
            chkDeblock.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            chkDeblock.AutoSize = true;
            chkDeblock.Location = new System.Drawing.Point(463, 272);
            chkDeblock.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chkDeblock.Name = "chkDeblock";
            chkDeblock.Size = new System.Drawing.Size(69, 19);
            chkDeblock.TabIndex = 30;
            chkDeblock.Text = "Deblock";
            chkDeblock.UseVisualStyleBackColor = true;
            // 
            // chkCloseSequenceApplicationOnFullScreenDisplayDevice
            // 
            chkCloseSequenceApplicationOnFullScreenDisplayDevice.AutoSize = true;
            chkCloseSequenceApplicationOnFullScreenDisplayDevice.Location = new System.Drawing.Point(12, 250);
            chkCloseSequenceApplicationOnFullScreenDisplayDevice.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chkCloseSequenceApplicationOnFullScreenDisplayDevice.Name = "chkCloseSequenceApplicationOnFullScreenDisplayDevice";
            chkCloseSequenceApplicationOnFullScreenDisplayDevice.Size = new System.Drawing.Size(318, 19);
            chkCloseSequenceApplicationOnFullScreenDisplayDevice.TabIndex = 27;
            chkCloseSequenceApplicationOnFullScreenDisplayDevice.Text = "Close sequence application on fullscreen display device";
            chkCloseSequenceApplicationOnFullScreenDisplayDevice.UseVisualStyleBackColor = true;
            // 
            // lblKBD300ACOMPort
            // 
            lblKBD300ACOMPort.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lblKBD300ACOMPort.AutoSize = true;
            lblKBD300ACOMPort.Location = new System.Drawing.Point(341, 223);
            lblKBD300ACOMPort.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblKBD300ACOMPort.Name = "lblKBD300ACOMPort";
            lblKBD300ACOMPort.Size = new System.Drawing.Size(111, 15);
            lblKBD300ACOMPort.TabIndex = 25;
            lblKBD300ACOMPort.Text = "KBD300A COM port";
            // 
            // cbKBD300ACOMPort
            // 
            cbKBD300ACOMPort.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            cbKBD300ACOMPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbKBD300ACOMPort.FormattingEnabled = true;
            cbKBD300ACOMPort.Location = new System.Drawing.Point(463, 219);
            cbKBD300ACOMPort.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cbKBD300ACOMPort.Name = "cbKBD300ACOMPort";
            cbKBD300ACOMPort.Size = new System.Drawing.Size(193, 23);
            cbKBD300ACOMPort.TabIndex = 26;
            // 
            // chkLiveView
            // 
            chkLiveView.AutoSize = true;
            chkLiveView.Location = new System.Drawing.Point(12, 224);
            chkLiveView.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chkLiveView.Name = "chkLiveView";
            chkLiveView.Size = new System.Drawing.Size(143, 19);
            chkLiveView.TabIndex = 24;
            chkLiveView.Text = "LiveView on fullscreen";
            chkLiveView.UseVisualStyleBackColor = true;
            // 
            // chkThreading
            // 
            chkThreading.AutoSize = true;
            chkThreading.Checked = true;
            chkThreading.CheckState = System.Windows.Forms.CheckState.Checked;
            chkThreading.Location = new System.Drawing.Point(519, 20);
            chkThreading.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chkThreading.Name = "chkThreading";
            chkThreading.Size = new System.Drawing.Size(80, 19);
            chkThreading.TabIndex = 2;
            chkThreading.Text = "Threading";
            chkThreading.UseVisualStyleBackColor = true;
            // 
            // chkOpenMotionPopupWhenProgramStarts
            // 
            chkOpenMotionPopupWhenProgramStarts.AutoSize = true;
            chkOpenMotionPopupWhenProgramStarts.Location = new System.Drawing.Point(210, 20);
            chkOpenMotionPopupWhenProgramStarts.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chkOpenMotionPopupWhenProgramStarts.Name = "chkOpenMotionPopupWhenProgramStarts";
            chkOpenMotionPopupWhenProgramStarts.Size = new System.Drawing.Size(247, 19);
            chkOpenMotionPopupWhenProgramStarts.TabIndex = 1;
            chkOpenMotionPopupWhenProgramStarts.Text = "Open Motion Popup when program starts";
            chkOpenMotionPopupWhenProgramStarts.UseVisualStyleBackColor = true;
            // 
            // lblMinutes2
            // 
            lblMinutes2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lblMinutes2.AutoSize = true;
            lblMinutes2.Location = new System.Drawing.Point(552, 195);
            lblMinutes2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblMinutes2.Name = "lblMinutes2";
            lblMinutes2.Size = new System.Drawing.Size(58, 15);
            lblMinutes2.TabIndex = 23;
            lblMinutes2.Text = "minute(s)";
            // 
            // nudRestartTemplate
            // 
            nudRestartTemplate.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            nudRestartTemplate.Location = new System.Drawing.Point(463, 190);
            nudRestartTemplate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            nudRestartTemplate.Maximum = new decimal(new int[] { 35791, 0, 0, 0 });
            nudRestartTemplate.Name = "nudRestartTemplate";
            nudRestartTemplate.Size = new System.Drawing.Size(82, 23);
            nudRestartTemplate.TabIndex = 22;
            // 
            // lblRestartTemplateAfterEvery
            // 
            lblRestartTemplateAfterEvery.AutoSize = true;
            lblRestartTemplateAfterEvery.Location = new System.Drawing.Point(8, 195);
            lblRestartTemplateAfterEvery.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblRestartTemplateAfterEvery.Name = "lblRestartTemplateAfterEvery";
            lblRestartTemplateAfterEvery.Size = new System.Drawing.Size(325, 15);
            lblRestartTemplateAfterEvery.TabIndex = 21;
            lblRestartTemplateAfterEvery.Text = "Restart Template after every (0 means do not restart sampes)";
            // 
            // cbUsers
            // 
            cbUsers.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            cbUsers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbUsers.FormattingEnabled = true;
            cbUsers.Location = new System.Drawing.Point(463, 114);
            cbUsers.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cbUsers.Name = "cbUsers";
            cbUsers.Size = new System.Drawing.Size(193, 23);
            cbUsers.TabIndex = 14;
            // 
            // lblSeconds
            // 
            lblSeconds.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lblSeconds.AutoSize = true;
            lblSeconds.Location = new System.Drawing.Point(552, 170);
            lblSeconds.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblSeconds.Name = "lblSeconds";
            lblSeconds.Size = new System.Drawing.Size(58, 15);
            lblSeconds.TabIndex = 20;
            lblSeconds.Text = "second(s)";
            // 
            // gbDatabaseOptions
            // 
            gbDatabaseOptions.BackColor = System.Drawing.Color.Transparent;
            gbDatabaseOptions.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            gbDatabaseOptions.Controls.Add(tbDatabaseUsage);
            gbDatabaseOptions.Controls.Add(btnChangeDatabaseDirectory);
            gbDatabaseOptions.Controls.Add(tbDatabaseFolder);
            gbDatabaseOptions.Controls.Add(lblUsage);
            gbDatabaseOptions.Controls.Add(lblServerPort);
            gbDatabaseOptions.Controls.Add(nudDatabasePort);
            gbDatabaseOptions.Controls.Add(lblServerNetworkAddress);
            gbDatabaseOptions.Controls.Add(tbDatabaseServerIp);
            gbDatabaseOptions.Controls.Add(tbPassword);
            gbDatabaseOptions.Controls.Add(lblPassword);
            gbDatabaseOptions.Controls.Add(tbUsername);
            gbDatabaseOptions.Controls.Add(lblUsername);
            gbDatabaseOptions.Controls.Add(tbDatabaseName);
            gbDatabaseOptions.Controls.Add(lblDatabaseName);
            gbDatabaseOptions.Location = new System.Drawing.Point(0, 307);
            gbDatabaseOptions.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbDatabaseOptions.Name = "gbDatabaseOptions";
            gbDatabaseOptions.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbDatabaseOptions.Size = new System.Drawing.Size(362, 204);
            gbDatabaseOptions.TabIndex = 1;
            gbDatabaseOptions.TabStop = false;
            gbDatabaseOptions.Text = "Database options";
            // 
            // tbDatabaseUsage
            // 
            tbDatabaseUsage.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            tbDatabaseUsage.Location = new System.Drawing.Point(226, 18);
            tbDatabaseUsage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tbDatabaseUsage.Name = "tbDatabaseUsage";
            tbDatabaseUsage.ReadOnly = true;
            tbDatabaseUsage.Size = new System.Drawing.Size(126, 23);
            tbDatabaseUsage.TabIndex = 1;
            tbDatabaseUsage.TabStop = false;
            // 
            // btnChangeDatabaseDirectory
            // 
            btnChangeDatabaseDirectory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnChangeDatabaseDirectory.Location = new System.Drawing.Point(12, 167);
            btnChangeDatabaseDirectory.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnChangeDatabaseDirectory.Name = "btnChangeDatabaseDirectory";
            btnChangeDatabaseDirectory.Size = new System.Drawing.Size(208, 27);
            btnChangeDatabaseDirectory.TabIndex = 12;
            btnChangeDatabaseDirectory.Text = "Change databases folder";
            btnChangeDatabaseDirectory.UseVisualStyleBackColor = true;
            btnChangeDatabaseDirectory.Click += BtnChangeDatabaseDirectory_Click;
            // 
            // tbDatabaseFolder
            // 
            tbDatabaseFolder.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            tbDatabaseFolder.Location = new System.Drawing.Point(226, 170);
            tbDatabaseFolder.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tbDatabaseFolder.Name = "tbDatabaseFolder";
            tbDatabaseFolder.ReadOnly = true;
            tbDatabaseFolder.Size = new System.Drawing.Size(126, 23);
            tbDatabaseFolder.TabIndex = 13;
            tbDatabaseFolder.TabStop = false;
            // 
            // lblUsage
            // 
            lblUsage.AutoSize = true;
            lblUsage.BackColor = System.Drawing.Color.Transparent;
            lblUsage.Location = new System.Drawing.Point(8, 22);
            lblUsage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblUsage.Name = "lblUsage";
            lblUsage.Size = new System.Drawing.Size(39, 15);
            lblUsage.TabIndex = 0;
            lblUsage.Text = "Usage";
            // 
            // lblServerPort
            // 
            lblServerPort.AutoSize = true;
            lblServerPort.BackColor = System.Drawing.Color.Transparent;
            lblServerPort.Location = new System.Drawing.Point(8, 147);
            lblServerPort.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblServerPort.Name = "lblServerPort";
            lblServerPort.Size = new System.Drawing.Size(64, 15);
            lblServerPort.TabIndex = 10;
            lblServerPort.Text = "Server port";
            // 
            // nudDatabasePort
            // 
            nudDatabasePort.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            nudDatabasePort.Location = new System.Drawing.Point(226, 144);
            nudDatabasePort.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            nudDatabasePort.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            nudDatabasePort.Name = "nudDatabasePort";
            nudDatabasePort.Size = new System.Drawing.Size(127, 23);
            nudDatabasePort.TabIndex = 11;
            nudDatabasePort.Value = new decimal(new int[] { 2242, 0, 0, 0 });
            // 
            // lblServerNetworkAddress
            // 
            lblServerNetworkAddress.AutoSize = true;
            lblServerNetworkAddress.BackColor = System.Drawing.Color.Transparent;
            lblServerNetworkAddress.Location = new System.Drawing.Point(8, 122);
            lblServerNetworkAddress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblServerNetworkAddress.Name = "lblServerNetworkAddress";
            lblServerNetworkAddress.Size = new System.Drawing.Size(128, 15);
            lblServerNetworkAddress.TabIndex = 8;
            lblServerNetworkAddress.Text = "Server network address";
            // 
            // tbDatabaseServerIp
            // 
            tbDatabaseServerIp.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            tbDatabaseServerIp.Location = new System.Drawing.Point(226, 119);
            tbDatabaseServerIp.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tbDatabaseServerIp.Name = "tbDatabaseServerIp";
            tbDatabaseServerIp.Size = new System.Drawing.Size(126, 23);
            tbDatabaseServerIp.TabIndex = 9;
            tbDatabaseServerIp.Text = "127.0.0.1";
            // 
            // tbPassword
            // 
            tbPassword.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            tbPassword.Location = new System.Drawing.Point(226, 93);
            tbPassword.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tbPassword.Name = "tbPassword";
            tbPassword.PasswordChar = '*';
            tbPassword.Size = new System.Drawing.Size(126, 23);
            tbPassword.TabIndex = 7;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.BackColor = System.Drawing.Color.Transparent;
            lblPassword.Location = new System.Drawing.Point(8, 97);
            lblPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new System.Drawing.Size(57, 15);
            lblPassword.TabIndex = 6;
            lblPassword.Text = "Password";
            // 
            // tbUsername
            // 
            tbUsername.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            tbUsername.Location = new System.Drawing.Point(226, 68);
            tbUsername.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tbUsername.Name = "tbUsername";
            tbUsername.Size = new System.Drawing.Size(126, 23);
            tbUsername.TabIndex = 5;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.BackColor = System.Drawing.Color.Transparent;
            lblUsername.Location = new System.Drawing.Point(8, 72);
            lblUsername.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new System.Drawing.Size(60, 15);
            lblUsername.TabIndex = 4;
            lblUsername.Text = "Username";
            // 
            // tbDatabaseName
            // 
            tbDatabaseName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            tbDatabaseName.Location = new System.Drawing.Point(226, 43);
            tbDatabaseName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tbDatabaseName.Name = "tbDatabaseName";
            tbDatabaseName.Size = new System.Drawing.Size(126, 23);
            tbDatabaseName.TabIndex = 3;
            // 
            // lblDatabaseName
            // 
            lblDatabaseName.AutoSize = true;
            lblDatabaseName.BackColor = System.Drawing.Color.Transparent;
            lblDatabaseName.Location = new System.Drawing.Point(8, 46);
            lblDatabaseName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblDatabaseName.Name = "lblDatabaseName";
            lblDatabaseName.Size = new System.Drawing.Size(88, 15);
            lblDatabaseName.TabIndex = 2;
            lblDatabaseName.Text = "Database name";
            // 
            // lblMilliseconds3
            // 
            lblMilliseconds3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lblMilliseconds3.AutoSize = true;
            lblMilliseconds3.Location = new System.Drawing.Point(552, 144);
            lblMilliseconds3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblMilliseconds3.Name = "lblMilliseconds3";
            lblMilliseconds3.Size = new System.Drawing.Size(81, 15);
            lblMilliseconds3.TabIndex = 17;
            lblMilliseconds3.Text = "millisecond(s)";
            // 
            // pbStatus
            // 
            pbStatus.Location = new System.Drawing.Point(7, 27);
            pbStatus.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pbStatus.Name = "pbStatus";
            pbStatus.OriginalSize = new System.Drawing.Size(100, 50);
            pbStatus.RepositioningAndResizingControlsOnResize = false;
            pbStatus.Size = new System.Drawing.Size(12, 12);
            pbStatus.TabIndex = 10;
            pbStatus.TabStop = false;
            pbStatus.Visible = false;
            // 
            // nudMaximumTimeToWaitForNewPicture
            // 
            nudMaximumTimeToWaitForNewPicture.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            nudMaximumTimeToWaitForNewPicture.Location = new System.Drawing.Point(463, 165);
            nudMaximumTimeToWaitForNewPicture.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            nudMaximumTimeToWaitForNewPicture.Maximum = new decimal(new int[] { 600, 0, 0, 0 });
            nudMaximumTimeToWaitForNewPicture.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudMaximumTimeToWaitForNewPicture.Name = "nudMaximumTimeToWaitForNewPicture";
            nudMaximumTimeToWaitForNewPicture.Size = new System.Drawing.Size(82, 23);
            nudMaximumTimeToWaitForNewPicture.TabIndex = 19;
            nudMaximumTimeToWaitForNewPicture.Value = new decimal(new int[] { 300, 0, 0, 0 });
            // 
            // lblMaximumTimeToWaitForNewPicture
            // 
            lblMaximumTimeToWaitForNewPicture.AutoSize = true;
            lblMaximumTimeToWaitForNewPicture.Location = new System.Drawing.Point(8, 170);
            lblMaximumTimeToWaitForNewPicture.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblMaximumTimeToWaitForNewPicture.Name = "lblMaximumTimeToWaitForNewPicture";
            lblMaximumTimeToWaitForNewPicture.Size = new System.Drawing.Size(210, 15);
            lblMaximumTimeToWaitForNewPicture.TabIndex = 18;
            lblMaximumTimeToWaitForNewPicture.Text = "Maximum time to wait for new picture";
            // 
            // nudMaximumDeflectionBetweenLiveViewAndRecorder
            // 
            nudMaximumDeflectionBetweenLiveViewAndRecorder.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            nudMaximumDeflectionBetweenLiveViewAndRecorder.Location = new System.Drawing.Point(463, 140);
            nudMaximumDeflectionBetweenLiveViewAndRecorder.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            nudMaximumDeflectionBetweenLiveViewAndRecorder.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            nudMaximumDeflectionBetweenLiveViewAndRecorder.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            nudMaximumDeflectionBetweenLiveViewAndRecorder.Name = "nudMaximumDeflectionBetweenLiveViewAndRecorder";
            nudMaximumDeflectionBetweenLiveViewAndRecorder.Size = new System.Drawing.Size(82, 23);
            nudMaximumDeflectionBetweenLiveViewAndRecorder.TabIndex = 16;
            nudMaximumDeflectionBetweenLiveViewAndRecorder.Value = new decimal(new int[] { 5000, 0, 0, 0 });
            // 
            // lblMaximumDeflectionBetweenLiveViewAndRecorder
            // 
            lblMaximumDeflectionBetweenLiveViewAndRecorder.AutoSize = true;
            lblMaximumDeflectionBetweenLiveViewAndRecorder.Location = new System.Drawing.Point(8, 144);
            lblMaximumDeflectionBetweenLiveViewAndRecorder.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblMaximumDeflectionBetweenLiveViewAndRecorder.Name = "lblMaximumDeflectionBetweenLiveViewAndRecorder";
            lblMaximumDeflectionBetweenLiveViewAndRecorder.Size = new System.Drawing.Size(283, 15);
            lblMaximumDeflectionBetweenLiveViewAndRecorder.TabIndex = 15;
            lblMaximumDeflectionBetweenLiveViewAndRecorder.Text = "Maximum deflection between live view and recorder";
            // 
            // lblAutologinIfLastStatisticMessageIsEarlierThan
            // 
            lblAutologinIfLastStatisticMessageIsEarlierThan.AutoSize = true;
            lblAutologinIfLastStatisticMessageIsEarlierThan.Location = new System.Drawing.Point(8, 119);
            lblAutologinIfLastStatisticMessageIsEarlierThan.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblAutologinIfLastStatisticMessageIsEarlierThan.Name = "lblAutologinIfLastStatisticMessageIsEarlierThan";
            lblAutologinIfLastStatisticMessageIsEarlierThan.Size = new System.Drawing.Size(255, 15);
            lblAutologinIfLastStatisticMessageIsEarlierThan.TabIndex = 12;
            lblAutologinIfLastStatisticMessageIsEarlierThan.Text = "Autologin if last statistic message if earlier than";
            // 
            // lblMinutes
            // 
            lblMinutes.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lblMinutes.AutoSize = true;
            lblMinutes.Location = new System.Drawing.Point(552, 95);
            lblMinutes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblMinutes.Name = "lblMinutes";
            lblMinutes.Size = new System.Drawing.Size(58, 15);
            lblMinutes.TabIndex = 11;
            lblMinutes.Text = "minute(s)";
            // 
            // lblMilliseconds2
            // 
            lblMilliseconds2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lblMilliseconds2.AutoSize = true;
            lblMilliseconds2.Location = new System.Drawing.Point(552, 69);
            lblMilliseconds2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblMilliseconds2.Name = "lblMilliseconds2";
            lblMilliseconds2.Size = new System.Drawing.Size(81, 15);
            lblMilliseconds2.TabIndex = 8;
            lblMilliseconds2.Text = "millisecond(s)";
            // 
            // lblMilliseconds
            // 
            lblMilliseconds.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lblMilliseconds.AutoSize = true;
            lblMilliseconds.Location = new System.Drawing.Point(552, 44);
            lblMilliseconds.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblMilliseconds.Name = "lblMilliseconds";
            lblMilliseconds.Size = new System.Drawing.Size(81, 15);
            lblMilliseconds.TabIndex = 5;
            lblMilliseconds.Text = "millisecond(s)";
            // 
            // nudStatisticMessageAfterEveryMinutes
            // 
            nudStatisticMessageAfterEveryMinutes.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            nudStatisticMessageAfterEveryMinutes.Location = new System.Drawing.Point(463, 90);
            nudStatisticMessageAfterEveryMinutes.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            nudStatisticMessageAfterEveryMinutes.Maximum = new decimal(new int[] { 35791, 0, 0, 0 });
            nudStatisticMessageAfterEveryMinutes.Name = "nudStatisticMessageAfterEveryMinutes";
            nudStatisticMessageAfterEveryMinutes.Size = new System.Drawing.Size(82, 23);
            nudStatisticMessageAfterEveryMinutes.TabIndex = 10;
            nudStatisticMessageAfterEveryMinutes.Value = new decimal(new int[] { 1440, 0, 0, 0 });
            // 
            // lblStatisticMessageAfterEvery
            // 
            lblStatisticMessageAfterEvery.AutoSize = true;
            lblStatisticMessageAfterEvery.Location = new System.Drawing.Point(8, 95);
            lblStatisticMessageAfterEvery.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblStatisticMessageAfterEvery.Name = "lblStatisticMessageAfterEvery";
            lblStatisticMessageAfterEvery.Size = new System.Drawing.Size(158, 15);
            lblStatisticMessageAfterEvery.TabIndex = 9;
            lblStatisticMessageAfterEvery.Text = "Statistic message after every ";
            // 
            // btnStandard
            // 
            btnStandard.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btnStandard.Location = new System.Drawing.Point(99, 620);
            btnStandard.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnStandard.Name = "btnStandard";
            btnStandard.Size = new System.Drawing.Size(88, 27);
            btnStandard.TabIndex = 5;
            btnStandard.Text = "Standard";
            btnStandard.UseVisualStyleBackColor = true;
            btnStandard.Click += BtnStandard_Click;
            // 
            // btnDefault
            // 
            btnDefault.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btnDefault.Location = new System.Drawing.Point(5, 620);
            btnDefault.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnDefault.Name = "btnDefault";
            btnDefault.Size = new System.Drawing.Size(88, 27);
            btnDefault.TabIndex = 4;
            btnDefault.Text = "Default";
            btnDefault.UseVisualStyleBackColor = true;
            btnDefault.Click += BtnDefault_Click;
            // 
            // pMain
            // 
            pMain.Controls.Add(btnStandard);
            pMain.Controls.Add(btnDefault);
            pMain.Controls.Add(gbNoSignalImage);
            pMain.Controls.Add(gbEventLogging);
            pMain.Controls.Add(gbTechnicalOptions);
            pMain.Controls.Add(btnClose);
            pMain.Controls.Add(btnSave);
            pMain.Controls.Add(gbDatabaseOptions);
            pMain.Dock = System.Windows.Forms.DockStyle.Fill;
            pMain.Location = new System.Drawing.Point(0, 0);
            pMain.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pMain.Name = "pMain";
            pMain.Size = new System.Drawing.Size(701, 653);
            pMain.TabIndex = 1;
            // 
            // gbNoSignalImage
            // 
            gbNoSignalImage.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            gbNoSignalImage.Controls.Add(pbStatus);
            gbNoSignalImage.Controls.Add(chkUseCustomNoSignalImage);
            gbNoSignalImage.Controls.Add(pbNoSignalImage);
            gbNoSignalImage.Controls.Add(btnNoSignalImageBrowse);
            gbNoSignalImage.Location = new System.Drawing.Point(369, 307);
            gbNoSignalImage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbNoSignalImage.Name = "gbNoSignalImage";
            gbNoSignalImage.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbNoSignalImage.Size = new System.Drawing.Size(332, 309);
            gbNoSignalImage.TabIndex = 3;
            gbNoSignalImage.TabStop = false;
            gbNoSignalImage.Text = " ";
            // 
            // chkUseCustomNoSignalImage
            // 
            chkUseCustomNoSignalImage.AutoSize = true;
            chkUseCustomNoSignalImage.Location = new System.Drawing.Point(13, 1);
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
            pbNoSignalImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            pbNoSignalImage.Location = new System.Drawing.Point(7, 60);
            pbNoSignalImage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pbNoSignalImage.Name = "pbNoSignalImage";
            pbNoSignalImage.OriginalSize = new System.Drawing.Size(100, 50);
            pbNoSignalImage.RepositioningAndResizingControlsOnResize = false;
            pbNoSignalImage.Size = new System.Drawing.Size(317, 242);
            pbNoSignalImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pbNoSignalImage.TabIndex = 19;
            pbNoSignalImage.TabStop = false;
            // 
            // btnNoSignalImageBrowse
            // 
            btnNoSignalImageBrowse.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnNoSignalImageBrowse.Enabled = false;
            btnNoSignalImageBrowse.Location = new System.Drawing.Point(237, 27);
            btnNoSignalImageBrowse.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnNoSignalImageBrowse.Name = "btnNoSignalImageBrowse";
            btnNoSignalImageBrowse.Size = new System.Drawing.Size(88, 27);
            btnNoSignalImageBrowse.TabIndex = 1;
            btnNoSignalImageBrowse.Text = "Browse";
            btnNoSignalImageBrowse.UseVisualStyleBackColor = true;
            btnNoSignalImageBrowse.Click += BtnNoSignalImageBrowse_Click;
            // 
            // gbEventLogging
            // 
            gbEventLogging.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            gbEventLogging.Controls.Add(rbVerboseLogEveryEvents);
            gbEventLogging.Controls.Add(rbVerboseLogOnlyErrors);
            gbEventLogging.Controls.Add(chkVerboseDebugLogging);
            gbEventLogging.Location = new System.Drawing.Point(0, 513);
            gbEventLogging.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbEventLogging.Name = "gbEventLogging";
            gbEventLogging.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbEventLogging.Size = new System.Drawing.Size(362, 103);
            gbEventLogging.TabIndex = 2;
            gbEventLogging.TabStop = false;
            gbEventLogging.Text = "Event logging";
            // 
            // rbVerboseLogEveryEvents
            // 
            rbVerboseLogEveryEvents.AutoSize = true;
            rbVerboseLogEveryEvents.Enabled = false;
            rbVerboseLogEveryEvents.Location = new System.Drawing.Point(33, 74);
            rbVerboseLogEveryEvents.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            rbVerboseLogEveryEvents.Name = "rbVerboseLogEveryEvents";
            rbVerboseLogEveryEvents.Size = new System.Drawing.Size(154, 19);
            rbVerboseLogEveryEvents.TabIndex = 2;
            rbVerboseLogEveryEvents.Text = "Verbose log every events";
            rbVerboseLogEveryEvents.UseVisualStyleBackColor = true;
            // 
            // rbVerboseLogOnlyErrors
            // 
            rbVerboseLogOnlyErrors.AutoSize = true;
            rbVerboseLogOnlyErrors.Checked = true;
            rbVerboseLogOnlyErrors.Enabled = false;
            rbVerboseLogOnlyErrors.Location = new System.Drawing.Point(33, 48);
            rbVerboseLogOnlyErrors.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            rbVerboseLogOnlyErrors.Name = "rbVerboseLogOnlyErrors";
            rbVerboseLogOnlyErrors.Size = new System.Drawing.Size(145, 19);
            rbVerboseLogOnlyErrors.TabIndex = 1;
            rbVerboseLogOnlyErrors.TabStop = true;
            rbVerboseLogOnlyErrors.Text = "Verbose log only errors";
            rbVerboseLogOnlyErrors.UseVisualStyleBackColor = true;
            // 
            // chkVerboseDebugLogging
            // 
            chkVerboseDebugLogging.AutoSize = true;
            chkVerboseDebugLogging.Location = new System.Drawing.Point(12, 22);
            chkVerboseDebugLogging.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chkVerboseDebugLogging.Name = "chkVerboseDebugLogging";
            chkVerboseDebugLogging.Size = new System.Drawing.Size(148, 19);
            chkVerboseDebugLogging.TabIndex = 0;
            chkVerboseDebugLogging.Text = "Verbose debug logging";
            chkVerboseDebugLogging.UseVisualStyleBackColor = true;
            // 
            // gbTechnicalOptions
            // 
            gbTechnicalOptions.Controls.Add(chkReduceSequenceUsageOfNetworkAndCPU);
            gbTechnicalOptions.Controls.Add(lblFps);
            gbTechnicalOptions.Controls.Add(nudFPS);
            gbTechnicalOptions.Controls.Add(chkDeblock);
            gbTechnicalOptions.Controls.Add(chkCloseSequenceApplicationOnFullScreenDisplayDevice);
            gbTechnicalOptions.Controls.Add(lblKBD300ACOMPort);
            gbTechnicalOptions.Controls.Add(cbKBD300ACOMPort);
            gbTechnicalOptions.Controls.Add(chkLiveView);
            gbTechnicalOptions.Controls.Add(chkThreading);
            gbTechnicalOptions.Controls.Add(chkOpenMotionPopupWhenProgramStarts);
            gbTechnicalOptions.Controls.Add(lblMinutes2);
            gbTechnicalOptions.Controls.Add(nudRestartTemplate);
            gbTechnicalOptions.Controls.Add(lblRestartTemplateAfterEvery);
            gbTechnicalOptions.Controls.Add(cbUsers);
            gbTechnicalOptions.Controls.Add(lblSeconds);
            gbTechnicalOptions.Controls.Add(lblMilliseconds3);
            gbTechnicalOptions.Controls.Add(nudMaximumTimeToWaitForNewPicture);
            gbTechnicalOptions.Controls.Add(lblMaximumTimeToWaitForNewPicture);
            gbTechnicalOptions.Controls.Add(nudMaximumDeflectionBetweenLiveViewAndRecorder);
            gbTechnicalOptions.Controls.Add(lblMaximumDeflectionBetweenLiveViewAndRecorder);
            gbTechnicalOptions.Controls.Add(lblAutologinIfLastStatisticMessageIsEarlierThan);
            gbTechnicalOptions.Controls.Add(lblMinutes);
            gbTechnicalOptions.Controls.Add(lblMilliseconds2);
            gbTechnicalOptions.Controls.Add(lblMilliseconds);
            gbTechnicalOptions.Controls.Add(nudStatisticMessageAfterEveryMinutes);
            gbTechnicalOptions.Controls.Add(lblStatisticMessageAfterEvery);
            gbTechnicalOptions.Controls.Add(chkUseWatchDog);
            gbTechnicalOptions.Controls.Add(nudTimeBetweenCheckVideoServers);
            gbTechnicalOptions.Controls.Add(lblTimeBetweenCheckVideoServers);
            gbTechnicalOptions.Controls.Add(nudMaximumTimeToWaitForAVideoServerIs);
            gbTechnicalOptions.Controls.Add(lblMaximumTimeToWaitForAVideoServerIs);
            gbTechnicalOptions.Dock = System.Windows.Forms.DockStyle.Top;
            gbTechnicalOptions.Location = new System.Drawing.Point(0, 0);
            gbTechnicalOptions.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbTechnicalOptions.Name = "gbTechnicalOptions";
            gbTechnicalOptions.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbTechnicalOptions.Size = new System.Drawing.Size(701, 301);
            gbTechnicalOptions.TabIndex = 0;
            gbTechnicalOptions.TabStop = false;
            gbTechnicalOptions.Text = "Technical options";
            // 
            // chkUseWatchDog
            // 
            chkUseWatchDog.AutoSize = true;
            chkUseWatchDog.Location = new System.Drawing.Point(12, 20);
            chkUseWatchDog.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chkUseWatchDog.Name = "chkUseWatchDog";
            chkUseWatchDog.Size = new System.Drawing.Size(101, 19);
            chkUseWatchDog.TabIndex = 0;
            chkUseWatchDog.Text = "Use watchdog";
            chkUseWatchDog.UseVisualStyleBackColor = true;
            // 
            // nudTimeBetweenCheckVideoServers
            // 
            nudTimeBetweenCheckVideoServers.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            nudTimeBetweenCheckVideoServers.Location = new System.Drawing.Point(463, 39);
            nudTimeBetweenCheckVideoServers.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            nudTimeBetweenCheckVideoServers.Maximum = new decimal(new int[] { 600000, 0, 0, 0 });
            nudTimeBetweenCheckVideoServers.Minimum = new decimal(new int[] { 1000, 0, 0, 0 });
            nudTimeBetweenCheckVideoServers.Name = "nudTimeBetweenCheckVideoServers";
            nudTimeBetweenCheckVideoServers.Size = new System.Drawing.Size(82, 23);
            nudTimeBetweenCheckVideoServers.TabIndex = 4;
            nudTimeBetweenCheckVideoServers.Value = new decimal(new int[] { 3000, 0, 0, 0 });
            // 
            // lblTimeBetweenCheckVideoServers
            // 
            lblTimeBetweenCheckVideoServers.AutoSize = true;
            lblTimeBetweenCheckVideoServers.Location = new System.Drawing.Point(8, 44);
            lblTimeBetweenCheckVideoServers.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblTimeBetweenCheckVideoServers.Name = "lblTimeBetweenCheckVideoServers";
            lblTimeBetweenCheckVideoServers.Size = new System.Drawing.Size(187, 15);
            lblTimeBetweenCheckVideoServers.TabIndex = 3;
            lblTimeBetweenCheckVideoServers.Text = "Time between check video servers";
            // 
            // nudMaximumTimeToWaitForAVideoServerIs
            // 
            nudMaximumTimeToWaitForAVideoServerIs.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            nudMaximumTimeToWaitForAVideoServerIs.Location = new System.Drawing.Point(463, 65);
            nudMaximumTimeToWaitForAVideoServerIs.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            nudMaximumTimeToWaitForAVideoServerIs.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            nudMaximumTimeToWaitForAVideoServerIs.Minimum = new decimal(new int[] { 100, 0, 0, 0 });
            nudMaximumTimeToWaitForAVideoServerIs.Name = "nudMaximumTimeToWaitForAVideoServerIs";
            nudMaximumTimeToWaitForAVideoServerIs.Size = new System.Drawing.Size(82, 23);
            nudMaximumTimeToWaitForAVideoServerIs.TabIndex = 7;
            nudMaximumTimeToWaitForAVideoServerIs.Value = new decimal(new int[] { 5000, 0, 0, 0 });
            // 
            // lblMaximumTimeToWaitForAVideoServerIs
            // 
            lblMaximumTimeToWaitForAVideoServerIs.AutoSize = true;
            lblMaximumTimeToWaitForAVideoServerIs.Location = new System.Drawing.Point(8, 69);
            lblMaximumTimeToWaitForAVideoServerIs.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblMaximumTimeToWaitForAVideoServerIs.Name = "lblMaximumTimeToWaitForAVideoServerIs";
            lblMaximumTimeToWaitForAVideoServerIs.Size = new System.Drawing.Size(231, 15);
            lblMaximumTimeToWaitForAVideoServerIs.TabIndex = 6;
            lblMaximumTimeToWaitForAVideoServerIs.Text = "Maximum time to wait for a video server is";
            // 
            // btnClose
            // 
            btnClose.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            btnClose.Location = new System.Drawing.Point(605, 620);
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
            btnSave.Location = new System.Drawing.Point(506, 620);
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
            ClientSize = new System.Drawing.Size(701, 653);
            Controls.Add(pMain);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MinimumSize = new System.Drawing.Size(708, 678);
            Name = "GeneralOptionsForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "General options";
            Shown += GeneralOptionsForm_Shown;
            ((System.ComponentModel.ISupportInitialize)nudFPS).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudRestartTemplate).EndInit();
            gbDatabaseOptions.ResumeLayout(false);
            gbDatabaseOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudDatabasePort).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbStatus).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudMaximumTimeToWaitForNewPicture).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudMaximumDeflectionBetweenLiveViewAndRecorder).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudStatisticMessageAfterEveryMinutes).EndInit();
            pMain.ResumeLayout(false);
            gbNoSignalImage.ResumeLayout(false);
            gbNoSignalImage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbNoSignalImage).EndInit();
            gbEventLogging.ResumeLayout(false);
            gbEventLogging.PerformLayout();
            gbTechnicalOptions.ResumeLayout(false);
            gbTechnicalOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudTimeBetweenCheckVideoServers).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudMaximumTimeToWaitForAVideoServerIs).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.CheckBox chkReduceSequenceUsageOfNetworkAndCPU;
        private System.Windows.Forms.Label lblFps;
        private System.Windows.Forms.NumericUpDown nudFPS;
        private System.Windows.Forms.CheckBox chkDeblock;
        private System.Windows.Forms.CheckBox chkCloseSequenceApplicationOnFullScreenDisplayDevice;
        private System.Windows.Forms.Label lblKBD300ACOMPort;
        private System.Windows.Forms.ComboBox cbKBD300ACOMPort;
        private System.Windows.Forms.CheckBox chkLiveView;
        private System.Windows.Forms.CheckBox chkThreading;
        private System.Windows.Forms.CheckBox chkOpenMotionPopupWhenProgramStarts;
        private System.Windows.Forms.Label lblMinutes2;
        private System.Windows.Forms.NumericUpDown nudRestartTemplate;
        private System.Windows.Forms.Label lblRestartTemplateAfterEvery;
        private System.Windows.Forms.ComboBox cbUsers;
        private System.Windows.Forms.Label lblSeconds;
        private System.Windows.Forms.GroupBox gbDatabaseOptions;
        private System.Windows.Forms.TextBox tbDatabaseUsage;
        private System.Windows.Forms.Button btnChangeDatabaseDirectory;
        private System.Windows.Forms.TextBox tbDatabaseFolder;
        private System.Windows.Forms.Label lblUsage;
        private System.Windows.Forms.Label lblServerPort;
        private System.Windows.Forms.NumericUpDown nudDatabasePort;
        private System.Windows.Forms.Label lblServerNetworkAddress;
        private System.Windows.Forms.TextBox tbDatabaseServerIp;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox tbDatabaseName;
        private System.Windows.Forms.Label lblDatabaseName;
        private System.Windows.Forms.Label lblMilliseconds3;
        private Mtf.Controls.MtfPictureBox pbStatus;
        private System.Windows.Forms.NumericUpDown nudMaximumTimeToWaitForNewPicture;
        private System.Windows.Forms.Label lblMaximumTimeToWaitForNewPicture;
        private System.Windows.Forms.NumericUpDown nudMaximumDeflectionBetweenLiveViewAndRecorder;
        private System.Windows.Forms.Label lblMaximumDeflectionBetweenLiveViewAndRecorder;
        private System.Windows.Forms.Label lblAutologinIfLastStatisticMessageIsEarlierThan;
        private System.Windows.Forms.Label lblMinutes;
        private System.Windows.Forms.Label lblMilliseconds2;
        private System.Windows.Forms.Label lblMilliseconds;
        private System.Windows.Forms.NumericUpDown nudStatisticMessageAfterEveryMinutes;
        private System.Windows.Forms.Label lblStatisticMessageAfterEvery;
        private System.Windows.Forms.Button btnStandard;
        private System.Windows.Forms.Button btnDefault;
        private System.Windows.Forms.Panel pMain;
        private System.Windows.Forms.GroupBox gbNoSignalImage;
        private System.Windows.Forms.CheckBox chkUseCustomNoSignalImage;
        private Mtf.Controls.MtfPictureBox pbNoSignalImage;
        private System.Windows.Forms.Button btnNoSignalImageBrowse;
        private System.Windows.Forms.GroupBox gbEventLogging;
        private System.Windows.Forms.RadioButton rbVerboseLogEveryEvents;
        private System.Windows.Forms.RadioButton rbVerboseLogOnlyErrors;
        private System.Windows.Forms.CheckBox chkVerboseDebugLogging;
        private System.Windows.Forms.GroupBox gbTechnicalOptions;
        private System.Windows.Forms.CheckBox chkUseWatchDog;
        private System.Windows.Forms.NumericUpDown nudTimeBetweenCheckVideoServers;
        private System.Windows.Forms.Label lblTimeBetweenCheckVideoServers;
        private System.Windows.Forms.NumericUpDown nudMaximumTimeToWaitForAVideoServerIs;
        private System.Windows.Forms.Label lblMaximumTimeToWaitForAVideoServerIs;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}