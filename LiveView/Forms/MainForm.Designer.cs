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
            var treeNode1 = new System.Windows.Forms.TreeNode("I/O Devices", 0, 0);
            tsmi_GeneralOptions = new System.Windows.Forms.ToolStripMenuItem();
            tsmi_Options = new System.Windows.Forms.ToolStripMenuItem();
            tsmi_PersonalOptions = new System.Windows.Forms.ToolStripMenuItem();
            tsmi_DisplaySettings = new System.Windows.Forms.ToolStripMenuItem();
            tsmi_Profile = new System.Windows.Forms.ToolStripMenuItem();
            tss_Separator4 = new System.Windows.Forms.ToolStripSeparator();
            tsmi_UserAndGroupManagement = new System.Windows.Forms.ToolStripMenuItem();
            tsmi_Users = new System.Windows.Forms.ToolStripMenuItem();
            tsmi_Templates = new System.Windows.Forms.ToolStripMenuItem();
            tss_Separator3 = new System.Windows.Forms.ToolStripSeparator();
            tsmi_AutoCreateWizard = new System.Windows.Forms.ToolStripMenuItem();
            tss_Separator2 = new System.Windows.Forms.ToolStripSeparator();
            tsmi_SequentialChains = new System.Windows.Forms.ToolStripMenuItem();
            tsmi_GridManagement = new System.Windows.Forms.ToolStripMenuItem();
            tss_Separator = new System.Windows.Forms.ToolStripSeparator();
            tsmi_ServerAndCameraManagement = new System.Windows.Forms.ToolStripMenuItem();
            btn_LoginLogoutPrimary = new System.Windows.Forms.Button();
            tb_Password = new Mtf.Controls.PasswordBox();
            lbl_Password = new System.Windows.Forms.Label();
            tb_Username = new System.Windows.Forms.TextBox();
            tsmi_ControlCenter = new System.Windows.Forms.ToolStripMenuItem();
            tt_Hint = new System.Windows.Forms.ToolTip(components);
            il_DatabaseIcons = new System.Windows.Forms.ImageList(components);
            tsb_DatabaseUsage = new System.Windows.Forms.ToolStripButton();
            tssl_Uptime = new System.Windows.Forms.ToolStripStatusLabel();
            tssl_SpaceHolder = new System.Windows.Forms.ToolStripStatusLabel();
            tssl_LoggedOnUser = new System.Windows.Forms.ToolStripStatusLabel();
            ss_StatusStrip = new System.Windows.Forms.StatusStrip();
            tsmi_Exit = new System.Windows.Forms.ToolStripMenuItem();
            tsmi_License = new System.Windows.Forms.ToolStripMenuItem();
            tsmi_Main = new System.Windows.Forms.ToolStripMenuItem();
            tsmi_About = new System.Windows.Forms.ToolStripMenuItem();
            tsmi_MapCreator = new System.Windows.Forms.ToolStripMenuItem();
            tsmi_MotionPopup = new System.Windows.Forms.ToolStripMenuItem();
            tsmi_IOPortsSettings = new System.Windows.Forms.ToolStripMenuItem();
            tsmi_SyncronView = new System.Windows.Forms.ToolStripMenuItem();
            tsmi_BarCodeReadings = new System.Windows.Forms.ToolStripMenuItem();
            tsmi_PositioningMousePointer = new System.Windows.Forms.ToolStripMenuItem();
            tsmi_LogViewer = new System.Windows.Forms.ToolStripMenuItem();
            tsmi_LanguageEditor = new System.Windows.Forms.ToolStripMenuItem();
            tsmi_Help = new System.Windows.Forms.ToolStripMenuItem();
            tsmi_Tools = new System.Windows.Forms.ToolStripMenuItem();
            lbl_Username = new System.Windows.Forms.Label();
            gb_UserEvents = new System.Windows.Forms.GroupBox();
            lv_UserEvents = new Mtf.Controls.MtfListView();
            ch_0_EventName = new System.Windows.Forms.ColumnHeader();
            ch_1_Description = new System.Windows.Forms.ColumnHeader();
            s_Splitter = new System.Windows.Forms.Splitter();
            p_Left = new System.Windows.Forms.Panel();
            p_LeftBottom = new System.Windows.Forms.Panel();
            s_Splitter4 = new System.Windows.Forms.Splitter();
            tv_IOPorts = new Mtf.Controls.MtfTreeView();
            il_IOPortIcons = new System.Windows.Forms.ImageList(components);
            s_Splitter2 = new System.Windows.Forms.Splitter();
            lv_IOPorts = new Mtf.Controls.MtfListView();
            ch_0_PortName = new System.Windows.Forms.ColumnHeader();
            ch_1_PortValue = new System.Windows.Forms.ColumnHeader();
            ch_2_PortDirection = new System.Windows.Forms.ColumnHeader();
            gb_SecondaryLogon = new System.Windows.Forms.GroupBox();
            btn_LoginLogoutSecondary = new System.Windows.Forms.Button();
            tb_Password2 = new Mtf.Controls.PasswordBox();
            lbl_Password2 = new System.Windows.Forms.Label();
            tb_Username2 = new System.Windows.Forms.TextBox();
            lbl_Username2 = new System.Windows.Forms.Label();
            gb_PrimaryLogon = new System.Windows.Forms.GroupBox();
            ch_6_IOPortEventNote = new System.Windows.Forms.ColumnHeader();
            ch_5_IOPortEventLoggedOnUser = new System.Windows.Forms.ColumnHeader();
            ch_4_IOPortEventPortState = new System.Windows.Forms.ColumnHeader();
            ch_3_IOPortEventPortNumber = new System.Windows.Forms.ColumnHeader();
            ch_2_IOPortEventDevice = new System.Windows.Forms.ColumnHeader();
            ch_1_IOPortEventDate = new System.Windows.Forms.ColumnHeader();
            ch_0_IOPortEventID = new System.Windows.Forms.ColumnHeader();
            lv_PortEvents = new Mtf.Controls.MtfListView();
            gb_PortEvents = new System.Windows.Forms.GroupBox();
            s_Splitter3 = new System.Windows.Forms.Splitter();
            p_RightBottom = new System.Windows.Forms.Panel();
            pb_Map = new Mtf.Controls.MtfPictureBox();
            p_Map = new System.Windows.Forms.Panel();
            p_Main = new System.Windows.Forms.Panel();
            ms_Menu = new System.Windows.Forms.MenuStrip();
            bw_CreateStatisticsMessage = new System.ComponentModel.BackgroundWorker();
            ss_StatusStrip.SuspendLayout();
            gb_UserEvents.SuspendLayout();
            p_Left.SuspendLayout();
            p_LeftBottom.SuspendLayout();
            gb_SecondaryLogon.SuspendLayout();
            gb_PrimaryLogon.SuspendLayout();
            gb_PortEvents.SuspendLayout();
            p_RightBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pb_Map).BeginInit();
            p_Map.SuspendLayout();
            p_Main.SuspendLayout();
            ms_Menu.SuspendLayout();
            SuspendLayout();
            // 
            // tsmi_GeneralOptions
            // 
            tsmi_GeneralOptions.Enabled = false;
            tsmi_GeneralOptions.Image = (System.Drawing.Image)resources.GetObject("tsmi_GeneralOptions.Image");
            tsmi_GeneralOptions.Name = "tsmi_GeneralOptions";
            tsmi_GeneralOptions.Size = new System.Drawing.Size(162, 22);
            tsmi_GeneralOptions.Text = "General options";
            tsmi_GeneralOptions.Click += Tsmi_GeneralOptions_Click;
            // 
            // tsmi_Options
            // 
            tsmi_Options.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { tsmi_PersonalOptions, tsmi_GeneralOptions, tsmi_DisplaySettings });
            tsmi_Options.Image = (System.Drawing.Image)resources.GetObject("tsmi_Options.Image");
            tsmi_Options.Name = "tsmi_Options";
            tsmi_Options.Size = new System.Drawing.Size(77, 20);
            tsmi_Options.Text = "Options";
            // 
            // tsmi_PersonalOptions
            // 
            tsmi_PersonalOptions.Enabled = false;
            tsmi_PersonalOptions.Image = (System.Drawing.Image)resources.GetObject("tsmi_PersonalOptions.Image");
            tsmi_PersonalOptions.Name = "tsmi_PersonalOptions";
            tsmi_PersonalOptions.Size = new System.Drawing.Size(162, 22);
            tsmi_PersonalOptions.Text = "Personal options";
            tsmi_PersonalOptions.Click += Tsmi_PersonalOptions_Click;
            // 
            // tsmi_DisplaySettings
            // 
            tsmi_DisplaySettings.Enabled = false;
            tsmi_DisplaySettings.Image = (System.Drawing.Image)resources.GetObject("tsmi_DisplaySettings.Image");
            tsmi_DisplaySettings.Name = "tsmi_DisplaySettings";
            tsmi_DisplaySettings.Size = new System.Drawing.Size(162, 22);
            tsmi_DisplaySettings.Text = "Display settings";
            tsmi_DisplaySettings.Click += Tsmi_DisplaySettings_Click;
            // 
            // tsmi_Profile
            // 
            tsmi_Profile.Enabled = false;
            tsmi_Profile.Image = (System.Drawing.Image)resources.GetObject("tsmi_Profile.Image");
            tsmi_Profile.Name = "tsmi_Profile";
            tsmi_Profile.Size = new System.Drawing.Size(229, 22);
            tsmi_Profile.Text = "Profile";
            tsmi_Profile.Click += Tsmi_Profile_Click;
            // 
            // tss_Separator4
            // 
            tss_Separator4.Name = "tss_Separator4";
            tss_Separator4.Size = new System.Drawing.Size(226, 6);
            // 
            // tsmi_UserAndGroupManagement
            // 
            tsmi_UserAndGroupManagement.Enabled = false;
            tsmi_UserAndGroupManagement.Image = (System.Drawing.Image)resources.GetObject("tsmi_UserAndGroupManagement.Image");
            tsmi_UserAndGroupManagement.Name = "tsmi_UserAndGroupManagement";
            tsmi_UserAndGroupManagement.Size = new System.Drawing.Size(229, 22);
            tsmi_UserAndGroupManagement.Text = "User and group management";
            tsmi_UserAndGroupManagement.Click += Tsmi_UserAndGroupManagement_Click;
            // 
            // tsmi_Users
            // 
            tsmi_Users.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { tsmi_UserAndGroupManagement, tss_Separator4, tsmi_Profile });
            tsmi_Users.Image = (System.Drawing.Image)resources.GetObject("tsmi_Users.Image");
            tsmi_Users.Name = "tsmi_Users";
            tsmi_Users.Size = new System.Drawing.Size(63, 20);
            tsmi_Users.Text = "Users";
            // 
            // tsmi_Templates
            // 
            tsmi_Templates.Enabled = false;
            tsmi_Templates.Image = (System.Drawing.Image)resources.GetObject("tsmi_Templates.Image");
            tsmi_Templates.Name = "tsmi_Templates";
            tsmi_Templates.Size = new System.Drawing.Size(245, 22);
            tsmi_Templates.Text = "Templates";
            tsmi_Templates.Click += Tsmi_Templates_Click;
            // 
            // tss_Separator3
            // 
            tss_Separator3.Name = "tss_Separator3";
            tss_Separator3.Size = new System.Drawing.Size(242, 6);
            // 
            // tsmi_AutoCreateWizard
            // 
            tsmi_AutoCreateWizard.Enabled = false;
            tsmi_AutoCreateWizard.Image = (System.Drawing.Image)resources.GetObject("tsmi_AutoCreateWizard.Image");
            tsmi_AutoCreateWizard.Name = "tsmi_AutoCreateWizard";
            tsmi_AutoCreateWizard.Size = new System.Drawing.Size(245, 22);
            tsmi_AutoCreateWizard.Text = "Auto create wizard";
            tsmi_AutoCreateWizard.Click += Tsmi_AutoCreateWizard_Click;
            // 
            // tss_Separator2
            // 
            tss_Separator2.Name = "tss_Separator2";
            tss_Separator2.Size = new System.Drawing.Size(242, 6);
            // 
            // tsmi_SequentialChains
            // 
            tsmi_SequentialChains.Enabled = false;
            tsmi_SequentialChains.Image = (System.Drawing.Image)resources.GetObject("tsmi_SequentialChains.Image");
            tsmi_SequentialChains.Name = "tsmi_SequentialChains";
            tsmi_SequentialChains.Size = new System.Drawing.Size(245, 22);
            tsmi_SequentialChains.Text = "Sequential chains";
            tsmi_SequentialChains.Click += Tsmi_SequentialChains_Click;
            // 
            // tsmi_GridManagement
            // 
            tsmi_GridManagement.Enabled = false;
            tsmi_GridManagement.Image = (System.Drawing.Image)resources.GetObject("tsmi_GridManagement.Image");
            tsmi_GridManagement.Name = "tsmi_GridManagement";
            tsmi_GridManagement.Size = new System.Drawing.Size(245, 22);
            tsmi_GridManagement.Text = "Grid management";
            tsmi_GridManagement.Click += Tsmi_GridManagement_Click;
            // 
            // tss_Separator
            // 
            tss_Separator.Name = "tss_Separator";
            tss_Separator.Size = new System.Drawing.Size(242, 6);
            // 
            // tsmi_ServerAndCameraManagement
            // 
            tsmi_ServerAndCameraManagement.Enabled = false;
            tsmi_ServerAndCameraManagement.Image = (System.Drawing.Image)resources.GetObject("tsmi_ServerAndCameraManagement.Image");
            tsmi_ServerAndCameraManagement.Name = "tsmi_ServerAndCameraManagement";
            tsmi_ServerAndCameraManagement.Size = new System.Drawing.Size(245, 22);
            tsmi_ServerAndCameraManagement.Text = "Server and camera management";
            tsmi_ServerAndCameraManagement.Click += Tsmi_ServerAndCameraManagement_Click;
            // 
            // btn_LoginLogoutPrimary
            // 
            btn_LoginLogoutPrimary.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            btn_LoginLogoutPrimary.Location = new System.Drawing.Point(7, 134);
            btn_LoginLogoutPrimary.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_LoginLogoutPrimary.Name = "btn_LoginLogoutPrimary";
            btn_LoginLogoutPrimary.Size = new System.Drawing.Size(234, 27);
            btn_LoginLogoutPrimary.TabIndex = 18;
            btn_LoginLogoutPrimary.Text = "Login";
            btn_LoginLogoutPrimary.UseVisualStyleBackColor = true;
            btn_LoginLogoutPrimary.Click += Btn_LoginLogoutPrimary_Click;
            // 
            // tb_Password
            // 
            tb_Password.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tb_Password.Location = new System.Drawing.Point(7, 105);
            tb_Password.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tb_Password.MaxLength = 100;
            tb_Password.Name = "tb_Password";
            tb_Password.Password = "";
            tb_Password.PasswordChar = '*';
            tb_Password.ShowRealPasswordLength = false;
            tb_Password.Size = new System.Drawing.Size(234, 23);
            tb_Password.TabIndex = 17;
            // 
            // lbl_Password
            // 
            lbl_Password.AutoSize = true;
            lbl_Password.Location = new System.Drawing.Point(4, 83);
            lbl_Password.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_Password.Name = "lbl_Password";
            lbl_Password.Size = new System.Drawing.Size(57, 15);
            lbl_Password.TabIndex = 16;
            lbl_Password.Text = "Password";
            // 
            // tb_Username
            // 
            tb_Username.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tb_Username.Location = new System.Drawing.Point(7, 54);
            tb_Username.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tb_Username.MaxLength = 100;
            tb_Username.Name = "tb_Username";
            tb_Username.Size = new System.Drawing.Size(234, 23);
            tb_Username.TabIndex = 15;
            // 
            // tsmi_ControlCenter
            // 
            tsmi_ControlCenter.Image = (System.Drawing.Image)resources.GetObject("tsmi_ControlCenter.Image");
            tsmi_ControlCenter.Name = "tsmi_ControlCenter";
            tsmi_ControlCenter.Size = new System.Drawing.Size(111, 20);
            tsmi_ControlCenter.Text = "Control center";
            tsmi_ControlCenter.Click += Tsmi_ControlCenter_Click;
            // 
            // il_DatabaseIcons
            // 
            il_DatabaseIcons.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            il_DatabaseIcons.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("il_DatabaseIcons.ImageStream");
            il_DatabaseIcons.TransparentColor = System.Drawing.Color.Transparent;
            il_DatabaseIcons.Images.SetKeyName(0, "database_10.ico");
            il_DatabaseIcons.Images.SetKeyName(1, "database_20.ico");
            il_DatabaseIcons.Images.SetKeyName(2, "database_30.ico");
            il_DatabaseIcons.Images.SetKeyName(3, "database_40.ico");
            il_DatabaseIcons.Images.SetKeyName(4, "database_50.ico");
            il_DatabaseIcons.Images.SetKeyName(5, "database_60.ico");
            il_DatabaseIcons.Images.SetKeyName(6, "database_70.ico");
            il_DatabaseIcons.Images.SetKeyName(7, "database_80.ico");
            il_DatabaseIcons.Images.SetKeyName(8, "database_90.ico");
            il_DatabaseIcons.Images.SetKeyName(9, "database_100.ico");
            il_DatabaseIcons.Images.SetKeyName(10, "database_110.ico");
            // 
            // tsb_DatabaseUsage
            // 
            tsb_DatabaseUsage.Checked = true;
            tsb_DatabaseUsage.CheckState = System.Windows.Forms.CheckState.Checked;
            tsb_DatabaseUsage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            tsb_DatabaseUsage.ImageTransparentColor = System.Drawing.Color.Magenta;
            tsb_DatabaseUsage.Name = "tsb_DatabaseUsage";
            tsb_DatabaseUsage.Size = new System.Drawing.Size(87, 19);
            tsb_DatabaseUsage.Text = "Not accessible";
            // 
            // tssl_Uptime
            // 
            tssl_Uptime.Name = "tssl_Uptime";
            tssl_Uptime.Size = new System.Drawing.Size(125, 15);
            tssl_Uptime.Text = "Uptime: 0 day 00:00:00";
            // 
            // tssl_SpaceHolder
            // 
            tssl_SpaceHolder.Name = "tssl_SpaceHolder";
            tssl_SpaceHolder.Size = new System.Drawing.Size(0, 0);
            tssl_SpaceHolder.Spring = true;
            // 
            // tssl_LoggedOnUser
            // 
            tssl_LoggedOnUser.Name = "tssl_LoggedOnUser";
            tssl_LoggedOnUser.Size = new System.Drawing.Size(145, 15);
            tssl_LoggedOnUser.Text = "There's no logged in users";
            tssl_LoggedOnUser.Visible = false;
            // 
            // ss_StatusStrip
            // 
            ss_StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { tssl_LoggedOnUser, tssl_SpaceHolder, tssl_Uptime, tsb_DatabaseUsage });
            ss_StatusStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            ss_StatusStrip.Location = new System.Drawing.Point(0, 676);
            ss_StatusStrip.Name = "ss_StatusStrip";
            ss_StatusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            ss_StatusStrip.ShowItemToolTips = true;
            ss_StatusStrip.Size = new System.Drawing.Size(1186, 21);
            ss_StatusStrip.TabIndex = 3;
            ss_StatusStrip.Text = "statusStrip1";
            // 
            // tsmi_Exit
            // 
            tsmi_Exit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            tsmi_Exit.Image = (System.Drawing.Image)resources.GetObject("tsmi_Exit.Image");
            tsmi_Exit.Name = "tsmi_Exit";
            tsmi_Exit.Size = new System.Drawing.Size(53, 20);
            tsmi_Exit.Text = "Exit";
            tsmi_Exit.Click += Tsmi_Exit_Click;
            // 
            // tsmi_License
            // 
            tsmi_License.Image = (System.Drawing.Image)resources.GetObject("tsmi_License.Image");
            tsmi_License.Name = "tsmi_License";
            tsmi_License.Size = new System.Drawing.Size(113, 22);
            tsmi_License.Text = "License";
            tsmi_License.Click += Tsmi_License_Click;
            // 
            // tsmi_Main
            // 
            tsmi_Main.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { tsmi_ServerAndCameraManagement, tss_Separator, tsmi_GridManagement, tsmi_SequentialChains, tss_Separator2, tsmi_AutoCreateWizard, tss_Separator3, tsmi_Templates });
            tsmi_Main.Image = (System.Drawing.Image)resources.GetObject("tsmi_Main.Image");
            tsmi_Main.Name = "tsmi_Main";
            tsmi_Main.Size = new System.Drawing.Size(62, 20);
            tsmi_Main.Text = "Main";
            // 
            // tsmi_About
            // 
            tsmi_About.Image = (System.Drawing.Image)resources.GetObject("tsmi_About.Image");
            tsmi_About.Name = "tsmi_About";
            tsmi_About.Size = new System.Drawing.Size(113, 22);
            tsmi_About.Text = "About";
            tsmi_About.Click += Tsmi_About_Click;
            // 
            // tsmi_MapCreator
            // 
            tsmi_MapCreator.Image = (System.Drawing.Image)resources.GetObject("tsmi_MapCreator.Image");
            tsmi_MapCreator.Name = "tsmi_MapCreator";
            tsmi_MapCreator.Size = new System.Drawing.Size(215, 22);
            tsmi_MapCreator.Text = "Map creator";
            tsmi_MapCreator.Click += Tsmi_MapCreator_Click;
            // 
            // tsmi_MotionPopup
            // 
            tsmi_MotionPopup.Enabled = false;
            tsmi_MotionPopup.Image = (System.Drawing.Image)resources.GetObject("tsmi_MotionPopup.Image");
            tsmi_MotionPopup.Name = "tsmi_MotionPopup";
            tsmi_MotionPopup.Size = new System.Drawing.Size(215, 22);
            tsmi_MotionPopup.Text = "Motion popup";
            tsmi_MotionPopup.Click += Tsmi_MotionPopup_Click;
            // 
            // tsmi_IOPortsSettings
            // 
            tsmi_IOPortsSettings.Enabled = false;
            tsmi_IOPortsSettings.Image = (System.Drawing.Image)resources.GetObject("tsmi_IOPortsSettings.Image");
            tsmi_IOPortsSettings.Name = "tsmi_IOPortsSettings";
            tsmi_IOPortsSettings.Size = new System.Drawing.Size(215, 22);
            tsmi_IOPortsSettings.Text = "I/O ports' settings";
            tsmi_IOPortsSettings.Click += Tsmi_IOPortsSettings_Click;
            // 
            // tsmi_SyncronView
            // 
            tsmi_SyncronView.Enabled = false;
            tsmi_SyncronView.Image = (System.Drawing.Image)resources.GetObject("tsmi_SyncronView.Image");
            tsmi_SyncronView.Name = "tsmi_SyncronView";
            tsmi_SyncronView.Size = new System.Drawing.Size(215, 22);
            tsmi_SyncronView.Text = "Syncron view";
            tsmi_SyncronView.Click += Tsmi_SyncronView_Click;
            // 
            // tsmi_BarCodeReadings
            // 
            tsmi_BarCodeReadings.Enabled = false;
            tsmi_BarCodeReadings.Image = (System.Drawing.Image)resources.GetObject("tsmi_BarCodeReadings.Image");
            tsmi_BarCodeReadings.Name = "tsmi_BarCodeReadings";
            tsmi_BarCodeReadings.Size = new System.Drawing.Size(215, 22);
            tsmi_BarCodeReadings.Text = "Bar code readings";
            tsmi_BarCodeReadings.Click += Tsmi_BarCodeReadings_Click;
            // 
            // tsmi_PositioningMousePointer
            // 
            tsmi_PositioningMousePointer.Image = (System.Drawing.Image)resources.GetObject("tsmi_PositioningMousePointer.Image");
            tsmi_PositioningMousePointer.Name = "tsmi_PositioningMousePointer";
            tsmi_PositioningMousePointer.ShortcutKeyDisplayString = "Home";
            tsmi_PositioningMousePointer.Size = new System.Drawing.Size(215, 22);
            tsmi_PositioningMousePointer.Text = "Set mouse position";
            tsmi_PositioningMousePointer.Click += Tsmi_PositioningMousePointer_Click;
            // 
            // tsmi_LogViewer
            // 
            tsmi_LogViewer.Enabled = false;
            tsmi_LogViewer.Image = (System.Drawing.Image)resources.GetObject("tsmi_LogViewer.Image");
            tsmi_LogViewer.Name = "tsmi_LogViewer";
            tsmi_LogViewer.Size = new System.Drawing.Size(215, 22);
            tsmi_LogViewer.Text = "Log viewer";
            tsmi_LogViewer.Click += Tsmi_LogViewer_Click;
            // 
            // tsmi_LanguageEditor
            // 
            tsmi_LanguageEditor.Enabled = false;
            tsmi_LanguageEditor.Image = (System.Drawing.Image)resources.GetObject("tsmi_LanguageEditor.Image");
            tsmi_LanguageEditor.Name = "tsmi_LanguageEditor";
            tsmi_LanguageEditor.Size = new System.Drawing.Size(215, 22);
            tsmi_LanguageEditor.Text = "Language editor";
            tsmi_LanguageEditor.Click += Tsmi_LanguageEditor_Click;
            // 
            // tsmi_Help
            // 
            tsmi_Help.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { tsmi_About, tsmi_License });
            tsmi_Help.Image = (System.Drawing.Image)resources.GetObject("tsmi_Help.Image");
            tsmi_Help.Name = "tsmi_Help";
            tsmi_Help.Size = new System.Drawing.Size(60, 20);
            tsmi_Help.Text = "Help";
            // 
            // tsmi_Tools
            // 
            tsmi_Tools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { tsmi_LanguageEditor, tsmi_LogViewer, tsmi_PositioningMousePointer, tsmi_BarCodeReadings, tsmi_SyncronView, tsmi_IOPortsSettings, tsmi_MotionPopup, tsmi_MapCreator });
            tsmi_Tools.Image = (System.Drawing.Image)resources.GetObject("tsmi_Tools.Image");
            tsmi_Tools.Name = "tsmi_Tools";
            tsmi_Tools.Size = new System.Drawing.Size(63, 20);
            tsmi_Tools.Text = "Tools";
            // 
            // lbl_Username
            // 
            lbl_Username.AutoSize = true;
            lbl_Username.Location = new System.Drawing.Point(4, 32);
            lbl_Username.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_Username.Name = "lbl_Username";
            lbl_Username.Size = new System.Drawing.Size(60, 15);
            lbl_Username.TabIndex = 14;
            lbl_Username.Text = "Username";
            // 
            // gb_UserEvents
            // 
            gb_UserEvents.Controls.Add(lv_UserEvents);
            gb_UserEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            gb_UserEvents.Location = new System.Drawing.Point(0, 147);
            gb_UserEvents.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gb_UserEvents.Name = "gb_UserEvents";
            gb_UserEvents.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gb_UserEvents.Size = new System.Drawing.Size(253, 171);
            gb_UserEvents.TabIndex = 14;
            gb_UserEvents.TabStop = false;
            gb_UserEvents.Text = "Choose the active event";
            // 
            // lv_UserEvents
            // 
            lv_UserEvents.AlternatingColorEven = System.Drawing.Color.LightBlue;
            lv_UserEvents.AlternatingColorOdd = System.Drawing.SystemColors.Window;
            lv_UserEvents.AlternatingColorsAreInUse = true;
            lv_UserEvents.AlternatingPairColorEven = System.Drawing.Color.LightSeaGreen;
            lv_UserEvents.AlternatingPairColorOdd = System.Drawing.Color.CadetBlue;
            lv_UserEvents.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { ch_0_EventName, ch_1_Description });
            lv_UserEvents.CompactView = false;
            lv_UserEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            lv_UserEvents.Enabled = false;
            lv_UserEvents.EnsureLastItemIsVisible = false;
            lv_UserEvents.FirstItemIsGray = false;
            lv_UserEvents.FullRowSelect = true;
            lv_UserEvents.Location = new System.Drawing.Point(4, 19);
            lv_UserEvents.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            lv_UserEvents.MultiSelect = false;
            lv_UserEvents.Name = "lv_UserEvents";
            lv_UserEvents.OwnerDraw = true;
            lv_UserEvents.ReadonlyCheckboxes = false;
            lv_UserEvents.SameItemsColorEven = System.Drawing.Color.DarkOrange;
            lv_UserEvents.SameItemsColorOdd = System.Drawing.Color.LightSalmon;
            lv_UserEvents.Size = new System.Drawing.Size(245, 149);
            lv_UserEvents.TabIndex = 0;
            lv_UserEvents.UseCompatibleStateImageBehavior = false;
            lv_UserEvents.View = System.Windows.Forms.View.Details;
            // 
            // ch_0_EventName
            // 
            ch_0_EventName.Text = "Event name";
            ch_0_EventName.Width = 77;
            // 
            // ch_1_Description
            // 
            ch_1_Description.Text = "Description";
            ch_1_Description.Width = 130;
            // 
            // s_Splitter
            // 
            s_Splitter.BackColor = System.Drawing.SystemColors.ControlDark;
            s_Splitter.Location = new System.Drawing.Point(253, 24);
            s_Splitter.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            s_Splitter.Name = "s_Splitter";
            s_Splitter.Size = new System.Drawing.Size(4, 652);
            s_Splitter.TabIndex = 6;
            s_Splitter.TabStop = false;
            // 
            // p_Left
            // 
            p_Left.Controls.Add(p_LeftBottom);
            p_Left.Controls.Add(gb_SecondaryLogon);
            p_Left.Controls.Add(gb_PrimaryLogon);
            p_Left.Dock = System.Windows.Forms.DockStyle.Left;
            p_Left.Location = new System.Drawing.Point(0, 24);
            p_Left.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            p_Left.Name = "p_Left";
            p_Left.Size = new System.Drawing.Size(253, 652);
            p_Left.TabIndex = 5;
            // 
            // p_LeftBottom
            // 
            p_LeftBottom.Controls.Add(gb_UserEvents);
            p_LeftBottom.Controls.Add(s_Splitter4);
            p_LeftBottom.Controls.Add(tv_IOPorts);
            p_LeftBottom.Controls.Add(s_Splitter2);
            p_LeftBottom.Controls.Add(lv_IOPorts);
            p_LeftBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            p_LeftBottom.Location = new System.Drawing.Point(0, 334);
            p_LeftBottom.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            p_LeftBottom.Name = "p_LeftBottom";
            p_LeftBottom.Size = new System.Drawing.Size(253, 318);
            p_LeftBottom.TabIndex = 13;
            // 
            // s_Splitter4
            // 
            s_Splitter4.Dock = System.Windows.Forms.DockStyle.Top;
            s_Splitter4.Location = new System.Drawing.Point(0, 144);
            s_Splitter4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            s_Splitter4.Name = "s_Splitter4";
            s_Splitter4.Size = new System.Drawing.Size(253, 3);
            s_Splitter4.TabIndex = 4;
            s_Splitter4.TabStop = false;
            // 
            // tv_IOPorts
            // 
            tv_IOPorts.CheckBoxBackground = System.Drawing.SystemColors.Window;
            tv_IOPorts.Dock = System.Windows.Forms.DockStyle.Top;
            tv_IOPorts.DrawDefaultImageToNodes = true;
            tv_IOPorts.HideSelection = false;
            tv_IOPorts.ImageIndex = 0;
            tv_IOPorts.ImageList = il_IOPortIcons;
            tv_IOPorts.LineStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            tv_IOPorts.Location = new System.Drawing.Point(0, 80);
            tv_IOPorts.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tv_IOPorts.MultiSelect = false;
            tv_IOPorts.Name = "tv_IOPorts";
            treeNode1.ImageIndex = 0;
            treeNode1.Name = "IO_Devices";
            treeNode1.SelectedImageIndex = 0;
            treeNode1.Text = "I/O Devices";
            tv_IOPorts.Nodes.AddRange(new System.Windows.Forms.TreeNode[] { treeNode1 });
            tv_IOPorts.SelectedImageIndex = 0;
            tv_IOPorts.ShowPlusMinusOnRootNodes = true;
            tv_IOPorts.Size = new System.Drawing.Size(253, 64);
            tv_IOPorts.StateImageList = il_IOPortIcons;
            tv_IOPorts.StateImageOrCheckBoxOnLeft = false;
            tv_IOPorts.TabIndex = 3;
            tv_IOPorts.TickColor = System.Drawing.Color.Green;
            // 
            // il_IOPortIcons
            // 
            il_IOPortIcons.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            il_IOPortIcons.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("il_IOPortIcons.ImageStream");
            il_IOPortIcons.TransparentColor = System.Drawing.Color.Transparent;
            il_IOPortIcons.Images.SetKeyName(0, "app.ico");
            il_IOPortIcons.Images.SetKeyName(1, "0.ico");
            il_IOPortIcons.Images.SetKeyName(2, "1.ico");
            il_IOPortIcons.Images.SetKeyName(3, "in.ico");
            il_IOPortIcons.Images.SetKeyName(4, "out.ico");
            // 
            // s_Splitter2
            // 
            s_Splitter2.Dock = System.Windows.Forms.DockStyle.Top;
            s_Splitter2.Location = new System.Drawing.Point(0, 77);
            s_Splitter2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            s_Splitter2.Name = "s_Splitter2";
            s_Splitter2.Size = new System.Drawing.Size(253, 3);
            s_Splitter2.TabIndex = 2;
            s_Splitter2.TabStop = false;
            // 
            // lv_IOPorts
            // 
            lv_IOPorts.AlternatingColorEven = System.Drawing.Color.LightBlue;
            lv_IOPorts.AlternatingColorOdd = System.Drawing.SystemColors.Window;
            lv_IOPorts.AlternatingColorsAreInUse = true;
            lv_IOPorts.AlternatingPairColorEven = System.Drawing.Color.LightSeaGreen;
            lv_IOPorts.AlternatingPairColorOdd = System.Drawing.Color.CadetBlue;
            lv_IOPorts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { ch_0_PortName, ch_1_PortValue, ch_2_PortDirection });
            lv_IOPorts.CompactView = false;
            lv_IOPorts.Dock = System.Windows.Forms.DockStyle.Top;
            lv_IOPorts.EnsureLastItemIsVisible = false;
            lv_IOPorts.FirstItemIsGray = false;
            lv_IOPorts.FullRowSelect = true;
            lv_IOPorts.Location = new System.Drawing.Point(0, 0);
            lv_IOPorts.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            lv_IOPorts.Name = "lv_IOPorts";
            lv_IOPorts.OwnerDraw = true;
            lv_IOPorts.ReadonlyCheckboxes = false;
            lv_IOPorts.SameItemsColorEven = System.Drawing.Color.DarkOrange;
            lv_IOPorts.SameItemsColorOdd = System.Drawing.Color.LightSalmon;
            lv_IOPorts.Size = new System.Drawing.Size(253, 77);
            lv_IOPorts.TabIndex = 1;
            lv_IOPorts.UseCompatibleStateImageBehavior = false;
            lv_IOPorts.View = System.Windows.Forms.View.Details;
            lv_IOPorts.Visible = false;
            // 
            // ch_0_PortName
            // 
            ch_0_PortName.Text = "Port name";
            ch_0_PortName.Width = 106;
            // 
            // ch_1_PortValue
            // 
            ch_1_PortValue.Text = "Value";
            // 
            // ch_2_PortDirection
            // 
            ch_2_PortDirection.Text = "Direction";
            // 
            // gb_SecondaryLogon
            // 
            gb_SecondaryLogon.Controls.Add(btn_LoginLogoutSecondary);
            gb_SecondaryLogon.Controls.Add(tb_Password2);
            gb_SecondaryLogon.Controls.Add(lbl_Password2);
            gb_SecondaryLogon.Controls.Add(tb_Username2);
            gb_SecondaryLogon.Controls.Add(lbl_Username2);
            gb_SecondaryLogon.Dock = System.Windows.Forms.DockStyle.Top;
            gb_SecondaryLogon.Location = new System.Drawing.Point(0, 167);
            gb_SecondaryLogon.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gb_SecondaryLogon.Name = "gb_SecondaryLogon";
            gb_SecondaryLogon.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gb_SecondaryLogon.Size = new System.Drawing.Size(253, 167);
            gb_SecondaryLogon.TabIndex = 7;
            gb_SecondaryLogon.TabStop = false;
            gb_SecondaryLogon.Text = "Secondary login";
            gb_SecondaryLogon.Visible = false;
            // 
            // btn_LoginLogoutSecondary
            // 
            btn_LoginLogoutSecondary.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            btn_LoginLogoutSecondary.Location = new System.Drawing.Point(7, 134);
            btn_LoginLogoutSecondary.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_LoginLogoutSecondary.Name = "btn_LoginLogoutSecondary";
            btn_LoginLogoutSecondary.Size = new System.Drawing.Size(234, 27);
            btn_LoginLogoutSecondary.TabIndex = 18;
            btn_LoginLogoutSecondary.Text = "Login";
            btn_LoginLogoutSecondary.UseVisualStyleBackColor = true;
            btn_LoginLogoutSecondary.Click += Btn_LoginLogoutSecondary_Click;
            // 
            // tb_Password2
            // 
            tb_Password2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tb_Password2.Location = new System.Drawing.Point(7, 105);
            tb_Password2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tb_Password2.MaxLength = 100;
            tb_Password2.Name = "tb_Password2";
            tb_Password2.Password = "";
            tb_Password2.PasswordChar = '*';
            tb_Password2.ShowRealPasswordLength = false;
            tb_Password2.Size = new System.Drawing.Size(234, 23);
            tb_Password2.TabIndex = 17;
            // 
            // lbl_Password2
            // 
            lbl_Password2.AutoSize = true;
            lbl_Password2.Location = new System.Drawing.Point(4, 83);
            lbl_Password2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_Password2.Name = "lbl_Password2";
            lbl_Password2.Size = new System.Drawing.Size(57, 15);
            lbl_Password2.TabIndex = 16;
            lbl_Password2.Text = "Password";
            // 
            // tb_Username2
            // 
            tb_Username2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tb_Username2.Location = new System.Drawing.Point(7, 54);
            tb_Username2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tb_Username2.MaxLength = 100;
            tb_Username2.Name = "tb_Username2";
            tb_Username2.Size = new System.Drawing.Size(234, 23);
            tb_Username2.TabIndex = 15;
            // 
            // lbl_Username2
            // 
            lbl_Username2.AutoSize = true;
            lbl_Username2.Location = new System.Drawing.Point(4, 32);
            lbl_Username2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_Username2.Name = "lbl_Username2";
            lbl_Username2.Size = new System.Drawing.Size(60, 15);
            lbl_Username2.TabIndex = 14;
            lbl_Username2.Text = "Username";
            // 
            // gb_PrimaryLogon
            // 
            gb_PrimaryLogon.Controls.Add(btn_LoginLogoutPrimary);
            gb_PrimaryLogon.Controls.Add(tb_Password);
            gb_PrimaryLogon.Controls.Add(lbl_Password);
            gb_PrimaryLogon.Controls.Add(tb_Username);
            gb_PrimaryLogon.Controls.Add(lbl_Username);
            gb_PrimaryLogon.Dock = System.Windows.Forms.DockStyle.Top;
            gb_PrimaryLogon.Location = new System.Drawing.Point(0, 0);
            gb_PrimaryLogon.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gb_PrimaryLogon.Name = "gb_PrimaryLogon";
            gb_PrimaryLogon.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gb_PrimaryLogon.Size = new System.Drawing.Size(253, 167);
            gb_PrimaryLogon.TabIndex = 6;
            gb_PrimaryLogon.TabStop = false;
            gb_PrimaryLogon.Text = "Primary login";
            // 
            // ch_6_IOPortEventNote
            // 
            ch_6_IOPortEventNote.Text = "Note";
            ch_6_IOPortEventNote.Width = 200;
            // 
            // ch_5_IOPortEventLoggedOnUser
            // 
            ch_5_IOPortEventLoggedOnUser.Text = "Logged in user";
            ch_5_IOPortEventLoggedOnUser.Width = 215;
            // 
            // ch_4_IOPortEventPortState
            // 
            ch_4_IOPortEventPortState.Text = "State";
            ch_4_IOPortEventPortState.Width = 56;
            // 
            // ch_3_IOPortEventPortNumber
            // 
            ch_3_IOPortEventPortNumber.Text = "Port number";
            ch_3_IOPortEventPortNumber.Width = 70;
            // 
            // ch_2_IOPortEventDevice
            // 
            ch_2_IOPortEventDevice.Text = "I/O device";
            ch_2_IOPortEventDevice.Width = 73;
            // 
            // ch_1_IOPortEventDate
            // 
            ch_1_IOPortEventDate.Text = "Date";
            ch_1_IOPortEventDate.Width = 114;
            // 
            // ch_0_IOPortEventID
            // 
            ch_0_IOPortEventID.Text = "ID";
            ch_0_IOPortEventID.Width = 56;
            // 
            // lv_PortEvents
            // 
            lv_PortEvents.AlternatingColorEven = System.Drawing.Color.LightBlue;
            lv_PortEvents.AlternatingColorOdd = System.Drawing.SystemColors.Window;
            lv_PortEvents.AlternatingColorsAreInUse = true;
            lv_PortEvents.AlternatingPairColorEven = System.Drawing.Color.LightSeaGreen;
            lv_PortEvents.AlternatingPairColorOdd = System.Drawing.Color.CadetBlue;
            lv_PortEvents.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { ch_0_IOPortEventID, ch_1_IOPortEventDate, ch_2_IOPortEventDevice, ch_3_IOPortEventPortNumber, ch_4_IOPortEventPortState, ch_5_IOPortEventLoggedOnUser, ch_6_IOPortEventNote });
            lv_PortEvents.CompactView = false;
            lv_PortEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            lv_PortEvents.EnsureLastItemIsVisible = false;
            lv_PortEvents.FirstItemIsGray = false;
            lv_PortEvents.FullRowSelect = true;
            lv_PortEvents.Location = new System.Drawing.Point(4, 19);
            lv_PortEvents.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            lv_PortEvents.Name = "lv_PortEvents";
            lv_PortEvents.OwnerDraw = true;
            lv_PortEvents.ReadonlyCheckboxes = false;
            lv_PortEvents.SameItemsColorEven = System.Drawing.Color.DarkOrange;
            lv_PortEvents.SameItemsColorOdd = System.Drawing.Color.LightSalmon;
            lv_PortEvents.Size = new System.Drawing.Size(921, 142);
            lv_PortEvents.TabIndex = 1;
            lv_PortEvents.UseCompatibleStateImageBehavior = false;
            lv_PortEvents.View = System.Windows.Forms.View.Details;
            // 
            // gb_PortEvents
            // 
            gb_PortEvents.Controls.Add(lv_PortEvents);
            gb_PortEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            gb_PortEvents.Location = new System.Drawing.Point(0, 0);
            gb_PortEvents.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gb_PortEvents.Name = "gb_PortEvents";
            gb_PortEvents.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gb_PortEvents.Size = new System.Drawing.Size(929, 164);
            gb_PortEvents.TabIndex = 0;
            gb_PortEvents.TabStop = false;
            // 
            // s_Splitter3
            // 
            s_Splitter3.BackColor = System.Drawing.SystemColors.ControlDark;
            s_Splitter3.Dock = System.Windows.Forms.DockStyle.Bottom;
            s_Splitter3.Location = new System.Drawing.Point(257, 509);
            s_Splitter3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            s_Splitter3.Name = "s_Splitter3";
            s_Splitter3.Size = new System.Drawing.Size(929, 3);
            s_Splitter3.TabIndex = 10;
            s_Splitter3.TabStop = false;
            // 
            // p_RightBottom
            // 
            p_RightBottom.Controls.Add(gb_PortEvents);
            p_RightBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            p_RightBottom.Location = new System.Drawing.Point(257, 512);
            p_RightBottom.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            p_RightBottom.Name = "p_RightBottom";
            p_RightBottom.Size = new System.Drawing.Size(929, 164);
            p_RightBottom.TabIndex = 9;
            // 
            // pb_Map
            // 
            pb_Map.Dock = System.Windows.Forms.DockStyle.Fill;
            pb_Map.Image = (System.Drawing.Image)resources.GetObject("pb_Map.Image");
            pb_Map.Location = new System.Drawing.Point(0, 0);
            pb_Map.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pb_Map.Name = "pb_Map";
            pb_Map.OriginalSize = new System.Drawing.Size(100, 50);
            pb_Map.RepositioningAndResizingControlsOnResize = false;
            pb_Map.Size = new System.Drawing.Size(929, 485);
            pb_Map.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pb_Map.TabIndex = 0;
            pb_Map.TabStop = false;
            // 
            // p_Map
            // 
            p_Map.BackColor = System.Drawing.Color.AliceBlue;
            p_Map.Controls.Add(pb_Map);
            p_Map.Dock = System.Windows.Forms.DockStyle.Fill;
            p_Map.Location = new System.Drawing.Point(257, 24);
            p_Map.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            p_Map.Name = "p_Map";
            p_Map.Size = new System.Drawing.Size(929, 485);
            p_Map.TabIndex = 11;
            // 
            // p_Main
            // 
            p_Main.Controls.Add(p_Map);
            p_Main.Controls.Add(s_Splitter3);
            p_Main.Controls.Add(p_RightBottom);
            p_Main.Controls.Add(s_Splitter);
            p_Main.Controls.Add(p_Left);
            p_Main.Controls.Add(ms_Menu);
            p_Main.Controls.Add(ss_StatusStrip);
            p_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            p_Main.Location = new System.Drawing.Point(0, 0);
            p_Main.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            p_Main.Name = "p_Main";
            p_Main.Size = new System.Drawing.Size(1186, 697);
            p_Main.TabIndex = 1;
            // 
            // ms_Menu
            // 
            ms_Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { tsmi_ControlCenter, tsmi_Main, tsmi_Users, tsmi_Options, tsmi_Tools, tsmi_Help, tsmi_Exit });
            ms_Menu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            ms_Menu.Location = new System.Drawing.Point(0, 0);
            ms_Menu.Name = "ms_Menu";
            ms_Menu.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            ms_Menu.Size = new System.Drawing.Size(1186, 24);
            ms_Menu.TabIndex = 4;
            ms_Menu.Text = "menuStrip1";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1186, 697);
            Controls.Add(p_Main);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "MainForm";
            StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            Text = "LiveView";
            FormClosing += MainForm_FormClosing;
            ss_StatusStrip.ResumeLayout(false);
            ss_StatusStrip.PerformLayout();
            gb_UserEvents.ResumeLayout(false);
            p_Left.ResumeLayout(false);
            p_LeftBottom.ResumeLayout(false);
            gb_SecondaryLogon.ResumeLayout(false);
            gb_SecondaryLogon.PerformLayout();
            gb_PrimaryLogon.ResumeLayout(false);
            gb_PrimaryLogon.PerformLayout();
            gb_PortEvents.ResumeLayout(false);
            p_RightBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pb_Map).EndInit();
            p_Map.ResumeLayout(false);
            p_Main.ResumeLayout(false);
            p_Main.PerformLayout();
            ms_Menu.ResumeLayout(false);
            ms_Menu.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem tsmi_GeneralOptions;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Options;
        private System.Windows.Forms.ToolStripMenuItem tsmi_PersonalOptions;
        private System.Windows.Forms.ToolStripMenuItem tsmi_DisplaySettings;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Profile;
        private System.Windows.Forms.ToolStripSeparator tss_Separator4;
        private System.Windows.Forms.ToolStripMenuItem tsmi_UserAndGroupManagement;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Users;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Templates;
        private System.Windows.Forms.ToolStripSeparator tss_Separator3;
        private System.Windows.Forms.ToolStripMenuItem tsmi_AutoCreateWizard;
        private System.Windows.Forms.ToolStripSeparator tss_Separator2;
        private System.Windows.Forms.ToolStripMenuItem tsmi_SequentialChains;
        private System.Windows.Forms.ToolStripMenuItem tsmi_GridManagement;
        private System.Windows.Forms.ToolStripSeparator tss_Separator;
        private System.Windows.Forms.ToolStripMenuItem tsmi_ServerAndCameraManagement;
        private System.Windows.Forms.Button btn_LoginLogoutPrimary;
        private Mtf.Controls.PasswordBox tb_Password;
        private System.Windows.Forms.Label lbl_Password;
        private System.Windows.Forms.TextBox tb_Username;
        private System.Windows.Forms.ToolStripMenuItem tsmi_ControlCenter;
        private System.Windows.Forms.ToolTip tt_Hint;
        private System.Windows.Forms.ImageList il_DatabaseIcons;
        private System.Windows.Forms.ToolStripButton tsb_DatabaseUsage;
        private System.Windows.Forms.ToolStripStatusLabel tssl_Uptime;
        private System.Windows.Forms.ToolStripStatusLabel tssl_SpaceHolder;
        private System.Windows.Forms.ToolStripStatusLabel tssl_LoggedOnUser;
        private System.Windows.Forms.StatusStrip ss_StatusStrip;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Exit;
        private System.Windows.Forms.ToolStripMenuItem tsmi_License;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Main;
        private System.Windows.Forms.ToolStripMenuItem tsmi_About;
        private System.Windows.Forms.ToolStripMenuItem tsmi_MapCreator;
        private System.Windows.Forms.ToolStripMenuItem tsmi_MotionPopup;
        private System.Windows.Forms.ToolStripMenuItem tsmi_IOPortsSettings;
        private System.Windows.Forms.ToolStripMenuItem tsmi_SyncronView;
        private System.Windows.Forms.ToolStripMenuItem tsmi_BarCodeReadings;
        private System.Windows.Forms.ToolStripMenuItem tsmi_PositioningMousePointer;
        private System.Windows.Forms.ToolStripMenuItem tsmi_LogViewer;
        private System.Windows.Forms.ToolStripMenuItem tsmi_LanguageEditor;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Help;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Tools;
        private System.Windows.Forms.Label lbl_Username;
        private System.Windows.Forms.GroupBox gb_UserEvents;
        private Mtf.Controls.MtfListView lv_UserEvents;
        private System.Windows.Forms.ColumnHeader ch_0_EventName;
        private System.Windows.Forms.ColumnHeader ch_1_Description;
        private System.Windows.Forms.Splitter s_Splitter;
        private System.Windows.Forms.Panel p_Left;
        private System.Windows.Forms.Panel p_LeftBottom;
        private System.Windows.Forms.Splitter s_Splitter4;
        private Mtf.Controls.MtfTreeView tv_IOPorts;
        private System.Windows.Forms.ImageList il_IOPortIcons;
        private System.Windows.Forms.Splitter s_Splitter2;
        private Mtf.Controls.MtfListView lv_IOPorts;
        private System.Windows.Forms.ColumnHeader ch_0_PortName;
        private System.Windows.Forms.ColumnHeader ch_1_PortValue;
        private System.Windows.Forms.ColumnHeader ch_2_PortDirection;
        private System.Windows.Forms.GroupBox gb_SecondaryLogon;
        private System.Windows.Forms.Button btn_LoginLogoutSecondary;
        private Mtf.Controls.PasswordBox tb_Password2;
        private System.Windows.Forms.Label lbl_Password2;
        private System.Windows.Forms.TextBox tb_Username2;
        private System.Windows.Forms.Label lbl_Username2;
        private System.Windows.Forms.GroupBox gb_PrimaryLogon;
        private System.Windows.Forms.ColumnHeader ch_6_IOPortEventNote;
        private System.Windows.Forms.ColumnHeader ch_5_IOPortEventLoggedOnUser;
        private System.Windows.Forms.ColumnHeader ch_4_IOPortEventPortState;
        private System.Windows.Forms.ColumnHeader ch_3_IOPortEventPortNumber;
        private System.Windows.Forms.ColumnHeader ch_2_IOPortEventDevice;
        private System.Windows.Forms.ColumnHeader ch_1_IOPortEventDate;
        private System.Windows.Forms.ColumnHeader ch_0_IOPortEventID;
        private Mtf.Controls.MtfListView lv_PortEvents;
        private System.Windows.Forms.GroupBox gb_PortEvents;
        private System.Windows.Forms.Splitter s_Splitter3;
        private System.Windows.Forms.Panel p_RightBottom;
        private Mtf.Controls.MtfPictureBox pb_Map;
        private System.Windows.Forms.Panel p_Map;
        private System.Windows.Forms.Panel p_Main;
        private System.Windows.Forms.MenuStrip ms_Menu;
        private System.ComponentModel.BackgroundWorker bw_CreateStatisticsMessage;
    }
}