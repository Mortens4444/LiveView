namespace LiveView.Forms
{
    partial class ControlCenter
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlCenter));
            tsmiProperties = new System.Windows.Forms.ToolStripMenuItem();
            btnPlayOrPauseSequence = new System.Windows.Forms.Button();
            ilSequenceControllers = new System.Windows.Forms.ImageList(components);
            btnShowPreviousGrid = new System.Windows.Forms.Button();
            lblNumberOfCameras = new System.Windows.Forms.Label();
            lblSecondsLeft = new System.Windows.Forms.Label();
            lblGridNumber = new System.Windows.Forms.Label();
            lblGridName = new System.Windows.Forms.Label();
            lblSequenceName = new System.Windows.Forms.Label();
            gbDisplayDevices = new System.Windows.Forms.GroupBox();
            cbAgents = new System.Windows.Forms.ComboBox();
            pCrossHair = new System.Windows.Forms.Panel();
            pbCrossHair = new Mtf.Controls.MtfPictureBox();
            lblDisplayDeviceName = new System.Windows.Forms.Label();
            btnIdentify = new System.Windows.Forms.Button();
            pDisplayDevices = new Mtf.Controls.TransparentPanel();
            btnRearrangeGrid = new System.Windows.Forms.Button();
            gbActiveSequence = new System.Windows.Forms.GroupBox();
            btnShowNextGrid = new System.Windows.Forms.Button();
            btnCloseFullScreenCamera = new System.Windows.Forms.Button();
            chNumber = new System.Windows.Forms.ColumnHeader();
            chCameraName = new System.Windows.Forms.ColumnHeader();
            lvCameras = new Mtf.Controls.MtfListView();
            gbCameras = new System.Windows.Forms.GroupBox();
            splitter3 = new System.Windows.Forms.Splitter();
            cmDisplayDeviceContextMenu = new System.Windows.Forms.ContextMenuStrip(components);
            pTemplates = new System.Windows.Forms.Panel();
            gbTemplates = new System.Windows.Forms.GroupBox();
            lvTemplates = new Mtf.Controls.MtfListView();
            chTemplateName = new System.Windows.Forms.ColumnHeader();
            ttHint = new System.Windows.Forms.ToolTip(components);
            bwSequenceWatcher = new System.ComponentModel.BackgroundWorker();
            splitter4 = new System.Windows.Forms.Splitter();
            pFullScreenCameraController = new System.Windows.Forms.Panel();
            gbFullScreenCameraController = new System.Windows.Forms.GroupBox();
            lblSeparator = new System.Windows.Forms.Label();
            lblJoystickCoordinates = new System.Windows.Forms.Label();
            pJoystick = new System.Windows.Forms.Panel();
            btnZoomOut = new System.Windows.Forms.Button();
            btnZoomIn = new System.Windows.Forms.Button();
            btnCalibrate = new System.Windows.Forms.Button();
            lblX = new System.Windows.Forms.Label();
            lblY = new System.Windows.Forms.Label();
            lblZ = new System.Windows.Forms.Label();
            lblStyle = new System.Windows.Forms.Label();
            rbNoFrames = new System.Windows.Forms.RadioButton();
            rbDefaultStyle = new System.Windows.Forms.RadioButton();
            btnMoveCameraSouthWest = new System.Windows.Forms.Button();
            btnMoveCameraSouthEast = new System.Windows.Forms.Button();
            btnMoveCameraSouth = new System.Windows.Forms.Button();
            btnMoveCameraWest = new System.Windows.Forms.Button();
            btnMoveCameraEast = new System.Windows.Forms.Button();
            btnMoveCameraToPresetZero = new System.Windows.Forms.Button();
            btnMoveCameraNorthWest = new System.Windows.Forms.Button();
            btnMoveCameraNorthEast = new System.Windows.Forms.Button();
            btnMoveCameraNorth = new System.Windows.Forms.Button();
            pMoveCameraSouthEast = new System.Windows.Forms.Panel();
            pMoveCameraEast = new System.Windows.Forms.Panel();
            pMoveCameraSouth = new System.Windows.Forms.Panel();
            pMoveCameraNorthEast = new System.Windows.Forms.Panel();
            pMoveCameraSouthWest = new System.Windows.Forms.Panel();
            pMoveCameraToPresetZero = new System.Windows.Forms.Panel();
            pMoveCameraNorth = new System.Windows.Forms.Panel();
            pMoveCameraWest = new System.Windows.Forms.Panel();
            pMoveCameraNorthWest = new System.Windows.Forms.Panel();
            ilCameraImages = new System.Windows.Forms.ImageList(components);
            ilBigImages = new System.Windows.Forms.ImageList(components);
            chSequenceName = new System.Windows.Forms.ColumnHeader();
            btnCloseSequenceApplications = new System.Windows.Forms.Button();
            lvSequences = new Mtf.Controls.MtfListView();
            gbSequences = new System.Windows.Forms.GroupBox();
            pbSziltechLogo = new Mtf.Controls.MtfPictureBox();
            pCameras = new System.Windows.Forms.Panel();
            spitter1 = new System.Windows.Forms.Splitter();
            pSequences = new System.Windows.Forms.Panel();
            pLogo = new System.Windows.Forms.Panel();
            pMain = new System.Windows.Forms.Panel();
            pActiveSequence = new System.Windows.Forms.Panel();
            splitter2 = new System.Windows.Forms.Splitter();
            pDisplays = new System.Windows.Forms.Panel();
            gbDisplayDevices.SuspendLayout();
            pCrossHair.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbCrossHair).BeginInit();
            gbActiveSequence.SuspendLayout();
            gbCameras.SuspendLayout();
            cmDisplayDeviceContextMenu.SuspendLayout();
            pTemplates.SuspendLayout();
            gbTemplates.SuspendLayout();
            pFullScreenCameraController.SuspendLayout();
            gbFullScreenCameraController.SuspendLayout();
            pJoystick.SuspendLayout();
            gbSequences.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbSziltechLogo).BeginInit();
            pCameras.SuspendLayout();
            pSequences.SuspendLayout();
            pLogo.SuspendLayout();
            pMain.SuspendLayout();
            pActiveSequence.SuspendLayout();
            pDisplays.SuspendLayout();
            SuspendLayout();
            // 
            // tsmiProperties
            // 
            tsmiProperties.Name = "tsmiProperties";
            tsmiProperties.Size = new System.Drawing.Size(127, 22);
            tsmiProperties.Text = "Properties";
            // 
            // btnPlayOrPauseSequence
            // 
            btnPlayOrPauseSequence.Image = (System.Drawing.Image)resources.GetObject("btnPlayOrPauseSequence.Image");
            btnPlayOrPauseSequence.Location = new System.Drawing.Point(50, 105);
            btnPlayOrPauseSequence.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnPlayOrPauseSequence.Name = "btnPlayOrPauseSequence";
            btnPlayOrPauseSequence.Size = new System.Drawing.Size(28, 28);
            btnPlayOrPauseSequence.TabIndex = 6;
            btnPlayOrPauseSequence.UseVisualStyleBackColor = true;
            btnPlayOrPauseSequence.Click += BtnPlayOrPauseSequence_Click;
            // 
            // ilSequenceControllers
            // 
            ilSequenceControllers.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            ilSequenceControllers.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("ilSequenceControllers.ImageStream");
            ilSequenceControllers.TransparentColor = System.Drawing.Color.Transparent;
            ilSequenceControllers.Images.SetKeyName(0, "rewind.png");
            ilSequenceControllers.Images.SetKeyName(1, "forward.png");
            ilSequenceControllers.Images.SetKeyName(2, "play_pause.png");
            // 
            // btnShowPreviousGrid
            // 
            btnShowPreviousGrid.Image = (System.Drawing.Image)resources.GetObject("btnShowPreviousGrid.Image");
            btnShowPreviousGrid.Location = new System.Drawing.Point(15, 105);
            btnShowPreviousGrid.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnShowPreviousGrid.Name = "btnShowPreviousGrid";
            btnShowPreviousGrid.Size = new System.Drawing.Size(28, 28);
            btnShowPreviousGrid.TabIndex = 5;
            btnShowPreviousGrid.UseVisualStyleBackColor = true;
            btnShowPreviousGrid.Click += BtnShowPreviousGrid_Click;
            // 
            // lblNumberOfCameras
            // 
            lblNumberOfCameras.AutoSize = true;
            lblNumberOfCameras.Location = new System.Drawing.Point(9, 43);
            lblNumberOfCameras.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblNumberOfCameras.Name = "lblNumberOfCameras";
            lblNumberOfCameras.Size = new System.Drawing.Size(0, 15);
            lblNumberOfCameras.TabIndex = 1;
            // 
            // lblSecondsLeft
            // 
            lblSecondsLeft.AutoSize = true;
            lblSecondsLeft.Location = new System.Drawing.Point(9, 105);
            lblSecondsLeft.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblSecondsLeft.Name = "lblSecondsLeft";
            lblSecondsLeft.Size = new System.Drawing.Size(0, 15);
            lblSecondsLeft.TabIndex = 4;
            // 
            // lblGridNumber
            // 
            lblGridNumber.AutoSize = true;
            lblGridNumber.Location = new System.Drawing.Point(9, 84);
            lblGridNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblGridNumber.Name = "lblGridNumber";
            lblGridNumber.Size = new System.Drawing.Size(0, 15);
            lblGridNumber.TabIndex = 3;
            // 
            // lblGridName
            // 
            lblGridName.AutoSize = true;
            lblGridName.Location = new System.Drawing.Point(9, 63);
            lblGridName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblGridName.Name = "lblGridName";
            lblGridName.Size = new System.Drawing.Size(0, 15);
            lblGridName.TabIndex = 2;
            // 
            // lblSequenceName
            // 
            lblSequenceName.AutoSize = true;
            lblSequenceName.Location = new System.Drawing.Point(9, 22);
            lblSequenceName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblSequenceName.Name = "lblSequenceName";
            lblSequenceName.Size = new System.Drawing.Size(0, 15);
            lblSequenceName.TabIndex = 0;
            // 
            // gbDisplayDevices
            // 
            gbDisplayDevices.Controls.Add(cbAgents);
            gbDisplayDevices.Controls.Add(pCrossHair);
            gbDisplayDevices.Controls.Add(lblDisplayDeviceName);
            gbDisplayDevices.Controls.Add(btnIdentify);
            gbDisplayDevices.Controls.Add(pDisplayDevices);
            gbDisplayDevices.Dock = System.Windows.Forms.DockStyle.Fill;
            gbDisplayDevices.Location = new System.Drawing.Point(0, 0);
            gbDisplayDevices.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbDisplayDevices.Name = "gbDisplayDevices";
            gbDisplayDevices.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbDisplayDevices.Size = new System.Drawing.Size(328, 183);
            gbDisplayDevices.TabIndex = 0;
            gbDisplayDevices.TabStop = false;
            gbDisplayDevices.Text = "Primary display";
            // 
            // cbAgents
            // 
            cbAgents.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbAgents.FormattingEnabled = true;
            cbAgents.Location = new System.Drawing.Point(43, 154);
            cbAgents.Name = "cbAgents";
            cbAgents.Size = new System.Drawing.Size(188, 23);
            cbAgents.TabIndex = 2;
            // 
            // pCrossHair
            // 
            pCrossHair.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            pCrossHair.BackColor = System.Drawing.SystemColors.Control;
            pCrossHair.Controls.Add(pbCrossHair);
            pCrossHair.Location = new System.Drawing.Point(6, 150);
            pCrossHair.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pCrossHair.Name = "pCrossHair";
            pCrossHair.Size = new System.Drawing.Size(29, 29);
            pCrossHair.TabIndex = 1;
            // 
            // pbCrossHair
            // 
            pbCrossHair.Image = Properties.Resources.pb_CrossHair_Image;
            pbCrossHair.Location = new System.Drawing.Point(0, 0);
            pbCrossHair.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pbCrossHair.Name = "pbCrossHair";
            pbCrossHair.OriginalSize = new System.Drawing.Size(100, 50);
            pbCrossHair.RepositioningAndResizingControlsOnResize = false;
            pbCrossHair.Size = new System.Drawing.Size(29, 29);
            pbCrossHair.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pbCrossHair.TabIndex = 0;
            pbCrossHair.TabStop = false;
            // 
            // lblDisplayDeviceName
            // 
            lblDisplayDeviceName.AutoSize = true;
            lblDisplayDeviceName.Font = (System.Drawing.Font)resources.GetObject("lblDisplayDeviceName.Font");
            lblDisplayDeviceName.Location = new System.Drawing.Point(44, 164);
            lblDisplayDeviceName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblDisplayDeviceName.Name = "lblDisplayDeviceName";
            lblDisplayDeviceName.Size = new System.Drawing.Size(0, 17);
            lblDisplayDeviceName.TabIndex = 2;
            lblDisplayDeviceName.Visible = false;
            // 
            // btnIdentify
            // 
            btnIdentify.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnIdentify.BackColor = System.Drawing.SystemColors.Control;
            btnIdentify.Location = new System.Drawing.Point(237, 150);
            btnIdentify.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnIdentify.Name = "btnIdentify";
            btnIdentify.Size = new System.Drawing.Size(88, 29);
            btnIdentify.TabIndex = 4;
            btnIdentify.Text = "Identify";
            btnIdentify.UseVisualStyleBackColor = false;
            btnIdentify.Click += BtnIdentify_Click;
            // 
            // pDisplayDevices
            // 
            pDisplayDevices.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            pDisplayDevices.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            pDisplayDevices.Location = new System.Drawing.Point(4, 18);
            pDisplayDevices.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pDisplayDevices.Name = "pDisplayDevices";
            pDisplayDevices.Size = new System.Drawing.Size(321, 124);
            pDisplayDevices.TabIndex = 0;
            pDisplayDevices.TransparentColor = System.Drawing.Color.Black;
            pDisplayDevices.UseTransparentColor = false;
            pDisplayDevices.Paint += PDisplayDevices_Paint;
            pDisplayDevices.MouseClick += PDisplayDevices_MouseClick;
            // 
            // btnRearrangeGrid
            // 
            btnRearrangeGrid.Image = (System.Drawing.Image)resources.GetObject("btnRearrangeGrid.Image");
            btnRearrangeGrid.Location = new System.Drawing.Point(120, 105);
            btnRearrangeGrid.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnRearrangeGrid.Name = "btnRearrangeGrid";
            btnRearrangeGrid.Size = new System.Drawing.Size(28, 28);
            btnRearrangeGrid.TabIndex = 8;
            btnRearrangeGrid.UseVisualStyleBackColor = true;
            btnRearrangeGrid.Click += BtnRearrangeGrid_Click;
            // 
            // gbActiveSequence
            // 
            gbActiveSequence.Controls.Add(btnRearrangeGrid);
            gbActiveSequence.Controls.Add(btnShowNextGrid);
            gbActiveSequence.Controls.Add(btnPlayOrPauseSequence);
            gbActiveSequence.Controls.Add(btnShowPreviousGrid);
            gbActiveSequence.Controls.Add(lblNumberOfCameras);
            gbActiveSequence.Controls.Add(lblSecondsLeft);
            gbActiveSequence.Controls.Add(lblGridNumber);
            gbActiveSequence.Controls.Add(lblGridName);
            gbActiveSequence.Controls.Add(lblSequenceName);
            gbActiveSequence.Dock = System.Windows.Forms.DockStyle.Fill;
            gbActiveSequence.Location = new System.Drawing.Point(0, 0);
            gbActiveSequence.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbActiveSequence.Name = "gbActiveSequence";
            gbActiveSequence.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbActiveSequence.Size = new System.Drawing.Size(328, 137);
            gbActiveSequence.TabIndex = 0;
            gbActiveSequence.TabStop = false;
            gbActiveSequence.Text = "Active sequence";
            // 
            // btnShowNextGrid
            // 
            btnShowNextGrid.Image = (System.Drawing.Image)resources.GetObject("btnShowNextGrid.Image");
            btnShowNextGrid.Location = new System.Drawing.Point(85, 105);
            btnShowNextGrid.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnShowNextGrid.Name = "btnShowNextGrid";
            btnShowNextGrid.Size = new System.Drawing.Size(28, 28);
            btnShowNextGrid.TabIndex = 7;
            btnShowNextGrid.UseVisualStyleBackColor = true;
            btnShowNextGrid.Click += BtnShowNextGrid_Click;
            // 
            // btnCloseFullScreenCamera
            // 
            btnCloseFullScreenCamera.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnCloseFullScreenCamera.BackColor = System.Drawing.SystemColors.Control;
            btnCloseFullScreenCamera.Image = Properties.Resources.btn_CloseSequenceApplications_Image;
            btnCloseFullScreenCamera.Location = new System.Drawing.Point(303, 7);
            btnCloseFullScreenCamera.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnCloseFullScreenCamera.Name = "btnCloseFullScreenCamera";
            btnCloseFullScreenCamera.Size = new System.Drawing.Size(21, 21);
            btnCloseFullScreenCamera.TabIndex = 0;
            btnCloseFullScreenCamera.UseVisualStyleBackColor = false;
            btnCloseFullScreenCamera.Click += BtnCloseFullScreenCamera_Click;
            // 
            // chNumber
            // 
            chNumber.Text = "#";
            chNumber.Width = 25;
            // 
            // chCameraName
            // 
            chCameraName.Text = "Camera name";
            chCameraName.Width = 245;
            // 
            // lvCameras
            // 
            lvCameras.AlternatingColorEven = System.Drawing.Color.LightBlue;
            lvCameras.AlternatingColorOdd = System.Drawing.SystemColors.Window;
            lvCameras.AlternatingColorsAreInUse = true;
            lvCameras.AlternatingPairColorEven = System.Drawing.Color.LightSeaGreen;
            lvCameras.AlternatingPairColorOdd = System.Drawing.Color.CadetBlue;
            lvCameras.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            lvCameras.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { chCameraName, chNumber });
            lvCameras.CompactView = false;
            lvCameras.EnsureLastItemIsVisible = false;
            lvCameras.FirstItemIsGray = false;
            lvCameras.FullRowSelect = true;
            lvCameras.Location = new System.Drawing.Point(4, 29);
            lvCameras.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            lvCameras.MultiSelect = false;
            lvCameras.Name = "lvCameras";
            lvCameras.OwnerDraw = true;
            lvCameras.ReadonlyCheckboxes = false;
            lvCameras.SameItemsColorEven = System.Drawing.Color.DarkOrange;
            lvCameras.SameItemsColorOdd = System.Drawing.Color.LightSalmon;
            lvCameras.Size = new System.Drawing.Size(320, 130);
            lvCameras.TabIndex = 1;
            lvCameras.UseCompatibleStateImageBehavior = false;
            lvCameras.View = System.Windows.Forms.View.Details;
            lvCameras.ItemSelectionChanged += LvCameras_ItemSelectionChanged;
            // 
            // gbCameras
            // 
            gbCameras.Controls.Add(lvCameras);
            gbCameras.Controls.Add(btnCloseFullScreenCamera);
            gbCameras.Dock = System.Windows.Forms.DockStyle.Fill;
            gbCameras.Location = new System.Drawing.Point(0, 0);
            gbCameras.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbCameras.Name = "gbCameras";
            gbCameras.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbCameras.Size = new System.Drawing.Size(328, 162);
            gbCameras.TabIndex = 0;
            gbCameras.TabStop = false;
            gbCameras.Text = "Select a camera to view";
            // 
            // splitter3
            // 
            splitter3.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            splitter3.Dock = System.Windows.Forms.DockStyle.Top;
            splitter3.Location = new System.Drawing.Point(0, 540);
            splitter3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            splitter3.MaximumSize = new System.Drawing.Size(0, 3);
            splitter3.MinimumSize = new System.Drawing.Size(0, 3);
            splitter3.Name = "splitter3";
            splitter3.Size = new System.Drawing.Size(328, 3);
            splitter3.TabIndex = 68;
            splitter3.TabStop = false;
            // 
            // cmDisplayDeviceContextMenu
            // 
            cmDisplayDeviceContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { tsmiProperties });
            cmDisplayDeviceContextMenu.Name = "contextMenuStrip2";
            cmDisplayDeviceContextMenu.Size = new System.Drawing.Size(128, 26);
            // 
            // pTemplates
            // 
            pTemplates.Controls.Add(gbTemplates);
            pTemplates.Dock = System.Windows.Forms.DockStyle.Fill;
            pTemplates.Location = new System.Drawing.Point(0, 700);
            pTemplates.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pTemplates.Name = "pTemplates";
            pTemplates.Size = new System.Drawing.Size(328, 103);
            pTemplates.TabIndex = 71;
            // 
            // gbTemplates
            // 
            gbTemplates.Controls.Add(lvTemplates);
            gbTemplates.Dock = System.Windows.Forms.DockStyle.Fill;
            gbTemplates.Location = new System.Drawing.Point(0, 0);
            gbTemplates.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbTemplates.Name = "gbTemplates";
            gbTemplates.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbTemplates.Size = new System.Drawing.Size(328, 103);
            gbTemplates.TabIndex = 0;
            gbTemplates.TabStop = false;
            gbTemplates.Text = "Templates";
            // 
            // lvTemplates
            // 
            lvTemplates.AlternatingColorEven = System.Drawing.Color.LightBlue;
            lvTemplates.AlternatingColorOdd = System.Drawing.SystemColors.Window;
            lvTemplates.AlternatingColorsAreInUse = true;
            lvTemplates.AlternatingPairColorEven = System.Drawing.Color.LightSeaGreen;
            lvTemplates.AlternatingPairColorOdd = System.Drawing.Color.CadetBlue;
            lvTemplates.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { chTemplateName });
            lvTemplates.CompactView = false;
            lvTemplates.Dock = System.Windows.Forms.DockStyle.Fill;
            lvTemplates.EnsureLastItemIsVisible = false;
            lvTemplates.FirstItemIsGray = false;
            lvTemplates.FullRowSelect = true;
            lvTemplates.Location = new System.Drawing.Point(4, 19);
            lvTemplates.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            lvTemplates.MultiSelect = false;
            lvTemplates.Name = "lvTemplates";
            lvTemplates.OwnerDraw = true;
            lvTemplates.ReadonlyCheckboxes = false;
            lvTemplates.SameItemsColorEven = System.Drawing.Color.DarkOrange;
            lvTemplates.SameItemsColorOdd = System.Drawing.Color.LightSalmon;
            lvTemplates.Size = new System.Drawing.Size(320, 81);
            lvTemplates.TabIndex = 0;
            lvTemplates.UseCompatibleStateImageBehavior = false;
            lvTemplates.View = System.Windows.Forms.View.Details;
            // 
            // chTemplateName
            // 
            chTemplateName.Text = "Template name";
            chTemplateName.Width = 271;
            // 
            // splitter4
            // 
            splitter4.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            splitter4.Dock = System.Windows.Forms.DockStyle.Top;
            splitter4.Location = new System.Drawing.Point(0, 697);
            splitter4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            splitter4.MaximumSize = new System.Drawing.Size(0, 3);
            splitter4.MinimumSize = new System.Drawing.Size(0, 3);
            splitter4.Name = "splitter4";
            splitter4.Size = new System.Drawing.Size(328, 3);
            splitter4.TabIndex = 70;
            splitter4.TabStop = false;
            // 
            // pFullScreenCameraController
            // 
            pFullScreenCameraController.Controls.Add(gbFullScreenCameraController);
            pFullScreenCameraController.Dock = System.Windows.Forms.DockStyle.Top;
            pFullScreenCameraController.Location = new System.Drawing.Point(0, 543);
            pFullScreenCameraController.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pFullScreenCameraController.Name = "pFullScreenCameraController";
            pFullScreenCameraController.Size = new System.Drawing.Size(328, 154);
            pFullScreenCameraController.TabIndex = 69;
            // 
            // gbFullScreenCameraController
            // 
            gbFullScreenCameraController.Controls.Add(lblSeparator);
            gbFullScreenCameraController.Controls.Add(lblJoystickCoordinates);
            gbFullScreenCameraController.Controls.Add(pJoystick);
            gbFullScreenCameraController.Controls.Add(lblStyle);
            gbFullScreenCameraController.Controls.Add(rbNoFrames);
            gbFullScreenCameraController.Controls.Add(rbDefaultStyle);
            gbFullScreenCameraController.Controls.Add(btnMoveCameraSouthWest);
            gbFullScreenCameraController.Controls.Add(btnMoveCameraSouthEast);
            gbFullScreenCameraController.Controls.Add(btnMoveCameraSouth);
            gbFullScreenCameraController.Controls.Add(btnMoveCameraWest);
            gbFullScreenCameraController.Controls.Add(btnMoveCameraEast);
            gbFullScreenCameraController.Controls.Add(btnMoveCameraToPresetZero);
            gbFullScreenCameraController.Controls.Add(btnMoveCameraNorthWest);
            gbFullScreenCameraController.Controls.Add(btnMoveCameraNorthEast);
            gbFullScreenCameraController.Controls.Add(btnMoveCameraNorth);
            gbFullScreenCameraController.Controls.Add(pMoveCameraSouthEast);
            gbFullScreenCameraController.Controls.Add(pMoveCameraEast);
            gbFullScreenCameraController.Controls.Add(pMoveCameraSouth);
            gbFullScreenCameraController.Controls.Add(pMoveCameraNorthEast);
            gbFullScreenCameraController.Controls.Add(pMoveCameraSouthWest);
            gbFullScreenCameraController.Controls.Add(pMoveCameraToPresetZero);
            gbFullScreenCameraController.Controls.Add(pMoveCameraNorth);
            gbFullScreenCameraController.Controls.Add(pMoveCameraWest);
            gbFullScreenCameraController.Controls.Add(pMoveCameraNorthWest);
            gbFullScreenCameraController.Dock = System.Windows.Forms.DockStyle.Fill;
            gbFullScreenCameraController.Location = new System.Drawing.Point(0, 0);
            gbFullScreenCameraController.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbFullScreenCameraController.Name = "gbFullScreenCameraController";
            gbFullScreenCameraController.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbFullScreenCameraController.Size = new System.Drawing.Size(328, 154);
            gbFullScreenCameraController.TabIndex = 0;
            gbFullScreenCameraController.TabStop = false;
            gbFullScreenCameraController.Text = "Full screen camera controller";
            // 
            // lblSeparator
            // 
            lblSeparator.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            lblSeparator.Location = new System.Drawing.Point(6, 58);
            lblSeparator.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblSeparator.Name = "lblSeparator";
            lblSeparator.Size = new System.Drawing.Size(316, 2);
            lblSeparator.TabIndex = 82;
            // 
            // lblJoystickCoordinates
            // 
            lblJoystickCoordinates.AutoSize = true;
            lblJoystickCoordinates.Location = new System.Drawing.Point(4, 60);
            lblJoystickCoordinates.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblJoystickCoordinates.Name = "lblJoystickCoordinates";
            lblJoystickCoordinates.Size = new System.Drawing.Size(113, 15);
            lblJoystickCoordinates.TabIndex = 81;
            lblJoystickCoordinates.Text = "Joystick coordinates";
            // 
            // pJoystick
            // 
            pJoystick.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pJoystick.Controls.Add(btnZoomOut);
            pJoystick.Controls.Add(btnZoomIn);
            pJoystick.Controls.Add(btnCalibrate);
            pJoystick.Controls.Add(lblX);
            pJoystick.Controls.Add(lblY);
            pJoystick.Controls.Add(lblZ);
            pJoystick.Location = new System.Drawing.Point(6, 80);
            pJoystick.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pJoystick.Name = "pJoystick";
            pJoystick.Size = new System.Drawing.Size(165, 65);
            pJoystick.TabIndex = 0;
            // 
            // btnZoomOut
            // 
            btnZoomOut.Enabled = false;
            btnZoomOut.Font = (System.Drawing.Font)resources.GetObject("btnZoomOut.Font");
            btnZoomOut.Location = new System.Drawing.Point(122, 3);
            btnZoomOut.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnZoomOut.Name = "btnZoomOut";
            btnZoomOut.Size = new System.Drawing.Size(38, 27);
            btnZoomOut.TabIndex = 80;
            btnZoomOut.Text = "-";
            btnZoomOut.UseVisualStyleBackColor = true;
            btnZoomOut.MouseDown += BtnZoomOut_MouseDown;
            btnZoomOut.MouseUp += BtnZoomOut_MouseUp;
            // 
            // btnZoomIn
            // 
            btnZoomIn.Enabled = false;
            btnZoomIn.Font = (System.Drawing.Font)resources.GetObject("btnZoomIn.Font");
            btnZoomIn.Location = new System.Drawing.Point(74, 3);
            btnZoomIn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnZoomIn.Name = "btnZoomIn";
            btnZoomIn.Size = new System.Drawing.Size(38, 27);
            btnZoomIn.TabIndex = 73;
            btnZoomIn.Text = "+";
            btnZoomIn.UseVisualStyleBackColor = true;
            btnZoomIn.MouseDown += BtnZoomIn_MouseDown;
            btnZoomIn.MouseUp += BtnZoomIn_MouseUp;
            // 
            // btnCalibrate
            // 
            btnCalibrate.Enabled = false;
            btnCalibrate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            btnCalibrate.Location = new System.Drawing.Point(74, 33);
            btnCalibrate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnCalibrate.Name = "btnCalibrate";
            btnCalibrate.Size = new System.Drawing.Size(88, 27);
            btnCalibrate.TabIndex = 59;
            btnCalibrate.Text = "Calibrate";
            btnCalibrate.UseVisualStyleBackColor = true;
            btnCalibrate.Click += BtnCalibrate_Click;
            // 
            // lblX
            // 
            lblX.AutoSize = true;
            lblX.Location = new System.Drawing.Point(2, 1);
            lblX.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblX.Name = "lblX";
            lblX.Size = new System.Drawing.Size(34, 15);
            lblX.TabIndex = 56;
            lblX.Text = "X = 0";
            // 
            // lblY
            // 
            lblY.AutoSize = true;
            lblY.Location = new System.Drawing.Point(2, 23);
            lblY.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblY.Name = "lblY";
            lblY.Size = new System.Drawing.Size(34, 15);
            lblY.TabIndex = 57;
            lblY.Text = "Y = 0";
            // 
            // lblZ
            // 
            lblZ.AutoSize = true;
            lblZ.Location = new System.Drawing.Point(2, 45);
            lblZ.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblZ.Name = "lblZ";
            lblZ.Size = new System.Drawing.Size(34, 15);
            lblZ.TabIndex = 58;
            lblZ.Text = "Z = 0";
            // 
            // lblStyle
            // 
            lblStyle.AutoSize = true;
            lblStyle.Location = new System.Drawing.Point(4, 18);
            lblStyle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblStyle.Name = "lblStyle";
            lblStyle.Size = new System.Drawing.Size(32, 15);
            lblStyle.TabIndex = 80;
            lblStyle.Text = "Style";
            // 
            // rbNoFrames
            // 
            rbNoFrames.AutoSize = true;
            rbNoFrames.Location = new System.Drawing.Point(138, 37);
            rbNoFrames.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            rbNoFrames.Name = "rbNoFrames";
            rbNoFrames.Size = new System.Drawing.Size(80, 19);
            rbNoFrames.TabIndex = 79;
            rbNoFrames.Text = "No frames";
            rbNoFrames.UseVisualStyleBackColor = true;
            // 
            // rbDefaultStyle
            // 
            rbDefaultStyle.AutoSize = true;
            rbDefaultStyle.Checked = true;
            rbDefaultStyle.Location = new System.Drawing.Point(7, 37);
            rbDefaultStyle.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            rbDefaultStyle.Name = "rbDefaultStyle";
            rbDefaultStyle.Size = new System.Drawing.Size(63, 19);
            rbDefaultStyle.TabIndex = 78;
            rbDefaultStyle.TabStop = true;
            rbDefaultStyle.Text = "Default";
            rbDefaultStyle.UseVisualStyleBackColor = true;
            // 
            // btnMoveCameraSouthWest
            // 
            btnMoveCameraSouthWest.Enabled = false;
            btnMoveCameraSouthWest.Image = Properties.Resources.sw;
            btnMoveCameraSouthWest.Location = new System.Drawing.Point(178, 121);
            btnMoveCameraSouthWest.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnMoveCameraSouthWest.Name = "btnMoveCameraSouthWest";
            btnMoveCameraSouthWest.Size = new System.Drawing.Size(48, 27);
            btnMoveCameraSouthWest.TabIndex = 75;
            btnMoveCameraSouthWest.UseVisualStyleBackColor = true;
            btnMoveCameraSouthWest.MouseDown += BtnMoveCameraSouthWest_MouseDown;
            btnMoveCameraSouthWest.MouseUp += BtnMoveCameraSouthWest_MouseUp;
            // 
            // btnMoveCameraSouthEast
            // 
            btnMoveCameraSouthEast.Enabled = false;
            btnMoveCameraSouthEast.Image = Properties.Resources.se;
            btnMoveCameraSouthEast.Location = new System.Drawing.Point(274, 121);
            btnMoveCameraSouthEast.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnMoveCameraSouthEast.Name = "btnMoveCameraSouthEast";
            btnMoveCameraSouthEast.Size = new System.Drawing.Size(48, 27);
            btnMoveCameraSouthEast.TabIndex = 74;
            btnMoveCameraSouthEast.UseVisualStyleBackColor = true;
            btnMoveCameraSouthEast.MouseDown += BtnMoveCameraSouthEast_MouseDown;
            btnMoveCameraSouthEast.MouseUp += BtnMoveCameraSouthEast_MouseUp;
            // 
            // btnMoveCameraSouth
            // 
            btnMoveCameraSouth.Enabled = false;
            btnMoveCameraSouth.Image = Properties.Resources.arrow_down;
            btnMoveCameraSouth.Location = new System.Drawing.Point(226, 121);
            btnMoveCameraSouth.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnMoveCameraSouth.Name = "btnMoveCameraSouth";
            btnMoveCameraSouth.Size = new System.Drawing.Size(48, 27);
            btnMoveCameraSouth.TabIndex = 73;
            btnMoveCameraSouth.UseVisualStyleBackColor = true;
            btnMoveCameraSouth.MouseDown += BtnMoveCameraSouth_MouseDown;
            btnMoveCameraSouth.MouseUp += BtnMoveCameraSouth_MouseUp;
            // 
            // btnMoveCameraWest
            // 
            btnMoveCameraWest.Enabled = false;
            btnMoveCameraWest.Image = Properties.Resources.arrow_left;
            btnMoveCameraWest.Location = new System.Drawing.Point(178, 95);
            btnMoveCameraWest.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnMoveCameraWest.Name = "btnMoveCameraWest";
            btnMoveCameraWest.Size = new System.Drawing.Size(48, 27);
            btnMoveCameraWest.TabIndex = 72;
            btnMoveCameraWest.UseVisualStyleBackColor = true;
            btnMoveCameraWest.MouseDown += BtnMoveCameraWest_MouseDown;
            btnMoveCameraWest.MouseUp += BtnMoveCameraWest_MouseUp;
            // 
            // btnMoveCameraEast
            // 
            btnMoveCameraEast.Enabled = false;
            btnMoveCameraEast.Image = Properties.Resources.arrow_right;
            btnMoveCameraEast.Location = new System.Drawing.Point(274, 95);
            btnMoveCameraEast.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnMoveCameraEast.Name = "btnMoveCameraEast";
            btnMoveCameraEast.Size = new System.Drawing.Size(48, 27);
            btnMoveCameraEast.TabIndex = 71;
            btnMoveCameraEast.UseVisualStyleBackColor = true;
            btnMoveCameraEast.MouseDown += BtnMoveCameraEast_MouseDown;
            btnMoveCameraEast.MouseUp += BtnMoveCameraEast_MouseUp;
            // 
            // btnMoveCameraToPresetZero
            // 
            btnMoveCameraToPresetZero.Enabled = false;
            btnMoveCameraToPresetZero.Image = Properties.Resources.house;
            btnMoveCameraToPresetZero.Location = new System.Drawing.Point(226, 95);
            btnMoveCameraToPresetZero.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnMoveCameraToPresetZero.Name = "btnMoveCameraToPresetZero";
            btnMoveCameraToPresetZero.Size = new System.Drawing.Size(48, 27);
            btnMoveCameraToPresetZero.TabIndex = 70;
            btnMoveCameraToPresetZero.UseVisualStyleBackColor = true;
            btnMoveCameraToPresetZero.Click += BtnMoveCameraToPresetZero_Click;
            // 
            // btnMoveCameraNorthWest
            // 
            btnMoveCameraNorthWest.Enabled = false;
            btnMoveCameraNorthWest.Image = Properties.Resources.nw;
            btnMoveCameraNorthWest.Location = new System.Drawing.Point(178, 68);
            btnMoveCameraNorthWest.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnMoveCameraNorthWest.Name = "btnMoveCameraNorthWest";
            btnMoveCameraNorthWest.Size = new System.Drawing.Size(48, 27);
            btnMoveCameraNorthWest.TabIndex = 69;
            btnMoveCameraNorthWest.UseVisualStyleBackColor = true;
            btnMoveCameraNorthWest.MouseDown += BtnMoveCameraNorthWest_MouseDown;
            btnMoveCameraNorthWest.MouseUp += BtnMoveCameraNorthWest_MouseUp;
            // 
            // btnMoveCameraNorthEast
            // 
            btnMoveCameraNorthEast.Enabled = false;
            btnMoveCameraNorthEast.Image = Properties.Resources.ne;
            btnMoveCameraNorthEast.Location = new System.Drawing.Point(274, 68);
            btnMoveCameraNorthEast.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnMoveCameraNorthEast.Name = "btnMoveCameraNorthEast";
            btnMoveCameraNorthEast.Size = new System.Drawing.Size(48, 27);
            btnMoveCameraNorthEast.TabIndex = 68;
            btnMoveCameraNorthEast.UseVisualStyleBackColor = true;
            btnMoveCameraNorthEast.MouseDown += BtnMoveCameraNorthEast_MouseDown;
            btnMoveCameraNorthEast.MouseUp += BtnMoveCameraNorthEast_MouseUp;
            // 
            // btnMoveCameraNorth
            // 
            btnMoveCameraNorth.Enabled = false;
            btnMoveCameraNorth.Image = Properties.Resources.arrow_up;
            btnMoveCameraNorth.Location = new System.Drawing.Point(226, 68);
            btnMoveCameraNorth.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnMoveCameraNorth.Name = "btnMoveCameraNorth";
            btnMoveCameraNorth.Size = new System.Drawing.Size(48, 27);
            btnMoveCameraNorth.TabIndex = 67;
            btnMoveCameraNorth.UseVisualStyleBackColor = true;
            btnMoveCameraNorth.MouseDown += BtnMoveCameraNorth_MouseDown;
            btnMoveCameraNorth.MouseUp += BtnMoveCameraNorth_MouseUp;
            // 
            // pMoveCameraSouthEast
            // 
            pMoveCameraSouthEast.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            pMoveCameraSouthEast.Enabled = false;
            pMoveCameraSouthEast.Location = new System.Drawing.Point(274, 122);
            pMoveCameraSouthEast.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pMoveCameraSouthEast.Name = "pMoveCameraSouthEast";
            pMoveCameraSouthEast.Size = new System.Drawing.Size(21, 23);
            pMoveCameraSouthEast.TabIndex = 66;
            pMoveCameraSouthEast.Visible = false;
            // 
            // pMoveCameraEast
            // 
            pMoveCameraEast.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            pMoveCameraEast.Enabled = false;
            pMoveCameraEast.Location = new System.Drawing.Point(274, 95);
            pMoveCameraEast.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pMoveCameraEast.Name = "pMoveCameraEast";
            pMoveCameraEast.Size = new System.Drawing.Size(48, 28);
            pMoveCameraEast.TabIndex = 63;
            pMoveCameraEast.Visible = false;
            // 
            // pMoveCameraSouth
            // 
            pMoveCameraSouth.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            pMoveCameraSouth.Enabled = false;
            pMoveCameraSouth.Location = new System.Drawing.Point(226, 122);
            pMoveCameraSouth.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pMoveCameraSouth.Name = "pMoveCameraSouth";
            pMoveCameraSouth.Size = new System.Drawing.Size(48, 28);
            pMoveCameraSouth.TabIndex = 65;
            pMoveCameraSouth.Visible = false;
            // 
            // pMoveCameraNorthEast
            // 
            pMoveCameraNorthEast.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            pMoveCameraNorthEast.Enabled = false;
            pMoveCameraNorthEast.Location = new System.Drawing.Point(274, 72);
            pMoveCameraNorthEast.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pMoveCameraNorthEast.Name = "pMoveCameraNorthEast";
            pMoveCameraNorthEast.Size = new System.Drawing.Size(21, 23);
            pMoveCameraNorthEast.TabIndex = 60;
            pMoveCameraNorthEast.Visible = false;
            // 
            // pMoveCameraSouthWest
            // 
            pMoveCameraSouthWest.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            pMoveCameraSouthWest.Enabled = false;
            pMoveCameraSouthWest.Location = new System.Drawing.Point(205, 122);
            pMoveCameraSouthWest.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pMoveCameraSouthWest.Name = "pMoveCameraSouthWest";
            pMoveCameraSouthWest.Size = new System.Drawing.Size(21, 23);
            pMoveCameraSouthWest.TabIndex = 64;
            pMoveCameraSouthWest.Visible = false;
            // 
            // pMoveCameraToPresetZero
            // 
            pMoveCameraToPresetZero.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            pMoveCameraToPresetZero.Enabled = false;
            pMoveCameraToPresetZero.Location = new System.Drawing.Point(226, 95);
            pMoveCameraToPresetZero.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pMoveCameraToPresetZero.Name = "pMoveCameraToPresetZero";
            pMoveCameraToPresetZero.Size = new System.Drawing.Size(48, 28);
            pMoveCameraToPresetZero.TabIndex = 62;
            pMoveCameraToPresetZero.Visible = false;
            // 
            // pMoveCameraNorth
            // 
            pMoveCameraNorth.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            pMoveCameraNorth.Enabled = false;
            pMoveCameraNorth.Location = new System.Drawing.Point(226, 67);
            pMoveCameraNorth.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pMoveCameraNorth.Name = "pMoveCameraNorth";
            pMoveCameraNorth.Size = new System.Drawing.Size(48, 28);
            pMoveCameraNorth.TabIndex = 59;
            pMoveCameraNorth.Visible = false;
            // 
            // pMoveCameraWest
            // 
            pMoveCameraWest.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            pMoveCameraWest.Enabled = false;
            pMoveCameraWest.Location = new System.Drawing.Point(178, 95);
            pMoveCameraWest.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pMoveCameraWest.Name = "pMoveCameraWest";
            pMoveCameraWest.Size = new System.Drawing.Size(48, 28);
            pMoveCameraWest.TabIndex = 61;
            pMoveCameraWest.Visible = false;
            // 
            // pMoveCameraNorthWest
            // 
            pMoveCameraNorthWest.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            pMoveCameraNorthWest.Enabled = false;
            pMoveCameraNorthWest.Location = new System.Drawing.Point(205, 72);
            pMoveCameraNorthWest.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pMoveCameraNorthWest.Name = "pMoveCameraNorthWest";
            pMoveCameraNorthWest.Size = new System.Drawing.Size(21, 23);
            pMoveCameraNorthWest.TabIndex = 58;
            pMoveCameraNorthWest.Visible = false;
            // 
            // ilCameraImages
            // 
            ilCameraImages.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            ilCameraImages.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("ilCameraImages.ImageStream");
            ilCameraImages.TransparentColor = System.Drawing.Color.Transparent;
            ilCameraImages.Images.SetKeyName(0, "nw.ico");
            ilCameraImages.Images.SetKeyName(1, "arrow_up.png");
            ilCameraImages.Images.SetKeyName(2, "ne.ico");
            ilCameraImages.Images.SetKeyName(3, "arrow_left.png");
            ilCameraImages.Images.SetKeyName(4, "house.ico");
            ilCameraImages.Images.SetKeyName(5, "arrow_right.png");
            ilCameraImages.Images.SetKeyName(6, "sw.ico");
            ilCameraImages.Images.SetKeyName(7, "arrow_down.png");
            ilCameraImages.Images.SetKeyName(8, "se.ico");
            // 
            // ilBigImages
            // 
            ilBigImages.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            ilBigImages.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("ilBigImages.ImageStream");
            ilBigImages.TransparentColor = System.Drawing.Color.Transparent;
            ilBigImages.Images.SetKeyName(0, "bigcam.ico");
            ilBigImages.Images.SetKeyName(1, "bigsequential.ico");
            ilBigImages.Images.SetKeyName(2, "bell 2.ico");
            ilBigImages.Images.SetKeyName(3, "monitor-32.ico");
            ilBigImages.Images.SetKeyName(4, "templates.ico");
            // 
            // chSequenceName
            // 
            chSequenceName.Text = "Sequence name";
            chSequenceName.Width = 271;
            // 
            // btnCloseSequenceApplications
            // 
            btnCloseSequenceApplications.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnCloseSequenceApplications.BackColor = System.Drawing.SystemColors.Control;
            btnCloseSequenceApplications.Image = Properties.Resources.btn_CloseSequenceApplications_Image;
            btnCloseSequenceApplications.Location = new System.Drawing.Point(303, 6);
            btnCloseSequenceApplications.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnCloseSequenceApplications.Name = "btnCloseSequenceApplications";
            btnCloseSequenceApplications.Size = new System.Drawing.Size(21, 21);
            btnCloseSequenceApplications.TabIndex = 0;
            btnCloseSequenceApplications.UseVisualStyleBackColor = false;
            btnCloseSequenceApplications.Click += BtnCloseSequenceApplications_Click;
            // 
            // lvSequences
            // 
            lvSequences.AlternatingColorEven = System.Drawing.Color.LightBlue;
            lvSequences.AlternatingColorOdd = System.Drawing.SystemColors.Window;
            lvSequences.AlternatingColorsAreInUse = true;
            lvSequences.AlternatingPairColorEven = System.Drawing.Color.LightSeaGreen;
            lvSequences.AlternatingPairColorOdd = System.Drawing.Color.CadetBlue;
            lvSequences.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            lvSequences.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { chSequenceName });
            lvSequences.CompactView = false;
            lvSequences.EnsureLastItemIsVisible = false;
            lvSequences.FirstItemIsGray = false;
            lvSequences.FullRowSelect = true;
            lvSequences.Location = new System.Drawing.Point(4, 29);
            lvSequences.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            lvSequences.MultiSelect = false;
            lvSequences.Name = "lvSequences";
            lvSequences.OwnerDraw = true;
            lvSequences.ReadonlyCheckboxes = false;
            lvSequences.SameItemsColorEven = System.Drawing.Color.DarkOrange;
            lvSequences.SameItemsColorOdd = System.Drawing.Color.LightSalmon;
            lvSequences.Size = new System.Drawing.Size(321, 105);
            lvSequences.TabIndex = 1;
            lvSequences.UseCompatibleStateImageBehavior = false;
            lvSequences.View = System.Windows.Forms.View.Details;
            lvSequences.ItemSelectionChanged += LvSequences_ItemSelectionChanged;
            // 
            // gbSequences
            // 
            gbSequences.Controls.Add(btnCloseSequenceApplications);
            gbSequences.Controls.Add(lvSequences);
            gbSequences.Dock = System.Windows.Forms.DockStyle.Fill;
            gbSequences.Location = new System.Drawing.Point(0, 0);
            gbSequences.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbSequences.Name = "gbSequences";
            gbSequences.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbSequences.Size = new System.Drawing.Size(328, 137);
            gbSequences.TabIndex = 0;
            gbSequences.TabStop = false;
            gbSequences.Text = "Select a sequence to view";
            // 
            // pbSziltechLogo
            // 
            pbSziltechLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            pbSziltechLogo.Image = Properties.Resources.pb_Logo_Image;
            pbSziltechLogo.Location = new System.Drawing.Point(0, 0);
            pbSziltechLogo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pbSziltechLogo.Name = "pbSziltechLogo";
            pbSziltechLogo.OriginalSize = new System.Drawing.Size(100, 50);
            pbSziltechLogo.RepositioningAndResizingControlsOnResize = false;
            pbSziltechLogo.Size = new System.Drawing.Size(328, 52);
            pbSziltechLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pbSziltechLogo.TabIndex = 83;
            pbSziltechLogo.TabStop = false;
            // 
            // pCameras
            // 
            pCameras.Controls.Add(gbCameras);
            pCameras.Dock = System.Windows.Forms.DockStyle.Top;
            pCameras.Location = new System.Drawing.Point(0, 378);
            pCameras.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pCameras.Name = "pCameras";
            pCameras.Size = new System.Drawing.Size(328, 162);
            pCameras.TabIndex = 67;
            // 
            // spitter1
            // 
            spitter1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            spitter1.Dock = System.Windows.Forms.DockStyle.Top;
            spitter1.Location = new System.Drawing.Point(0, 189);
            spitter1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            spitter1.MaximumSize = new System.Drawing.Size(0, 3);
            spitter1.MinimumSize = new System.Drawing.Size(0, 3);
            spitter1.Name = "spitter1";
            spitter1.Size = new System.Drawing.Size(328, 3);
            spitter1.TabIndex = 1;
            spitter1.TabStop = false;
            // 
            // pSequences
            // 
            pSequences.Controls.Add(gbSequences);
            pSequences.Dock = System.Windows.Forms.DockStyle.Top;
            pSequences.Location = new System.Drawing.Point(0, 52);
            pSequences.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pSequences.Name = "pSequences";
            pSequences.Size = new System.Drawing.Size(328, 137);
            pSequences.TabIndex = 1;
            // 
            // pLogo
            // 
            pLogo.Controls.Add(pbSziltechLogo);
            pLogo.Dock = System.Windows.Forms.DockStyle.Top;
            pLogo.Location = new System.Drawing.Point(0, 0);
            pLogo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pLogo.Name = "pLogo";
            pLogo.Size = new System.Drawing.Size(328, 52);
            pLogo.TabIndex = 0;
            // 
            // pMain
            // 
            pMain.Controls.Add(pTemplates);
            pMain.Controls.Add(splitter4);
            pMain.Controls.Add(pFullScreenCameraController);
            pMain.Controls.Add(splitter3);
            pMain.Controls.Add(pCameras);
            pMain.Controls.Add(pActiveSequence);
            pMain.Controls.Add(splitter2);
            pMain.Controls.Add(pDisplays);
            pMain.Controls.Add(spitter1);
            pMain.Controls.Add(pSequences);
            pMain.Controls.Add(pLogo);
            pMain.Dock = System.Windows.Forms.DockStyle.Fill;
            pMain.Location = new System.Drawing.Point(0, 0);
            pMain.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pMain.Name = "pMain";
            pMain.Size = new System.Drawing.Size(328, 940);
            pMain.TabIndex = 1;
            // 
            // pActiveSequence
            // 
            pActiveSequence.Controls.Add(gbActiveSequence);
            pActiveSequence.Dock = System.Windows.Forms.DockStyle.Bottom;
            pActiveSequence.Location = new System.Drawing.Point(0, 803);
            pActiveSequence.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pActiveSequence.Name = "pActiveSequence";
            pActiveSequence.Size = new System.Drawing.Size(328, 137);
            pActiveSequence.TabIndex = 65;
            // 
            // splitter2
            // 
            splitter2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            splitter2.Dock = System.Windows.Forms.DockStyle.Top;
            splitter2.Location = new System.Drawing.Point(0, 375);
            splitter2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            splitter2.MaximumSize = new System.Drawing.Size(0, 3);
            splitter2.MinimumSize = new System.Drawing.Size(0, 3);
            splitter2.Name = "splitter2";
            splitter2.Size = new System.Drawing.Size(328, 3);
            splitter2.TabIndex = 2;
            splitter2.TabStop = false;
            // 
            // pDisplays
            // 
            pDisplays.Controls.Add(gbDisplayDevices);
            pDisplays.Dock = System.Windows.Forms.DockStyle.Top;
            pDisplays.Location = new System.Drawing.Point(0, 192);
            pDisplays.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pDisplays.Name = "pDisplays";
            pDisplays.Size = new System.Drawing.Size(328, 183);
            pDisplays.TabIndex = 5;
            // 
            // ControlCenter
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(328, 940);
            Controls.Add(pMain);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ControlCenter";
            StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            Text = "Control center";
            TopMost = true;
            Load += ControlCenter_Load;
            Shown += ControlCenter_Shown;
            gbDisplayDevices.ResumeLayout(false);
            gbDisplayDevices.PerformLayout();
            pCrossHair.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbCrossHair).EndInit();
            gbActiveSequence.ResumeLayout(false);
            gbActiveSequence.PerformLayout();
            gbCameras.ResumeLayout(false);
            cmDisplayDeviceContextMenu.ResumeLayout(false);
            pTemplates.ResumeLayout(false);
            gbTemplates.ResumeLayout(false);
            pFullScreenCameraController.ResumeLayout(false);
            gbFullScreenCameraController.ResumeLayout(false);
            gbFullScreenCameraController.PerformLayout();
            pJoystick.ResumeLayout(false);
            pJoystick.PerformLayout();
            gbSequences.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbSziltechLogo).EndInit();
            pCameras.ResumeLayout(false);
            pSequences.ResumeLayout(false);
            pLogo.ResumeLayout(false);
            pMain.ResumeLayout(false);
            pActiveSequence.ResumeLayout(false);
            pDisplays.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem tsmiProperties;
        private System.Windows.Forms.Button btnPlayOrPauseSequence;
        private System.Windows.Forms.ImageList ilSequenceControllers;
        private System.Windows.Forms.Button btnShowPreviousGrid;
        private System.Windows.Forms.Label lblNumberOfCameras;
        private System.Windows.Forms.Label lblSecondsLeft;
        private System.Windows.Forms.Label lblGridNumber;
        private System.Windows.Forms.Label lblGridName;
        private System.Windows.Forms.Label lblSequenceName;
        private System.Windows.Forms.GroupBox gbDisplayDevices;
        private System.Windows.Forms.Panel pCrossHair;
        private Mtf.Controls.MtfPictureBox pbCrossHair;
        private System.Windows.Forms.Label lblDisplayDeviceName;
        private System.Windows.Forms.Button btnIdentify;
        private Mtf.Controls.TransparentPanel pDisplayDevices;
        private System.Windows.Forms.Button btnRearrangeGrid;
        private System.Windows.Forms.GroupBox gbActiveSequence;
        private System.Windows.Forms.Button btnShowNextGrid;
        private System.Windows.Forms.Button btnCloseFullScreenCamera;
        private System.Windows.Forms.ColumnHeader chNumber;
        private System.Windows.Forms.ColumnHeader chCameraName;
        private Mtf.Controls.MtfListView lvCameras;
        private System.Windows.Forms.GroupBox gbCameras;
        private System.Windows.Forms.Splitter splitter3;
        private System.Windows.Forms.ContextMenuStrip cmDisplayDeviceContextMenu;
        private System.Windows.Forms.Panel pTemplates;
        private System.Windows.Forms.GroupBox gbTemplates;
        private Mtf.Controls.MtfListView lvTemplates;
        private System.Windows.Forms.ColumnHeader chTemplateName;
        private System.Windows.Forms.ToolTip ttHint;
        private System.ComponentModel.BackgroundWorker bwSequenceWatcher;
        private System.Windows.Forms.Splitter splitter4;
        private System.Windows.Forms.Panel pFullScreenCameraController;
        private System.Windows.Forms.GroupBox gbFullScreenCameraController;
        private System.Windows.Forms.Label lblSeparator;
        private System.Windows.Forms.Label lblJoystickCoordinates;
        private System.Windows.Forms.Panel pJoystick;
        private System.Windows.Forms.Button btnZoomOut;
        private System.Windows.Forms.Button btnZoomIn;
        private System.Windows.Forms.Button btnCalibrate;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.Label lblZ;
        private System.Windows.Forms.Label lblStyle;
        private System.Windows.Forms.RadioButton rbNoFrames;
        private System.Windows.Forms.RadioButton rbDefaultStyle;
        private System.Windows.Forms.Button btnMoveCameraSouthWest;
        private System.Windows.Forms.ImageList ilCameraImages;
        private System.Windows.Forms.Button btnMoveCameraSouthEast;
        private System.Windows.Forms.Button btnMoveCameraSouth;
        private System.Windows.Forms.Button btnMoveCameraWest;
        private System.Windows.Forms.Button btnMoveCameraEast;
        private System.Windows.Forms.Button btnMoveCameraToPresetZero;
        private System.Windows.Forms.Button btnMoveCameraNorthWest;
        private System.Windows.Forms.Button btnMoveCameraNorthEast;
        private System.Windows.Forms.Button btnMoveCameraNorth;
        private System.Windows.Forms.Panel pMoveCameraSouthEast;
        private System.Windows.Forms.Panel pMoveCameraEast;
        private System.Windows.Forms.Panel pMoveCameraSouth;
        private System.Windows.Forms.Panel pMoveCameraNorthEast;
        private System.Windows.Forms.Panel pMoveCameraSouthWest;
        private System.Windows.Forms.Panel pMoveCameraToPresetZero;
        private System.Windows.Forms.Panel pMoveCameraNorth;
        private System.Windows.Forms.Panel pMoveCameraWest;
        private System.Windows.Forms.Panel pMoveCameraNorthWest;
        private System.Windows.Forms.ImageList ilBigImages;
        private System.Windows.Forms.ColumnHeader chSequenceName;
        private System.Windows.Forms.Button btnCloseSequenceApplications;
        private Mtf.Controls.MtfListView lvSequences;
        private System.Windows.Forms.GroupBox gbSequences;
        private Mtf.Controls.MtfPictureBox pbSziltechLogo;
        private System.Windows.Forms.Panel pCameras;
        private System.Windows.Forms.Splitter spitter1;
        private System.Windows.Forms.Panel pSequences;
        private System.Windows.Forms.Panel pLogo;
        private System.Windows.Forms.Panel pMain;
        private System.Windows.Forms.Panel pActiveSequence;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Panel pDisplays;
        private System.Windows.Forms.ComboBox cbAgents;
    }
}