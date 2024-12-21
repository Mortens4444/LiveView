namespace LiveView.Forms
{
    partial class BarcodeReadings
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
            chkStoreDates = new System.Windows.Forms.CheckBox();
            lblMinute = new System.Windows.Forms.Label();
            cbSlPort = new System.Windows.Forms.CheckBox();
            nudSlPort = new System.Windows.Forms.NumericUpDown();
            lblSender = new System.Windows.Forms.Label();
            tbSender = new System.Windows.Forms.TextBox();
            lblValue = new System.Windows.Forms.Label();
            chkAck = new System.Windows.Forms.CheckBox();
            lblMinute2 = new System.Windows.Forms.Label();
            lblHour2 = new System.Windows.Forms.Label();
            lblHour = new System.Windows.Forms.Label();
            nudToMinutes = new System.Windows.Forms.NumericUpDown();
            nudToHour = new System.Windows.Forms.NumericUpDown();
            nudFromMinutes = new System.Windows.Forms.NumericUpDown();
            nudFromHour = new System.Windows.Forms.NumericUpDown();
            dtpToDate = new System.Windows.Forms.DateTimePicker();
            dtpFromDate = new System.Windows.Forms.DateTimePicker();
            lblFrom = new System.Windows.Forms.Label();
            gbMaximumRows = new System.Windows.Forms.GroupBox();
            chkMaximumRows = new System.Windows.Forms.CheckBox();
            nudMaximumRows = new System.Windows.Forms.NumericUpDown();
            btnQuery = new System.Windows.Forms.Button();
            chId = new System.Windows.Forms.ColumnHeader();
            chStoreDate = new System.Windows.Forms.ColumnHeader();
            chUtcStoreDate = new System.Windows.Forms.ColumnHeader();
            chBcScanDate = new System.Windows.Forms.ColumnHeader();
            chUtcBcScanDate = new System.Windows.Forms.ColumnHeader();
            chValue = new System.Windows.Forms.ColumnHeader();
            chSender = new System.Windows.Forms.ColumnHeader();
            chSlPort = new System.Windows.Forms.ColumnHeader();
            lblTo = new System.Windows.Forms.Label();
            pMain = new System.Windows.Forms.Panel();
            lvScans = new Mtf.Controls.MtfListView();
            chAck = new System.Windows.Forms.ColumnHeader();
            cmsMenu = new System.Windows.Forms.ContextMenuStrip(components);
            tsmiMore = new System.Windows.Forms.ToolStripMenuItem();
            gbFilters = new System.Windows.Forms.GroupBox();
            gbBarcodeScanDates = new System.Windows.Forms.GroupBox();
            chkUtc2 = new System.Windows.Forms.CheckBox();
            chkBarcodeScanDates = new System.Windows.Forms.CheckBox();
            lblMinute4 = new System.Windows.Forms.Label();
            lblMinute3 = new System.Windows.Forms.Label();
            lblHour4 = new System.Windows.Forms.Label();
            lblHour3 = new System.Windows.Forms.Label();
            nudToMinutes2 = new System.Windows.Forms.NumericUpDown();
            nudToHour2 = new System.Windows.Forms.NumericUpDown();
            nudFromMinutes2 = new System.Windows.Forms.NumericUpDown();
            nudFromHour2 = new System.Windows.Forms.NumericUpDown();
            dtpToDate2 = new System.Windows.Forms.DateTimePicker();
            dtpFromDate2 = new System.Windows.Forms.DateTimePicker();
            lblTo2 = new System.Windows.Forms.Label();
            lblFrom2 = new System.Windows.Forms.Label();
            gbDatabaseServer = new System.Windows.Forms.GroupBox();
            cbDatabaseServer = new System.Windows.Forms.ComboBox();
            gbOther = new System.Windows.Forms.GroupBox();
            tbValue = new System.Windows.Forms.TextBox();
            gbStoreDates = new System.Windows.Forms.GroupBox();
            chkUtc = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)nudSlPort).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudToMinutes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudToHour).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudFromMinutes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudFromHour).BeginInit();
            gbMaximumRows.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudMaximumRows).BeginInit();
            pMain.SuspendLayout();
            cmsMenu.SuspendLayout();
            gbFilters.SuspendLayout();
            gbBarcodeScanDates.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudToMinutes2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudToHour2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudFromMinutes2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudFromHour2).BeginInit();
            gbDatabaseServer.SuspendLayout();
            gbOther.SuspendLayout();
            gbStoreDates.SuspendLayout();
            SuspendLayout();
            // 
            // chkStoreDates
            // 
            chkStoreDates.AutoSize = true;
            chkStoreDates.Location = new System.Drawing.Point(13, -1);
            chkStoreDates.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chkStoreDates.Name = "chkStoreDates";
            chkStoreDates.Size = new System.Drawing.Size(84, 19);
            chkStoreDates.TabIndex = 12;
            chkStoreDates.Text = "Store dates";
            chkStoreDates.UseVisualStyleBackColor = true;
            // 
            // lblMinute
            // 
            lblMinute.AutoSize = true;
            lblMinute.Enabled = false;
            lblMinute.Location = new System.Drawing.Point(368, 23);
            lblMinute.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblMinute.Name = "lblMinute";
            lblMinute.Size = new System.Drawing.Size(18, 15);
            lblMinute.TabIndex = 5;
            lblMinute.Text = "m";
            // 
            // cbSlPort
            // 
            cbSlPort.AutoSize = true;
            cbSlPort.Location = new System.Drawing.Point(304, 22);
            cbSlPort.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cbSlPort.Name = "cbSlPort";
            cbSlPort.Size = new System.Drawing.Size(63, 19);
            cbSlPort.TabIndex = 11;
            cbSlPort.Text = "SL port";
            cbSlPort.UseVisualStyleBackColor = true;
            // 
            // nudSlPort
            // 
            nudSlPort.Location = new System.Drawing.Point(304, 45);
            nudSlPort.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            nudSlPort.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            nudSlPort.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudSlPort.Name = "nudSlPort";
            nudSlPort.Size = new System.Drawing.Size(70, 23);
            nudSlPort.TabIndex = 10;
            nudSlPort.Value = new decimal(new int[] { 23550, 0, 0, 0 });
            // 
            // lblSender
            // 
            lblSender.AutoSize = true;
            lblSender.Location = new System.Drawing.Point(146, 23);
            lblSender.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblSender.Name = "lblSender";
            lblSender.Size = new System.Drawing.Size(43, 15);
            lblSender.TabIndex = 9;
            lblSender.Text = "Sender";
            // 
            // tbSender
            // 
            tbSender.Location = new System.Drawing.Point(149, 44);
            tbSender.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tbSender.Name = "tbSender";
            tbSender.Size = new System.Drawing.Size(134, 23);
            tbSender.TabIndex = 8;
            // 
            // lblValue
            // 
            lblValue.AutoSize = true;
            lblValue.Location = new System.Drawing.Point(9, 23);
            lblValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblValue.Name = "lblValue";
            lblValue.Size = new System.Drawing.Size(35, 15);
            lblValue.TabIndex = 7;
            lblValue.Text = "Value";
            // 
            // chkAck
            // 
            chkAck.AutoSize = true;
            chkAck.Checked = true;
            chkAck.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            chkAck.Location = new System.Drawing.Point(399, 46);
            chkAck.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chkAck.Name = "chkAck";
            chkAck.Size = new System.Drawing.Size(49, 19);
            chkAck.TabIndex = 6;
            chkAck.Text = "ACK";
            chkAck.ThreeState = true;
            chkAck.UseVisualStyleBackColor = true;
            // 
            // lblMinute2
            // 
            lblMinute2.AutoSize = true;
            lblMinute2.Enabled = false;
            lblMinute2.Location = new System.Drawing.Point(368, 50);
            lblMinute2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblMinute2.Name = "lblMinute2";
            lblMinute2.Size = new System.Drawing.Size(18, 15);
            lblMinute2.TabIndex = 11;
            lblMinute2.Text = "m";
            // 
            // lblHour2
            // 
            lblHour2.AutoSize = true;
            lblHour2.Enabled = false;
            lblHour2.Location = new System.Drawing.Point(294, 50);
            lblHour2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblHour2.Name = "lblHour2";
            lblHour2.Size = new System.Drawing.Size(14, 15);
            lblHour2.TabIndex = 9;
            lblHour2.Text = "h";
            // 
            // lblHour
            // 
            lblHour.AutoSize = true;
            lblHour.Enabled = false;
            lblHour.Location = new System.Drawing.Point(294, 23);
            lblHour.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblHour.Name = "lblHour";
            lblHour.Size = new System.Drawing.Size(14, 15);
            lblHour.TabIndex = 3;
            lblHour.Text = "h";
            // 
            // nudToMinutes
            // 
            nudToMinutes.Enabled = false;
            nudToMinutes.Location = new System.Drawing.Point(313, 45);
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
            nudToHour.Location = new System.Drawing.Point(239, 45);
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
            nudFromMinutes.Location = new System.Drawing.Point(313, 18);
            nudFromMinutes.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            nudFromMinutes.Maximum = new decimal(new int[] { 59, 0, 0, 0 });
            nudFromMinutes.Name = "nudFromMinutes";
            nudFromMinutes.Size = new System.Drawing.Size(54, 23);
            nudFromMinutes.TabIndex = 4;
            // 
            // nudFromHour
            // 
            nudFromHour.Enabled = false;
            nudFromHour.Location = new System.Drawing.Point(239, 18);
            nudFromHour.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            nudFromHour.Maximum = new decimal(new int[] { 23, 0, 0, 0 });
            nudFromHour.Name = "nudFromHour";
            nudFromHour.Size = new System.Drawing.Size(54, 23);
            nudFromHour.TabIndex = 2;
            // 
            // dtpToDate
            // 
            dtpToDate.Enabled = false;
            dtpToDate.Location = new System.Drawing.Point(77, 45);
            dtpToDate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            dtpToDate.Name = "dtpToDate";
            dtpToDate.Size = new System.Drawing.Size(154, 23);
            dtpToDate.TabIndex = 7;
            // 
            // dtpFromDate
            // 
            dtpFromDate.Enabled = false;
            dtpFromDate.Location = new System.Drawing.Point(77, 18);
            dtpFromDate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            dtpFromDate.Name = "dtpFromDate";
            dtpFromDate.Size = new System.Drawing.Size(154, 23);
            dtpFromDate.TabIndex = 1;
            // 
            // lblFrom
            // 
            lblFrom.AutoSize = true;
            lblFrom.Enabled = false;
            lblFrom.Location = new System.Drawing.Point(9, 23);
            lblFrom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblFrom.Name = "lblFrom";
            lblFrom.Size = new System.Drawing.Size(61, 15);
            lblFrom.TabIndex = 0;
            lblFrom.Text = "From date";
            // 
            // gbMaximumRows
            // 
            gbMaximumRows.Controls.Add(chkMaximumRows);
            gbMaximumRows.Controls.Add(nudMaximumRows);
            gbMaximumRows.Location = new System.Drawing.Point(471, 98);
            gbMaximumRows.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbMaximumRows.Name = "gbMaximumRows";
            gbMaximumRows.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbMaximumRows.Size = new System.Drawing.Size(174, 74);
            gbMaximumRows.TabIndex = 2;
            gbMaximumRows.TabStop = false;
            gbMaximumRows.Text = " ";
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
            // nudMaximumRows
            // 
            nudMaximumRows.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            nudMaximumRows.Location = new System.Drawing.Point(7, 45);
            nudMaximumRows.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            nudMaximumRows.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            nudMaximumRows.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudMaximumRows.Name = "nudMaximumRows";
            nudMaximumRows.Size = new System.Drawing.Size(160, 23);
            nudMaximumRows.TabIndex = 0;
            nudMaximumRows.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // btnQuery
            // 
            btnQuery.Location = new System.Drawing.Point(844, 140);
            btnQuery.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnQuery.Name = "btnQuery";
            btnQuery.Size = new System.Drawing.Size(88, 27);
            btnQuery.TabIndex = 11;
            btnQuery.Text = "Query";
            btnQuery.UseVisualStyleBackColor = true;
            btnQuery.Click += BtnQuery_Click;
            // 
            // chId
            // 
            chId.Text = "ID";
            chId.Width = 41;
            // 
            // chStoreDate
            // 
            chStoreDate.Text = "Store date";
            chStoreDate.Width = 115;
            // 
            // chUtcStoreDate
            // 
            chUtcStoreDate.Text = "Store date (UTC)";
            chUtcStoreDate.Width = 115;
            // 
            // chBcScanDate
            // 
            chBcScanDate.Text = "BC scan date";
            chBcScanDate.Width = 115;
            // 
            // chUtcBcScanDate
            // 
            chUtcBcScanDate.Text = "BC scan date (UTC)";
            chUtcBcScanDate.Width = 115;
            // 
            // chValue
            // 
            chValue.Text = "Value";
            chValue.Width = 111;
            // 
            // chSender
            // 
            chSender.Text = "Sender";
            chSender.Width = 131;
            // 
            // chSlPort
            // 
            chSlPort.Text = "SL port";
            chSlPort.Width = 50;
            // 
            // lblTo
            // 
            lblTo.AutoSize = true;
            lblTo.Enabled = false;
            lblTo.Location = new System.Drawing.Point(9, 50);
            lblTo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblTo.Name = "lblTo";
            lblTo.Size = new System.Drawing.Size(46, 15);
            lblTo.TabIndex = 6;
            lblTo.Text = "To date";
            // 
            // pMain
            // 
            pMain.Controls.Add(lvScans);
            pMain.Controls.Add(gbFilters);
            pMain.Dock = System.Windows.Forms.DockStyle.Fill;
            pMain.Location = new System.Drawing.Point(0, 0);
            pMain.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pMain.Name = "pMain";
            pMain.Size = new System.Drawing.Size(979, 549);
            pMain.TabIndex = 1;
            // 
            // lvScans
            // 
            lvScans.AlternatingColorEven = System.Drawing.Color.LightBlue;
            lvScans.AlternatingColorOdd = System.Drawing.SystemColors.Window;
            lvScans.AlternatingColorsAreInUse = true;
            lvScans.AlternatingPairColorEven = System.Drawing.Color.LightSeaGreen;
            lvScans.AlternatingPairColorOdd = System.Drawing.Color.CadetBlue;
            lvScans.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { chId, chStoreDate, chUtcStoreDate, chBcScanDate, chUtcBcScanDate, chValue, chSender, chSlPort, chAck });
            lvScans.CompactView = false;
            lvScans.ContextMenuStrip = cmsMenu;
            lvScans.Dock = System.Windows.Forms.DockStyle.Fill;
            lvScans.EnsureLastItemIsVisible = false;
            lvScans.FirstItemIsGray = false;
            lvScans.FullRowSelect = true;
            lvScans.Location = new System.Drawing.Point(0, 178);
            lvScans.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            lvScans.Name = "lvScans";
            lvScans.OwnerDraw = true;
            lvScans.ReadonlyCheckboxes = false;
            lvScans.SameItemsColorEven = System.Drawing.Color.DarkOrange;
            lvScans.SameItemsColorOdd = System.Drawing.Color.LightSalmon;
            lvScans.Size = new System.Drawing.Size(979, 371);
            lvScans.TabIndex = 11;
            lvScans.UseCompatibleStateImageBehavior = false;
            lvScans.View = System.Windows.Forms.View.Details;
            // 
            // chAck
            // 
            chAck.Text = "ACK";
            chAck.Width = 38;
            // 
            // cmsMenu
            // 
            cmsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { tsmiMore });
            cmsMenu.Name = "contextMenuStrip1";
            cmsMenu.Size = new System.Drawing.Size(103, 26);
            // 
            // tsmiMore
            // 
            tsmiMore.Name = "tsmiMore";
            tsmiMore.Size = new System.Drawing.Size(102, 22);
            tsmiMore.Text = "More";
            // 
            // gbFilters
            // 
            gbFilters.Controls.Add(gbBarcodeScanDates);
            gbFilters.Controls.Add(gbDatabaseServer);
            gbFilters.Controls.Add(gbOther);
            gbFilters.Controls.Add(gbStoreDates);
            gbFilters.Controls.Add(gbMaximumRows);
            gbFilters.Controls.Add(btnQuery);
            gbFilters.Dock = System.Windows.Forms.DockStyle.Top;
            gbFilters.Location = new System.Drawing.Point(0, 0);
            gbFilters.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbFilters.Name = "gbFilters";
            gbFilters.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbFilters.Size = new System.Drawing.Size(979, 178);
            gbFilters.TabIndex = 1;
            gbFilters.TabStop = false;
            gbFilters.Text = "Filters";
            // 
            // gbBarcodeScanDates
            // 
            gbBarcodeScanDates.Controls.Add(chkUtc2);
            gbBarcodeScanDates.Controls.Add(chkBarcodeScanDates);
            gbBarcodeScanDates.Controls.Add(lblMinute4);
            gbBarcodeScanDates.Controls.Add(lblMinute3);
            gbBarcodeScanDates.Controls.Add(lblHour4);
            gbBarcodeScanDates.Controls.Add(lblHour3);
            gbBarcodeScanDates.Controls.Add(nudToMinutes2);
            gbBarcodeScanDates.Controls.Add(nudToHour2);
            gbBarcodeScanDates.Controls.Add(nudFromMinutes2);
            gbBarcodeScanDates.Controls.Add(nudFromHour2);
            gbBarcodeScanDates.Controls.Add(dtpToDate2);
            gbBarcodeScanDates.Controls.Add(dtpFromDate2);
            gbBarcodeScanDates.Controls.Add(lblTo2);
            gbBarcodeScanDates.Controls.Add(lblFrom2);
            gbBarcodeScanDates.Location = new System.Drawing.Point(471, 17);
            gbBarcodeScanDates.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbBarcodeScanDates.Name = "gbBarcodeScanDates";
            gbBarcodeScanDates.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbBarcodeScanDates.Size = new System.Drawing.Size(460, 74);
            gbBarcodeScanDates.TabIndex = 14;
            gbBarcodeScanDates.TabStop = false;
            gbBarcodeScanDates.Text = " ";
            // 
            // chkUtc2
            // 
            chkUtc2.AutoSize = true;
            chkUtc2.Enabled = false;
            chkUtc2.Location = new System.Drawing.Point(399, 48);
            chkUtc2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chkUtc2.Name = "chkUtc2";
            chkUtc2.Size = new System.Drawing.Size(48, 19);
            chkUtc2.TabIndex = 13;
            chkUtc2.Text = "UTC";
            chkUtc2.UseVisualStyleBackColor = true;
            // 
            // chkBarcodeScanDates
            // 
            chkBarcodeScanDates.AutoSize = true;
            chkBarcodeScanDates.Location = new System.Drawing.Point(13, -1);
            chkBarcodeScanDates.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chkBarcodeScanDates.Name = "chkBarcodeScanDates";
            chkBarcodeScanDates.Size = new System.Drawing.Size(127, 19);
            chkBarcodeScanDates.TabIndex = 12;
            chkBarcodeScanDates.Text = "Barcode scan dates";
            chkBarcodeScanDates.UseVisualStyleBackColor = true;
            // 
            // lblMinute4
            // 
            lblMinute4.AutoSize = true;
            lblMinute4.Enabled = false;
            lblMinute4.Location = new System.Drawing.Point(366, 50);
            lblMinute4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblMinute4.Name = "lblMinute4";
            lblMinute4.Size = new System.Drawing.Size(18, 15);
            lblMinute4.TabIndex = 11;
            lblMinute4.Text = "m";
            // 
            // lblMinute3
            // 
            lblMinute3.AutoSize = true;
            lblMinute3.Enabled = false;
            lblMinute3.Location = new System.Drawing.Point(366, 23);
            lblMinute3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblMinute3.Name = "lblMinute3";
            lblMinute3.Size = new System.Drawing.Size(18, 15);
            lblMinute3.TabIndex = 5;
            lblMinute3.Text = "m";
            // 
            // lblHour4
            // 
            lblHour4.AutoSize = true;
            lblHour4.Enabled = false;
            lblHour4.Location = new System.Drawing.Point(292, 50);
            lblHour4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblHour4.Name = "lblHour4";
            lblHour4.Size = new System.Drawing.Size(14, 15);
            lblHour4.TabIndex = 9;
            lblHour4.Text = "h";
            // 
            // lblHour3
            // 
            lblHour3.AutoSize = true;
            lblHour3.Enabled = false;
            lblHour3.Location = new System.Drawing.Point(292, 23);
            lblHour3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblHour3.Name = "lblHour3";
            lblHour3.Size = new System.Drawing.Size(14, 15);
            lblHour3.TabIndex = 3;
            lblHour3.Text = "h";
            // 
            // nudToMinutes2
            // 
            nudToMinutes2.Enabled = false;
            nudToMinutes2.Location = new System.Drawing.Point(311, 45);
            nudToMinutes2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            nudToMinutes2.Maximum = new decimal(new int[] { 59, 0, 0, 0 });
            nudToMinutes2.Name = "nudToMinutes2";
            nudToMinutes2.Size = new System.Drawing.Size(54, 23);
            nudToMinutes2.TabIndex = 10;
            nudToMinutes2.Value = new decimal(new int[] { 59, 0, 0, 0 });
            // 
            // nudToHour2
            // 
            nudToHour2.Enabled = false;
            nudToHour2.Location = new System.Drawing.Point(237, 45);
            nudToHour2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            nudToHour2.Maximum = new decimal(new int[] { 23, 0, 0, 0 });
            nudToHour2.Name = "nudToHour2";
            nudToHour2.Size = new System.Drawing.Size(54, 23);
            nudToHour2.TabIndex = 8;
            nudToHour2.Value = new decimal(new int[] { 23, 0, 0, 0 });
            // 
            // nudFromMinutes2
            // 
            nudFromMinutes2.Enabled = false;
            nudFromMinutes2.Location = new System.Drawing.Point(311, 18);
            nudFromMinutes2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            nudFromMinutes2.Maximum = new decimal(new int[] { 59, 0, 0, 0 });
            nudFromMinutes2.Name = "nudFromMinutes2";
            nudFromMinutes2.Size = new System.Drawing.Size(54, 23);
            nudFromMinutes2.TabIndex = 4;
            // 
            // nudFromHour2
            // 
            nudFromHour2.Enabled = false;
            nudFromHour2.Location = new System.Drawing.Point(237, 18);
            nudFromHour2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            nudFromHour2.Maximum = new decimal(new int[] { 23, 0, 0, 0 });
            nudFromHour2.Name = "nudFromHour2";
            nudFromHour2.Size = new System.Drawing.Size(54, 23);
            nudFromHour2.TabIndex = 2;
            // 
            // dtpToDate2
            // 
            dtpToDate2.Enabled = false;
            dtpToDate2.Location = new System.Drawing.Point(75, 45);
            dtpToDate2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            dtpToDate2.Name = "dtpToDate2";
            dtpToDate2.Size = new System.Drawing.Size(154, 23);
            dtpToDate2.TabIndex = 7;
            // 
            // dtpFromDate2
            // 
            dtpFromDate2.Enabled = false;
            dtpFromDate2.Location = new System.Drawing.Point(75, 18);
            dtpFromDate2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            dtpFromDate2.Name = "dtpFromDate2";
            dtpFromDate2.Size = new System.Drawing.Size(154, 23);
            dtpFromDate2.TabIndex = 1;
            // 
            // lblTo2
            // 
            lblTo2.AutoSize = true;
            lblTo2.Enabled = false;
            lblTo2.Location = new System.Drawing.Point(9, 50);
            lblTo2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblTo2.Name = "lblTo2";
            lblTo2.Size = new System.Drawing.Size(46, 15);
            lblTo2.TabIndex = 6;
            lblTo2.Text = "To date";
            // 
            // lblFrom2
            // 
            lblFrom2.AutoSize = true;
            lblFrom2.Enabled = false;
            lblFrom2.Location = new System.Drawing.Point(9, 23);
            lblFrom2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblFrom2.Name = "lblFrom2";
            lblFrom2.Size = new System.Drawing.Size(61, 15);
            lblFrom2.TabIndex = 0;
            lblFrom2.Text = "From date";
            // 
            // gbDatabaseServer
            // 
            gbDatabaseServer.Controls.Add(cbDatabaseServer);
            gbDatabaseServer.Location = new System.Drawing.Point(656, 98);
            gbDatabaseServer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbDatabaseServer.Name = "gbDatabaseServer";
            gbDatabaseServer.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbDatabaseServer.Size = new System.Drawing.Size(174, 74);
            gbDatabaseServer.TabIndex = 3;
            gbDatabaseServer.TabStop = false;
            gbDatabaseServer.Text = "Database server";
            // 
            // cbDatabaseServer
            // 
            cbDatabaseServer.FormattingEnabled = true;
            cbDatabaseServer.Location = new System.Drawing.Point(13, 44);
            cbDatabaseServer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cbDatabaseServer.Name = "cbDatabaseServer";
            cbDatabaseServer.Size = new System.Drawing.Size(140, 23);
            cbDatabaseServer.TabIndex = 13;
            // 
            // gbOther
            // 
            gbOther.Controls.Add(cbSlPort);
            gbOther.Controls.Add(nudSlPort);
            gbOther.Controls.Add(lblSender);
            gbOther.Controls.Add(tbSender);
            gbOther.Controls.Add(lblValue);
            gbOther.Controls.Add(chkAck);
            gbOther.Controls.Add(tbValue);
            gbOther.Location = new System.Drawing.Point(5, 98);
            gbOther.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbOther.Name = "gbOther";
            gbOther.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbOther.Size = new System.Drawing.Size(460, 74);
            gbOther.TabIndex = 7;
            gbOther.TabStop = false;
            gbOther.Text = "Other";
            // 
            // tbValue
            // 
            tbValue.Location = new System.Drawing.Point(7, 44);
            tbValue.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tbValue.Name = "tbValue";
            tbValue.Size = new System.Drawing.Size(134, 23);
            tbValue.TabIndex = 5;
            // 
            // gbStoreDates
            // 
            gbStoreDates.Controls.Add(chkUtc);
            gbStoreDates.Controls.Add(chkStoreDates);
            gbStoreDates.Controls.Add(lblMinute2);
            gbStoreDates.Controls.Add(lblMinute);
            gbStoreDates.Controls.Add(lblHour2);
            gbStoreDates.Controls.Add(lblHour);
            gbStoreDates.Controls.Add(nudToMinutes);
            gbStoreDates.Controls.Add(nudToHour);
            gbStoreDates.Controls.Add(nudFromMinutes);
            gbStoreDates.Controls.Add(nudFromHour);
            gbStoreDates.Controls.Add(dtpToDate);
            gbStoreDates.Controls.Add(dtpFromDate);
            gbStoreDates.Controls.Add(lblTo);
            gbStoreDates.Controls.Add(lblFrom);
            gbStoreDates.Location = new System.Drawing.Point(5, 17);
            gbStoreDates.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbStoreDates.Name = "gbStoreDates";
            gbStoreDates.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbStoreDates.Size = new System.Drawing.Size(460, 74);
            gbStoreDates.TabIndex = 3;
            gbStoreDates.TabStop = false;
            gbStoreDates.Text = " ";
            // 
            // chkUtc
            // 
            chkUtc.AutoSize = true;
            chkUtc.Enabled = false;
            chkUtc.Location = new System.Drawing.Point(399, 48);
            chkUtc.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chkUtc.Name = "chkUtc";
            chkUtc.Size = new System.Drawing.Size(48, 19);
            chkUtc.TabIndex = 13;
            chkUtc.Text = "UTC";
            chkUtc.UseVisualStyleBackColor = true;
            // 
            // BarcodeReadings
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(979, 549);
            Controls.Add(pMain);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "BarcodeReadings";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Barcode readings";
            Shown += BarcodeReadings_Shown;
            ((System.ComponentModel.ISupportInitialize)nudSlPort).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudToMinutes).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudToHour).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudFromMinutes).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudFromHour).EndInit();
            gbMaximumRows.ResumeLayout(false);
            gbMaximumRows.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudMaximumRows).EndInit();
            pMain.ResumeLayout(false);
            cmsMenu.ResumeLayout(false);
            gbFilters.ResumeLayout(false);
            gbBarcodeScanDates.ResumeLayout(false);
            gbBarcodeScanDates.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudToMinutes2).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudToHour2).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudFromMinutes2).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudFromHour2).EndInit();
            gbDatabaseServer.ResumeLayout(false);
            gbOther.ResumeLayout(false);
            gbOther.PerformLayout();
            gbStoreDates.ResumeLayout(false);
            gbStoreDates.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.CheckBox chkStoreDates;
        private System.Windows.Forms.Label lblMinute;
        private System.Windows.Forms.CheckBox cbSlPort;
        private System.Windows.Forms.NumericUpDown nudSlPort;
        private System.Windows.Forms.Label lblSender;
        private System.Windows.Forms.TextBox tbSender;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.CheckBox chkAck;
        private System.Windows.Forms.Label lblMinute2;
        private System.Windows.Forms.Label lblHour2;
        private System.Windows.Forms.Label lblHour;
        private System.Windows.Forms.NumericUpDown nudToMinutes;
        private System.Windows.Forms.NumericUpDown nudToHour;
        private System.Windows.Forms.NumericUpDown nudFromMinutes;
        private System.Windows.Forms.NumericUpDown nudFromHour;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.GroupBox gbMaximumRows;
        private System.Windows.Forms.CheckBox chkMaximumRows;
        private System.Windows.Forms.NumericUpDown nudMaximumRows;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.ColumnHeader chId;
        private System.Windows.Forms.ColumnHeader chStoreDate;
        private System.Windows.Forms.ColumnHeader chUtcStoreDate;
        private System.Windows.Forms.ColumnHeader chBcScanDate;
        private System.Windows.Forms.ColumnHeader chUtcBcScanDate;
        private System.Windows.Forms.ColumnHeader chValue;
        private System.Windows.Forms.ColumnHeader chSender;
        private System.Windows.Forms.ColumnHeader chSlPort;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Panel pMain;
        private Mtf.Controls.MtfListView lvScans;
        private System.Windows.Forms.ColumnHeader chAck;
        private System.Windows.Forms.ContextMenuStrip cmsMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmiMore;
        private System.Windows.Forms.GroupBox gbFilters;
        private System.Windows.Forms.GroupBox gbBarcodeScanDates;
        private System.Windows.Forms.CheckBox chkUtc2;
        private System.Windows.Forms.CheckBox chkBarcodeScanDates;
        private System.Windows.Forms.Label lblMinute4;
        private System.Windows.Forms.Label lblMinute3;
        private System.Windows.Forms.Label lblHour4;
        private System.Windows.Forms.Label lblHour3;
        private System.Windows.Forms.NumericUpDown nudToMinutes2;
        private System.Windows.Forms.NumericUpDown nudToHour2;
        private System.Windows.Forms.NumericUpDown nudFromMinutes2;
        private System.Windows.Forms.NumericUpDown nudFromHour2;
        private System.Windows.Forms.DateTimePicker dtpToDate2;
        private System.Windows.Forms.DateTimePicker dtpFromDate2;
        private System.Windows.Forms.Label lblTo2;
        private System.Windows.Forms.Label lblFrom2;
        private System.Windows.Forms.GroupBox gbDatabaseServer;
        private System.Windows.Forms.ComboBox cbDatabaseServer;
        private System.Windows.Forms.GroupBox gbOther;
        private System.Windows.Forms.TextBox tbValue;
        private System.Windows.Forms.GroupBox gbStoreDates;
        private System.Windows.Forms.CheckBox chkUtc;
    }
}