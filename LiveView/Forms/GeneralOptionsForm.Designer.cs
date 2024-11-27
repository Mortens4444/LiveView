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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(GeneralOptionsForm));
            chk_ReduceSequenceUsageOfNetworkAndCPU = new System.Windows.Forms.CheckBox();
            lbl_FPS = new System.Windows.Forms.Label();
            nud_FPS = new System.Windows.Forms.NumericUpDown();
            chk_Deblock = new System.Windows.Forms.CheckBox();
            chk_CloseSequenceApplicationOnFullScreenDisplayDevice = new System.Windows.Forms.CheckBox();
            lbl_KBD300ACOMPort = new System.Windows.Forms.Label();
            cb_KBD300ACOMPort = new System.Windows.Forms.ComboBox();
            chk_LiveView = new System.Windows.Forms.CheckBox();
            chk_Threading = new System.Windows.Forms.CheckBox();
            chk_OpenMotionPopupWhenProgramStarts = new System.Windows.Forms.CheckBox();
            lbl_Minutes_2 = new System.Windows.Forms.Label();
            nud_RestartTemplate = new System.Windows.Forms.NumericUpDown();
            lbl_RestartTemplateAfterEvery = new System.Windows.Forms.Label();
            cb_UserID = new System.Windows.Forms.ComboBox();
            cb_Users = new System.Windows.Forms.ComboBox();
            lbl_Seconds = new System.Windows.Forms.Label();
            gb_DatabaseOptions = new System.Windows.Forms.GroupBox();
            tb_DatabaseUsage = new System.Windows.Forms.TextBox();
            button4 = new System.Windows.Forms.Button();
            tb_DatabaseFolder = new System.Windows.Forms.TextBox();
            lbl_Usage = new System.Windows.Forms.Label();
            lbl_ServerPort = new System.Windows.Forms.Label();
            nud_DatabasePort = new System.Windows.Forms.NumericUpDown();
            lbl_ServerNetworkAddress = new System.Windows.Forms.Label();
            tb_DatabaseServerIP = new System.Windows.Forms.TextBox();
            tb_Password = new System.Windows.Forms.TextBox();
            lbl_Password = new System.Windows.Forms.Label();
            tb_Username = new System.Windows.Forms.TextBox();
            lbl_Username = new System.Windows.Forms.Label();
            tb_DatabaseName = new System.Windows.Forms.TextBox();
            lbl_DatabaseName = new System.Windows.Forms.Label();
            lbl_Milliseconds_3 = new System.Windows.Forms.Label();
            pictureBox2 = new Mtf.Controls.MtfPictureBox();
            nud_MaximumTimeToWaitForNewPicture = new System.Windows.Forms.NumericUpDown();
            lbl_MaximumTimeToWaitForNewPicture = new System.Windows.Forms.Label();
            nud_MaximumDeflectionBetweenLiveViewAndRecorder = new System.Windows.Forms.NumericUpDown();
            lbl_MaximumDeflectionBetweenLiveViewAndRecorder = new System.Windows.Forms.Label();
            lbl_AutologinIfLastStatisticMessageIsEarlierThan = new System.Windows.Forms.Label();
            lbl_Minutes = new System.Windows.Forms.Label();
            lbl_Milliseconds_2 = new System.Windows.Forms.Label();
            lbl_Milliseconds = new System.Windows.Forms.Label();
            nud_StatisticMessageAfterEveryMinutes = new System.Windows.Forms.NumericUpDown();
            lbl_StatisticMessageAfterEvery = new System.Windows.Forms.Label();
            btn_Standard = new System.Windows.Forms.Button();
            btn_Default = new System.Windows.Forms.Button();
            p_Main = new System.Windows.Forms.Panel();
            gb_NoSignalImage = new System.Windows.Forms.GroupBox();
            chk_UseCustomNoSignalImage = new System.Windows.Forms.CheckBox();
            pb_NoSignalImage = new Mtf.Controls.MtfPictureBox();
            btn_Browse = new System.Windows.Forms.Button();
            gb_EventLogging = new System.Windows.Forms.GroupBox();
            rb_VerboseLogEveryEvents = new System.Windows.Forms.RadioButton();
            rb_VerboseLogOnlyErrors = new System.Windows.Forms.RadioButton();
            chk_VerboseDebugLogging = new System.Windows.Forms.CheckBox();
            gb_TechnicalOptions = new System.Windows.Forms.GroupBox();
            chk_UseWatchDog = new System.Windows.Forms.CheckBox();
            nud_TimeBetweenCheckVideoServers = new System.Windows.Forms.NumericUpDown();
            lbl_TimeBetweenCheckVideoServers = new System.Windows.Forms.Label();
            label12 = new System.Windows.Forms.Label();
            nud_MaximumTimeToWaitForAVideoServerIs = new System.Windows.Forms.NumericUpDown();
            lbl_MaximumTimeToWaitForAVideoServerIs = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            btn_Close = new System.Windows.Forms.Button();
            btn_Save = new System.Windows.Forms.Button();
            folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)nud_FPS).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_RestartTemplate).BeginInit();
            gb_DatabaseOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nud_DatabasePort).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_MaximumTimeToWaitForNewPicture).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_MaximumDeflectionBetweenLiveViewAndRecorder).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_StatisticMessageAfterEveryMinutes).BeginInit();
            p_Main.SuspendLayout();
            gb_NoSignalImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pb_NoSignalImage).BeginInit();
            gb_EventLogging.SuspendLayout();
            gb_TechnicalOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nud_TimeBetweenCheckVideoServers).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_MaximumTimeToWaitForAVideoServerIs).BeginInit();
            SuspendLayout();
            // 
            // chk_ReduceSequenceUsageOfNetworkAndCPU
            // 
            chk_ReduceSequenceUsageOfNetworkAndCPU.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            chk_ReduceSequenceUsageOfNetworkAndCPU.AutoSize = true;
            chk_ReduceSequenceUsageOfNetworkAndCPU.Location = new System.Drawing.Point(482, 250);
            chk_ReduceSequenceUsageOfNetworkAndCPU.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chk_ReduceSequenceUsageOfNetworkAndCPU.Name = "chk_ReduceSequenceUsageOfNetworkAndCPU";
            chk_ReduceSequenceUsageOfNetworkAndCPU.Size = new System.Drawing.Size(194, 19);
            chk_ReduceSequenceUsageOfNetworkAndCPU.TabIndex = 31;
            chk_ReduceSequenceUsageOfNetworkAndCPU.Text = "Reduce network and CPU usage";
            chk_ReduceSequenceUsageOfNetworkAndCPU.UseVisualStyleBackColor = true;
            // 
            // lbl_FPS
            // 
            lbl_FPS.AutoSize = true;
            lbl_FPS.Location = new System.Drawing.Point(8, 273);
            lbl_FPS.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_FPS.Name = "lbl_FPS";
            lbl_FPS.Size = new System.Drawing.Size(26, 15);
            lbl_FPS.TabIndex = 28;
            lbl_FPS.Text = "FPS";
            // 
            // nud_FPS
            // 
            nud_FPS.Location = new System.Drawing.Point(84, 271);
            nud_FPS.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            nud_FPS.Maximum = new decimal(new int[] { 25, 0, 0, 0 });
            nud_FPS.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nud_FPS.Name = "nud_FPS";
            nud_FPS.Size = new System.Drawing.Size(82, 23);
            nud_FPS.TabIndex = 29;
            nud_FPS.Value = new decimal(new int[] { 25, 0, 0, 0 });
            // 
            // chk_Deblock
            // 
            chk_Deblock.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            chk_Deblock.AutoSize = true;
            chk_Deblock.Location = new System.Drawing.Point(471, 272);
            chk_Deblock.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chk_Deblock.Name = "chk_Deblock";
            chk_Deblock.Size = new System.Drawing.Size(69, 19);
            chk_Deblock.TabIndex = 30;
            chk_Deblock.Text = "Deblock";
            chk_Deblock.UseVisualStyleBackColor = true;
            // 
            // chk_CloseSequenceApplicationOnFullScreenDisplayDevice
            // 
            chk_CloseSequenceApplicationOnFullScreenDisplayDevice.AutoSize = true;
            chk_CloseSequenceApplicationOnFullScreenDisplayDevice.Location = new System.Drawing.Point(12, 250);
            chk_CloseSequenceApplicationOnFullScreenDisplayDevice.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chk_CloseSequenceApplicationOnFullScreenDisplayDevice.Name = "chk_CloseSequenceApplicationOnFullScreenDisplayDevice";
            chk_CloseSequenceApplicationOnFullScreenDisplayDevice.Size = new System.Drawing.Size(318, 19);
            chk_CloseSequenceApplicationOnFullScreenDisplayDevice.TabIndex = 27;
            chk_CloseSequenceApplicationOnFullScreenDisplayDevice.Text = "Close sequence application on fullscreen display device";
            chk_CloseSequenceApplicationOnFullScreenDisplayDevice.UseVisualStyleBackColor = true;
            // 
            // lbl_KBD300ACOMPort
            // 
            lbl_KBD300ACOMPort.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lbl_KBD300ACOMPort.AutoSize = true;
            lbl_KBD300ACOMPort.Location = new System.Drawing.Point(341, 223);
            lbl_KBD300ACOMPort.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_KBD300ACOMPort.Name = "lbl_KBD300ACOMPort";
            lbl_KBD300ACOMPort.Size = new System.Drawing.Size(111, 15);
            lbl_KBD300ACOMPort.TabIndex = 25;
            lbl_KBD300ACOMPort.Text = "KBD300A COM port";
            // 
            // cb_KBD300ACOMPort
            // 
            cb_KBD300ACOMPort.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            cb_KBD300ACOMPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cb_KBD300ACOMPort.FormattingEnabled = true;
            cb_KBD300ACOMPort.Location = new System.Drawing.Point(463, 219);
            cb_KBD300ACOMPort.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cb_KBD300ACOMPort.Name = "cb_KBD300ACOMPort";
            cb_KBD300ACOMPort.Size = new System.Drawing.Size(193, 23);
            cb_KBD300ACOMPort.TabIndex = 26;
            // 
            // chk_LiveView
            // 
            chk_LiveView.AutoSize = true;
            chk_LiveView.Location = new System.Drawing.Point(12, 224);
            chk_LiveView.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chk_LiveView.Name = "chk_LiveView";
            chk_LiveView.Size = new System.Drawing.Size(143, 19);
            chk_LiveView.TabIndex = 24;
            chk_LiveView.Text = "LiveView on fullscreen";
            chk_LiveView.UseVisualStyleBackColor = true;
            // 
            // chk_Threading
            // 
            chk_Threading.AutoSize = true;
            chk_Threading.Checked = true;
            chk_Threading.CheckState = System.Windows.Forms.CheckState.Checked;
            chk_Threading.Location = new System.Drawing.Point(519, 20);
            chk_Threading.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chk_Threading.Name = "chk_Threading";
            chk_Threading.Size = new System.Drawing.Size(80, 19);
            chk_Threading.TabIndex = 2;
            chk_Threading.Text = "Threading";
            chk_Threading.UseVisualStyleBackColor = true;
            // 
            // chk_OpenMotionPopupWhenProgramStarts
            // 
            chk_OpenMotionPopupWhenProgramStarts.AutoSize = true;
            chk_OpenMotionPopupWhenProgramStarts.Location = new System.Drawing.Point(210, 20);
            chk_OpenMotionPopupWhenProgramStarts.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chk_OpenMotionPopupWhenProgramStarts.Name = "chk_OpenMotionPopupWhenProgramStarts";
            chk_OpenMotionPopupWhenProgramStarts.Size = new System.Drawing.Size(247, 19);
            chk_OpenMotionPopupWhenProgramStarts.TabIndex = 1;
            chk_OpenMotionPopupWhenProgramStarts.Text = "Open Motion Popup when program starts";
            chk_OpenMotionPopupWhenProgramStarts.UseVisualStyleBackColor = true;
            // 
            // lbl_Minutes_2
            // 
            lbl_Minutes_2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lbl_Minutes_2.AutoSize = true;
            lbl_Minutes_2.Location = new System.Drawing.Point(552, 195);
            lbl_Minutes_2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_Minutes_2.Name = "lbl_Minutes_2";
            lbl_Minutes_2.Size = new System.Drawing.Size(58, 15);
            lbl_Minutes_2.TabIndex = 23;
            lbl_Minutes_2.Text = "minute(s)";
            // 
            // nud_RestartTemplate
            // 
            nud_RestartTemplate.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            nud_RestartTemplate.Location = new System.Drawing.Point(463, 190);
            nud_RestartTemplate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            nud_RestartTemplate.Maximum = new decimal(new int[] { 35791, 0, 0, 0 });
            nud_RestartTemplate.Name = "nud_RestartTemplate";
            nud_RestartTemplate.Size = new System.Drawing.Size(82, 23);
            nud_RestartTemplate.TabIndex = 22;
            // 
            // lbl_RestartTemplateAfterEvery
            // 
            lbl_RestartTemplateAfterEvery.AutoSize = true;
            lbl_RestartTemplateAfterEvery.Location = new System.Drawing.Point(8, 195);
            lbl_RestartTemplateAfterEvery.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_RestartTemplateAfterEvery.Name = "lbl_RestartTemplateAfterEvery";
            lbl_RestartTemplateAfterEvery.Size = new System.Drawing.Size(325, 15);
            lbl_RestartTemplateAfterEvery.TabIndex = 21;
            lbl_RestartTemplateAfterEvery.Text = "Restart Template after every (0 means do not restart sampes)";
            // 
            // cb_UserID
            // 
            cb_UserID.FormattingEnabled = true;
            cb_UserID.Location = new System.Drawing.Point(350, 114);
            cb_UserID.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cb_UserID.Name = "cb_UserID";
            cb_UserID.Size = new System.Drawing.Size(48, 23);
            cb_UserID.TabIndex = 13;
            cb_UserID.Visible = false;
            // 
            // cb_Users
            // 
            cb_Users.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            cb_Users.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cb_Users.FormattingEnabled = true;
            cb_Users.Location = new System.Drawing.Point(463, 114);
            cb_Users.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cb_Users.Name = "cb_Users";
            cb_Users.Size = new System.Drawing.Size(193, 23);
            cb_Users.TabIndex = 14;
            // 
            // lbl_Seconds
            // 
            lbl_Seconds.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lbl_Seconds.AutoSize = true;
            lbl_Seconds.Location = new System.Drawing.Point(552, 170);
            lbl_Seconds.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_Seconds.Name = "lbl_Seconds";
            lbl_Seconds.Size = new System.Drawing.Size(58, 15);
            lbl_Seconds.TabIndex = 20;
            lbl_Seconds.Text = "second(s)";
            // 
            // gb_DatabaseOptions
            // 
            gb_DatabaseOptions.BackColor = System.Drawing.Color.Transparent;
            gb_DatabaseOptions.BackgroundImage = (System.Drawing.Image)resources.GetObject("gb_DatabaseOptions.BackgroundImage");
            gb_DatabaseOptions.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            gb_DatabaseOptions.Controls.Add(tb_DatabaseUsage);
            gb_DatabaseOptions.Controls.Add(button4);
            gb_DatabaseOptions.Controls.Add(tb_DatabaseFolder);
            gb_DatabaseOptions.Controls.Add(lbl_Usage);
            gb_DatabaseOptions.Controls.Add(lbl_ServerPort);
            gb_DatabaseOptions.Controls.Add(nud_DatabasePort);
            gb_DatabaseOptions.Controls.Add(lbl_ServerNetworkAddress);
            gb_DatabaseOptions.Controls.Add(tb_DatabaseServerIP);
            gb_DatabaseOptions.Controls.Add(tb_Password);
            gb_DatabaseOptions.Controls.Add(lbl_Password);
            gb_DatabaseOptions.Controls.Add(tb_Username);
            gb_DatabaseOptions.Controls.Add(lbl_Username);
            gb_DatabaseOptions.Controls.Add(tb_DatabaseName);
            gb_DatabaseOptions.Controls.Add(lbl_DatabaseName);
            gb_DatabaseOptions.Location = new System.Drawing.Point(0, 307);
            gb_DatabaseOptions.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gb_DatabaseOptions.Name = "gb_DatabaseOptions";
            gb_DatabaseOptions.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gb_DatabaseOptions.Size = new System.Drawing.Size(362, 204);
            gb_DatabaseOptions.TabIndex = 1;
            gb_DatabaseOptions.TabStop = false;
            gb_DatabaseOptions.Text = "Database options";
            // 
            // tb_DatabaseUsage
            // 
            tb_DatabaseUsage.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            tb_DatabaseUsage.Location = new System.Drawing.Point(226, 18);
            tb_DatabaseUsage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tb_DatabaseUsage.Name = "tb_DatabaseUsage";
            tb_DatabaseUsage.ReadOnly = true;
            tb_DatabaseUsage.Size = new System.Drawing.Size(126, 23);
            tb_DatabaseUsage.TabIndex = 1;
            tb_DatabaseUsage.TabStop = false;
            // 
            // button4
            // 
            button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button4.Location = new System.Drawing.Point(12, 167);
            button4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            button4.Name = "button4";
            button4.Size = new System.Drawing.Size(208, 27);
            button4.TabIndex = 12;
            button4.Text = "Change databases folder";
            button4.UseVisualStyleBackColor = true;
            // 
            // tb_DatabaseFolder
            // 
            tb_DatabaseFolder.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            tb_DatabaseFolder.Location = new System.Drawing.Point(226, 170);
            tb_DatabaseFolder.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tb_DatabaseFolder.Name = "tb_DatabaseFolder";
            tb_DatabaseFolder.ReadOnly = true;
            tb_DatabaseFolder.Size = new System.Drawing.Size(126, 23);
            tb_DatabaseFolder.TabIndex = 13;
            tb_DatabaseFolder.TabStop = false;
            // 
            // lbl_Usage
            // 
            lbl_Usage.AutoSize = true;
            lbl_Usage.BackColor = System.Drawing.Color.Transparent;
            lbl_Usage.Location = new System.Drawing.Point(8, 22);
            lbl_Usage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_Usage.Name = "lbl_Usage";
            lbl_Usage.Size = new System.Drawing.Size(39, 15);
            lbl_Usage.TabIndex = 0;
            lbl_Usage.Text = "Usage";
            // 
            // lbl_ServerPort
            // 
            lbl_ServerPort.AutoSize = true;
            lbl_ServerPort.BackColor = System.Drawing.Color.Transparent;
            lbl_ServerPort.Location = new System.Drawing.Point(8, 147);
            lbl_ServerPort.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_ServerPort.Name = "lbl_ServerPort";
            lbl_ServerPort.Size = new System.Drawing.Size(64, 15);
            lbl_ServerPort.TabIndex = 10;
            lbl_ServerPort.Text = "Server port";
            // 
            // nud_DatabasePort
            // 
            nud_DatabasePort.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            nud_DatabasePort.Location = new System.Drawing.Point(226, 144);
            nud_DatabasePort.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            nud_DatabasePort.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            nud_DatabasePort.Name = "nud_DatabasePort";
            nud_DatabasePort.Size = new System.Drawing.Size(127, 23);
            nud_DatabasePort.TabIndex = 11;
            nud_DatabasePort.Value = new decimal(new int[] { 2242, 0, 0, 0 });
            // 
            // lbl_ServerNetworkAddress
            // 
            lbl_ServerNetworkAddress.AutoSize = true;
            lbl_ServerNetworkAddress.BackColor = System.Drawing.Color.Transparent;
            lbl_ServerNetworkAddress.Location = new System.Drawing.Point(8, 122);
            lbl_ServerNetworkAddress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_ServerNetworkAddress.Name = "lbl_ServerNetworkAddress";
            lbl_ServerNetworkAddress.Size = new System.Drawing.Size(128, 15);
            lbl_ServerNetworkAddress.TabIndex = 8;
            lbl_ServerNetworkAddress.Text = "Server network address";
            // 
            // tb_DatabaseServerIP
            // 
            tb_DatabaseServerIP.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            tb_DatabaseServerIP.Location = new System.Drawing.Point(226, 119);
            tb_DatabaseServerIP.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tb_DatabaseServerIP.Name = "tb_DatabaseServerIP";
            tb_DatabaseServerIP.Size = new System.Drawing.Size(126, 23);
            tb_DatabaseServerIP.TabIndex = 9;
            tb_DatabaseServerIP.Text = "127.0.0.1";
            // 
            // tb_Password
            // 
            tb_Password.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            tb_Password.Location = new System.Drawing.Point(226, 93);
            tb_Password.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tb_Password.Name = "tb_Password";
            tb_Password.PasswordChar = '*';
            tb_Password.Size = new System.Drawing.Size(126, 23);
            tb_Password.TabIndex = 7;
            // 
            // lbl_Password
            // 
            lbl_Password.AutoSize = true;
            lbl_Password.BackColor = System.Drawing.Color.Transparent;
            lbl_Password.Location = new System.Drawing.Point(8, 97);
            lbl_Password.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_Password.Name = "lbl_Password";
            lbl_Password.Size = new System.Drawing.Size(57, 15);
            lbl_Password.TabIndex = 6;
            lbl_Password.Text = "Password";
            // 
            // tb_Username
            // 
            tb_Username.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            tb_Username.Location = new System.Drawing.Point(226, 68);
            tb_Username.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tb_Username.Name = "tb_Username";
            tb_Username.Size = new System.Drawing.Size(126, 23);
            tb_Username.TabIndex = 5;
            // 
            // lbl_Username
            // 
            lbl_Username.AutoSize = true;
            lbl_Username.BackColor = System.Drawing.Color.Transparent;
            lbl_Username.Location = new System.Drawing.Point(8, 72);
            lbl_Username.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_Username.Name = "lbl_Username";
            lbl_Username.Size = new System.Drawing.Size(60, 15);
            lbl_Username.TabIndex = 4;
            lbl_Username.Text = "Username";
            // 
            // tb_DatabaseName
            // 
            tb_DatabaseName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            tb_DatabaseName.Location = new System.Drawing.Point(226, 43);
            tb_DatabaseName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tb_DatabaseName.Name = "tb_DatabaseName";
            tb_DatabaseName.Size = new System.Drawing.Size(126, 23);
            tb_DatabaseName.TabIndex = 3;
            // 
            // lbl_DatabaseName
            // 
            lbl_DatabaseName.AutoSize = true;
            lbl_DatabaseName.BackColor = System.Drawing.Color.Transparent;
            lbl_DatabaseName.Location = new System.Drawing.Point(8, 46);
            lbl_DatabaseName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_DatabaseName.Name = "lbl_DatabaseName";
            lbl_DatabaseName.Size = new System.Drawing.Size(88, 15);
            lbl_DatabaseName.TabIndex = 2;
            lbl_DatabaseName.Text = "Database name";
            // 
            // lbl_Milliseconds_3
            // 
            lbl_Milliseconds_3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lbl_Milliseconds_3.AutoSize = true;
            lbl_Milliseconds_3.Location = new System.Drawing.Point(552, 144);
            lbl_Milliseconds_3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_Milliseconds_3.Name = "lbl_Milliseconds_3";
            lbl_Milliseconds_3.Size = new System.Drawing.Size(81, 15);
            lbl_Milliseconds_3.TabIndex = 17;
            lbl_Milliseconds_3.Text = "millisecond(s)";
            // 
            // pictureBox2
            // 
            pictureBox2.Location = new System.Drawing.Point(7, 27);
            pictureBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new System.Drawing.Size(12, 12);
            pictureBox2.TabIndex = 10;
            pictureBox2.TabStop = false;
            pictureBox2.Visible = false;
            // 
            // nud_MaximumTimeToWaitForNewPicture
            // 
            nud_MaximumTimeToWaitForNewPicture.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            nud_MaximumTimeToWaitForNewPicture.Location = new System.Drawing.Point(463, 165);
            nud_MaximumTimeToWaitForNewPicture.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            nud_MaximumTimeToWaitForNewPicture.Maximum = new decimal(new int[] { 600, 0, 0, 0 });
            nud_MaximumTimeToWaitForNewPicture.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nud_MaximumTimeToWaitForNewPicture.Name = "nud_MaximumTimeToWaitForNewPicture";
            nud_MaximumTimeToWaitForNewPicture.Size = new System.Drawing.Size(82, 23);
            nud_MaximumTimeToWaitForNewPicture.TabIndex = 19;
            nud_MaximumTimeToWaitForNewPicture.Value = new decimal(new int[] { 300, 0, 0, 0 });
            // 
            // lbl_MaximumTimeToWaitForNewPicture
            // 
            lbl_MaximumTimeToWaitForNewPicture.AutoSize = true;
            lbl_MaximumTimeToWaitForNewPicture.Location = new System.Drawing.Point(8, 170);
            lbl_MaximumTimeToWaitForNewPicture.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_MaximumTimeToWaitForNewPicture.Name = "lbl_MaximumTimeToWaitForNewPicture";
            lbl_MaximumTimeToWaitForNewPicture.Size = new System.Drawing.Size(210, 15);
            lbl_MaximumTimeToWaitForNewPicture.TabIndex = 18;
            lbl_MaximumTimeToWaitForNewPicture.Text = "Maximum time to wait for new picture";
            // 
            // nud_MaximumDeflectionBetweenLiveViewAndRecorder
            // 
            nud_MaximumDeflectionBetweenLiveViewAndRecorder.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            nud_MaximumDeflectionBetweenLiveViewAndRecorder.Location = new System.Drawing.Point(463, 140);
            nud_MaximumDeflectionBetweenLiveViewAndRecorder.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            nud_MaximumDeflectionBetweenLiveViewAndRecorder.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            nud_MaximumDeflectionBetweenLiveViewAndRecorder.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            nud_MaximumDeflectionBetweenLiveViewAndRecorder.Name = "nud_MaximumDeflectionBetweenLiveViewAndRecorder";
            nud_MaximumDeflectionBetweenLiveViewAndRecorder.Size = new System.Drawing.Size(82, 23);
            nud_MaximumDeflectionBetweenLiveViewAndRecorder.TabIndex = 16;
            nud_MaximumDeflectionBetweenLiveViewAndRecorder.Value = new decimal(new int[] { 5000, 0, 0, 0 });
            // 
            // lbl_MaximumDeflectionBetweenLiveViewAndRecorder
            // 
            lbl_MaximumDeflectionBetweenLiveViewAndRecorder.AutoSize = true;
            lbl_MaximumDeflectionBetweenLiveViewAndRecorder.Location = new System.Drawing.Point(8, 144);
            lbl_MaximumDeflectionBetweenLiveViewAndRecorder.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_MaximumDeflectionBetweenLiveViewAndRecorder.Name = "lbl_MaximumDeflectionBetweenLiveViewAndRecorder";
            lbl_MaximumDeflectionBetweenLiveViewAndRecorder.Size = new System.Drawing.Size(283, 15);
            lbl_MaximumDeflectionBetweenLiveViewAndRecorder.TabIndex = 15;
            lbl_MaximumDeflectionBetweenLiveViewAndRecorder.Text = "Maximum deflection between live view and recorder";
            // 
            // lbl_AutologinIfLastStatisticMessageIsEarlierThan
            // 
            lbl_AutologinIfLastStatisticMessageIsEarlierThan.AutoSize = true;
            lbl_AutologinIfLastStatisticMessageIsEarlierThan.Location = new System.Drawing.Point(8, 119);
            lbl_AutologinIfLastStatisticMessageIsEarlierThan.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_AutologinIfLastStatisticMessageIsEarlierThan.Name = "lbl_AutologinIfLastStatisticMessageIsEarlierThan";
            lbl_AutologinIfLastStatisticMessageIsEarlierThan.Size = new System.Drawing.Size(255, 15);
            lbl_AutologinIfLastStatisticMessageIsEarlierThan.TabIndex = 12;
            lbl_AutologinIfLastStatisticMessageIsEarlierThan.Text = "Autologin if last statistic message if earlier than";
            // 
            // lbl_Minutes
            // 
            lbl_Minutes.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lbl_Minutes.AutoSize = true;
            lbl_Minutes.Location = new System.Drawing.Point(552, 95);
            lbl_Minutes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_Minutes.Name = "lbl_Minutes";
            lbl_Minutes.Size = new System.Drawing.Size(58, 15);
            lbl_Minutes.TabIndex = 11;
            lbl_Minutes.Text = "minute(s)";
            // 
            // lbl_Milliseconds_2
            // 
            lbl_Milliseconds_2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lbl_Milliseconds_2.AutoSize = true;
            lbl_Milliseconds_2.Location = new System.Drawing.Point(552, 69);
            lbl_Milliseconds_2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_Milliseconds_2.Name = "lbl_Milliseconds_2";
            lbl_Milliseconds_2.Size = new System.Drawing.Size(81, 15);
            lbl_Milliseconds_2.TabIndex = 8;
            lbl_Milliseconds_2.Text = "millisecond(s)";
            // 
            // lbl_Milliseconds
            // 
            lbl_Milliseconds.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lbl_Milliseconds.AutoSize = true;
            lbl_Milliseconds.Location = new System.Drawing.Point(552, 44);
            lbl_Milliseconds.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_Milliseconds.Name = "lbl_Milliseconds";
            lbl_Milliseconds.Size = new System.Drawing.Size(81, 15);
            lbl_Milliseconds.TabIndex = 5;
            lbl_Milliseconds.Text = "millisecond(s)";
            // 
            // nud_StatisticMessageAfterEveryMinutes
            // 
            nud_StatisticMessageAfterEveryMinutes.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            nud_StatisticMessageAfterEveryMinutes.Location = new System.Drawing.Point(463, 90);
            nud_StatisticMessageAfterEveryMinutes.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            nud_StatisticMessageAfterEveryMinutes.Maximum = new decimal(new int[] { 35791, 0, 0, 0 });
            nud_StatisticMessageAfterEveryMinutes.Name = "nud_StatisticMessageAfterEveryMinutes";
            nud_StatisticMessageAfterEveryMinutes.Size = new System.Drawing.Size(82, 23);
            nud_StatisticMessageAfterEveryMinutes.TabIndex = 10;
            nud_StatisticMessageAfterEveryMinutes.Value = new decimal(new int[] { 1440, 0, 0, 0 });
            // 
            // lbl_StatisticMessageAfterEvery
            // 
            lbl_StatisticMessageAfterEvery.AutoSize = true;
            lbl_StatisticMessageAfterEvery.Location = new System.Drawing.Point(8, 95);
            lbl_StatisticMessageAfterEvery.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_StatisticMessageAfterEvery.Name = "lbl_StatisticMessageAfterEvery";
            lbl_StatisticMessageAfterEvery.Size = new System.Drawing.Size(158, 15);
            lbl_StatisticMessageAfterEvery.TabIndex = 9;
            lbl_StatisticMessageAfterEvery.Text = "Statistic message after every ";
            // 
            // btn_Standard
            // 
            btn_Standard.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btn_Standard.Location = new System.Drawing.Point(94, 623);
            btn_Standard.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_Standard.Name = "btn_Standard";
            btn_Standard.Size = new System.Drawing.Size(88, 27);
            btn_Standard.TabIndex = 5;
            btn_Standard.Text = "Standard";
            btn_Standard.UseVisualStyleBackColor = true;
            // 
            // btn_Default
            // 
            btn_Default.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btn_Default.Location = new System.Drawing.Point(0, 623);
            btn_Default.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_Default.Name = "btn_Default";
            btn_Default.Size = new System.Drawing.Size(88, 27);
            btn_Default.TabIndex = 4;
            btn_Default.Text = "Default";
            btn_Default.UseVisualStyleBackColor = true;
            // 
            // p_Main
            // 
            p_Main.Controls.Add(btn_Standard);
            p_Main.Controls.Add(btn_Default);
            p_Main.Controls.Add(gb_NoSignalImage);
            p_Main.Controls.Add(gb_EventLogging);
            p_Main.Controls.Add(gb_TechnicalOptions);
            p_Main.Controls.Add(btn_Close);
            p_Main.Controls.Add(btn_Save);
            p_Main.Controls.Add(gb_DatabaseOptions);
            p_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            p_Main.Location = new System.Drawing.Point(0, 0);
            p_Main.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            p_Main.Name = "p_Main";
            p_Main.Size = new System.Drawing.Size(701, 653);
            p_Main.TabIndex = 1;
            // 
            // gb_NoSignalImage
            // 
            gb_NoSignalImage.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            gb_NoSignalImage.Controls.Add(pictureBox2);
            gb_NoSignalImage.Controls.Add(chk_UseCustomNoSignalImage);
            gb_NoSignalImage.Controls.Add(pb_NoSignalImage);
            gb_NoSignalImage.Controls.Add(btn_Browse);
            gb_NoSignalImage.Location = new System.Drawing.Point(369, 307);
            gb_NoSignalImage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gb_NoSignalImage.Name = "gb_NoSignalImage";
            gb_NoSignalImage.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gb_NoSignalImage.Size = new System.Drawing.Size(332, 309);
            gb_NoSignalImage.TabIndex = 3;
            gb_NoSignalImage.TabStop = false;
            gb_NoSignalImage.Text = " ";
            // 
            // chk_UseCustomNoSignalImage
            // 
            chk_UseCustomNoSignalImage.AutoSize = true;
            chk_UseCustomNoSignalImage.Location = new System.Drawing.Point(13, 1);
            chk_UseCustomNoSignalImage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chk_UseCustomNoSignalImage.Name = "chk_UseCustomNoSignalImage";
            chk_UseCustomNoSignalImage.Size = new System.Drawing.Size(220, 19);
            chk_UseCustomNoSignalImage.TabIndex = 0;
            chk_UseCustomNoSignalImage.Text = "\"No signal or no connection\" picture";
            chk_UseCustomNoSignalImage.UseVisualStyleBackColor = true;
            // 
            // pb_NoSignalImage
            // 
            pb_NoSignalImage.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            pb_NoSignalImage.BackColor = System.Drawing.SystemColors.AppWorkspace;
            pb_NoSignalImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            pb_NoSignalImage.Location = new System.Drawing.Point(7, 60);
            pb_NoSignalImage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pb_NoSignalImage.Name = "pb_NoSignalImage";
            pb_NoSignalImage.Size = new System.Drawing.Size(317, 242);
            pb_NoSignalImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pb_NoSignalImage.TabIndex = 19;
            pb_NoSignalImage.TabStop = false;
            // 
            // btn_Browse
            // 
            btn_Browse.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btn_Browse.Enabled = false;
            btn_Browse.Location = new System.Drawing.Point(237, 27);
            btn_Browse.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_Browse.Name = "btn_Browse";
            btn_Browse.Size = new System.Drawing.Size(88, 27);
            btn_Browse.TabIndex = 1;
            btn_Browse.Text = "Browse";
            btn_Browse.UseVisualStyleBackColor = true;
            // 
            // gb_EventLogging
            // 
            gb_EventLogging.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            gb_EventLogging.Controls.Add(rb_VerboseLogEveryEvents);
            gb_EventLogging.Controls.Add(rb_VerboseLogOnlyErrors);
            gb_EventLogging.Controls.Add(chk_VerboseDebugLogging);
            gb_EventLogging.Location = new System.Drawing.Point(0, 513);
            gb_EventLogging.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gb_EventLogging.Name = "gb_EventLogging";
            gb_EventLogging.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gb_EventLogging.Size = new System.Drawing.Size(362, 103);
            gb_EventLogging.TabIndex = 2;
            gb_EventLogging.TabStop = false;
            gb_EventLogging.Text = "Event logging";
            // 
            // rb_VerboseLogEveryEvents
            // 
            rb_VerboseLogEveryEvents.AutoSize = true;
            rb_VerboseLogEveryEvents.Enabled = false;
            rb_VerboseLogEveryEvents.Location = new System.Drawing.Point(33, 74);
            rb_VerboseLogEveryEvents.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            rb_VerboseLogEveryEvents.Name = "rb_VerboseLogEveryEvents";
            rb_VerboseLogEveryEvents.Size = new System.Drawing.Size(154, 19);
            rb_VerboseLogEveryEvents.TabIndex = 2;
            rb_VerboseLogEveryEvents.Text = "Verbose log every events";
            rb_VerboseLogEveryEvents.UseVisualStyleBackColor = true;
            // 
            // rb_VerboseLogOnlyErrors
            // 
            rb_VerboseLogOnlyErrors.AutoSize = true;
            rb_VerboseLogOnlyErrors.Checked = true;
            rb_VerboseLogOnlyErrors.Enabled = false;
            rb_VerboseLogOnlyErrors.Location = new System.Drawing.Point(33, 48);
            rb_VerboseLogOnlyErrors.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            rb_VerboseLogOnlyErrors.Name = "rb_VerboseLogOnlyErrors";
            rb_VerboseLogOnlyErrors.Size = new System.Drawing.Size(145, 19);
            rb_VerboseLogOnlyErrors.TabIndex = 1;
            rb_VerboseLogOnlyErrors.TabStop = true;
            rb_VerboseLogOnlyErrors.Text = "Verbose log only errors";
            rb_VerboseLogOnlyErrors.UseVisualStyleBackColor = true;
            // 
            // chk_VerboseDebugLogging
            // 
            chk_VerboseDebugLogging.AutoSize = true;
            chk_VerboseDebugLogging.Location = new System.Drawing.Point(12, 22);
            chk_VerboseDebugLogging.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chk_VerboseDebugLogging.Name = "chk_VerboseDebugLogging";
            chk_VerboseDebugLogging.Size = new System.Drawing.Size(148, 19);
            chk_VerboseDebugLogging.TabIndex = 0;
            chk_VerboseDebugLogging.Text = "Verbose debug logging";
            chk_VerboseDebugLogging.UseVisualStyleBackColor = true;
            // 
            // gb_TechnicalOptions
            // 
            gb_TechnicalOptions.Controls.Add(chk_ReduceSequenceUsageOfNetworkAndCPU);
            gb_TechnicalOptions.Controls.Add(lbl_FPS);
            gb_TechnicalOptions.Controls.Add(nud_FPS);
            gb_TechnicalOptions.Controls.Add(chk_Deblock);
            gb_TechnicalOptions.Controls.Add(chk_CloseSequenceApplicationOnFullScreenDisplayDevice);
            gb_TechnicalOptions.Controls.Add(lbl_KBD300ACOMPort);
            gb_TechnicalOptions.Controls.Add(cb_KBD300ACOMPort);
            gb_TechnicalOptions.Controls.Add(chk_LiveView);
            gb_TechnicalOptions.Controls.Add(chk_Threading);
            gb_TechnicalOptions.Controls.Add(chk_OpenMotionPopupWhenProgramStarts);
            gb_TechnicalOptions.Controls.Add(lbl_Minutes_2);
            gb_TechnicalOptions.Controls.Add(nud_RestartTemplate);
            gb_TechnicalOptions.Controls.Add(lbl_RestartTemplateAfterEvery);
            gb_TechnicalOptions.Controls.Add(cb_UserID);
            gb_TechnicalOptions.Controls.Add(cb_Users);
            gb_TechnicalOptions.Controls.Add(lbl_Seconds);
            gb_TechnicalOptions.Controls.Add(lbl_Milliseconds_3);
            gb_TechnicalOptions.Controls.Add(nud_MaximumTimeToWaitForNewPicture);
            gb_TechnicalOptions.Controls.Add(lbl_MaximumTimeToWaitForNewPicture);
            gb_TechnicalOptions.Controls.Add(nud_MaximumDeflectionBetweenLiveViewAndRecorder);
            gb_TechnicalOptions.Controls.Add(lbl_MaximumDeflectionBetweenLiveViewAndRecorder);
            gb_TechnicalOptions.Controls.Add(lbl_AutologinIfLastStatisticMessageIsEarlierThan);
            gb_TechnicalOptions.Controls.Add(lbl_Minutes);
            gb_TechnicalOptions.Controls.Add(lbl_Milliseconds_2);
            gb_TechnicalOptions.Controls.Add(lbl_Milliseconds);
            gb_TechnicalOptions.Controls.Add(nud_StatisticMessageAfterEveryMinutes);
            gb_TechnicalOptions.Controls.Add(lbl_StatisticMessageAfterEvery);
            gb_TechnicalOptions.Controls.Add(chk_UseWatchDog);
            gb_TechnicalOptions.Controls.Add(nud_TimeBetweenCheckVideoServers);
            gb_TechnicalOptions.Controls.Add(lbl_TimeBetweenCheckVideoServers);
            gb_TechnicalOptions.Controls.Add(label12);
            gb_TechnicalOptions.Controls.Add(nud_MaximumTimeToWaitForAVideoServerIs);
            gb_TechnicalOptions.Controls.Add(lbl_MaximumTimeToWaitForAVideoServerIs);
            gb_TechnicalOptions.Controls.Add(label10);
            gb_TechnicalOptions.Controls.Add(label2);
            gb_TechnicalOptions.Dock = System.Windows.Forms.DockStyle.Top;
            gb_TechnicalOptions.Location = new System.Drawing.Point(0, 0);
            gb_TechnicalOptions.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gb_TechnicalOptions.Name = "gb_TechnicalOptions";
            gb_TechnicalOptions.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gb_TechnicalOptions.Size = new System.Drawing.Size(701, 301);
            gb_TechnicalOptions.TabIndex = 0;
            gb_TechnicalOptions.TabStop = false;
            gb_TechnicalOptions.Text = "Technical options";
            // 
            // chk_UseWatchDog
            // 
            chk_UseWatchDog.AutoSize = true;
            chk_UseWatchDog.Location = new System.Drawing.Point(12, 20);
            chk_UseWatchDog.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chk_UseWatchDog.Name = "chk_UseWatchDog";
            chk_UseWatchDog.Size = new System.Drawing.Size(101, 19);
            chk_UseWatchDog.TabIndex = 0;
            chk_UseWatchDog.Text = "Use watchdog";
            chk_UseWatchDog.UseVisualStyleBackColor = true;
            // 
            // nud_TimeBetweenCheckVideoServers
            // 
            nud_TimeBetweenCheckVideoServers.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            nud_TimeBetweenCheckVideoServers.Location = new System.Drawing.Point(463, 39);
            nud_TimeBetweenCheckVideoServers.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            nud_TimeBetweenCheckVideoServers.Maximum = new decimal(new int[] { 600000, 0, 0, 0 });
            nud_TimeBetweenCheckVideoServers.Minimum = new decimal(new int[] { 1000, 0, 0, 0 });
            nud_TimeBetweenCheckVideoServers.Name = "nud_TimeBetweenCheckVideoServers";
            nud_TimeBetweenCheckVideoServers.Size = new System.Drawing.Size(82, 23);
            nud_TimeBetweenCheckVideoServers.TabIndex = 4;
            nud_TimeBetweenCheckVideoServers.Value = new decimal(new int[] { 3000, 0, 0, 0 });
            // 
            // lbl_TimeBetweenCheckVideoServers
            // 
            lbl_TimeBetweenCheckVideoServers.AutoSize = true;
            lbl_TimeBetweenCheckVideoServers.Location = new System.Drawing.Point(8, 44);
            lbl_TimeBetweenCheckVideoServers.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_TimeBetweenCheckVideoServers.Name = "lbl_TimeBetweenCheckVideoServers";
            lbl_TimeBetweenCheckVideoServers.Size = new System.Drawing.Size(187, 15);
            lbl_TimeBetweenCheckVideoServers.TabIndex = 3;
            lbl_TimeBetweenCheckVideoServers.Text = "Time between check video servers";
            // 
            // label12
            // 
            label12.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            label12.AutoSize = true;
            label12.Location = new System.Drawing.Point(1027, 45);
            label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(23, 15);
            label12.TabIndex = 5;
            label12.Text = "ms";
            // 
            // nud_MaximumTimeToWaitForAVideoServerIs
            // 
            nud_MaximumTimeToWaitForAVideoServerIs.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            nud_MaximumTimeToWaitForAVideoServerIs.Location = new System.Drawing.Point(463, 65);
            nud_MaximumTimeToWaitForAVideoServerIs.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            nud_MaximumTimeToWaitForAVideoServerIs.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            nud_MaximumTimeToWaitForAVideoServerIs.Minimum = new decimal(new int[] { 100, 0, 0, 0 });
            nud_MaximumTimeToWaitForAVideoServerIs.Name = "nud_MaximumTimeToWaitForAVideoServerIs";
            nud_MaximumTimeToWaitForAVideoServerIs.Size = new System.Drawing.Size(82, 23);
            nud_MaximumTimeToWaitForAVideoServerIs.TabIndex = 7;
            nud_MaximumTimeToWaitForAVideoServerIs.Value = new decimal(new int[] { 5000, 0, 0, 0 });
            // 
            // lbl_MaximumTimeToWaitForAVideoServerIs
            // 
            lbl_MaximumTimeToWaitForAVideoServerIs.AutoSize = true;
            lbl_MaximumTimeToWaitForAVideoServerIs.Location = new System.Drawing.Point(8, 69);
            lbl_MaximumTimeToWaitForAVideoServerIs.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_MaximumTimeToWaitForAVideoServerIs.Name = "lbl_MaximumTimeToWaitForAVideoServerIs";
            lbl_MaximumTimeToWaitForAVideoServerIs.Size = new System.Drawing.Size(231, 15);
            lbl_MaximumTimeToWaitForAVideoServerIs.TabIndex = 6;
            lbl_MaximumTimeToWaitForAVideoServerIs.Text = "Maximum time to wait for a video server is";
            // 
            // label10
            // 
            label10.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(1027, 72);
            label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(23, 15);
            label10.TabIndex = 8;
            label10.Text = "ms";
            // 
            // label2
            // 
            label2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(1027, 18);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(23, 15);
            label2.TabIndex = 2;
            label2.Text = "ms";
            // 
            // btn_Close
            // 
            btn_Close.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btn_Close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            btn_Close.Location = new System.Drawing.Point(606, 623);
            btn_Close.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_Close.Name = "btn_Close";
            btn_Close.Size = new System.Drawing.Size(88, 27);
            btn_Close.TabIndex = 7;
            btn_Close.Text = "Close";
            btn_Close.UseVisualStyleBackColor = true;
            // 
            // btn_Save
            // 
            btn_Save.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btn_Save.DialogResult = System.Windows.Forms.DialogResult.OK;
            btn_Save.Location = new System.Drawing.Point(507, 623);
            btn_Save.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_Save.Name = "btn_Save";
            btn_Save.Size = new System.Drawing.Size(88, 27);
            btn_Save.TabIndex = 6;
            btn_Save.Text = "Save";
            btn_Save.UseVisualStyleBackColor = true;
            // 
            // SystemOptions
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(701, 653);
            Controls.Add(p_Main);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MinimumSize = new System.Drawing.Size(708, 678);
            Name = "SystemOptions";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "System options";
            ((System.ComponentModel.ISupportInitialize)nud_FPS).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_RestartTemplate).EndInit();
            gb_DatabaseOptions.ResumeLayout(false);
            gb_DatabaseOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nud_DatabasePort).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_MaximumTimeToWaitForNewPicture).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_MaximumDeflectionBetweenLiveViewAndRecorder).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_StatisticMessageAfterEveryMinutes).EndInit();
            p_Main.ResumeLayout(false);
            gb_NoSignalImage.ResumeLayout(false);
            gb_NoSignalImage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pb_NoSignalImage).EndInit();
            gb_EventLogging.ResumeLayout(false);
            gb_EventLogging.PerformLayout();
            gb_TechnicalOptions.ResumeLayout(false);
            gb_TechnicalOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nud_TimeBetweenCheckVideoServers).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_MaximumTimeToWaitForAVideoServerIs).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.CheckBox chk_ReduceSequenceUsageOfNetworkAndCPU;
        private System.Windows.Forms.Label lbl_FPS;
        private System.Windows.Forms.NumericUpDown nud_FPS;
        private System.Windows.Forms.CheckBox chk_Deblock;
        private System.Windows.Forms.CheckBox chk_CloseSequenceApplicationOnFullScreenDisplayDevice;
        private System.Windows.Forms.Label lbl_KBD300ACOMPort;
        private System.Windows.Forms.ComboBox cb_KBD300ACOMPort;
        private System.Windows.Forms.CheckBox chk_LiveView;
        private System.Windows.Forms.CheckBox chk_Threading;
        private System.Windows.Forms.CheckBox chk_OpenMotionPopupWhenProgramStarts;
        private System.Windows.Forms.Label lbl_Minutes_2;
        private System.Windows.Forms.NumericUpDown nud_RestartTemplate;
        private System.Windows.Forms.Label lbl_RestartTemplateAfterEvery;
        private System.Windows.Forms.ComboBox cb_UserID;
        private System.Windows.Forms.ComboBox cb_Users;
        private System.Windows.Forms.Label lbl_Seconds;
        private System.Windows.Forms.GroupBox gb_DatabaseOptions;
        private System.Windows.Forms.TextBox tb_DatabaseUsage;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox tb_DatabaseFolder;
        private System.Windows.Forms.Label lbl_Usage;
        private System.Windows.Forms.Label lbl_ServerPort;
        private System.Windows.Forms.NumericUpDown nud_DatabasePort;
        private System.Windows.Forms.Label lbl_ServerNetworkAddress;
        private System.Windows.Forms.TextBox tb_DatabaseServerIP;
        private System.Windows.Forms.TextBox tb_Password;
        private System.Windows.Forms.Label lbl_Password;
        private System.Windows.Forms.TextBox tb_Username;
        private System.Windows.Forms.Label lbl_Username;
        private System.Windows.Forms.TextBox tb_DatabaseName;
        private System.Windows.Forms.Label lbl_DatabaseName;
        private System.Windows.Forms.Label lbl_Milliseconds_3;
        private Mtf.Controls.MtfPictureBox pictureBox2;
        private System.Windows.Forms.NumericUpDown nud_MaximumTimeToWaitForNewPicture;
        private System.Windows.Forms.Label lbl_MaximumTimeToWaitForNewPicture;
        private System.Windows.Forms.NumericUpDown nud_MaximumDeflectionBetweenLiveViewAndRecorder;
        private System.Windows.Forms.Label lbl_MaximumDeflectionBetweenLiveViewAndRecorder;
        private System.Windows.Forms.Label lbl_AutologinIfLastStatisticMessageIsEarlierThan;
        private System.Windows.Forms.Label lbl_Minutes;
        private System.Windows.Forms.Label lbl_Milliseconds_2;
        private System.Windows.Forms.Label lbl_Milliseconds;
        private System.Windows.Forms.NumericUpDown nud_StatisticMessageAfterEveryMinutes;
        private System.Windows.Forms.Label lbl_StatisticMessageAfterEvery;
        private System.Windows.Forms.Button btn_Standard;
        private System.Windows.Forms.Button btn_Default;
        private System.Windows.Forms.Panel p_Main;
        private System.Windows.Forms.GroupBox gb_NoSignalImage;
        private System.Windows.Forms.CheckBox chk_UseCustomNoSignalImage;
        private Mtf.Controls.MtfPictureBox pb_NoSignalImage;
        private System.Windows.Forms.Button btn_Browse;
        private System.Windows.Forms.GroupBox gb_EventLogging;
        private System.Windows.Forms.RadioButton rb_VerboseLogEveryEvents;
        private System.Windows.Forms.RadioButton rb_VerboseLogOnlyErrors;
        private System.Windows.Forms.CheckBox chk_VerboseDebugLogging;
        private System.Windows.Forms.GroupBox gb_TechnicalOptions;
        private System.Windows.Forms.CheckBox chk_UseWatchDog;
        private System.Windows.Forms.NumericUpDown nud_TimeBetweenCheckVideoServers;
        private System.Windows.Forms.Label lbl_TimeBetweenCheckVideoServers;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown nud_MaximumTimeToWaitForAVideoServerIs;
        private System.Windows.Forms.Label lbl_MaximumTimeToWaitForAVideoServerIs;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}