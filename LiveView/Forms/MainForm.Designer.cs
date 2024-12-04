namespace LiveView.Forms
{
    partial class MainForm
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            var treeNode2 = new System.Windows.Forms.TreeNode("I/O Devices", 0, 0);
            tsmiGeneralOptions = new System.Windows.Forms.ToolStripMenuItem();
            tsmiOptions = new System.Windows.Forms.ToolStripMenuItem();
            tsmiPersonalOptions = new System.Windows.Forms.ToolStripMenuItem();
            tsmiDisplaySettings = new System.Windows.Forms.ToolStripMenuItem();
            tsmiProfile = new System.Windows.Forms.ToolStripMenuItem();
            tssSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            tsmiUserAndGroupManagement = new System.Windows.Forms.ToolStripMenuItem();
            tsmiUsers = new System.Windows.Forms.ToolStripMenuItem();
            tsmiTemplates = new System.Windows.Forms.ToolStripMenuItem();
            tssSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            tsmiAutoCreateWizard = new System.Windows.Forms.ToolStripMenuItem();
            tssSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            tsmiSequentialChains = new System.Windows.Forms.ToolStripMenuItem();
            tsmiGridManagement = new System.Windows.Forms.ToolStripMenuItem();
            tssSeparator = new System.Windows.Forms.ToolStripSeparator();
            tsmiServerAndCameraManagement = new System.Windows.Forms.ToolStripMenuItem();
            btnLoginLogoutPrimary = new System.Windows.Forms.Button();
            tbPassword = new Mtf.Controls.PasswordBox();
            lblPassword = new System.Windows.Forms.Label();
            tbUsername = new System.Windows.Forms.TextBox();
            tsmiControlCenter = new System.Windows.Forms.ToolStripMenuItem();
            ttHint = new System.Windows.Forms.ToolTip(components);
            ilDatabaseIcons = new System.Windows.Forms.ImageList(components);
            tsbDatabaseUsage = new System.Windows.Forms.ToolStripButton();
            tsslUptime = new System.Windows.Forms.ToolStripStatusLabel();
            tsslSpaceHolder = new System.Windows.Forms.ToolStripStatusLabel();
            tsslLoggedOnUser = new System.Windows.Forms.ToolStripStatusLabel();
            ssStatusStrip = new System.Windows.Forms.StatusStrip();
            tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            tsmiLicense = new System.Windows.Forms.ToolStripMenuItem();
            tsmiMain = new System.Windows.Forms.ToolStripMenuItem();
            tsmiAbout = new System.Windows.Forms.ToolStripMenuItem();
            tsmiMapCreator = new System.Windows.Forms.ToolStripMenuItem();
            tsmiMotionPopup = new System.Windows.Forms.ToolStripMenuItem();
            tsmiIOPortsSettings = new System.Windows.Forms.ToolStripMenuItem();
            tsmiSyncronView = new System.Windows.Forms.ToolStripMenuItem();
            tsmiBarCodeReadings = new System.Windows.Forms.ToolStripMenuItem();
            tsmiPositioningMousePointer = new System.Windows.Forms.ToolStripMenuItem();
            tsmiLogViewer = new System.Windows.Forms.ToolStripMenuItem();
            tsmiLanguageEditor = new System.Windows.Forms.ToolStripMenuItem();
            tsmiHelp = new System.Windows.Forms.ToolStripMenuItem();
            tsmiTools = new System.Windows.Forms.ToolStripMenuItem();
            lblUsername = new System.Windows.Forms.Label();
            gbUserEvents = new System.Windows.Forms.GroupBox();
            lvUserEvents = new Mtf.Controls.MtfListView();
            chEventName = new System.Windows.Forms.ColumnHeader();
            chDescription = new System.Windows.Forms.ColumnHeader();
            splitter = new System.Windows.Forms.Splitter();
            pLeft = new System.Windows.Forms.Panel();
            pLeftBottom = new System.Windows.Forms.Panel();
            splitter4 = new System.Windows.Forms.Splitter();
            tvIOPorts = new Mtf.Controls.MtfTreeView();
            ilIOPortIcons = new System.Windows.Forms.ImageList(components);
            splitter2 = new System.Windows.Forms.Splitter();
            lvIOPorts = new Mtf.Controls.MtfListView();
            chPortName = new System.Windows.Forms.ColumnHeader();
            chPortValue = new System.Windows.Forms.ColumnHeader();
            chPortDirection = new System.Windows.Forms.ColumnHeader();
            gbSecondaryLogon = new System.Windows.Forms.GroupBox();
            btnLoginLogoutSecondary = new System.Windows.Forms.Button();
            tbPassword2 = new Mtf.Controls.PasswordBox();
            lblPassword2 = new System.Windows.Forms.Label();
            tbUsername2 = new System.Windows.Forms.TextBox();
            lblUsername2 = new System.Windows.Forms.Label();
            gbPrimaryLogon = new System.Windows.Forms.GroupBox();
            chIOPortEventNote = new System.Windows.Forms.ColumnHeader();
            chIOPortEventLoggedOnUser = new System.Windows.Forms.ColumnHeader();
            chIOPortEventPortState = new System.Windows.Forms.ColumnHeader();
            chIOPortEventPortNumber = new System.Windows.Forms.ColumnHeader();
            chIOPortEventDevice = new System.Windows.Forms.ColumnHeader();
            chIOPortEventDate = new System.Windows.Forms.ColumnHeader();
            chIOPortEventID = new System.Windows.Forms.ColumnHeader();
            lvPortEvents = new Mtf.Controls.MtfListView();
            gb_PortEvents = new System.Windows.Forms.GroupBox();
            splitter3 = new System.Windows.Forms.Splitter();
            pRightBottom = new System.Windows.Forms.Panel();
            pbMap = new Mtf.Controls.MtfPictureBox();
            pMap = new System.Windows.Forms.Panel();
            pMain = new System.Windows.Forms.Panel();
            msMenu = new System.Windows.Forms.MenuStrip();
            bwCreateStatisticsMessage = new System.ComponentModel.BackgroundWorker();
            ssStatusStrip.SuspendLayout();
            gbUserEvents.SuspendLayout();
            pLeft.SuspendLayout();
            pLeftBottom.SuspendLayout();
            gbSecondaryLogon.SuspendLayout();
            gbPrimaryLogon.SuspendLayout();
            gb_PortEvents.SuspendLayout();
            pRightBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbMap).BeginInit();
            pMap.SuspendLayout();
            pMain.SuspendLayout();
            msMenu.SuspendLayout();
            SuspendLayout();
            // 
            // tsmiGeneralOptions
            // 
            tsmiGeneralOptions.Enabled = false;
            tsmiGeneralOptions.Image = (System.Drawing.Image)resources.GetObject("tsmiGeneralOptions.Image");
            tsmiGeneralOptions.Name = "tsmiGeneralOptions";
            tsmiGeneralOptions.Size = new System.Drawing.Size(180, 22);
            tsmiGeneralOptions.Text = "General options";
            tsmiGeneralOptions.Click += TsmiGeneralOptions_Click;
            // 
            // tsmiOptions
            // 
            tsmiOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { tsmiPersonalOptions, tsmiGeneralOptions, tsmiDisplaySettings });
            tsmiOptions.Image = (System.Drawing.Image)resources.GetObject("tsmiOptions.Image");
            tsmiOptions.Name = "tsmiOptions";
            tsmiOptions.Size = new System.Drawing.Size(77, 20);
            tsmiOptions.Text = "Options";
            // 
            // tsmiPersonalOptions
            // 
            tsmiPersonalOptions.Enabled = false;
            tsmiPersonalOptions.Image = (System.Drawing.Image)resources.GetObject("tsmiPersonalOptions.Image");
            tsmiPersonalOptions.Name = "tsmiPersonalOptions";
            tsmiPersonalOptions.Size = new System.Drawing.Size(180, 22);
            tsmiPersonalOptions.Text = "Personal options";
            tsmiPersonalOptions.Click += TsmiPersonalOptions_Click;
            // 
            // tsmiDisplaySettings
            // 
            tsmiDisplaySettings.Enabled = false;
            tsmiDisplaySettings.Image = (System.Drawing.Image)resources.GetObject("tsmiDisplaySettings.Image");
            tsmiDisplaySettings.Name = "tsmiDisplaySettings";
            tsmiDisplaySettings.Size = new System.Drawing.Size(180, 22);
            tsmiDisplaySettings.Text = "Display settings";
            tsmiDisplaySettings.Click += TsmiDisplaySettings_Click;
            // 
            // tsmiProfile
            // 
            tsmiProfile.Enabled = false;
            tsmiProfile.Image = (System.Drawing.Image)resources.GetObject("tsmiProfile.Image");
            tsmiProfile.Name = "tsmiProfile";
            tsmiProfile.Size = new System.Drawing.Size(229, 22);
            tsmiProfile.Text = "Profile";
            tsmiProfile.Click += TsmiProfile_Click;
            // 
            // tssSeparator4
            // 
            tssSeparator4.Name = "tssSeparator4";
            tssSeparator4.Size = new System.Drawing.Size(226, 6);
            // 
            // tsmiUserAndGroupManagement
            // 
            tsmiUserAndGroupManagement.Enabled = false;
            tsmiUserAndGroupManagement.Image = (System.Drawing.Image)resources.GetObject("tsmiUserAndGroupManagement.Image");
            tsmiUserAndGroupManagement.Name = "tsmiUserAndGroupManagement";
            tsmiUserAndGroupManagement.Size = new System.Drawing.Size(229, 22);
            tsmiUserAndGroupManagement.Text = "User and group management";
            tsmiUserAndGroupManagement.Click += TsmiUserAndGroupManagement_Click;
            // 
            // tsmiUsers
            // 
            tsmiUsers.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { tsmiUserAndGroupManagement, tssSeparator4, tsmiProfile });
            tsmiUsers.Image = (System.Drawing.Image)resources.GetObject("tsmiUsers.Image");
            tsmiUsers.Name = "tsmiUsers";
            tsmiUsers.Size = new System.Drawing.Size(63, 20);
            tsmiUsers.Text = "Users";
            // 
            // tsmiTemplates
            // 
            tsmiTemplates.Enabled = false;
            tsmiTemplates.Image = (System.Drawing.Image)resources.GetObject("tsmiTemplates.Image");
            tsmiTemplates.Name = "tsmiTemplates";
            tsmiTemplates.Size = new System.Drawing.Size(245, 22);
            tsmiTemplates.Text = "Templates";
            tsmiTemplates.Click += TsmiTemplates_Click;
            // 
            // tssSeparator3
            // 
            tssSeparator3.Name = "tssSeparator3";
            tssSeparator3.Size = new System.Drawing.Size(242, 6);
            // 
            // tsmiAutoCreateWizard
            // 
            tsmiAutoCreateWizard.Enabled = false;
            tsmiAutoCreateWizard.Image = (System.Drawing.Image)resources.GetObject("tsmiAutoCreateWizard.Image");
            tsmiAutoCreateWizard.Name = "tsmiAutoCreateWizard";
            tsmiAutoCreateWizard.Size = new System.Drawing.Size(245, 22);
            tsmiAutoCreateWizard.Text = "Auto create wizard";
            tsmiAutoCreateWizard.Click += TsmiAutoCreateWizard_Click;
            // 
            // tssSeparator2
            // 
            tssSeparator2.Name = "tssSeparator2";
            tssSeparator2.Size = new System.Drawing.Size(242, 6);
            // 
            // tsmiSequentialChains
            // 
            tsmiSequentialChains.Enabled = false;
            tsmiSequentialChains.Image = (System.Drawing.Image)resources.GetObject("tsmiSequentialChains.Image");
            tsmiSequentialChains.Name = "tsmiSequentialChains";
            tsmiSequentialChains.Size = new System.Drawing.Size(245, 22);
            tsmiSequentialChains.Text = "Sequential chains";
            tsmiSequentialChains.Click += TsmiSequentialChains_Click;
            // 
            // tsmiGridManagement
            // 
            tsmiGridManagement.Enabled = false;
            tsmiGridManagement.Image = (System.Drawing.Image)resources.GetObject("tsmiGridManagement.Image");
            tsmiGridManagement.Name = "tsmiGridManagement";
            tsmiGridManagement.Size = new System.Drawing.Size(245, 22);
            tsmiGridManagement.Text = "Grid management";
            tsmiGridManagement.Click += TsmiGridManagement_Click;
            // 
            // tssSeparator
            // 
            tssSeparator.Name = "tssSeparator";
            tssSeparator.Size = new System.Drawing.Size(242, 6);
            // 
            // tsmiServerAndCameraManagement
            // 
            tsmiServerAndCameraManagement.Enabled = false;
            tsmiServerAndCameraManagement.Image = (System.Drawing.Image)resources.GetObject("tsmiServerAndCameraManagement.Image");
            tsmiServerAndCameraManagement.Name = "tsmiServerAndCameraManagement";
            tsmiServerAndCameraManagement.Size = new System.Drawing.Size(245, 22);
            tsmiServerAndCameraManagement.Text = "Server and camera management";
            tsmiServerAndCameraManagement.Click += TsmiServerAndCameraManagement_Click;
            // 
            // btnLoginLogoutPrimary
            // 
            btnLoginLogoutPrimary.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            btnLoginLogoutPrimary.Location = new System.Drawing.Point(7, 134);
            btnLoginLogoutPrimary.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnLoginLogoutPrimary.Name = "btnLoginLogoutPrimary";
            btnLoginLogoutPrimary.Size = new System.Drawing.Size(234, 27);
            btnLoginLogoutPrimary.TabIndex = 18;
            btnLoginLogoutPrimary.Text = "Login";
            btnLoginLogoutPrimary.UseVisualStyleBackColor = true;
            btnLoginLogoutPrimary.Click += BtnLoginLogoutPrimary_Click;
            // 
            // tbPassword
            // 
            tbPassword.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tbPassword.Location = new System.Drawing.Point(7, 105);
            tbPassword.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tbPassword.MaxLength = 100;
            tbPassword.Name = "tbPassword";
            tbPassword.Password = "";
            tbPassword.PasswordChar = '*';
            tbPassword.ShowRealPasswordLength = false;
            tbPassword.Size = new System.Drawing.Size(234, 23);
            tbPassword.TabIndex = 17;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new System.Drawing.Point(4, 83);
            lblPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new System.Drawing.Size(57, 15);
            lblPassword.TabIndex = 16;
            lblPassword.Text = "Password";
            // 
            // tbUsername
            // 
            tbUsername.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tbUsername.Location = new System.Drawing.Point(7, 54);
            tbUsername.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tbUsername.MaxLength = 100;
            tbUsername.Name = "tbUsername";
            tbUsername.Size = new System.Drawing.Size(234, 23);
            tbUsername.TabIndex = 15;
            // 
            // tsmiControlCenter
            // 
            tsmiControlCenter.Image = (System.Drawing.Image)resources.GetObject("tsmiControlCenter.Image");
            tsmiControlCenter.Name = "tsmiControlCenter";
            tsmiControlCenter.Size = new System.Drawing.Size(111, 20);
            tsmiControlCenter.Text = "Control center";
            tsmiControlCenter.Click += TsmiControlCenter_Click;
            // 
            // ilDatabaseIcons
            // 
            ilDatabaseIcons.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            ilDatabaseIcons.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("ilDatabaseIcons.ImageStream");
            ilDatabaseIcons.TransparentColor = System.Drawing.Color.Transparent;
            ilDatabaseIcons.Images.SetKeyName(0, "database_10.ico");
            ilDatabaseIcons.Images.SetKeyName(1, "database_20.ico");
            ilDatabaseIcons.Images.SetKeyName(2, "database_30.ico");
            ilDatabaseIcons.Images.SetKeyName(3, "database_40.ico");
            ilDatabaseIcons.Images.SetKeyName(4, "database_50.ico");
            ilDatabaseIcons.Images.SetKeyName(5, "database_60.ico");
            ilDatabaseIcons.Images.SetKeyName(6, "database_70.ico");
            ilDatabaseIcons.Images.SetKeyName(7, "database_80.ico");
            ilDatabaseIcons.Images.SetKeyName(8, "database_90.ico");
            ilDatabaseIcons.Images.SetKeyName(9, "database_100.ico");
            ilDatabaseIcons.Images.SetKeyName(10, "database_110.ico");
            // 
            // tsbDatabaseUsage
            // 
            tsbDatabaseUsage.Checked = true;
            tsbDatabaseUsage.CheckState = System.Windows.Forms.CheckState.Checked;
            tsbDatabaseUsage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            tsbDatabaseUsage.ImageTransparentColor = System.Drawing.Color.Magenta;
            tsbDatabaseUsage.Name = "tsbDatabaseUsage";
            tsbDatabaseUsage.Size = new System.Drawing.Size(87, 19);
            tsbDatabaseUsage.Text = "Not accessible";
            // 
            // tsslUptime
            // 
            tsslUptime.Name = "tsslUptime";
            tsslUptime.Size = new System.Drawing.Size(125, 15);
            tsslUptime.Text = "Uptime: 0 day 00:00:00";
            // 
            // tsslSpaceHolder
            // 
            tsslSpaceHolder.Name = "tsslSpaceHolder";
            tsslSpaceHolder.Size = new System.Drawing.Size(0, 0);
            tsslSpaceHolder.Spring = true;
            // 
            // tsslLoggedOnUser
            // 
            tsslLoggedOnUser.Name = "tsslLoggedOnUser";
            tsslLoggedOnUser.Size = new System.Drawing.Size(145, 15);
            tsslLoggedOnUser.Text = "There's no logged in users";
            tsslLoggedOnUser.Visible = false;
            // 
            // ssStatusStrip
            // 
            ssStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { tsslLoggedOnUser, tsslSpaceHolder, tsslUptime, tsbDatabaseUsage });
            ssStatusStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            ssStatusStrip.Location = new System.Drawing.Point(0, 676);
            ssStatusStrip.Name = "ssStatusStrip";
            ssStatusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            ssStatusStrip.ShowItemToolTips = true;
            ssStatusStrip.Size = new System.Drawing.Size(1186, 21);
            ssStatusStrip.TabIndex = 3;
            ssStatusStrip.Text = "statusStrip1";
            // 
            // tsmiExit
            // 
            tsmiExit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            tsmiExit.Image = (System.Drawing.Image)resources.GetObject("tsmiExit.Image");
            tsmiExit.Name = "tsmiExit";
            tsmiExit.Size = new System.Drawing.Size(53, 20);
            tsmiExit.Text = "Exit";
            tsmiExit.Click += TsmiExit_Click;
            // 
            // tsmiLicense
            // 
            tsmiLicense.Image = (System.Drawing.Image)resources.GetObject("tsmiLicense.Image");
            tsmiLicense.Name = "tsmiLicense";
            tsmiLicense.Size = new System.Drawing.Size(180, 22);
            tsmiLicense.Text = "License";
            tsmiLicense.Click += TsmiLicense_Click;
            // 
            // tsmiMain
            // 
            tsmiMain.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { tsmiServerAndCameraManagement, tssSeparator, tsmiGridManagement, tsmiSequentialChains, tssSeparator2, tsmiAutoCreateWizard, tssSeparator3, tsmiTemplates });
            tsmiMain.Image = (System.Drawing.Image)resources.GetObject("tsmiMain.Image");
            tsmiMain.Name = "tsmiMain";
            tsmiMain.Size = new System.Drawing.Size(62, 20);
            tsmiMain.Text = "Main";
            // 
            // tsmiAbout
            // 
            tsmiAbout.Image = (System.Drawing.Image)resources.GetObject("tsmiAbout.Image");
            tsmiAbout.Name = "tsmiAbout";
            tsmiAbout.Size = new System.Drawing.Size(180, 22);
            tsmiAbout.Text = "About";
            tsmiAbout.Click += TsmiAbout_Click;
            // 
            // tsmiMapCreator
            // 
            tsmiMapCreator.Image = (System.Drawing.Image)resources.GetObject("tsmiMapCreator.Image");
            tsmiMapCreator.Name = "tsmiMapCreator";
            tsmiMapCreator.Size = new System.Drawing.Size(215, 22);
            tsmiMapCreator.Text = "Map creator";
            tsmiMapCreator.Click += TsmiMapCreator_Click;
            // 
            // tsmiMotionPopup
            // 
            tsmiMotionPopup.Enabled = false;
            tsmiMotionPopup.Image = (System.Drawing.Image)resources.GetObject("tsmiMotionPopup.Image");
            tsmiMotionPopup.Name = "tsmiMotionPopup";
            tsmiMotionPopup.Size = new System.Drawing.Size(215, 22);
            tsmiMotionPopup.Text = "Motion popup";
            tsmiMotionPopup.Click += TsmiMotionPopup_Click;
            // 
            // tsmiIOPortsSettings
            // 
            tsmiIOPortsSettings.Enabled = false;
            tsmiIOPortsSettings.Image = (System.Drawing.Image)resources.GetObject("tsmiIOPortsSettings.Image");
            tsmiIOPortsSettings.Name = "tsmiIOPortsSettings";
            tsmiIOPortsSettings.Size = new System.Drawing.Size(215, 22);
            tsmiIOPortsSettings.Text = "I/O ports' settings";
            tsmiIOPortsSettings.Click += TsmiIOPortsSettings_Click;
            // 
            // tsmiSyncronView
            // 
            tsmiSyncronView.Enabled = false;
            tsmiSyncronView.Image = (System.Drawing.Image)resources.GetObject("tsmiSyncronView.Image");
            tsmiSyncronView.Name = "tsmiSyncronView";
            tsmiSyncronView.Size = new System.Drawing.Size(215, 22);
            tsmiSyncronView.Text = "Syncron view";
            tsmiSyncronView.Click += TsmiSyncronView_Click;
            // 
            // tsmiBarCodeReadings
            // 
            tsmiBarCodeReadings.Enabled = false;
            tsmiBarCodeReadings.Image = (System.Drawing.Image)resources.GetObject("tsmiBarCodeReadings.Image");
            tsmiBarCodeReadings.Name = "tsmiBarCodeReadings";
            tsmiBarCodeReadings.Size = new System.Drawing.Size(215, 22);
            tsmiBarCodeReadings.Text = "Bar code readings";
            tsmiBarCodeReadings.Click += TsmiBarCodeReadings_Click;
            // 
            // tsmiPositioningMousePointer
            // 
            tsmiPositioningMousePointer.Image = (System.Drawing.Image)resources.GetObject("tsmiPositioningMousePointer.Image");
            tsmiPositioningMousePointer.Name = "tsmiPositioningMousePointer";
            tsmiPositioningMousePointer.ShortcutKeyDisplayString = "Home";
            tsmiPositioningMousePointer.Size = new System.Drawing.Size(215, 22);
            tsmiPositioningMousePointer.Text = "Set mouse position";
            tsmiPositioningMousePointer.Click += TsmiPositioningMousePointer_Click;
            // 
            // tsmiLogViewer
            // 
            tsmiLogViewer.Enabled = false;
            tsmiLogViewer.Image = (System.Drawing.Image)resources.GetObject("tsmiLogViewer.Image");
            tsmiLogViewer.Name = "tsmiLogViewer";
            tsmiLogViewer.Size = new System.Drawing.Size(215, 22);
            tsmiLogViewer.Text = "Log viewer";
            tsmiLogViewer.Click += TsmiLogViewer_Click;
            // 
            // tsmiLanguageEditor
            // 
            tsmiLanguageEditor.Enabled = false;
            tsmiLanguageEditor.Image = (System.Drawing.Image)resources.GetObject("tsmiLanguageEditor.Image");
            tsmiLanguageEditor.Name = "tsmiLanguageEditor";
            tsmiLanguageEditor.Size = new System.Drawing.Size(215, 22);
            tsmiLanguageEditor.Text = "Language editor";
            tsmiLanguageEditor.Click += TsmiLanguageEditor_Click;
            // 
            // tsmiHelp
            // 
            tsmiHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { tsmiAbout, tsmiLicense });
            tsmiHelp.Image = (System.Drawing.Image)resources.GetObject("tsmiHelp.Image");
            tsmiHelp.Name = "tsmiHelp";
            tsmiHelp.Size = new System.Drawing.Size(60, 20);
            tsmiHelp.Text = "Help";
            // 
            // tsmiTools
            // 
            tsmiTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { tsmiLanguageEditor, tsmiLogViewer, tsmiPositioningMousePointer, tsmiBarCodeReadings, tsmiSyncronView, tsmiIOPortsSettings, tsmiMotionPopup, tsmiMapCreator });
            tsmiTools.Image = (System.Drawing.Image)resources.GetObject("tsmiTools.Image");
            tsmiTools.Name = "tsmiTools";
            tsmiTools.Size = new System.Drawing.Size(63, 20);
            tsmiTools.Text = "Tools";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new System.Drawing.Point(4, 32);
            lblUsername.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new System.Drawing.Size(60, 15);
            lblUsername.TabIndex = 14;
            lblUsername.Text = "Username";
            // 
            // gbUserEvents
            // 
            gbUserEvents.Controls.Add(lvUserEvents);
            gbUserEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            gbUserEvents.Location = new System.Drawing.Point(0, 147);
            gbUserEvents.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbUserEvents.Name = "gbUserEvents";
            gbUserEvents.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbUserEvents.Size = new System.Drawing.Size(253, 171);
            gbUserEvents.TabIndex = 14;
            gbUserEvents.TabStop = false;
            gbUserEvents.Text = "Choose the active event";
            // 
            // lvUserEvents
            // 
            lvUserEvents.AlternatingColorEven = System.Drawing.Color.LightBlue;
            lvUserEvents.AlternatingColorOdd = System.Drawing.SystemColors.Window;
            lvUserEvents.AlternatingColorsAreInUse = true;
            lvUserEvents.AlternatingPairColorEven = System.Drawing.Color.LightSeaGreen;
            lvUserEvents.AlternatingPairColorOdd = System.Drawing.Color.CadetBlue;
            lvUserEvents.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { chEventName, chDescription });
            lvUserEvents.CompactView = false;
            lvUserEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            lvUserEvents.Enabled = false;
            lvUserEvents.EnsureLastItemIsVisible = false;
            lvUserEvents.FirstItemIsGray = false;
            lvUserEvents.FullRowSelect = true;
            lvUserEvents.Location = new System.Drawing.Point(4, 19);
            lvUserEvents.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            lvUserEvents.MultiSelect = false;
            lvUserEvents.Name = "lvUserEvents";
            lvUserEvents.OwnerDraw = true;
            lvUserEvents.ReadonlyCheckboxes = false;
            lvUserEvents.SameItemsColorEven = System.Drawing.Color.DarkOrange;
            lvUserEvents.SameItemsColorOdd = System.Drawing.Color.LightSalmon;
            lvUserEvents.Size = new System.Drawing.Size(245, 149);
            lvUserEvents.TabIndex = 0;
            lvUserEvents.UseCompatibleStateImageBehavior = false;
            lvUserEvents.View = System.Windows.Forms.View.Details;
            // 
            // chEventName
            // 
            chEventName.Text = "Event name";
            chEventName.Width = 77;
            // 
            // chDescription
            // 
            chDescription.Text = "Description";
            chDescription.Width = 130;
            // 
            // splitter
            // 
            splitter.BackColor = System.Drawing.SystemColors.ControlDark;
            splitter.Location = new System.Drawing.Point(253, 24);
            splitter.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            splitter.Name = "splitter";
            splitter.Size = new System.Drawing.Size(4, 652);
            splitter.TabIndex = 6;
            splitter.TabStop = false;
            // 
            // pLeft
            // 
            pLeft.Controls.Add(pLeftBottom);
            pLeft.Controls.Add(gbSecondaryLogon);
            pLeft.Controls.Add(gbPrimaryLogon);
            pLeft.Dock = System.Windows.Forms.DockStyle.Left;
            pLeft.Location = new System.Drawing.Point(0, 24);
            pLeft.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pLeft.Name = "pLeft";
            pLeft.Size = new System.Drawing.Size(253, 652);
            pLeft.TabIndex = 5;
            // 
            // pLeftBottom
            // 
            pLeftBottom.Controls.Add(gbUserEvents);
            pLeftBottom.Controls.Add(splitter4);
            pLeftBottom.Controls.Add(tvIOPorts);
            pLeftBottom.Controls.Add(splitter2);
            pLeftBottom.Controls.Add(lvIOPorts);
            pLeftBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            pLeftBottom.Location = new System.Drawing.Point(0, 334);
            pLeftBottom.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pLeftBottom.Name = "pLeftBottom";
            pLeftBottom.Size = new System.Drawing.Size(253, 318);
            pLeftBottom.TabIndex = 13;
            // 
            // splitter4
            // 
            splitter4.Dock = System.Windows.Forms.DockStyle.Top;
            splitter4.Location = new System.Drawing.Point(0, 144);
            splitter4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            splitter4.Name = "splitter4";
            splitter4.Size = new System.Drawing.Size(253, 3);
            splitter4.TabIndex = 4;
            splitter4.TabStop = false;
            // 
            // tvIOPorts
            // 
            tvIOPorts.CheckBoxBackground = System.Drawing.SystemColors.Window;
            tvIOPorts.Dock = System.Windows.Forms.DockStyle.Top;
            tvIOPorts.DrawDefaultImageToNodes = true;
            tvIOPorts.HideSelection = false;
            tvIOPorts.ImageIndex = 0;
            tvIOPorts.ImageList = ilIOPortIcons;
            tvIOPorts.LineStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            tvIOPorts.Location = new System.Drawing.Point(0, 80);
            tvIOPorts.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tvIOPorts.MultiSelect = false;
            tvIOPorts.Name = "tvIOPorts";
            treeNode2.ImageIndex = 0;
            treeNode2.Name = "IO_Devices";
            treeNode2.SelectedImageIndex = 0;
            treeNode2.Text = "I/O Devices";
            tvIOPorts.Nodes.AddRange(new System.Windows.Forms.TreeNode[] { treeNode2 });
            tvIOPorts.SelectedImageIndex = 0;
            tvIOPorts.ShowPlusMinusOnRootNodes = true;
            tvIOPorts.Size = new System.Drawing.Size(253, 64);
            tvIOPorts.StateImageList = ilIOPortIcons;
            tvIOPorts.StateImageOrCheckBoxOnLeft = false;
            tvIOPorts.TabIndex = 3;
            tvIOPorts.TickColor = System.Drawing.Color.Green;
            // 
            // ilIOPortIcons
            // 
            ilIOPortIcons.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            ilIOPortIcons.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("ilIOPortIcons.ImageStream");
            ilIOPortIcons.TransparentColor = System.Drawing.Color.Transparent;
            ilIOPortIcons.Images.SetKeyName(0, "app.ico");
            ilIOPortIcons.Images.SetKeyName(1, "0.ico");
            ilIOPortIcons.Images.SetKeyName(2, "1.ico");
            ilIOPortIcons.Images.SetKeyName(3, "in.ico");
            ilIOPortIcons.Images.SetKeyName(4, "out.ico");
            // 
            // splitter2
            // 
            splitter2.Dock = System.Windows.Forms.DockStyle.Top;
            splitter2.Location = new System.Drawing.Point(0, 77);
            splitter2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            splitter2.Name = "splitter2";
            splitter2.Size = new System.Drawing.Size(253, 3);
            splitter2.TabIndex = 2;
            splitter2.TabStop = false;
            // 
            // lvIOPorts
            // 
            lvIOPorts.AlternatingColorEven = System.Drawing.Color.LightBlue;
            lvIOPorts.AlternatingColorOdd = System.Drawing.SystemColors.Window;
            lvIOPorts.AlternatingColorsAreInUse = true;
            lvIOPorts.AlternatingPairColorEven = System.Drawing.Color.LightSeaGreen;
            lvIOPorts.AlternatingPairColorOdd = System.Drawing.Color.CadetBlue;
            lvIOPorts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { chPortName, chPortValue, chPortDirection });
            lvIOPorts.CompactView = false;
            lvIOPorts.Dock = System.Windows.Forms.DockStyle.Top;
            lvIOPorts.EnsureLastItemIsVisible = false;
            lvIOPorts.FirstItemIsGray = false;
            lvIOPorts.FullRowSelect = true;
            lvIOPorts.Location = new System.Drawing.Point(0, 0);
            lvIOPorts.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            lvIOPorts.Name = "lvIOPorts";
            lvIOPorts.OwnerDraw = true;
            lvIOPorts.ReadonlyCheckboxes = false;
            lvIOPorts.SameItemsColorEven = System.Drawing.Color.DarkOrange;
            lvIOPorts.SameItemsColorOdd = System.Drawing.Color.LightSalmon;
            lvIOPorts.Size = new System.Drawing.Size(253, 77);
            lvIOPorts.TabIndex = 1;
            lvIOPorts.UseCompatibleStateImageBehavior = false;
            lvIOPorts.View = System.Windows.Forms.View.Details;
            lvIOPorts.Visible = false;
            // 
            // chPortName
            // 
            chPortName.Text = "Port name";
            chPortName.Width = 106;
            // 
            // chPortValue
            // 
            chPortValue.Text = "Value";
            // 
            // chPortDirection
            // 
            chPortDirection.Text = "Direction";
            // 
            // gbSecondaryLogon
            // 
            gbSecondaryLogon.Controls.Add(btnLoginLogoutSecondary);
            gbSecondaryLogon.Controls.Add(tbPassword2);
            gbSecondaryLogon.Controls.Add(lblPassword2);
            gbSecondaryLogon.Controls.Add(tbUsername2);
            gbSecondaryLogon.Controls.Add(lblUsername2);
            gbSecondaryLogon.Dock = System.Windows.Forms.DockStyle.Top;
            gbSecondaryLogon.Location = new System.Drawing.Point(0, 167);
            gbSecondaryLogon.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbSecondaryLogon.Name = "gbSecondaryLogon";
            gbSecondaryLogon.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbSecondaryLogon.Size = new System.Drawing.Size(253, 167);
            gbSecondaryLogon.TabIndex = 7;
            gbSecondaryLogon.TabStop = false;
            gbSecondaryLogon.Text = "Secondary login";
            gbSecondaryLogon.Visible = false;
            // 
            // btnLoginLogoutSecondary
            // 
            btnLoginLogoutSecondary.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            btnLoginLogoutSecondary.Location = new System.Drawing.Point(7, 134);
            btnLoginLogoutSecondary.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnLoginLogoutSecondary.Name = "btnLoginLogoutSecondary";
            btnLoginLogoutSecondary.Size = new System.Drawing.Size(234, 27);
            btnLoginLogoutSecondary.TabIndex = 18;
            btnLoginLogoutSecondary.Text = "Login";
            btnLoginLogoutSecondary.UseVisualStyleBackColor = true;
            btnLoginLogoutSecondary.Click += BtnLoginLogoutSecondary_Click;
            // 
            // tbPassword2
            // 
            tbPassword2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tbPassword2.Location = new System.Drawing.Point(7, 105);
            tbPassword2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tbPassword2.MaxLength = 100;
            tbPassword2.Name = "tbPassword2";
            tbPassword2.Password = "";
            tbPassword2.PasswordChar = '*';
            tbPassword2.ShowRealPasswordLength = false;
            tbPassword2.Size = new System.Drawing.Size(234, 23);
            tbPassword2.TabIndex = 17;
            // 
            // lblPassword2
            // 
            lblPassword2.AutoSize = true;
            lblPassword2.Location = new System.Drawing.Point(4, 83);
            lblPassword2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblPassword2.Name = "lblPassword2";
            lblPassword2.Size = new System.Drawing.Size(57, 15);
            lblPassword2.TabIndex = 16;
            lblPassword2.Text = "Password";
            // 
            // tbUsername2
            // 
            tbUsername2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tbUsername2.Location = new System.Drawing.Point(7, 54);
            tbUsername2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tbUsername2.MaxLength = 100;
            tbUsername2.Name = "tbUsername2";
            tbUsername2.Size = new System.Drawing.Size(234, 23);
            tbUsername2.TabIndex = 15;
            // 
            // lblUsername2
            // 
            lblUsername2.AutoSize = true;
            lblUsername2.Location = new System.Drawing.Point(4, 32);
            lblUsername2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblUsername2.Name = "lblUsername2";
            lblUsername2.Size = new System.Drawing.Size(60, 15);
            lblUsername2.TabIndex = 14;
            lblUsername2.Text = "Username";
            // 
            // gbPrimaryLogon
            // 
            gbPrimaryLogon.Controls.Add(btnLoginLogoutPrimary);
            gbPrimaryLogon.Controls.Add(tbPassword);
            gbPrimaryLogon.Controls.Add(lblPassword);
            gbPrimaryLogon.Controls.Add(tbUsername);
            gbPrimaryLogon.Controls.Add(lblUsername);
            gbPrimaryLogon.Dock = System.Windows.Forms.DockStyle.Top;
            gbPrimaryLogon.Location = new System.Drawing.Point(0, 0);
            gbPrimaryLogon.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbPrimaryLogon.Name = "gbPrimaryLogon";
            gbPrimaryLogon.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbPrimaryLogon.Size = new System.Drawing.Size(253, 167);
            gbPrimaryLogon.TabIndex = 6;
            gbPrimaryLogon.TabStop = false;
            gbPrimaryLogon.Text = "Primary login";
            // 
            // chIOPortEventNote
            // 
            chIOPortEventNote.Text = "Note";
            chIOPortEventNote.Width = 200;
            // 
            // chIOPortEventLoggedOnUser
            // 
            chIOPortEventLoggedOnUser.Text = "Logged in user";
            chIOPortEventLoggedOnUser.Width = 215;
            // 
            // chIOPortEventPortState
            // 
            chIOPortEventPortState.Text = "State";
            chIOPortEventPortState.Width = 56;
            // 
            // chIOPortEventPortNumber
            // 
            chIOPortEventPortNumber.Text = "Port number";
            chIOPortEventPortNumber.Width = 70;
            // 
            // chIOPortEventDevice
            // 
            chIOPortEventDevice.Text = "I/O device";
            chIOPortEventDevice.Width = 73;
            // 
            // chIOPortEventDate
            // 
            chIOPortEventDate.Text = "Date";
            chIOPortEventDate.Width = 114;
            // 
            // chIOPortEventID
            // 
            chIOPortEventID.Text = "ID";
            chIOPortEventID.Width = 56;
            // 
            // lvPortEvents
            // 
            lvPortEvents.AlternatingColorEven = System.Drawing.Color.LightBlue;
            lvPortEvents.AlternatingColorOdd = System.Drawing.SystemColors.Window;
            lvPortEvents.AlternatingColorsAreInUse = true;
            lvPortEvents.AlternatingPairColorEven = System.Drawing.Color.LightSeaGreen;
            lvPortEvents.AlternatingPairColorOdd = System.Drawing.Color.CadetBlue;
            lvPortEvents.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { chIOPortEventID, chIOPortEventDate, chIOPortEventDevice, chIOPortEventPortNumber, chIOPortEventPortState, chIOPortEventLoggedOnUser, chIOPortEventNote });
            lvPortEvents.CompactView = false;
            lvPortEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            lvPortEvents.EnsureLastItemIsVisible = false;
            lvPortEvents.FirstItemIsGray = false;
            lvPortEvents.FullRowSelect = true;
            lvPortEvents.Location = new System.Drawing.Point(4, 19);
            lvPortEvents.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            lvPortEvents.Name = "lvPortEvents";
            lvPortEvents.OwnerDraw = true;
            lvPortEvents.ReadonlyCheckboxes = false;
            lvPortEvents.SameItemsColorEven = System.Drawing.Color.DarkOrange;
            lvPortEvents.SameItemsColorOdd = System.Drawing.Color.LightSalmon;
            lvPortEvents.Size = new System.Drawing.Size(921, 142);
            lvPortEvents.TabIndex = 1;
            lvPortEvents.UseCompatibleStateImageBehavior = false;
            lvPortEvents.View = System.Windows.Forms.View.Details;
            // 
            // gb_PortEvents
            // 
            gb_PortEvents.Controls.Add(lvPortEvents);
            gb_PortEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            gb_PortEvents.Location = new System.Drawing.Point(0, 0);
            gb_PortEvents.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gb_PortEvents.Name = "gb_PortEvents";
            gb_PortEvents.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gb_PortEvents.Size = new System.Drawing.Size(929, 164);
            gb_PortEvents.TabIndex = 0;
            gb_PortEvents.TabStop = false;
            // 
            // splitter3
            // 
            splitter3.BackColor = System.Drawing.SystemColors.ControlDark;
            splitter3.Dock = System.Windows.Forms.DockStyle.Bottom;
            splitter3.Location = new System.Drawing.Point(257, 509);
            splitter3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            splitter3.Name = "splitter3";
            splitter3.Size = new System.Drawing.Size(929, 3);
            splitter3.TabIndex = 10;
            splitter3.TabStop = false;
            // 
            // pRightBottom
            // 
            pRightBottom.Controls.Add(gb_PortEvents);
            pRightBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            pRightBottom.Location = new System.Drawing.Point(257, 512);
            pRightBottom.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pRightBottom.Name = "pRightBottom";
            pRightBottom.Size = new System.Drawing.Size(929, 164);
            pRightBottom.TabIndex = 9;
            // 
            // pbMap
            // 
            pbMap.Dock = System.Windows.Forms.DockStyle.Fill;
            pbMap.Image = (System.Drawing.Image)resources.GetObject("pbMap.Image");
            pbMap.Location = new System.Drawing.Point(0, 0);
            pbMap.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pbMap.Name = "pbMap";
            pbMap.OriginalSize = new System.Drawing.Size(100, 50);
            pbMap.RepositioningAndResizingControlsOnResize = false;
            pbMap.Size = new System.Drawing.Size(929, 485);
            pbMap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pbMap.TabIndex = 0;
            pbMap.TabStop = false;
            // 
            // pMap
            // 
            pMap.BackColor = System.Drawing.Color.AliceBlue;
            pMap.Controls.Add(pbMap);
            pMap.Dock = System.Windows.Forms.DockStyle.Fill;
            pMap.Location = new System.Drawing.Point(257, 24);
            pMap.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pMap.Name = "pMap";
            pMap.Size = new System.Drawing.Size(929, 485);
            pMap.TabIndex = 11;
            // 
            // pMain
            // 
            pMain.Controls.Add(pMap);
            pMain.Controls.Add(splitter3);
            pMain.Controls.Add(pRightBottom);
            pMain.Controls.Add(splitter);
            pMain.Controls.Add(pLeft);
            pMain.Controls.Add(msMenu);
            pMain.Controls.Add(ssStatusStrip);
            pMain.Dock = System.Windows.Forms.DockStyle.Fill;
            pMain.Location = new System.Drawing.Point(0, 0);
            pMain.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pMain.Name = "pMain";
            pMain.Size = new System.Drawing.Size(1186, 697);
            pMain.TabIndex = 1;
            // 
            // msMenu
            // 
            msMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { tsmiControlCenter, tsmiMain, tsmiUsers, tsmiOptions, tsmiTools, tsmiHelp, tsmiExit });
            msMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            msMenu.Location = new System.Drawing.Point(0, 0);
            msMenu.Name = "msMenu";
            msMenu.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            msMenu.Size = new System.Drawing.Size(1186, 24);
            msMenu.TabIndex = 4;
            msMenu.Text = "menuStrip1";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1186, 697);
            Controls.Add(pMain);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "MainForm";
            StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            Text = "LiveView";
            FormClosing += MainForm_FormClosing;
            Shown += MainForm_Shown;
            ssStatusStrip.ResumeLayout(false);
            ssStatusStrip.PerformLayout();
            gbUserEvents.ResumeLayout(false);
            pLeft.ResumeLayout(false);
            pLeftBottom.ResumeLayout(false);
            gbSecondaryLogon.ResumeLayout(false);
            gbSecondaryLogon.PerformLayout();
            gbPrimaryLogon.ResumeLayout(false);
            gbPrimaryLogon.PerformLayout();
            gb_PortEvents.ResumeLayout(false);
            pRightBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbMap).EndInit();
            pMap.ResumeLayout(false);
            pMain.ResumeLayout(false);
            pMain.PerformLayout();
            msMenu.ResumeLayout(false);
            msMenu.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem tsmiGeneralOptions;
        private System.Windows.Forms.ToolStripMenuItem tsmiOptions;
        private System.Windows.Forms.ToolStripMenuItem tsmiPersonalOptions;
        private System.Windows.Forms.ToolStripMenuItem tsmiDisplaySettings;
        private System.Windows.Forms.ToolStripMenuItem tsmiProfile;
        private System.Windows.Forms.ToolStripSeparator tssSeparator4;
        private System.Windows.Forms.ToolStripMenuItem tsmiUserAndGroupManagement;
        private System.Windows.Forms.ToolStripMenuItem tsmiUsers;
        private System.Windows.Forms.ToolStripMenuItem tsmiTemplates;
        private System.Windows.Forms.ToolStripSeparator tssSeparator3;
        private System.Windows.Forms.ToolStripMenuItem tsmiAutoCreateWizard;
        private System.Windows.Forms.ToolStripSeparator tssSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmiSequentialChains;
        private System.Windows.Forms.ToolStripMenuItem tsmiGridManagement;
        private System.Windows.Forms.ToolStripSeparator tssSeparator;
        private System.Windows.Forms.ToolStripMenuItem tsmiServerAndCameraManagement;
        private System.Windows.Forms.Button btnLoginLogoutPrimary;
        private Mtf.Controls.PasswordBox tbPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.ToolStripMenuItem tsmiControlCenter;
        private System.Windows.Forms.ToolTip ttHint;
        private System.Windows.Forms.ImageList ilDatabaseIcons;
        private System.Windows.Forms.ToolStripButton tsbDatabaseUsage;
        private System.Windows.Forms.ToolStripStatusLabel tsslUptime;
        private System.Windows.Forms.ToolStripStatusLabel tsslSpaceHolder;
        private System.Windows.Forms.ToolStripStatusLabel tsslLoggedOnUser;
        private System.Windows.Forms.StatusStrip ssStatusStrip;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.ToolStripMenuItem tsmiLicense;
        private System.Windows.Forms.ToolStripMenuItem tsmiMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiAbout;
        private System.Windows.Forms.ToolStripMenuItem tsmiMapCreator;
        private System.Windows.Forms.ToolStripMenuItem tsmiMotionPopup;
        private System.Windows.Forms.ToolStripMenuItem tsmiIOPortsSettings;
        private System.Windows.Forms.ToolStripMenuItem tsmiSyncronView;
        private System.Windows.Forms.ToolStripMenuItem tsmiBarCodeReadings;
        private System.Windows.Forms.ToolStripMenuItem tsmiPositioningMousePointer;
        private System.Windows.Forms.ToolStripMenuItem tsmiLogViewer;
        private System.Windows.Forms.ToolStripMenuItem tsmiLanguageEditor;
        private System.Windows.Forms.ToolStripMenuItem tsmiHelp;
        private System.Windows.Forms.ToolStripMenuItem tsmiTools;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.GroupBox gbUserEvents;
        private Mtf.Controls.MtfListView lvUserEvents;
        private System.Windows.Forms.ColumnHeader chEventName;
        private System.Windows.Forms.ColumnHeader chDescription;
        private System.Windows.Forms.Splitter splitter;
        private System.Windows.Forms.Panel pLeft;
        private System.Windows.Forms.Panel pLeftBottom;
        private System.Windows.Forms.Splitter splitter4;
        private Mtf.Controls.MtfTreeView tvIOPorts;
        private System.Windows.Forms.ImageList ilIOPortIcons;
        private System.Windows.Forms.Splitter splitter2;
        private Mtf.Controls.MtfListView lvIOPorts;
        private System.Windows.Forms.ColumnHeader chPortName;
        private System.Windows.Forms.ColumnHeader chPortValue;
        private System.Windows.Forms.ColumnHeader chPortDirection;
        private System.Windows.Forms.GroupBox gbSecondaryLogon;
        private System.Windows.Forms.Button btnLoginLogoutSecondary;
        private Mtf.Controls.PasswordBox tbPassword2;
        private System.Windows.Forms.Label lblPassword2;
        private System.Windows.Forms.TextBox tbUsername2;
        private System.Windows.Forms.Label lblUsername2;
        private System.Windows.Forms.GroupBox gbPrimaryLogon;
        private System.Windows.Forms.ColumnHeader chIOPortEventNote;
        private System.Windows.Forms.ColumnHeader chIOPortEventLoggedOnUser;
        private System.Windows.Forms.ColumnHeader chIOPortEventPortState;
        private System.Windows.Forms.ColumnHeader chIOPortEventPortNumber;
        private System.Windows.Forms.ColumnHeader chIOPortEventDevice;
        private System.Windows.Forms.ColumnHeader chIOPortEventDate;
        private System.Windows.Forms.ColumnHeader chIOPortEventID;
        private Mtf.Controls.MtfListView lvPortEvents;
        private System.Windows.Forms.GroupBox gb_PortEvents;
        private System.Windows.Forms.Splitter splitter3;
        private System.Windows.Forms.Panel pRightBottom;
        private Mtf.Controls.MtfPictureBox pbMap;
        private System.Windows.Forms.Panel pMap;
        private System.Windows.Forms.Panel pMain;
        private System.Windows.Forms.MenuStrip msMenu;
        private System.ComponentModel.BackgroundWorker bwCreateStatisticsMessage;
    }
}