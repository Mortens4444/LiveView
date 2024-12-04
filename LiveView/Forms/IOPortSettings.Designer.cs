namespace LiveView.Forms
{
    partial class IOPortSettings
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(IOPortSettings));
            pMain = new System.Windows.Forms.Panel();
            lblIODevice = new System.Windows.Forms.Label();
            chkZeroSignalled = new System.Windows.Forms.CheckBox();
            lvIOPortRules = new Mtf.Controls.MtfListView();
            this.chRuleIODevice = new System.Windows.Forms.ColumnHeader();
            this.chOutputIOPort = new System.Windows.Forms.ColumnHeader();
            this.chOperationOrEvent = new System.Windows.Forms.ColumnHeader();
            this.chZeroSignaled = new System.Windows.Forms.ColumnHeader();
            cmdDeleteRules = new System.Windows.Forms.ContextMenuStrip(components);
            deleteRulesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            lblOutputIOPort = new System.Windows.Forms.Label();
            btnAddToRules = new System.Windows.Forms.Button();
            this.cbOutputIOPort = new System.Windows.Forms.ComboBox();
            lblOperationOrEvent = new System.Windows.Forms.Label();
            cbIODevice = new System.Windows.Forms.ComboBox();
            cbOperationOrEvent = new System.Windows.Forms.ComboBox();
            pLower = new System.Windows.Forms.Panel();
            gbIORules = new System.Windows.Forms.GroupBox();
            changeFriendlyNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            cmsChangeSettings = new System.Windows.Forms.ContextMenuStrip(components);
            chMinTriggerTime = new System.Windows.Forms.ColumnHeader();
            chMaxSignalPerDay = new System.Windows.Forms.ColumnHeader();
            chFriendlyName = new System.Windows.Forms.ColumnHeader();
            chPortName = new System.Windows.Forms.ColumnHeader();
            chPortNumber = new System.Windows.Forms.ColumnHeader();
            chIODevice = new System.Windows.Forms.ColumnHeader();
            lvIODevices = new Mtf.Controls.MtfListView();
            pUpper = new System.Windows.Forms.Panel();
            cmdDeleteRules.SuspendLayout();
            pLower.SuspendLayout();
            gbIORules.SuspendLayout();
            cmsChangeSettings.SuspendLayout();
            pUpper.SuspendLayout();
            SuspendLayout();
            // 
            // pMain
            // 
            pMain.Dock = System.Windows.Forms.DockStyle.Fill;
            pMain.Location = new System.Drawing.Point(0, 0);
            pMain.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pMain.Name = "pMain";
            pMain.Size = new System.Drawing.Size(915, 517);
            pMain.TabIndex = 0;
            // 
            // lblIODevice
            // 
            lblIODevice.AutoSize = true;
            lblIODevice.Location = new System.Drawing.Point(4, 28);
            lblIODevice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblIODevice.Name = "lblIODevice";
            lblIODevice.Size = new System.Drawing.Size(62, 15);
            lblIODevice.TabIndex = 10;
            lblIODevice.Text = "I/O Device";
            // 
            // chkZeroSignalled
            // 
            chkZeroSignalled.AutoSize = true;
            chkZeroSignalled.Location = new System.Drawing.Point(552, 48);
            chkZeroSignalled.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chkZeroSignalled.Name = "chkZeroSignalled";
            chkZeroSignalled.Size = new System.Drawing.Size(97, 19);
            chkZeroSignalled.TabIndex = 6;
            chkZeroSignalled.Text = "Zero signaled";
            chkZeroSignalled.UseVisualStyleBackColor = true;
            // 
            // lvIOPortRules
            // 
            lvIOPortRules.AlternatingColorEven = System.Drawing.Color.LightBlue;
            lvIOPortRules.AlternatingColorOdd = System.Drawing.SystemColors.Window;
            lvIOPortRules.AlternatingColorsAreInUse = true;
            lvIOPortRules.AlternatingPairColorEven = System.Drawing.Color.LightSeaGreen;
            lvIOPortRules.AlternatingPairColorOdd = System.Drawing.Color.CadetBlue;
            lvIOPortRules.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            lvIOPortRules.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { this.chRuleIODevice, this.chOutputIOPort, this.chOperationOrEvent, this.chZeroSignaled });
            lvIOPortRules.CompactView = false;
            lvIOPortRules.ContextMenuStrip = cmdDeleteRules;
            lvIOPortRules.EnsureLastItemIsVisible = false;
            lvIOPortRules.FirstItemIsGray = false;
            lvIOPortRules.FullRowSelect = true;
            lvIOPortRules.Location = new System.Drawing.Point(4, 77);
            lvIOPortRules.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            lvIOPortRules.Name = "lvIOPortRules";
            lvIOPortRules.OwnerDraw = true;
            lvIOPortRules.ReadonlyCheckboxes = false;
            lvIOPortRules.SameItemsColorEven = System.Drawing.Color.DarkOrange;
            lvIOPortRules.SameItemsColorOdd = System.Drawing.Color.LightSalmon;
            lvIOPortRules.Size = new System.Drawing.Size(907, 151);
            lvIOPortRules.TabIndex = 5;
            lvIOPortRules.UseCompatibleStateImageBehavior = false;
            lvIOPortRules.View = System.Windows.Forms.View.Details;
            // 
            // chRuleIODevice
            // 
            this.chRuleIODevice.Text = "I/O Device";
            this.chRuleIODevice.Width = 102;
            // 
            // chOutputIOPort
            // 
            this.chOutputIOPort.Text = "Output I/O port";
            this.chOutputIOPort.Width = 183;
            // 
            // chOperationOrEvent
            // 
            this.chOperationOrEvent.Text = "Operation or event";
            this.chOperationOrEvent.Width = 184;
            // 
            // chZeroSignaled
            // 
            this.chZeroSignaled.Text = "Zero signaled";
            this.chZeroSignaled.Width = 81;
            // 
            // cmdDeleteRules
            // 
            cmdDeleteRules.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { deleteRulesToolStripMenuItem });
            cmdDeleteRules.Name = "contextMenuStrip2";
            cmdDeleteRules.Size = new System.Drawing.Size(181, 48);
            // 
            // deleteRulesToolStripMenuItem
            // 
            deleteRulesToolStripMenuItem.Name = "deleteRulesToolStripMenuItem";
            deleteRulesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            deleteRulesToolStripMenuItem.Text = "Delete rules";
            // 
            // lblOutputIOPort
            // 
            lblOutputIOPort.AutoSize = true;
            lblOutputIOPort.Location = new System.Drawing.Point(122, 28);
            lblOutputIOPort.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblOutputIOPort.Name = "lblOutputIOPort";
            lblOutputIOPort.Size = new System.Drawing.Size(90, 15);
            lblOutputIOPort.TabIndex = 2;
            lblOutputIOPort.Text = "Output I/O port";
            // 
            // btnAddToRules
            // 
            btnAddToRules.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnAddToRules.Location = new System.Drawing.Point(736, 42);
            btnAddToRules.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnAddToRules.Name = "btnAddToRules";
            btnAddToRules.Size = new System.Drawing.Size(164, 27);
            btnAddToRules.TabIndex = 4;
            btnAddToRules.Text = "Add to rules";
            btnAddToRules.UseVisualStyleBackColor = true;
            btnAddToRules.Click += BtnAddToRules_Click;
            // 
            // lblOperationOrEvent
            // 
            lblOperationOrEvent.AutoSize = true;
            lblOperationOrEvent.Location = new System.Drawing.Point(334, 28);
            lblOperationOrEvent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblOperationOrEvent.Name = "lblOperationOrEvent";
            lblOperationOrEvent.Size = new System.Drawing.Size(106, 15);
            lblOperationOrEvent.TabIndex = 3;
            lblOperationOrEvent.Text = "Operation or event";
            // 
            // cbOutputIOPort
            // 
            this.cbOutputIOPort.FormattingEnabled = true;
            this.cbOutputIOPort.Location = new System.Drawing.Point(122, 46);
            this.cbOutputIOPort.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cbOutputIOPort.Name = "cbOutputIOPort";
            this.cbOutputIOPort.Size = new System.Drawing.Size(207, 23);
            this.cbOutputIOPort.TabIndex = 1;
            // 
            // cbIODevice
            // 
            cbIODevice.FormattingEnabled = true;
            cbIODevice.Location = new System.Drawing.Point(4, 46);
            cbIODevice.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cbIODevice.Name = "cbIODevice";
            cbIODevice.Size = new System.Drawing.Size(108, 23);
            cbIODevice.TabIndex = 9;
            // 
            // cbOperationOrEvent
            // 
            cbOperationOrEvent.FormattingEnabled = true;
            cbOperationOrEvent.Location = new System.Drawing.Point(337, 46);
            cbOperationOrEvent.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cbOperationOrEvent.Name = "cbOperationOrEvent";
            cbOperationOrEvent.Size = new System.Drawing.Size(207, 23);
            cbOperationOrEvent.TabIndex = 0;
            // 
            // pLower
            // 
            pLower.Controls.Add(gbIORules);
            pLower.Dock = System.Windows.Forms.DockStyle.Fill;
            pLower.Location = new System.Drawing.Point(0, 285);
            pLower.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pLower.Name = "pLower";
            pLower.Size = new System.Drawing.Size(915, 232);
            pLower.TabIndex = 4;
            // 
            // gbIORules
            // 
            gbIORules.Controls.Add(lblIODevice);
            gbIORules.Controls.Add(cbIODevice);
            gbIORules.Controls.Add(chkZeroSignalled);
            gbIORules.Controls.Add(lvIOPortRules);
            gbIORules.Controls.Add(btnAddToRules);
            gbIORules.Controls.Add(lblOperationOrEvent);
            gbIORules.Controls.Add(this.cbOutputIOPort);
            gbIORules.Controls.Add(lblOutputIOPort);
            gbIORules.Controls.Add(cbOperationOrEvent);
            gbIORules.Dock = System.Windows.Forms.DockStyle.Fill;
            gbIORules.Location = new System.Drawing.Point(0, 0);
            gbIORules.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbIORules.Name = "gbIORules";
            gbIORules.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbIORules.Size = new System.Drawing.Size(915, 232);
            gbIORules.TabIndex = 3;
            gbIORules.TabStop = false;
            gbIORules.Text = "I/O port rules";
            // 
            // changeFriendlyNameToolStripMenuItem
            // 
            changeFriendlyNameToolStripMenuItem.Name = "changeFriendlyNameToolStripMenuItem";
            changeFriendlyNameToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            changeFriendlyNameToolStripMenuItem.Text = "Change settings";
            // 
            // cmsChangeSettings
            // 
            cmsChangeSettings.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { changeFriendlyNameToolStripMenuItem });
            cmsChangeSettings.Name = "contextMenuStrip1";
            cmsChangeSettings.Size = new System.Drawing.Size(160, 26);
            // 
            // chMinTriggerTime
            // 
            chMinTriggerTime.Text = "Minimum trigger time";
            chMinTriggerTime.Width = 107;
            // 
            // chMaxSignalPerDay
            // 
            chMaxSignalPerDay.Text = "Maximum signals per day";
            chMaxSignalPerDay.Width = 131;
            // 
            // chFriendlyName
            // 
            chFriendlyName.Text = "Friendly name";
            chFriendlyName.Width = 150;
            // 
            // chPortName
            // 
            chPortName.Text = "Port name";
            chPortName.Width = 150;
            // 
            // chPortNumber
            // 
            chPortNumber.Text = "Port number";
            chPortNumber.Width = 80;
            // 
            // chIODevice
            // 
            chIODevice.Text = "I/O device";
            chIODevice.Width = 99;
            // 
            // lvIODevices
            // 
            lvIODevices.AlternatingColorEven = System.Drawing.Color.LightBlue;
            lvIODevices.AlternatingColorOdd = System.Drawing.SystemColors.Window;
            lvIODevices.AlternatingColorsAreInUse = true;
            lvIODevices.AlternatingPairColorEven = System.Drawing.Color.LightSeaGreen;
            lvIODevices.AlternatingPairColorOdd = System.Drawing.Color.CadetBlue;
            lvIODevices.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { chIODevice, chPortNumber, chPortName, chFriendlyName, chMaxSignalPerDay, chMinTriggerTime });
            lvIODevices.CompactView = false;
            lvIODevices.ContextMenuStrip = cmsChangeSettings;
            lvIODevices.Dock = System.Windows.Forms.DockStyle.Fill;
            lvIODevices.EnsureLastItemIsVisible = false;
            lvIODevices.FirstItemIsGray = false;
            lvIODevices.FullRowSelect = true;
            lvIODevices.Location = new System.Drawing.Point(0, 0);
            lvIODevices.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            lvIODevices.MultiSelect = false;
            lvIODevices.Name = "lvIODevices";
            lvIODevices.OwnerDraw = true;
            lvIODevices.ReadonlyCheckboxes = false;
            lvIODevices.SameItemsColorEven = System.Drawing.Color.DarkOrange;
            lvIODevices.SameItemsColorOdd = System.Drawing.Color.LightSalmon;
            lvIODevices.Size = new System.Drawing.Size(915, 285);
            lvIODevices.TabIndex = 0;
            lvIODevices.UseCompatibleStateImageBehavior = false;
            lvIODevices.View = System.Windows.Forms.View.Details;
            // 
            // pUpper
            // 
            pUpper.Controls.Add(lvIODevices);
            pUpper.Dock = System.Windows.Forms.DockStyle.Top;
            pUpper.Location = new System.Drawing.Point(0, 0);
            pUpper.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pUpper.Name = "pUpper";
            pUpper.Size = new System.Drawing.Size(915, 285);
            pUpper.TabIndex = 3;
            // 
            // IOPortSettings
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(915, 517);
            Controls.Add(pLower);
            Controls.Add(pUpper);
            Controls.Add(pMain);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "IOPortSettings";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "I/O ports' settings";
            Shown += IOPortSettings_Shown;
            cmdDeleteRules.ResumeLayout(false);
            pLower.ResumeLayout(false);
            gbIORules.ResumeLayout(false);
            gbIORules.PerformLayout();
            cmsChangeSettings.ResumeLayout(false);
            pUpper.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pMain;
        private System.Windows.Forms.ComboBox cbOutputIOPort;
        private System.Windows.Forms.Label lblIODevice;
        private System.Windows.Forms.CheckBox chkZeroSignalled;
        private Mtf.Controls.MtfListView lvIOPortRules;
        private System.Windows.Forms.ColumnHeader chRuleIODevice;
        private System.Windows.Forms.ColumnHeader chOutputIOPort;
        private System.Windows.Forms.ColumnHeader chOperationOrEvent;
        private System.Windows.Forms.ColumnHeader chZeroSignaled;
        private System.Windows.Forms.ContextMenuStrip cmdDeleteRules;
        private System.Windows.Forms.ToolStripMenuItem deleteRulesToolStripMenuItem;
        private System.Windows.Forms.Label lblOutputIOPort;
        private System.Windows.Forms.Button btnAddToRules;
        private System.Windows.Forms.Label lblOperationOrEvent;
        private System.Windows.Forms.ComboBox cbIODevice;
        private System.Windows.Forms.ComboBox cbOperationOrEvent;
        private System.Windows.Forms.Panel pLower;
        private System.Windows.Forms.GroupBox gbIORules;
        private System.Windows.Forms.ToolStripMenuItem changeFriendlyNameToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmsChangeSettings;
        private System.Windows.Forms.ColumnHeader chMinTriggerTime;
        private System.Windows.Forms.ColumnHeader chMaxSignalPerDay;
        private System.Windows.Forms.ColumnHeader chFriendlyName;
        private System.Windows.Forms.ColumnHeader chPortName;
        private System.Windows.Forms.ColumnHeader chPortNumber;
        private System.Windows.Forms.ColumnHeader chIODevice;
        private Mtf.Controls.MtfListView lvIODevices;
        private System.Windows.Forms.Panel pUpper;
    }
}