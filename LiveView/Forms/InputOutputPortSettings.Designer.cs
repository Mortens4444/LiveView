namespace LiveView.Forms
{
    partial class InputOutputPortSettings
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
            pMain = new System.Windows.Forms.Panel();
            lblIODevice = new System.Windows.Forms.Label();
            chkZeroSignalled = new System.Windows.Forms.CheckBox();
            lvInputOutputPortRules = new Mtf.Controls.MtfListView();
            chRuleIODevice = new System.Windows.Forms.ColumnHeader();
            chOutputInputOutputPort = new System.Windows.Forms.ColumnHeader();
            chOperationOrEvent = new System.Windows.Forms.ColumnHeader();
            chZeroSignalled = new System.Windows.Forms.ColumnHeader();
            cmdDeleteRules = new System.Windows.Forms.ContextMenuStrip(components);
            deleteRulesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            lblOutputInputOutputPort = new System.Windows.Forms.Label();
            btnAddToRules = new System.Windows.Forms.Button();
            cbOutputInputOutputPort = new System.Windows.Forms.ComboBox();
            lblOperationOrEvent = new System.Windows.Forms.Label();
            cbInputOutputDevice = new System.Windows.Forms.ComboBox();
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
            lvInputOutputDevices = new Mtf.Controls.MtfListView();
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
            // lvInputOutputPortRules
            // 
            lvInputOutputPortRules.AlternatingColorEven = System.Drawing.Color.LightBlue;
            lvInputOutputPortRules.AlternatingColorOdd = System.Drawing.SystemColors.Window;
            lvInputOutputPortRules.AlternatingColorsAreInUse = true;
            lvInputOutputPortRules.AlternatingPairColorEven = System.Drawing.Color.LightSeaGreen;
            lvInputOutputPortRules.AlternatingPairColorOdd = System.Drawing.Color.CadetBlue;
            lvInputOutputPortRules.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            lvInputOutputPortRules.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { chRuleIODevice, chOutputInputOutputPort, chOperationOrEvent, chZeroSignalled });
            lvInputOutputPortRules.CompactView = false;
            lvInputOutputPortRules.ContextMenuStrip = cmdDeleteRules;
            lvInputOutputPortRules.EnsureLastItemIsVisible = false;
            lvInputOutputPortRules.FirstItemIsGray = false;
            lvInputOutputPortRules.FullRowSelect = true;
            lvInputOutputPortRules.Location = new System.Drawing.Point(4, 77);
            lvInputOutputPortRules.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            lvInputOutputPortRules.Name = "lvInputOutputPortRules";
            lvInputOutputPortRules.OwnerDraw = true;
            lvInputOutputPortRules.ReadonlyCheckboxes = false;
            lvInputOutputPortRules.SameItemsColorEven = System.Drawing.Color.DarkOrange;
            lvInputOutputPortRules.SameItemsColorOdd = System.Drawing.Color.LightSalmon;
            lvInputOutputPortRules.Size = new System.Drawing.Size(907, 151);
            lvInputOutputPortRules.TabIndex = 5;
            lvInputOutputPortRules.UseCompatibleStateImageBehavior = false;
            lvInputOutputPortRules.View = System.Windows.Forms.View.Details;
            // 
            // chRuleIODevice
            // 
            chRuleIODevice.Text = "I/O Device";
            chRuleIODevice.Width = 102;
            // 
            // chOutputInputOutputPort
            // 
            chOutputInputOutputPort.Text = "Output I/O port";
            chOutputInputOutputPort.Width = 183;
            // 
            // chOperationOrEvent
            // 
            chOperationOrEvent.Text = "Operation or event";
            chOperationOrEvent.Width = 184;
            // 
            // chZeroSignalled
            // 
            chZeroSignalled.Text = "Zero signalled";
            chZeroSignalled.Width = 81;
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
            deleteRulesToolStripMenuItem.Click += DeleteRulesToolStripMenuItem_Click;
            // 
            // lblOutputInputOutputPort
            // 
            lblOutputInputOutputPort.AutoSize = true;
            lblOutputInputOutputPort.Location = new System.Drawing.Point(122, 28);
            lblOutputInputOutputPort.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblOutputInputOutputPort.Name = "lblOutputInputOutputPort";
            lblOutputInputOutputPort.Size = new System.Drawing.Size(90, 15);
            lblOutputInputOutputPort.TabIndex = 2;
            lblOutputInputOutputPort.Text = "Output I/O port";
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
            // cbOutputInputOutputPort
            // 
            cbOutputInputOutputPort.FormattingEnabled = true;
            cbOutputInputOutputPort.Location = new System.Drawing.Point(122, 46);
            cbOutputInputOutputPort.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cbOutputInputOutputPort.Name = "cbOutputInputOutputPort";
            cbOutputInputOutputPort.Size = new System.Drawing.Size(207, 23);
            cbOutputInputOutputPort.TabIndex = 1;
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
            // cbIODevice
            // 
            cbInputOutputDevice.FormattingEnabled = true;
            cbInputOutputDevice.Location = new System.Drawing.Point(4, 46);
            cbInputOutputDevice.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cbInputOutputDevice.Name = "cbIODevice";
            cbInputOutputDevice.Size = new System.Drawing.Size(108, 23);
            cbInputOutputDevice.TabIndex = 9;
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
            gbIORules.Controls.Add(cbInputOutputDevice);
            gbIORules.Controls.Add(chkZeroSignalled);
            gbIORules.Controls.Add(lvInputOutputPortRules);
            gbIORules.Controls.Add(btnAddToRules);
            gbIORules.Controls.Add(lblOperationOrEvent);
            gbIORules.Controls.Add(cbOutputInputOutputPort);
            gbIORules.Controls.Add(lblOutputInputOutputPort);
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
            changeFriendlyNameToolStripMenuItem.Click += ChangeSettingsToolStripMenuItem_Click;
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
            lvInputOutputDevices.AlternatingColorEven = System.Drawing.Color.LightBlue;
            lvInputOutputDevices.AlternatingColorOdd = System.Drawing.SystemColors.Window;
            lvInputOutputDevices.AlternatingColorsAreInUse = true;
            lvInputOutputDevices.AlternatingPairColorEven = System.Drawing.Color.LightSeaGreen;
            lvInputOutputDevices.AlternatingPairColorOdd = System.Drawing.Color.CadetBlue;
            lvInputOutputDevices.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { chIODevice, chPortNumber, chPortName, chFriendlyName, chMaxSignalPerDay, chMinTriggerTime });
            lvInputOutputDevices.CompactView = false;
            lvInputOutputDevices.ContextMenuStrip = cmsChangeSettings;
            lvInputOutputDevices.Dock = System.Windows.Forms.DockStyle.Fill;
            lvInputOutputDevices.EnsureLastItemIsVisible = false;
            lvInputOutputDevices.FirstItemIsGray = false;
            lvInputOutputDevices.FullRowSelect = true;
            lvInputOutputDevices.Location = new System.Drawing.Point(0, 0);
            lvInputOutputDevices.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            lvInputOutputDevices.MultiSelect = false;
            lvInputOutputDevices.Name = "lvIODevices";
            lvInputOutputDevices.OwnerDraw = true;
            lvInputOutputDevices.ReadonlyCheckboxes = false;
            lvInputOutputDevices.SameItemsColorEven = System.Drawing.Color.DarkOrange;
            lvInputOutputDevices.SameItemsColorOdd = System.Drawing.Color.LightSalmon;
            lvInputOutputDevices.Size = new System.Drawing.Size(915, 285);
            lvInputOutputDevices.TabIndex = 0;
            lvInputOutputDevices.UseCompatibleStateImageBehavior = false;
            lvInputOutputDevices.View = System.Windows.Forms.View.Details;
            // 
            // pUpper
            // 
            pUpper.Controls.Add(lvInputOutputDevices);
            pUpper.Dock = System.Windows.Forms.DockStyle.Top;
            pUpper.Location = new System.Drawing.Point(0, 0);
            pUpper.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pUpper.Name = "pUpper";
            pUpper.Size = new System.Drawing.Size(915, 285);
            pUpper.TabIndex = 3;
            // 
            // InputOutputPortSettings
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(915, 517);
            Controls.Add(pLower);
            Controls.Add(pUpper);
            Controls.Add(pMain);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "InputOutputPortSettings";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "I/O ports’ settings";
            Shown += InputOutputPortSettings_Shown;
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
        private System.Windows.Forms.ComboBox cbOutputInputOutputPort;
        private System.Windows.Forms.Label lblIODevice;
        private System.Windows.Forms.CheckBox chkZeroSignalled;
        private Mtf.Controls.MtfListView lvInputOutputPortRules;
        private System.Windows.Forms.ColumnHeader chRuleIODevice;
        private System.Windows.Forms.ColumnHeader chOutputInputOutputPort;
        private System.Windows.Forms.ColumnHeader chOperationOrEvent;
        private System.Windows.Forms.ColumnHeader chZeroSignalled;
        private System.Windows.Forms.ContextMenuStrip cmdDeleteRules;
        private System.Windows.Forms.ToolStripMenuItem deleteRulesToolStripMenuItem;
        private System.Windows.Forms.Label lblOutputInputOutputPort;
        private System.Windows.Forms.Button btnAddToRules;
        private System.Windows.Forms.Label lblOperationOrEvent;
        private System.Windows.Forms.ComboBox cbInputOutputDevice;
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
        private Mtf.Controls.MtfListView lvInputOutputDevices;
        private System.Windows.Forms.Panel pUpper;
    }
}