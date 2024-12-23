namespace LiveView.Forms
{
    partial class LogViewer
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(LogViewer));
            chkMaximumRows = new System.Windows.Forms.CheckBox();
            gbLogType = new System.Windows.Forms.GroupBox();
            rbOperations = new System.Windows.Forms.RadioButton();
            rbErrors = new System.Windows.Forms.RadioButton();
            rbEvents = new System.Windows.Forms.RadioButton();
            rbAll = new System.Windows.Forms.RadioButton();
            chkDates = new System.Windows.Forms.CheckBox();
            lblToMinutes = new System.Windows.Forms.Label();
            lblFromMinutes = new System.Windows.Forms.Label();
            lblToHour = new System.Windows.Forms.Label();
            lblFromHour = new System.Windows.Forms.Label();
            nudToMinutes = new System.Windows.Forms.NumericUpDown();
            nudToHour = new System.Windows.Forms.NumericUpDown();
            nudFromMinutes = new System.Windows.Forms.NumericUpDown();
            nudFromHour = new System.Windows.Forms.NumericUpDown();
            nudMaximumRows = new System.Windows.Forms.NumericUpDown();
            btnClose = new System.Windows.Forms.Button();
            btnGetLogs = new System.Windows.Forms.Button();
            gbOperations = new System.Windows.Forms.GroupBox();
            lvOperationsEventsAndErrors = new Mtf.Controls.MtfListView();
            chKind = new System.Windows.Forms.ColumnHeader();
            chDate = new System.Windows.Forms.ColumnHeader();
            chUser = new System.Windows.Forms.ColumnHeader();
            chOperationEventOrError = new System.Windows.Forms.ColumnHeader();
            chDescription = new System.Windows.Forms.ColumnHeader();
            chOtherInformation = new System.Windows.Forms.ColumnHeader();
            cmsMenu = new System.Windows.Forms.ContextMenuStrip(components);
            tsmiCopyToClipboard = new System.Windows.Forms.ToolStripMenuItem();
            ilImages = new System.Windows.Forms.ImageList(components);
            dtpTo = new System.Windows.Forms.DateTimePicker();
            pMain = new System.Windows.Forms.Panel();
            lblResults = new System.Windows.Forms.Label();
            lblResultsFound = new System.Windows.Forms.Label();
            gbMessageFilter = new System.Windows.Forms.GroupBox();
            lblOtherInformation = new System.Windows.Forms.Label();
            tbOtherInformation = new System.Windows.Forms.TextBox();
            cbMessageFilter = new System.Windows.Forms.CheckBox();
            cbMessage = new System.Windows.Forms.ComboBox();
            lblMessage = new System.Windows.Forms.Label();
            btnDeleteAllLogs = new System.Windows.Forms.Button();
            gbDates = new System.Windows.Forms.GroupBox();
            dtpFrom = new System.Windows.Forms.DateTimePicker();
            lblTo = new System.Windows.Forms.Label();
            lblFrom = new System.Windows.Forms.Label();
            gbMaximumRows = new System.Windows.Forms.GroupBox();
            gbLogType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudToMinutes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudToHour).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudFromMinutes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudFromHour).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudMaximumRows).BeginInit();
            gbOperations.SuspendLayout();
            cmsMenu.SuspendLayout();
            pMain.SuspendLayout();
            gbMessageFilter.SuspendLayout();
            gbDates.SuspendLayout();
            gbMaximumRows.SuspendLayout();
            SuspendLayout();
            // 
            // chkMaximumRows
            // 
            chkMaximumRows.AutoSize = true;
            chkMaximumRows.Checked = true;
            chkMaximumRows.CheckState = System.Windows.Forms.CheckState.Checked;
            chkMaximumRows.Location = new System.Drawing.Point(13, -1);
            chkMaximumRows.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chkMaximumRows.Name = "chkMaximumRows";
            chkMaximumRows.Size = new System.Drawing.Size(108, 19);
            chkMaximumRows.TabIndex = 1;
            chkMaximumRows.Text = "Maximum rows";
            chkMaximumRows.UseVisualStyleBackColor = true;
            // 
            // gbLogType
            // 
            gbLogType.Controls.Add(rbOperations);
            gbLogType.Controls.Add(rbErrors);
            gbLogType.Controls.Add(rbEvents);
            gbLogType.Controls.Add(rbAll);
            gbLogType.Location = new System.Drawing.Point(0, 3);
            gbLogType.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbLogType.Name = "gbLogType";
            gbLogType.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbLogType.Size = new System.Drawing.Size(244, 78);
            gbLogType.TabIndex = 0;
            gbLogType.TabStop = false;
            gbLogType.Text = "Log type";
            // 
            // rbOperations
            // 
            rbOperations.AutoSize = true;
            rbOperations.Location = new System.Drawing.Point(113, 48);
            rbOperations.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            rbOperations.Name = "rbOperations";
            rbOperations.Size = new System.Drawing.Size(83, 19);
            rbOperations.TabIndex = 3;
            rbOperations.Text = "Operations";
            rbOperations.UseVisualStyleBackColor = true;
            // 
            // rbErrors
            // 
            rbErrors.AutoSize = true;
            rbErrors.Location = new System.Drawing.Point(113, 22);
            rbErrors.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            rbErrors.Name = "rbErrors";
            rbErrors.Size = new System.Drawing.Size(55, 19);
            rbErrors.TabIndex = 1;
            rbErrors.Text = "Errors";
            rbErrors.UseVisualStyleBackColor = true;
            // 
            // rbEvents
            // 
            rbEvents.AutoSize = true;
            rbEvents.Location = new System.Drawing.Point(7, 48);
            rbEvents.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            rbEvents.Name = "rbEvents";
            rbEvents.Size = new System.Drawing.Size(59, 19);
            rbEvents.TabIndex = 2;
            rbEvents.Text = "Events";
            rbEvents.UseVisualStyleBackColor = true;
            // 
            // rbAll
            // 
            rbAll.AutoSize = true;
            rbAll.Checked = true;
            rbAll.Location = new System.Drawing.Point(7, 22);
            rbAll.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            rbAll.Name = "rbAll";
            rbAll.Size = new System.Drawing.Size(39, 19);
            rbAll.TabIndex = 0;
            rbAll.TabStop = true;
            rbAll.Text = "All";
            rbAll.UseVisualStyleBackColor = true;
            // 
            // chkDates
            // 
            chkDates.AutoSize = true;
            chkDates.Location = new System.Drawing.Point(13, -1);
            chkDates.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chkDates.Name = "chkDates";
            chkDates.Size = new System.Drawing.Size(55, 19);
            chkDates.TabIndex = 12;
            chkDates.Text = "Dates";
            chkDates.UseVisualStyleBackColor = true;
            // 
            // lblToMinutes
            // 
            lblToMinutes.AutoSize = true;
            lblToMinutes.Enabled = false;
            lblToMinutes.Location = new System.Drawing.Point(357, 51);
            lblToMinutes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblToMinutes.Name = "lblToMinutes";
            lblToMinutes.Size = new System.Drawing.Size(18, 15);
            lblToMinutes.TabIndex = 11;
            lblToMinutes.Text = "m";
            // 
            // lblFromMinutes
            // 
            lblFromMinutes.AutoSize = true;
            lblFromMinutes.Enabled = false;
            lblFromMinutes.Location = new System.Drawing.Point(357, 24);
            lblFromMinutes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblFromMinutes.Name = "lblFromMinutes";
            lblFromMinutes.Size = new System.Drawing.Size(18, 15);
            lblFromMinutes.TabIndex = 5;
            lblFromMinutes.Text = "m";
            // 
            // lblToHour
            // 
            lblToHour.AutoSize = true;
            lblToHour.Enabled = false;
            lblToHour.Location = new System.Drawing.Point(282, 51);
            lblToHour.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblToHour.Name = "lblToHour";
            lblToHour.Size = new System.Drawing.Size(14, 15);
            lblToHour.TabIndex = 9;
            lblToHour.Text = "h";
            // 
            // lblFromHour
            // 
            lblFromHour.AutoSize = true;
            lblFromHour.Enabled = false;
            lblFromHour.Location = new System.Drawing.Point(282, 24);
            lblFromHour.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblFromHour.Name = "lblFromHour";
            lblFromHour.Size = new System.Drawing.Size(14, 15);
            lblFromHour.TabIndex = 3;
            lblFromHour.Text = "h";
            // 
            // nudToMinutes
            // 
            nudToMinutes.Enabled = false;
            nudToMinutes.Location = new System.Drawing.Point(302, 46);
            nudToMinutes.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            nudToMinutes.Maximum = new decimal(new int[] { 59, 0, 0, 0 });
            nudToMinutes.Name = "nudToMinutes";
            nudToMinutes.Size = new System.Drawing.Size(54, 23);
            nudToMinutes.TabIndex = 10;
            nudToMinutes.Value = new decimal(new int[] { 59, 0, 0, 0 });
            // 
            // nudToHour
            // 
            nudToHour.Enabled = false;
            nudToHour.Location = new System.Drawing.Point(227, 46);
            nudToHour.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            nudToHour.Maximum = new decimal(new int[] { 23, 0, 0, 0 });
            nudToHour.Name = "nudToHour";
            nudToHour.Size = new System.Drawing.Size(54, 23);
            nudToHour.TabIndex = 8;
            nudToHour.Value = new decimal(new int[] { 23, 0, 0, 0 });
            // 
            // nudFromMinutes
            // 
            nudFromMinutes.Enabled = false;
            nudFromMinutes.Location = new System.Drawing.Point(302, 20);
            nudFromMinutes.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            nudFromMinutes.Maximum = new decimal(new int[] { 59, 0, 0, 0 });
            nudFromMinutes.Name = "nudFromMinutes";
            nudFromMinutes.Size = new System.Drawing.Size(54, 23);
            nudFromMinutes.TabIndex = 4;
            // 
            // nudFromHour
            // 
            nudFromHour.Enabled = false;
            nudFromHour.Location = new System.Drawing.Point(227, 20);
            nudFromHour.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            nudFromHour.Maximum = new decimal(new int[] { 23, 0, 0, 0 });
            nudFromHour.Name = "nudFromHour";
            nudFromHour.Size = new System.Drawing.Size(54, 23);
            nudFromHour.TabIndex = 2;
            // 
            // nudMaximumRows
            // 
            nudMaximumRows.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            nudMaximumRows.Location = new System.Drawing.Point(7, 22);
            nudMaximumRows.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            nudMaximumRows.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            nudMaximumRows.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudMaximumRows.Name = "nudMaximumRows";
            nudMaximumRows.Size = new System.Drawing.Size(160, 23);
            nudMaximumRows.TabIndex = 0;
            nudMaximumRows.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // btnClose
            // 
            btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            btnClose.Location = new System.Drawing.Point(819, 10);
            btnClose.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnClose.Name = "btnClose";
            btnClose.Size = new System.Drawing.Size(0, 0);
            btnClose.TabIndex = 0;
            btnClose.UseVisualStyleBackColor = true;
            // 
            // btnGetLogs
            // 
            btnGetLogs.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnGetLogs.Location = new System.Drawing.Point(817, 96);
            btnGetLogs.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnGetLogs.Name = "btnGetLogs";
            btnGetLogs.Size = new System.Drawing.Size(190, 27);
            btnGetLogs.TabIndex = 3;
            btnGetLogs.Text = "Get logs";
            btnGetLogs.UseVisualStyleBackColor = true;
            btnGetLogs.Click += BtnGetLogs_Click;
            // 
            // gbOperations
            // 
            gbOperations.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            gbOperations.Controls.Add(lvOperationsEventsAndErrors);
            gbOperations.Location = new System.Drawing.Point(0, 158);
            gbOperations.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbOperations.Name = "gbOperations";
            gbOperations.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbOperations.Size = new System.Drawing.Size(1013, 391);
            gbOperations.TabIndex = 4;
            gbOperations.TabStop = false;
            gbOperations.Text = "Operations, events, errors";
            // 
            // lvOperationsEventsAndErrors
            // 
            lvOperationsEventsAndErrors.AlternatingColorEven = System.Drawing.Color.LightBlue;
            lvOperationsEventsAndErrors.AlternatingColorOdd = System.Drawing.SystemColors.Window;
            lvOperationsEventsAndErrors.AlternatingColorsAreInUse = true;
            lvOperationsEventsAndErrors.AlternatingPairColorEven = System.Drawing.Color.LightSeaGreen;
            lvOperationsEventsAndErrors.AlternatingPairColorOdd = System.Drawing.Color.CadetBlue;
            lvOperationsEventsAndErrors.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { chKind, chDate, chUser, chOperationEventOrError, chDescription, chOtherInformation });
            lvOperationsEventsAndErrors.CompactView = false;
            lvOperationsEventsAndErrors.ContextMenuStrip = cmsMenu;
            lvOperationsEventsAndErrors.Dock = System.Windows.Forms.DockStyle.Fill;
            lvOperationsEventsAndErrors.EnsureLastItemIsVisible = false;
            lvOperationsEventsAndErrors.FirstItemIsGray = false;
            lvOperationsEventsAndErrors.FullRowSelect = true;
            lvOperationsEventsAndErrors.Location = new System.Drawing.Point(4, 19);
            lvOperationsEventsAndErrors.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            lvOperationsEventsAndErrors.Name = "lvOperationsEventsAndErrors";
            lvOperationsEventsAndErrors.OwnerDraw = true;
            lvOperationsEventsAndErrors.ReadonlyCheckboxes = false;
            lvOperationsEventsAndErrors.SameItemsColorEven = System.Drawing.Color.DarkOrange;
            lvOperationsEventsAndErrors.SameItemsColorOdd = System.Drawing.Color.LightSalmon;
            lvOperationsEventsAndErrors.Size = new System.Drawing.Size(1005, 369);
            lvOperationsEventsAndErrors.SmallImageList = ilImages;
            lvOperationsEventsAndErrors.TabIndex = 0;
            lvOperationsEventsAndErrors.UseCompatibleStateImageBehavior = false;
            lvOperationsEventsAndErrors.View = System.Windows.Forms.View.Details;
            // 
            // chKind
            // 
            chKind.Text = "Kind";
            chKind.Width = 40;
            // 
            // chDate
            // 
            chDate.Text = "Date";
            chDate.Width = 121;
            // 
            // chUser
            // 
            chUser.Text = "User";
            chUser.Width = 105;
            // 
            // chOperationEventOrError
            // 
            chOperationEventOrError.Text = "Operation / Event / Error";
            chOperationEventOrError.Width = 147;
            // 
            // chDescription
            // 
            chDescription.Text = "Description";
            chDescription.Width = 181;
            // 
            // chOtherInformation
            // 
            chOtherInformation.Text = "Other information";
            chOtherInformation.Width = 261;
            // 
            // cmsMenu
            // 
            cmsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { tsmiCopyToClipboard });
            cmsMenu.Name = "contextMenuStrip1";
            cmsMenu.Size = new System.Drawing.Size(170, 26);
            // 
            // tsmiCopyToClipboard
            // 
            tsmiCopyToClipboard.Name = "tsmiCopyToClipboard";
            tsmiCopyToClipboard.Size = new System.Drawing.Size(169, 22);
            tsmiCopyToClipboard.Text = "Copy to clipboard";
            // 
            // ilImages
            // 
            ilImages.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            ilImages.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("ilImages.ImageStream");
            ilImages.TransparentColor = System.Drawing.Color.Transparent;
            ilImages.Images.SetKeyName(0, "bug.ico");
            ilImages.Images.SetKeyName(1, "error.ico");
            ilImages.Images.SetKeyName(2, "event.ico");
            ilImages.Images.SetKeyName(3, "operation.ico");
            ilImages.Images.SetKeyName(4, "car.ico");
            ilImages.Images.SetKeyName(5, "database_add.ico");
            ilImages.Images.SetKeyName(6, "cam 0.ico");
            ilImages.Images.SetKeyName(7, "cam 1.ico");
            ilImages.Images.SetKeyName(8, "grids.ico");
            ilImages.Images.SetKeyName(9, "clock.ico");
            ilImages.Images.SetKeyName(10, "exit.ico");
            ilImages.Images.SetKeyName(11, "key.ico");
            ilImages.Images.SetKeyName(12, "user_add.ico");
            ilImages.Images.SetKeyName(13, "cam 2.ico");
            ilImages.Images.SetKeyName(14, "videoserver.ico");
            ilImages.Images.SetKeyName(15, "monitor.ico");
            ilImages.Images.SetKeyName(16, "user_edit.ico");
            ilImages.Images.SetKeyName(17, "user_del.ico");
            ilImages.Images.SetKeyName(18, "group_del.ico");
            ilImages.Images.SetKeyName(19, "group_edit.ico");
            ilImages.Images.SetKeyName(20, "group_add.ico");
            // 
            // dtpTo
            // 
            dtpTo.Enabled = false;
            dtpTo.Location = new System.Drawing.Point(65, 46);
            dtpTo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            dtpTo.Name = "dtpTo";
            dtpTo.Size = new System.Drawing.Size(154, 23);
            dtpTo.TabIndex = 7;
            // 
            // pMain
            // 
            pMain.Controls.Add(lblResults);
            pMain.Controls.Add(lblResultsFound);
            pMain.Controls.Add(gbMessageFilter);
            pMain.Controls.Add(btnDeleteAllLogs);
            pMain.Controls.Add(gbDates);
            pMain.Controls.Add(gbMaximumRows);
            pMain.Controls.Add(gbLogType);
            pMain.Controls.Add(btnClose);
            pMain.Controls.Add(btnGetLogs);
            pMain.Controls.Add(gbOperations);
            pMain.Dock = System.Windows.Forms.DockStyle.Fill;
            pMain.Location = new System.Drawing.Point(0, 0);
            pMain.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pMain.Name = "pMain";
            pMain.Size = new System.Drawing.Size(1013, 549);
            pMain.TabIndex = 1;
            // 
            // lblResults
            // 
            lblResults.AutoSize = true;
            lblResults.Location = new System.Drawing.Point(816, 37);
            lblResults.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblResults.Name = "lblResults";
            lblResults.Size = new System.Drawing.Size(13, 15);
            lblResults.TabIndex = 41;
            lblResults.Text = "0";
            // 
            // lblResultsFound
            // 
            lblResultsFound.AutoSize = true;
            lblResultsFound.Location = new System.Drawing.Point(816, 14);
            lblResultsFound.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblResultsFound.Name = "lblResultsFound";
            lblResultsFound.Size = new System.Drawing.Size(79, 15);
            lblResultsFound.TabIndex = 40;
            lblResultsFound.Text = "Results found";
            // 
            // gbMessageFilter
            // 
            gbMessageFilter.Controls.Add(lblOtherInformation);
            gbMessageFilter.Controls.Add(tbOtherInformation);
            gbMessageFilter.Controls.Add(cbMessageFilter);
            gbMessageFilter.Controls.Add(cbMessage);
            gbMessageFilter.Controls.Add(lblMessage);
            gbMessageFilter.Location = new System.Drawing.Point(0, 89);
            gbMessageFilter.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbMessageFilter.Name = "gbMessageFilter";
            gbMessageFilter.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbMessageFilter.Size = new System.Drawing.Size(812, 69);
            gbMessageFilter.TabIndex = 6;
            gbMessageFilter.TabStop = false;
            gbMessageFilter.Text = " ";
            // 
            // lblOtherInformation
            // 
            lblOtherInformation.AutoSize = true;
            lblOtherInformation.Location = new System.Drawing.Point(413, 20);
            lblOtherInformation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblOtherInformation.Name = "lblOtherInformation";
            lblOtherInformation.Size = new System.Drawing.Size(103, 15);
            lblOtherInformation.TabIndex = 6;
            lblOtherInformation.Text = "Other information";
            // 
            // tbOtherInformation
            // 
            tbOtherInformation.Location = new System.Drawing.Point(413, 38);
            tbOtherInformation.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tbOtherInformation.Name = "tbOtherInformation";
            tbOtherInformation.Size = new System.Drawing.Size(391, 23);
            tbOtherInformation.TabIndex = 5;
            // 
            // cbMessageFilter
            // 
            cbMessageFilter.AutoSize = true;
            cbMessageFilter.Location = new System.Drawing.Point(14, -1);
            cbMessageFilter.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cbMessageFilter.Name = "cbMessageFilter";
            cbMessageFilter.Size = new System.Drawing.Size(99, 19);
            cbMessageFilter.TabIndex = 4;
            cbMessageFilter.Text = "Message filter";
            cbMessageFilter.UseVisualStyleBackColor = true;
            // 
            // cbMessage
            // 
            cbMessage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbMessage.FormattingEnabled = true;
            cbMessage.Location = new System.Drawing.Point(14, 38);
            cbMessage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cbMessage.Name = "cbMessage";
            cbMessage.Size = new System.Drawing.Size(391, 23);
            cbMessage.TabIndex = 1;
            // 
            // lblMessage
            // 
            lblMessage.AutoSize = true;
            lblMessage.Location = new System.Drawing.Point(14, 20);
            lblMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new System.Drawing.Size(53, 15);
            lblMessage.TabIndex = 0;
            lblMessage.Text = "Message";
            // 
            // btnDeleteAllLogs
            // 
            btnDeleteAllLogs.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnDeleteAllLogs.Location = new System.Drawing.Point(817, 127);
            btnDeleteAllLogs.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnDeleteAllLogs.Name = "btnDeleteAllLogs";
            btnDeleteAllLogs.Size = new System.Drawing.Size(190, 27);
            btnDeleteAllLogs.TabIndex = 5;
            btnDeleteAllLogs.Text = "Delete all logs";
            btnDeleteAllLogs.UseVisualStyleBackColor = true;
            btnDeleteAllLogs.Click += BtnDeleteAllLogs_Click;
            // 
            // gbDates
            // 
            gbDates.Controls.Add(chkDates);
            gbDates.Controls.Add(lblToMinutes);
            gbDates.Controls.Add(lblFromMinutes);
            gbDates.Controls.Add(lblToHour);
            gbDates.Controls.Add(lblFromHour);
            gbDates.Controls.Add(nudToMinutes);
            gbDates.Controls.Add(nudToHour);
            gbDates.Controls.Add(nudFromMinutes);
            gbDates.Controls.Add(nudFromHour);
            gbDates.Controls.Add(dtpTo);
            gbDates.Controls.Add(dtpFrom);
            gbDates.Controls.Add(lblTo);
            gbDates.Controls.Add(lblFrom);
            gbDates.Location = new System.Drawing.Point(251, 3);
            gbDates.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbDates.Name = "gbDates";
            gbDates.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbDates.Size = new System.Drawing.Size(380, 78);
            gbDates.TabIndex = 2;
            gbDates.TabStop = false;
            gbDates.Text = " ";
            // 
            // dtpFrom
            // 
            dtpFrom.Enabled = false;
            dtpFrom.Location = new System.Drawing.Point(65, 20);
            dtpFrom.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            dtpFrom.Name = "dtpFrom";
            dtpFrom.Size = new System.Drawing.Size(154, 23);
            dtpFrom.TabIndex = 1;
            // 
            // lblTo
            // 
            lblTo.AutoSize = true;
            lblTo.Enabled = false;
            lblTo.Location = new System.Drawing.Point(7, 51);
            lblTo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblTo.Name = "lblTo";
            lblTo.Size = new System.Drawing.Size(46, 15);
            lblTo.TabIndex = 6;
            lblTo.Text = "To date";
            // 
            // lblFrom
            // 
            lblFrom.AutoSize = true;
            lblFrom.Enabled = false;
            lblFrom.Location = new System.Drawing.Point(7, 24);
            lblFrom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblFrom.Name = "lblFrom";
            lblFrom.Size = new System.Drawing.Size(61, 15);
            lblFrom.TabIndex = 0;
            lblFrom.Text = "From date";
            // 
            // gbMaximumRows
            // 
            gbMaximumRows.Controls.Add(nudMaximumRows);
            gbMaximumRows.Location = new System.Drawing.Point(638, 3);
            gbMaximumRows.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbMaximumRows.Name = "gbMaximumRows";
            gbMaximumRows.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbMaximumRows.Size = new System.Drawing.Size(174, 78);
            gbMaximumRows.TabIndex = 1;
            gbMaximumRows.TabStop = false;
            gbMaximumRows.Text = " ";
            // 
            // LogViewer
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1013, 549);
            Controls.Add(pMain);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "LogViewer";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Log viewer";
            Shown += LogViewer_Shown;
            gbLogType.ResumeLayout(false);
            gbLogType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudToMinutes).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudToHour).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudFromMinutes).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudFromHour).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudMaximumRows).EndInit();
            gbOperations.ResumeLayout(false);
            cmsMenu.ResumeLayout(false);
            pMain.ResumeLayout(false);
            pMain.PerformLayout();
            gbMessageFilter.ResumeLayout(false);
            gbMessageFilter.PerformLayout();
            gbDates.ResumeLayout(false);
            gbDates.PerformLayout();
            gbMaximumRows.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.CheckBox chkMaximumRows;
        private System.Windows.Forms.GroupBox gbLogType;
        private System.Windows.Forms.RadioButton rbOperations;
        private System.Windows.Forms.RadioButton rbErrors;
        private System.Windows.Forms.RadioButton rbEvents;
        private System.Windows.Forms.RadioButton rbAll;
        private System.Windows.Forms.CheckBox chkDates;
        private System.Windows.Forms.Label lblToMinutes;
        private System.Windows.Forms.Label lblFromMinutes;
        private System.Windows.Forms.Label lblToHour;
        private System.Windows.Forms.Label lblFromHour;
        private System.Windows.Forms.NumericUpDown nudToMinutes;
        private System.Windows.Forms.NumericUpDown nudToHour;
        private System.Windows.Forms.NumericUpDown nudFromMinutes;
        private System.Windows.Forms.NumericUpDown nudFromHour;
        private System.Windows.Forms.NumericUpDown nudMaximumRows;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnGetLogs;
        private System.Windows.Forms.GroupBox gbOperations;
        private Mtf.Controls.MtfListView lvOperationsEventsAndErrors;
        private System.Windows.Forms.ColumnHeader chKind;
        private System.Windows.Forms.ColumnHeader chDate;
        private System.Windows.Forms.ColumnHeader chUser;
        private System.Windows.Forms.ColumnHeader chOperationEventOrError;
        private System.Windows.Forms.ColumnHeader chDescription;
        private System.Windows.Forms.ColumnHeader chOtherInformation;
        private System.Windows.Forms.ContextMenuStrip cmsMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmiCopyToClipboard;
        private System.Windows.Forms.ImageList ilImages;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Panel pMain;
        private System.Windows.Forms.Label lblResults;
        private System.Windows.Forms.Label lblResultsFound;
        private System.Windows.Forms.GroupBox gbMessageFilter;
        private System.Windows.Forms.Label lblOtherInformation;
        private System.Windows.Forms.TextBox tbOtherInformation;
        private System.Windows.Forms.CheckBox cbMessageFilter;
        private System.Windows.Forms.ComboBox cbMessage;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnDeleteAllLogs;
        private System.Windows.Forms.GroupBox gbDates;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.GroupBox gbMaximumRows;
    }
}