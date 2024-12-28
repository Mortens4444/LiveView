namespace LiveView.Forms
{
    partial class AddGrid
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(AddGrid));
            pMain = new System.Windows.Forms.Panel();
            axVideoPlayerWindow = new Mtf.Controls.x86.AxVideoPlayerWindow();
            ssStatusStrip = new System.Windows.Forms.StatusStrip();
            tsbPrevious = new System.Windows.Forms.ToolStripButton();
            tsbPlayOrPause = new System.Windows.Forms.ToolStripButton();
            tsbNext = new System.Windows.Forms.ToolStripButton();
            tsslSpaceHolder = new System.Windows.Forms.ToolStripStatusLabel();
            tsslSequence = new System.Windows.Forms.ToolStripStatusLabel();
            tsslGridName = new System.Windows.Forms.ToolStripStatusLabel();
            tsslNumberOfGrids = new System.Windows.Forms.ToolStripStatusLabel();
            tsslSecondsLeft = new System.Windows.Forms.ToolStripStatusLabel();
            tsslNumberOfCameras = new System.Windows.Forms.ToolStripStatusLabel();
            tsslActiveEvent = new System.Windows.Forms.ToolStripStatusLabel();
            tsslUser = new System.Windows.Forms.ToolStripStatusLabel();
            tsslSpaceHolder2 = new System.Windows.Forms.ToolStripStatusLabel();
            tsslSequence0 = new System.Windows.Forms.ToolStripStatusLabel();
            tsbRearrangeGrid = new System.Windows.Forms.ToolStripButton();
            pEditor = new Mtf.Controls.MovablePanel();
            gbDisplays = new System.Windows.Forms.GroupBox();
            cbDisplays = new System.Windows.Forms.ComboBox();
            gbTemplateGrids = new System.Windows.Forms.GroupBox();
            cbGrids = new System.Windows.Forms.ComboBox();
            btnTemplate12 = new System.Windows.Forms.Button();
            btnTemplate11 = new System.Windows.Forms.Button();
            btnTemplate10 = new System.Windows.Forms.Button();
            btnTemplate9 = new System.Windows.Forms.Button();
            btnTemplate8 = new System.Windows.Forms.Button();
            btnTemplate7 = new System.Windows.Forms.Button();
            btnTemplate6 = new System.Windows.Forms.Button();
            btnTemplate5 = new System.Windows.Forms.Button();
            btnTemplate4 = new System.Windows.Forms.Button();
            btnTemplate3 = new System.Windows.Forms.Button();
            btnTemplate2 = new System.Windows.Forms.Button();
            btnTemplate1 = new System.Windows.Forms.Button();
            gbCombine = new System.Windows.Forms.GroupBox();
            pMiniDesign = new Mtf.Controls.TransparentPanel();
            btnEastRight = new System.Windows.Forms.Button();
            btnEastLeft = new System.Windows.Forms.Button();
            btnWestRight = new System.Windows.Forms.Button();
            btnWestLeft = new System.Windows.Forms.Button();
            btnSouthDown = new System.Windows.Forms.Button();
            btnSouthUp = new System.Windows.Forms.Button();
            btnNorthDown = new System.Windows.Forms.Button();
            btnNorthUp = new System.Windows.Forms.Button();
            btnCombine = new System.Windows.Forms.Button();
            nudClosingRow = new System.Windows.Forms.NumericUpDown();
            nudClosingColumn = new System.Windows.Forms.NumericUpDown();
            lblClosingColoumn = new System.Windows.Forms.Label();
            lblClosingRow = new System.Windows.Forms.Label();
            nudInitialRow = new System.Windows.Forms.NumericUpDown();
            nudInitialColumn = new System.Windows.Forms.NumericUpDown();
            lblInitialColoumn = new System.Windows.Forms.Label();
            lblInitialRow = new System.Windows.Forms.Label();
            gbAuxiliaryGrid = new System.Windows.Forms.GroupBox();
            btn16_10_FixedRight = new System.Windows.Forms.Button();
            btn16_9_FixedRight = new System.Windows.Forms.Button();
            btn4_3_FixedRight = new System.Windows.Forms.Button();
            btn16_10 = new System.Windows.Forms.Button();
            btn16_9 = new System.Windows.Forms.Button();
            btn4_3 = new System.Windows.Forms.Button();
            nudPixelsFromBottom = new System.Windows.Forms.NumericUpDown();
            lblPixelsFromBottom = new System.Windows.Forms.Label();
            nudPixelsFromRight = new System.Windows.Forms.NumericUpDown();
            lblPixelsFromRight = new System.Windows.Forms.Label();
            nudNumberOfRows = new System.Windows.Forms.NumericUpDown();
            nudNumberOfColumns = new System.Windows.Forms.NumericUpDown();
            lblColumns = new System.Windows.Forms.Label();
            lblRows = new System.Windows.Forms.Label();
            gbProperties = new System.Windows.Forms.GroupBox();
            chkCreateSequence = new System.Windows.Forms.CheckBox();
            chkConnectToCamera = new System.Windows.Forms.CheckBox();
            tbGridName = new System.Windows.Forms.TextBox();
            lblGridName = new System.Windows.Forms.Label();
            btnSave = new System.Windows.Forms.Button();
            btnClose = new System.Windows.Forms.Button();
            pMain.SuspendLayout();
            ssStatusStrip.SuspendLayout();
            pEditor.SuspendLayout();
            gbDisplays.SuspendLayout();
            gbTemplateGrids.SuspendLayout();
            gbCombine.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudClosingRow).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudClosingColumn).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudInitialRow).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudInitialColumn).BeginInit();
            gbAuxiliaryGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudPixelsFromBottom).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudPixelsFromRight).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudNumberOfRows).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudNumberOfColumns).BeginInit();
            gbProperties.SuspendLayout();
            SuspendLayout();
            // 
            // pMain
            // 
            pMain.BackColor = System.Drawing.Color.Gray;
            pMain.Controls.Add(axVideoPlayerWindow);
            pMain.Controls.Add(ssStatusStrip);
            pMain.Controls.Add(pEditor);
            pMain.Dock = System.Windows.Forms.DockStyle.Fill;
            pMain.Location = new System.Drawing.Point(0, 0);
            pMain.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pMain.Name = "pMain";
            pMain.Size = new System.Drawing.Size(742, 835);
            pMain.TabIndex = 0;
            pMain.Paint += PMain_Paint;
            // 
            // axVideoPlayerWindow
            // 
            axVideoPlayerWindow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            axVideoPlayerWindow.Location = new System.Drawing.Point(220, 12);
            axVideoPlayerWindow.Name = "axVideoPlayerWindow";
            axVideoPlayerWindow.OverlayFont = (System.Drawing.Font)resources.GetObject("axVideoPlayerWindow.OverlayFont");
            axVideoPlayerWindow.OverlayLocation = new System.Drawing.Point(10, 10);
            axVideoPlayerWindow.OverlayText = "";
            axVideoPlayerWindow.Size = new System.Drawing.Size(114, 76);
            axVideoPlayerWindow.TabIndex = 7;
            axVideoPlayerWindow.Visible = false;
            // 
            // ssStatusStrip
            // 
            ssStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { tsbPrevious, tsbPlayOrPause, tsbNext, tsslSpaceHolder, tsslSequence, tsslGridName, tsslNumberOfGrids, tsslSecondsLeft, tsslNumberOfCameras, tsslActiveEvent, tsslUser, tsslSpaceHolder2, tsslSequence0, tsbRearrangeGrid });
            ssStatusStrip.Location = new System.Drawing.Point(0, 813);
            ssStatusStrip.Name = "ssStatusStrip";
            ssStatusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            ssStatusStrip.Size = new System.Drawing.Size(742, 22);
            ssStatusStrip.TabIndex = 6;
            ssStatusStrip.Text = "statusStrip1";
            // 
            // tsbPrevious
            // 
            tsbPrevious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            tsbPrevious.ImageTransparentColor = System.Drawing.Color.Magenta;
            tsbPrevious.Name = "tsbPrevious";
            tsbPrevious.Size = new System.Drawing.Size(23, 20);
            tsbPrevious.Text = "Previous";
            // 
            // tsbPlayOrPause
            // 
            tsbPlayOrPause.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            tsbPlayOrPause.ImageTransparentColor = System.Drawing.Color.Magenta;
            tsbPlayOrPause.Name = "tsbPlayOrPause";
            tsbPlayOrPause.Size = new System.Drawing.Size(23, 20);
            tsbPlayOrPause.Text = "PlayOrPause";
            // 
            // tsbNext
            // 
            tsbNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            tsbNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            tsbNext.Name = "tsbNext";
            tsbNext.Size = new System.Drawing.Size(23, 20);
            tsbNext.Text = "Next";
            // 
            // tsslSpaceHolder
            // 
            tsslSpaceHolder.Name = "tsslSpaceHolder";
            tsslSpaceHolder.Size = new System.Drawing.Size(304, 17);
            tsslSpaceHolder.Spring = true;
            // 
            // tsslSequence
            // 
            tsslSequence.Name = "tsslSequence";
            tsslSequence.Size = new System.Drawing.Size(0, 17);
            // 
            // tsslGridName
            // 
            tsslGridName.Name = "tsslGridName";
            tsslGridName.Size = new System.Drawing.Size(0, 17);
            // 
            // tsslNumberOfGrids
            // 
            tsslNumberOfGrids.Name = "tsslNumberOfGrids";
            tsslNumberOfGrids.Size = new System.Drawing.Size(24, 17);
            tsslNumberOfGrids.Text = "1/1";
            // 
            // tsslSecondsLeft
            // 
            tsslSecondsLeft.Name = "tsslSecondsLeft";
            tsslSecondsLeft.Size = new System.Drawing.Size(0, 17);
            // 
            // tsslNumberOfCameras
            // 
            tsslNumberOfCameras.Name = "tsslNumberOfCameras";
            tsslNumberOfCameras.Size = new System.Drawing.Size(0, 17);
            // 
            // tsslActiveEvent
            // 
            tsslActiveEvent.Name = "tsslActiveEvent";
            tsslActiveEvent.Size = new System.Drawing.Size(74, 17);
            tsslActiveEvent.Text = "Active_event";
            tsslActiveEvent.Visible = false;
            // 
            // tsslUser
            // 
            tsslUser.Name = "tsslUser";
            tsslUser.Size = new System.Drawing.Size(30, 17);
            tsslUser.Text = "User";
            tsslUser.Visible = false;
            // 
            // tsslSpaceHolder2
            // 
            tsslSpaceHolder2.Name = "tsslSpaceHolder2";
            tsslSpaceHolder2.Size = new System.Drawing.Size(304, 17);
            tsslSpaceHolder2.Spring = true;
            // 
            // tsslSequence0
            // 
            tsslSequence0.Name = "tsslSequence0";
            tsslSequence0.Size = new System.Drawing.Size(0, 17);
            // 
            // tsbRearrangeGrid
            // 
            tsbRearrangeGrid.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            tsbRearrangeGrid.ImageTransparentColor = System.Drawing.Color.Magenta;
            tsbRearrangeGrid.Name = "tsbRearrangeGrid";
            tsbRearrangeGrid.Size = new System.Drawing.Size(23, 20);
            // 
            // pEditor
            // 
            pEditor.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            pEditor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            pEditor.CanMove = true;
            pEditor.Controls.Add(gbDisplays);
            pEditor.Controls.Add(gbTemplateGrids);
            pEditor.Controls.Add(gbCombine);
            pEditor.Controls.Add(gbAuxiliaryGrid);
            pEditor.Controls.Add(gbProperties);
            pEditor.Controls.Add(btnSave);
            pEditor.Controls.Add(btnClose);
            pEditor.Cursor = System.Windows.Forms.Cursors.NoMove2D;
            pEditor.Location = new System.Drawing.Point(13, 2);
            pEditor.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pEditor.Name = "pEditor";
            pEditor.Size = new System.Drawing.Size(200, 821);
            pEditor.TabIndex = 4;
            pEditor.TransparentColor = System.Drawing.Color.Black;
            pEditor.UseTransparentColor = false;
            pEditor.LocationChanged += PEditor_LocationChanged;
            pEditor.Resize += PEditor_Resize;
            // 
            // gbDisplays
            // 
            gbDisplays.BackColor = System.Drawing.SystemColors.Control;
            gbDisplays.Controls.Add(cbDisplays);
            gbDisplays.Location = new System.Drawing.Point(7, 3);
            gbDisplays.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbDisplays.Name = "gbDisplays";
            gbDisplays.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbDisplays.Size = new System.Drawing.Size(182, 58);
            gbDisplays.TabIndex = 0;
            gbDisplays.TabStop = false;
            gbDisplays.Text = "Display";
            // 
            // cbDisplays
            // 
            cbDisplays.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbDisplays.FormattingEnabled = true;
            cbDisplays.Location = new System.Drawing.Point(10, 22);
            cbDisplays.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cbDisplays.Name = "cbDisplays";
            cbDisplays.Size = new System.Drawing.Size(164, 23);
            cbDisplays.TabIndex = 0;
            cbDisplays.SelectedIndexChanged += CbDisplays_SelectedIndexChanged;
            // 
            // gbTemplateGrids
            // 
            gbTemplateGrids.BackColor = System.Drawing.SystemColors.Control;
            gbTemplateGrids.Controls.Add(cbGrids);
            gbTemplateGrids.Controls.Add(btnTemplate12);
            gbTemplateGrids.Controls.Add(btnTemplate11);
            gbTemplateGrids.Controls.Add(btnTemplate10);
            gbTemplateGrids.Controls.Add(btnTemplate9);
            gbTemplateGrids.Controls.Add(btnTemplate8);
            gbTemplateGrids.Controls.Add(btnTemplate7);
            gbTemplateGrids.Controls.Add(btnTemplate6);
            gbTemplateGrids.Controls.Add(btnTemplate5);
            gbTemplateGrids.Controls.Add(btnTemplate4);
            gbTemplateGrids.Controls.Add(btnTemplate3);
            gbTemplateGrids.Controls.Add(btnTemplate2);
            gbTemplateGrids.Controls.Add(btnTemplate1);
            gbTemplateGrids.Location = new System.Drawing.Point(7, 66);
            gbTemplateGrids.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbTemplateGrids.Name = "gbTemplateGrids";
            gbTemplateGrids.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbTemplateGrids.Size = new System.Drawing.Size(182, 150);
            gbTemplateGrids.TabIndex = 1;
            gbTemplateGrids.TabStop = false;
            gbTemplateGrids.Text = "Template grids";
            // 
            // cbGrids
            // 
            cbGrids.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbGrids.FormattingEnabled = true;
            cbGrids.Location = new System.Drawing.Point(10, 118);
            cbGrids.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cbGrids.Name = "cbGrids";
            cbGrids.Size = new System.Drawing.Size(164, 23);
            cbGrids.TabIndex = 12;
            cbGrids.SelectedIndexChanged += CbGrids_SelectedIndexChanged;
            // 
            // btnTemplate12
            // 
            btnTemplate12.Image = Properties.Resources._64;
            btnTemplate12.Location = new System.Drawing.Point(131, 84);
            btnTemplate12.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnTemplate12.Name = "btnTemplate12";
            btnTemplate12.Size = new System.Drawing.Size(30, 27);
            btnTemplate12.TabIndex = 11;
            btnTemplate12.UseVisualStyleBackColor = true;
            btnTemplate12.Click += BtnTemplate12_Click;
            // 
            // btnTemplate11
            // 
            btnTemplate11.Image = Properties.Resources._49;
            btnTemplate11.Location = new System.Drawing.Point(93, 84);
            btnTemplate11.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnTemplate11.Name = "btnTemplate11";
            btnTemplate11.Size = new System.Drawing.Size(30, 27);
            btnTemplate11.TabIndex = 10;
            btnTemplate11.UseVisualStyleBackColor = true;
            btnTemplate11.Click += BtnTemplate11_Click;
            // 
            // btnTemplate10
            // 
            btnTemplate10.Image = Properties.Resources._36;
            btnTemplate10.Location = new System.Drawing.Point(56, 84);
            btnTemplate10.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnTemplate10.Name = "btnTemplate10";
            btnTemplate10.Size = new System.Drawing.Size(30, 27);
            btnTemplate10.TabIndex = 9;
            btnTemplate10.UseVisualStyleBackColor = true;
            btnTemplate10.Click += BtnTemplate10_Click;
            // 
            // btnTemplate9
            // 
            btnTemplate9.Image = Properties.Resources._25;
            btnTemplate9.Location = new System.Drawing.Point(19, 84);
            btnTemplate9.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnTemplate9.Name = "btnTemplate9";
            btnTemplate9.Size = new System.Drawing.Size(30, 27);
            btnTemplate9.TabIndex = 8;
            btnTemplate9.UseVisualStyleBackColor = true;
            btnTemplate9.Click += BtnTemplate9_Click;
            // 
            // btnTemplate8
            // 
            btnTemplate8.Image = Properties.Resources._16_way;
            btnTemplate8.Location = new System.Drawing.Point(131, 51);
            btnTemplate8.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnTemplate8.Name = "btnTemplate8";
            btnTemplate8.Size = new System.Drawing.Size(30, 27);
            btnTemplate8.TabIndex = 7;
            btnTemplate8.UseVisualStyleBackColor = true;
            btnTemplate8.Click += BtnTemplate8_Click;
            // 
            // btnTemplate7
            // 
            btnTemplate7.Image = Properties.Resources._10_way;
            btnTemplate7.Location = new System.Drawing.Point(93, 51);
            btnTemplate7.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnTemplate7.Name = "btnTemplate7";
            btnTemplate7.Size = new System.Drawing.Size(30, 27);
            btnTemplate7.TabIndex = 6;
            btnTemplate7.UseVisualStyleBackColor = true;
            btnTemplate7.Click += BtnTemplate7_Click;
            // 
            // btnTemplate6
            // 
            btnTemplate6.Image = Properties.Resources._9_way;
            btnTemplate6.Location = new System.Drawing.Point(56, 51);
            btnTemplate6.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnTemplate6.Name = "btnTemplate6";
            btnTemplate6.Size = new System.Drawing.Size(30, 27);
            btnTemplate6.TabIndex = 5;
            btnTemplate6.UseVisualStyleBackColor = true;
            btnTemplate6.Click += BtnTemplate6_Click;
            // 
            // btnTemplate5
            // 
            btnTemplate5.Image = Properties.Resources._8_way;
            btnTemplate5.Location = new System.Drawing.Point(19, 51);
            btnTemplate5.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnTemplate5.Name = "btnTemplate5";
            btnTemplate5.Size = new System.Drawing.Size(30, 27);
            btnTemplate5.TabIndex = 4;
            btnTemplate5.UseVisualStyleBackColor = true;
            btnTemplate5.Click += BtnTemplate5_Click;
            // 
            // btnTemplate4
            // 
            btnTemplate4.Image = Properties.Resources._7_way;
            btnTemplate4.Location = new System.Drawing.Point(131, 18);
            btnTemplate4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnTemplate4.Name = "btnTemplate4";
            btnTemplate4.Size = new System.Drawing.Size(30, 27);
            btnTemplate4.TabIndex = 3;
            btnTemplate4.UseVisualStyleBackColor = true;
            btnTemplate4.Click += BtnTemplate4_Click;
            // 
            // btnTemplate3
            // 
            btnTemplate3.Image = Properties.Resources._6_way;
            btnTemplate3.Location = new System.Drawing.Point(93, 18);
            btnTemplate3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnTemplate3.Name = "btnTemplate3";
            btnTemplate3.Size = new System.Drawing.Size(30, 27);
            btnTemplate3.TabIndex = 2;
            btnTemplate3.UseVisualStyleBackColor = true;
            btnTemplate3.Click += BtnTemplate3_Click;
            // 
            // btnTemplate2
            // 
            btnTemplate2.Image = Properties.Resources._4_way;
            btnTemplate2.Location = new System.Drawing.Point(56, 18);
            btnTemplate2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnTemplate2.Name = "btnTemplate2";
            btnTemplate2.Size = new System.Drawing.Size(30, 27);
            btnTemplate2.TabIndex = 1;
            btnTemplate2.UseVisualStyleBackColor = true;
            btnTemplate2.Click += BtnTemplate2_Click;
            // 
            // btnTemplate1
            // 
            btnTemplate1.Image = Properties.Resources._1_way;
            btnTemplate1.Location = new System.Drawing.Point(19, 18);
            btnTemplate1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnTemplate1.Name = "btnTemplate1";
            btnTemplate1.Size = new System.Drawing.Size(30, 27);
            btnTemplate1.TabIndex = 0;
            btnTemplate1.UseVisualStyleBackColor = true;
            btnTemplate1.Click += BtnTemplate1_Click;
            // 
            // gbCombine
            // 
            gbCombine.BackColor = System.Drawing.SystemColors.Control;
            gbCombine.Controls.Add(pMiniDesign);
            gbCombine.Controls.Add(btnEastRight);
            gbCombine.Controls.Add(btnEastLeft);
            gbCombine.Controls.Add(btnWestRight);
            gbCombine.Controls.Add(btnWestLeft);
            gbCombine.Controls.Add(btnSouthDown);
            gbCombine.Controls.Add(btnSouthUp);
            gbCombine.Controls.Add(btnNorthDown);
            gbCombine.Controls.Add(btnNorthUp);
            gbCombine.Controls.Add(btnCombine);
            gbCombine.Controls.Add(nudClosingRow);
            gbCombine.Controls.Add(nudClosingColumn);
            gbCombine.Controls.Add(lblClosingColoumn);
            gbCombine.Controls.Add(lblClosingRow);
            gbCombine.Controls.Add(nudInitialRow);
            gbCombine.Controls.Add(nudInitialColumn);
            gbCombine.Controls.Add(lblInitialColoumn);
            gbCombine.Controls.Add(lblInitialRow);
            gbCombine.Location = new System.Drawing.Point(7, 555);
            gbCombine.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbCombine.Name = "gbCombine";
            gbCombine.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbCombine.Size = new System.Drawing.Size(182, 226);
            gbCombine.TabIndex = 4;
            gbCombine.TabStop = false;
            gbCombine.Text = "Combine";
            // 
            // pMiniDesign
            // 
            pMiniDesign.Location = new System.Drawing.Point(45, 60);
            pMiniDesign.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pMiniDesign.Name = "pMiniDesign";
            pMiniDesign.Size = new System.Drawing.Size(92, 92);
            pMiniDesign.TabIndex = 16;
            pMiniDesign.TransparentColor = System.Drawing.Color.Black;
            pMiniDesign.UseTransparentColor = false;
            pMiniDesign.Paint += MiniDesign_Paint;
            // 
            // btnEastRight
            // 
            btnEastRight.Image = Properties.Resources.arrow_right;
            btnEastRight.Location = new System.Drawing.Point(145, 105);
            btnEastRight.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnEastRight.Name = "btnEastRight";
            btnEastRight.Size = new System.Drawing.Size(28, 27);
            btnEastRight.TabIndex = 9;
            btnEastRight.UseVisualStyleBackColor = true;
            btnEastRight.Click += BtnEastRight_Click;
            // 
            // btnEastLeft
            // 
            btnEastLeft.Image = Properties.Resources.arrow_left;
            btnEastLeft.Location = new System.Drawing.Point(145, 72);
            btnEastLeft.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnEastLeft.Name = "btnEastLeft";
            btnEastLeft.Size = new System.Drawing.Size(28, 27);
            btnEastLeft.TabIndex = 7;
            btnEastLeft.UseVisualStyleBackColor = true;
            btnEastLeft.Click += BtnEastLeft_Click;
            // 
            // btnWestRight
            // 
            btnWestRight.Image = Properties.Resources.arrow_right;
            btnWestRight.Location = new System.Drawing.Point(9, 105);
            btnWestRight.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnWestRight.Name = "btnWestRight";
            btnWestRight.Size = new System.Drawing.Size(28, 27);
            btnWestRight.TabIndex = 8;
            btnWestRight.UseVisualStyleBackColor = true;
            btnWestRight.Click += BtnWestRight_Click;
            // 
            // btnWestLeft
            // 
            btnWestLeft.Image = Properties.Resources.arrow_left;
            btnWestLeft.Location = new System.Drawing.Point(9, 72);
            btnWestLeft.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnWestLeft.Name = "btnWestLeft";
            btnWestLeft.Size = new System.Drawing.Size(28, 27);
            btnWestLeft.TabIndex = 6;
            btnWestLeft.UseVisualStyleBackColor = true;
            btnWestLeft.Click += BtnWestLeft_Click;
            // 
            // btnSouthDown
            // 
            btnSouthDown.Image = Properties.Resources.arrow_down;
            btnSouthDown.Location = new System.Drawing.Point(94, 158);
            btnSouthDown.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnSouthDown.Name = "btnSouthDown";
            btnSouthDown.Size = new System.Drawing.Size(28, 27);
            btnSouthDown.TabIndex = 15;
            btnSouthDown.UseVisualStyleBackColor = true;
            btnSouthDown.Click += BtnSouthDown_Click;
            // 
            // btnSouthUp
            // 
            btnSouthUp.Image = Properties.Resources.arrow_up;
            btnSouthUp.Location = new System.Drawing.Point(59, 158);
            btnSouthUp.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnSouthUp.Name = "btnSouthUp";
            btnSouthUp.Size = new System.Drawing.Size(28, 27);
            btnSouthUp.TabIndex = 14;
            btnSouthUp.UseVisualStyleBackColor = true;
            btnSouthUp.Click += BtnSouthUp_Click;
            // 
            // btnNorthDown
            // 
            btnNorthDown.Image = Properties.Resources.arrow_down;
            btnNorthDown.Location = new System.Drawing.Point(93, 27);
            btnNorthDown.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnNorthDown.Name = "btnNorthDown";
            btnNorthDown.Size = new System.Drawing.Size(28, 27);
            btnNorthDown.TabIndex = 5;
            btnNorthDown.UseVisualStyleBackColor = true;
            btnNorthDown.Click += BtnNorthDown_Click;
            // 
            // btnNorthUp
            // 
            btnNorthUp.Image = Properties.Resources.arrow_up;
            btnNorthUp.Location = new System.Drawing.Point(58, 27);
            btnNorthUp.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnNorthUp.Name = "btnNorthUp";
            btnNorthUp.Size = new System.Drawing.Size(28, 27);
            btnNorthUp.TabIndex = 4;
            btnNorthUp.UseVisualStyleBackColor = true;
            btnNorthUp.Click += BtnNorthUp_Click;
            // 
            // btnCombine
            // 
            btnCombine.Location = new System.Drawing.Point(10, 190);
            btnCombine.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnCombine.Name = "btnCombine";
            btnCombine.Size = new System.Drawing.Size(164, 27);
            btnCombine.TabIndex = 17;
            btnCombine.Text = "Combine";
            btnCombine.UseVisualStyleBackColor = true;
            btnCombine.Click += BtnCombine_Click;
            // 
            // nudClosingRow
            // 
            nudClosingRow.Location = new System.Drawing.Point(118, 39);
            nudClosingRow.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            nudClosingRow.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nudClosingRow.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudClosingRow.Name = "nudClosingRow";
            nudClosingRow.Size = new System.Drawing.Size(55, 23);
            nudClosingRow.TabIndex = 3;
            nudClosingRow.Value = new decimal(new int[] { 1, 0, 0, 0 });
            nudClosingRow.Visible = false;
            // 
            // nudClosingColumn
            // 
            nudClosingColumn.Location = new System.Drawing.Point(119, 170);
            nudClosingColumn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            nudClosingColumn.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nudClosingColumn.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudClosingColumn.Name = "nudClosingColumn";
            nudClosingColumn.Size = new System.Drawing.Size(55, 23);
            nudClosingColumn.TabIndex = 13;
            nudClosingColumn.Value = new decimal(new int[] { 1, 0, 0, 0 });
            nudClosingColumn.Visible = false;
            // 
            // lblClosingColoumn
            // 
            lblClosingColoumn.AutoSize = true;
            lblClosingColoumn.Location = new System.Drawing.Point(9, 172);
            lblClosingColoumn.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblClosingColoumn.Name = "lblClosingColoumn";
            lblClosingColoumn.Size = new System.Drawing.Size(64, 15);
            lblClosingColoumn.TabIndex = 12;
            lblClosingColoumn.Text = "To column";
            lblClosingColoumn.Visible = false;
            // 
            // lblClosingRow
            // 
            lblClosingRow.AutoSize = true;
            lblClosingRow.Location = new System.Drawing.Point(5, 42);
            lblClosingRow.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblClosingRow.Name = "lblClosingRow";
            lblClosingRow.Size = new System.Drawing.Size(70, 15);
            lblClosingRow.TabIndex = 2;
            lblClosingRow.Text = "Closing row";
            lblClosingRow.Visible = false;
            // 
            // nudInitialRow
            // 
            nudInitialRow.Location = new System.Drawing.Point(118, 16);
            nudInitialRow.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            nudInitialRow.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nudInitialRow.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudInitialRow.Name = "nudInitialRow";
            nudInitialRow.Size = new System.Drawing.Size(55, 23);
            nudInitialRow.TabIndex = 1;
            nudInitialRow.Value = new decimal(new int[] { 1, 0, 0, 0 });
            nudInitialRow.Visible = false;
            // 
            // nudInitialColumn
            // 
            nudInitialColumn.Location = new System.Drawing.Point(119, 145);
            nudInitialColumn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            nudInitialColumn.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nudInitialColumn.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudInitialColumn.Name = "nudInitialColumn";
            nudInitialColumn.Size = new System.Drawing.Size(55, 23);
            nudInitialColumn.TabIndex = 11;
            nudInitialColumn.Value = new decimal(new int[] { 1, 0, 0, 0 });
            nudInitialColumn.Visible = false;
            // 
            // lblInitialColoumn
            // 
            lblInitialColoumn.AutoSize = true;
            lblInitialColoumn.Location = new System.Drawing.Point(10, 148);
            lblInitialColoumn.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblInitialColoumn.Name = "lblInitialColoumn";
            lblInitialColoumn.Size = new System.Drawing.Size(87, 15);
            lblInitialColoumn.TabIndex = 10;
            lblInitialColoumn.Text = "Initial coloumn";
            lblInitialColoumn.Visible = false;
            // 
            // lblInitialRow
            // 
            lblInitialRow.AutoSize = true;
            lblInitialRow.Location = new System.Drawing.Point(7, 18);
            lblInitialRow.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblInitialRow.Name = "lblInitialRow";
            lblInitialRow.Size = new System.Drawing.Size(59, 15);
            lblInitialRow.TabIndex = 0;
            lblInitialRow.Text = "Initial row";
            lblInitialRow.Visible = false;
            // 
            // gbAuxiliaryGrid
            // 
            gbAuxiliaryGrid.BackColor = System.Drawing.SystemColors.Control;
            gbAuxiliaryGrid.Controls.Add(btn16_10_FixedRight);
            gbAuxiliaryGrid.Controls.Add(btn16_9_FixedRight);
            gbAuxiliaryGrid.Controls.Add(btn4_3_FixedRight);
            gbAuxiliaryGrid.Controls.Add(btn16_10);
            gbAuxiliaryGrid.Controls.Add(btn16_9);
            gbAuxiliaryGrid.Controls.Add(btn4_3);
            gbAuxiliaryGrid.Controls.Add(nudPixelsFromBottom);
            gbAuxiliaryGrid.Controls.Add(lblPixelsFromBottom);
            gbAuxiliaryGrid.Controls.Add(nudPixelsFromRight);
            gbAuxiliaryGrid.Controls.Add(lblPixelsFromRight);
            gbAuxiliaryGrid.Controls.Add(nudNumberOfRows);
            gbAuxiliaryGrid.Controls.Add(nudNumberOfColumns);
            gbAuxiliaryGrid.Controls.Add(lblColumns);
            gbAuxiliaryGrid.Controls.Add(lblRows);
            gbAuxiliaryGrid.Location = new System.Drawing.Point(7, 344);
            gbAuxiliaryGrid.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbAuxiliaryGrid.Name = "gbAuxiliaryGrid";
            gbAuxiliaryGrid.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbAuxiliaryGrid.Size = new System.Drawing.Size(182, 207);
            gbAuxiliaryGrid.TabIndex = 3;
            gbAuxiliaryGrid.TabStop = false;
            gbAuxiliaryGrid.Text = "Auxiliary grid";
            // 
            // btn16_10_FixedRight
            // 
            btn16_10_FixedRight.Image = Properties.Resources._16_10;
            btn16_10_FixedRight.Location = new System.Drawing.Point(148, 102);
            btn16_10_FixedRight.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn16_10_FixedRight.Name = "btn16_10_FixedRight";
            btn16_10_FixedRight.Size = new System.Drawing.Size(28, 20);
            btn16_10_FixedRight.TabIndex = 13;
            btn16_10_FixedRight.UseVisualStyleBackColor = true;
            btn16_10_FixedRight.Click += Btn16_10_FixedRight_Click;
            // 
            // btn16_9_FixedRight
            // 
            btn16_9_FixedRight.Image = Properties.Resources._16_9;
            btn16_9_FixedRight.Location = new System.Drawing.Point(118, 102);
            btn16_9_FixedRight.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn16_9_FixedRight.Name = "btn16_9_FixedRight";
            btn16_9_FixedRight.Size = new System.Drawing.Size(26, 20);
            btn16_9_FixedRight.TabIndex = 12;
            btn16_9_FixedRight.UseVisualStyleBackColor = true;
            btn16_9_FixedRight.Click += Btn16_9_FixedRight_Click;
            // 
            // btn4_3_FixedRight
            // 
            btn4_3_FixedRight.Image = Properties.Resources._4_3;
            btn4_3_FixedRight.Location = new System.Drawing.Point(88, 102);
            btn4_3_FixedRight.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn4_3_FixedRight.Name = "btn4_3_FixedRight";
            btn4_3_FixedRight.Size = new System.Drawing.Size(26, 20);
            btn4_3_FixedRight.TabIndex = 11;
            btn4_3_FixedRight.UseVisualStyleBackColor = true;
            btn4_3_FixedRight.Click += Btn4_3_FixedRight_Click;
            // 
            // btn16_10
            // 
            btn16_10.Image = Properties.Resources._16_10;
            btn16_10.Location = new System.Drawing.Point(148, 173);
            btn16_10.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn16_10.Name = "btn16_10";
            btn16_10.Size = new System.Drawing.Size(28, 20);
            btn16_10.TabIndex = 8;
            btn16_10.UseVisualStyleBackColor = true;
            btn16_10.Click += Btn16_10_Click;
            // 
            // btn16_9
            // 
            btn16_9.Image = Properties.Resources._16_9;
            btn16_9.Location = new System.Drawing.Point(118, 173);
            btn16_9.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn16_9.Name = "btn16_9";
            btn16_9.Size = new System.Drawing.Size(26, 20);
            btn16_9.TabIndex = 7;
            btn16_9.UseVisualStyleBackColor = true;
            btn16_9.Click += Btn16_9_Click;
            // 
            // btn4_3
            // 
            btn4_3.Image = Properties.Resources._4_3;
            btn4_3.Location = new System.Drawing.Point(88, 173);
            btn4_3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn4_3.Name = "btn4_3";
            btn4_3.Size = new System.Drawing.Size(26, 20);
            btn4_3.TabIndex = 6;
            btn4_3.UseVisualStyleBackColor = true;
            btn4_3.Click += Btn4_3_Click;
            // 
            // nudPixelsFromBottom
            // 
            nudPixelsFromBottom.Location = new System.Drawing.Point(10, 172);
            nudPixelsFromBottom.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            nudPixelsFromBottom.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            nudPixelsFromBottom.Name = "nudPixelsFromBottom";
            nudPixelsFromBottom.Size = new System.Drawing.Size(70, 23);
            nudPixelsFromBottom.TabIndex = 10;
            nudPixelsFromBottom.ValueChanged += NudPixelsFromBottom_ValueChanged;
            // 
            // lblPixelsFromBottom
            // 
            lblPixelsFromBottom.AutoSize = true;
            lblPixelsFromBottom.Location = new System.Drawing.Point(7, 153);
            lblPixelsFromBottom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblPixelsFromBottom.Name = "lblPixelsFromBottom";
            lblPixelsFromBottom.Size = new System.Drawing.Size(163, 15);
            lblPixelsFromBottom.TabIndex = 9;
            lblPixelsFromBottom.Text = "Pixels cropped on the bottom";
            // 
            // nudPixelsFromRight
            // 
            nudPixelsFromRight.Location = new System.Drawing.Point(10, 102);
            nudPixelsFromRight.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            nudPixelsFromRight.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            nudPixelsFromRight.Name = "nudPixelsFromRight";
            nudPixelsFromRight.Size = new System.Drawing.Size(70, 23);
            nudPixelsFromRight.TabIndex = 5;
            nudPixelsFromRight.ValueChanged += NudPixelsFromRight_ValueChanged;
            // 
            // lblPixelsFromRight
            // 
            lblPixelsFromRight.AutoSize = true;
            lblPixelsFromRight.Location = new System.Drawing.Point(7, 83);
            lblPixelsFromRight.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblPixelsFromRight.Name = "lblPixelsFromRight";
            lblPixelsFromRight.Size = new System.Drawing.Size(148, 15);
            lblPixelsFromRight.TabIndex = 4;
            lblPixelsFromRight.Text = "Pixels cropped on the right";
            // 
            // nudNumberOfRows
            // 
            nudNumberOfRows.Location = new System.Drawing.Point(92, 16);
            nudNumberOfRows.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            nudNumberOfRows.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nudNumberOfRows.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudNumberOfRows.Name = "nudNumberOfRows";
            nudNumberOfRows.Size = new System.Drawing.Size(83, 23);
            nudNumberOfRows.TabIndex = 1;
            nudNumberOfRows.Value = new decimal(new int[] { 1, 0, 0, 0 });
            nudNumberOfRows.ValueChanged += NudNumberOfRows_ValueChanged;
            // 
            // nudNumberOfColumns
            // 
            nudNumberOfColumns.Location = new System.Drawing.Point(92, 46);
            nudNumberOfColumns.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            nudNumberOfColumns.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nudNumberOfColumns.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudNumberOfColumns.Name = "nudNumberOfColumns";
            nudNumberOfColumns.Size = new System.Drawing.Size(83, 23);
            nudNumberOfColumns.TabIndex = 3;
            nudNumberOfColumns.Value = new decimal(new int[] { 1, 0, 0, 0 });
            nudNumberOfColumns.ValueChanged += NudNumberOfColumns_ValueChanged;
            // 
            // lblColumns
            // 
            lblColumns.AutoSize = true;
            lblColumns.Location = new System.Drawing.Point(8, 48);
            lblColumns.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblColumns.Name = "lblColumns";
            lblColumns.Size = new System.Drawing.Size(55, 15);
            lblColumns.TabIndex = 2;
            lblColumns.Text = "Columns";
            // 
            // lblRows
            // 
            lblRows.AutoSize = true;
            lblRows.Location = new System.Drawing.Point(7, 18);
            lblRows.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblRows.Name = "lblRows";
            lblRows.Size = new System.Drawing.Size(35, 15);
            lblRows.TabIndex = 0;
            lblRows.Text = "Rows";
            // 
            // gbProperties
            // 
            gbProperties.BackColor = System.Drawing.SystemColors.Control;
            gbProperties.Controls.Add(chkCreateSequence);
            gbProperties.Controls.Add(chkConnectToCamera);
            gbProperties.Controls.Add(tbGridName);
            gbProperties.Controls.Add(lblGridName);
            gbProperties.Location = new System.Drawing.Point(7, 220);
            gbProperties.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbProperties.Name = "gbProperties";
            gbProperties.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbProperties.Size = new System.Drawing.Size(182, 119);
            gbProperties.TabIndex = 2;
            gbProperties.TabStop = false;
            gbProperties.Text = "Properties";
            // 
            // chkCreateSequence
            // 
            chkCreateSequence.AutoSize = true;
            chkCreateSequence.Checked = true;
            chkCreateSequence.CheckState = System.Windows.Forms.CheckState.Checked;
            chkCreateSequence.Location = new System.Drawing.Point(7, 92);
            chkCreateSequence.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chkCreateSequence.Name = "chkCreateSequence";
            chkCreateSequence.Size = new System.Drawing.Size(143, 19);
            chkCreateSequence.TabIndex = 3;
            chkCreateSequence.Text = "Create a sequence too";
            chkCreateSequence.UseVisualStyleBackColor = true;
            // 
            // chkConnectToCamera
            // 
            chkConnectToCamera.AutoSize = true;
            chkConnectToCamera.Location = new System.Drawing.Point(7, 66);
            chkConnectToCamera.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chkConnectToCamera.Name = "chkConnectToCamera";
            chkConnectToCamera.Size = new System.Drawing.Size(127, 19);
            chkConnectToCamera.TabIndex = 2;
            chkConnectToCamera.Text = "Connect to camera";
            chkConnectToCamera.UseVisualStyleBackColor = true;
            // 
            // tbGridName
            // 
            tbGridName.Location = new System.Drawing.Point(7, 37);
            tbGridName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tbGridName.MaxLength = 50;
            tbGridName.Name = "tbGridName";
            tbGridName.Size = new System.Drawing.Size(167, 23);
            tbGridName.TabIndex = 1;
            // 
            // lblGridName
            // 
            lblGridName.AutoSize = true;
            lblGridName.Location = new System.Drawing.Point(6, 18);
            lblGridName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblGridName.Name = "lblGridName";
            lblGridName.Size = new System.Drawing.Size(39, 15);
            lblGridName.TabIndex = 0;
            lblGridName.Text = "Name";
            // 
            // btnSave
            // 
            btnSave.BackColor = System.Drawing.SystemColors.Control;
            btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            btnSave.Enabled = false;
            btnSave.Location = new System.Drawing.Point(7, 787);
            btnSave.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(88, 27);
            btnSave.TabIndex = 5;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += BtnSave_Click;
            // 
            // btnClose
            // 
            btnClose.BackColor = System.Drawing.SystemColors.Control;
            btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            btnClose.Location = new System.Drawing.Point(102, 787);
            btnClose.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnClose.Name = "btnClose";
            btnClose.Size = new System.Drawing.Size(88, 27);
            btnClose.TabIndex = 6;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += BtnClose_Click;
            // 
            // AddGrid
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(742, 835);
            Controls.Add(pMain);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "AddGrid";
            StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            Text = "New grid";
            Shown += AddGrid_Shown;
            pMain.ResumeLayout(false);
            pMain.PerformLayout();
            ssStatusStrip.ResumeLayout(false);
            ssStatusStrip.PerformLayout();
            pEditor.ResumeLayout(false);
            gbDisplays.ResumeLayout(false);
            gbTemplateGrids.ResumeLayout(false);
            gbCombine.ResumeLayout(false);
            gbCombine.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudClosingRow).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudClosingColumn).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudInitialRow).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudInitialColumn).EndInit();
            gbAuxiliaryGrid.ResumeLayout(false);
            gbAuxiliaryGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudPixelsFromBottom).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudPixelsFromRight).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudNumberOfRows).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudNumberOfColumns).EndInit();
            gbProperties.ResumeLayout(false);
            gbProperties.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pMain;
        private System.Windows.Forms.StatusStrip ssStatusStrip;
        private System.Windows.Forms.ToolStripButton tsbPrevious;
        private System.Windows.Forms.ToolStripButton tsbPlayOrPause;
        private System.Windows.Forms.ToolStripButton tsbNext;
        private System.Windows.Forms.ToolStripStatusLabel tsslSpaceHolder;
        private System.Windows.Forms.ToolStripStatusLabel tsslSequence;
        private System.Windows.Forms.ToolStripStatusLabel tsslGridName;
        private System.Windows.Forms.ToolStripStatusLabel tsslNumberOfGrids;
        private System.Windows.Forms.ToolStripStatusLabel tsslSecondsLeft;
        private System.Windows.Forms.ToolStripStatusLabel tsslNumberOfCameras;
        private System.Windows.Forms.ToolStripStatusLabel tsslActiveEvent;
        private System.Windows.Forms.ToolStripStatusLabel tsslUser;
        private System.Windows.Forms.ToolStripStatusLabel tsslSpaceHolder2;
        private System.Windows.Forms.ToolStripStatusLabel tsslSequence0;
        private System.Windows.Forms.ToolStripButton tsbRearrangeGrid;
        private Mtf.Controls.MovablePanel pEditor;
        private System.Windows.Forms.GroupBox gbDisplays;
        private System.Windows.Forms.ComboBox cbDisplays;
        private System.Windows.Forms.GroupBox gbTemplateGrids;
        private System.Windows.Forms.ComboBox cbGrids;
        private System.Windows.Forms.Button btnTemplate12;
        private System.Windows.Forms.Button btnTemplate11;
        private System.Windows.Forms.Button btnTemplate10;
        private System.Windows.Forms.Button btnTemplate9;
        private System.Windows.Forms.Button btnTemplate8;
        private System.Windows.Forms.Button btnTemplate7;
        private System.Windows.Forms.Button btnTemplate6;
        private System.Windows.Forms.Button btnTemplate5;
        private System.Windows.Forms.Button btnTemplate4;
        private System.Windows.Forms.Button btnTemplate3;
        private System.Windows.Forms.Button btnTemplate2;
        private System.Windows.Forms.Button btnTemplate1;
        private System.Windows.Forms.GroupBox gbCombine;
        private Mtf.Controls.TransparentPanel pMiniDesign;
        private System.Windows.Forms.Button btnEastRight;
        private System.Windows.Forms.Button btnEastLeft;
        private System.Windows.Forms.Button btnWestRight;
        private System.Windows.Forms.Button btnWestLeft;
        private System.Windows.Forms.Button btnSouthDown;
        private System.Windows.Forms.Button btnSouthUp;
        private System.Windows.Forms.Button btnNorthDown;
        private System.Windows.Forms.Button btnNorthUp;
        private System.Windows.Forms.Button btnCombine;
        private System.Windows.Forms.NumericUpDown nudClosingRow;
        private System.Windows.Forms.NumericUpDown nudClosingColumn;
        private System.Windows.Forms.Label lblClosingColoumn;
        private System.Windows.Forms.Label lblClosingRow;
        private System.Windows.Forms.NumericUpDown nudInitialRow;
        private System.Windows.Forms.NumericUpDown nudInitialColumn;
        private System.Windows.Forms.Label lblInitialColoumn;
        private System.Windows.Forms.Label lblInitialRow;
        private System.Windows.Forms.GroupBox gbAuxiliaryGrid;
        private System.Windows.Forms.Button btn16_10_FixedRight;
        private System.Windows.Forms.Button btn16_9_FixedRight;
        private System.Windows.Forms.Button btn4_3_FixedRight;
        private System.Windows.Forms.Button btn16_10;
        private System.Windows.Forms.Button btn16_9;
        private System.Windows.Forms.Button btn4_3;
        private System.Windows.Forms.NumericUpDown nudPixelsFromBottom;
        private System.Windows.Forms.Label lblPixelsFromBottom;
        private System.Windows.Forms.NumericUpDown nudPixelsFromRight;
        private System.Windows.Forms.Label lblPixelsFromRight;
        private System.Windows.Forms.NumericUpDown nudNumberOfRows;
        private System.Windows.Forms.NumericUpDown nudNumberOfColumns;
        private System.Windows.Forms.Label lblColumns;
        private System.Windows.Forms.Label lblRows;
        private System.Windows.Forms.GroupBox gbProperties;
        private System.Windows.Forms.CheckBox chkCreateSequence;
        private System.Windows.Forms.CheckBox chkConnectToCamera;
        private System.Windows.Forms.TextBox tbGridName;
        private System.Windows.Forms.Label lblGridName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private Mtf.Controls.x86.AxVideoPlayerWindow axVideoPlayerWindow;
    }
}