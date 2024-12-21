namespace LiveView.Forms
{
    partial class AutoCreateWizard
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(AutoCreateWizard));
            chLeftHeader = new System.Windows.Forms.ColumnHeader();
            btnRemoveAll = new System.Windows.Forms.Button();
            btnAdd = new System.Windows.Forms.Button();
            tblblSequenceNamePostfix = new System.Windows.Forms.TextBox();
            lblSequenceNamePostfix = new System.Windows.Forms.Label();
            tbSequenceNamePrefix = new System.Windows.Forms.TextBox();
            lblSequenceNamePrefix = new System.Windows.Forms.Label();
            tbGridNamePostfix = new System.Windows.Forms.TextBox();
            lblGridNamePostfix = new System.Windows.Forms.Label();
            btnRemove = new System.Windows.Forms.Button();
            tbGridNamePrefix = new System.Windows.Forms.TextBox();
            cbX = new System.Windows.Forms.ComboBox();
            lblSelectGridLook = new System.Windows.Forms.Label();
            cbSelectGridLook = new System.Windows.Forms.ComboBox();
            btnAddAll = new System.Windows.Forms.Button();
            lblStatus = new System.Windows.Forms.Label();
            pbCheck = new Mtf.Controls.MtfPictureBox();
            lblGridNamePrefix = new System.Windows.Forms.Label();
            btnAutoCreate = new System.Windows.Forms.Button();
            chkCreateSequences = new System.Windows.Forms.CheckBox();
            chRightHeader = new System.Windows.Forms.ColumnHeader();
            lvRightSide = new Mtf.Controls.MtfListView();
            ilImages = new System.Windows.Forms.ImageList(components);
            pLists = new System.Windows.Forms.Panel();
            lvLeftSide = new Mtf.Controls.MtfListView();
            btnClose = new System.Windows.Forms.Button();
            pFooter = new System.Windows.Forms.Panel();
            pControl = new System.Windows.Forms.Panel();
            gbMain = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)pbCheck).BeginInit();
            pLists.SuspendLayout();
            pFooter.SuspendLayout();
            pControl.SuspendLayout();
            gbMain.SuspendLayout();
            SuspendLayout();
            // 
            // chLeftHeader
            // 
            chLeftHeader.Width = 251;
            // 
            // btnRemoveAll
            // 
            btnRemoveAll.Anchor = System.Windows.Forms.AnchorStyles.Top;
            btnRemoveAll.Location = new System.Drawing.Point(306, 173);
            btnRemoveAll.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnRemoveAll.Name = "btnRemoveAll";
            btnRemoveAll.Size = new System.Drawing.Size(33, 27);
            btnRemoveAll.TabIndex = 5;
            btnRemoveAll.UseVisualStyleBackColor = true;
            btnRemoveAll.Click += BtnRemoveAll_Click;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Top;
            btnAdd.Location = new System.Drawing.Point(306, 73);
            btnAdd.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new System.Drawing.Size(33, 27);
            btnAdd.TabIndex = 2;
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += BtnAdd_Click;
            // 
            // tblblSequenceNamePostfix
            // 
            tblblSequenceNamePostfix.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            tblblSequenceNamePostfix.Location = new System.Drawing.Point(516, 493);
            tblblSequenceNamePostfix.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tblblSequenceNamePostfix.Name = "tblblSequenceNamePostfix";
            tblblSequenceNamePostfix.Size = new System.Drawing.Size(128, 23);
            tblblSequenceNamePostfix.TabIndex = 13;
            // 
            // lblSequenceNamePostfix
            // 
            lblSequenceNamePostfix.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            lblSequenceNamePostfix.AutoSize = true;
            lblSequenceNamePostfix.Location = new System.Drawing.Point(342, 496);
            lblSequenceNamePostfix.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblSequenceNamePostfix.Name = "lblSequenceNamePostfix";
            lblSequenceNamePostfix.Size = new System.Drawing.Size(129, 15);
            lblSequenceNamePostfix.TabIndex = 12;
            lblSequenceNamePostfix.Text = "Sequence name postfix";
            // 
            // tbSequenceNamePrefix
            // 
            tbSequenceNamePrefix.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            tbSequenceNamePrefix.Location = new System.Drawing.Point(171, 493);
            tbSequenceNamePrefix.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tbSequenceNamePrefix.Name = "tbSequenceNamePrefix";
            tbSequenceNamePrefix.Size = new System.Drawing.Size(128, 23);
            tbSequenceNamePrefix.TabIndex = 11;
            // 
            // lblSequenceNamePrefix
            // 
            lblSequenceNamePrefix.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            lblSequenceNamePrefix.AutoSize = true;
            lblSequenceNamePrefix.Location = new System.Drawing.Point(3, 496);
            lblSequenceNamePrefix.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblSequenceNamePrefix.Name = "lblSequenceNamePrefix";
            lblSequenceNamePrefix.Size = new System.Drawing.Size(123, 15);
            lblSequenceNamePrefix.TabIndex = 10;
            lblSequenceNamePrefix.Text = "Sequence name prefix";
            // 
            // tbGridNamePostfix
            // 
            tbGridNamePostfix.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            tbGridNamePostfix.Location = new System.Drawing.Point(516, 435);
            tbGridNamePostfix.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tbGridNamePostfix.Name = "tbGridNamePostfix";
            tbGridNamePostfix.Size = new System.Drawing.Size(128, 23);
            tbGridNamePostfix.TabIndex = 7;
            // 
            // lblGridNamePostfix
            // 
            lblGridNamePostfix.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            lblGridNamePostfix.AutoSize = true;
            lblGridNamePostfix.Location = new System.Drawing.Point(342, 438);
            lblGridNamePostfix.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblGridNamePostfix.Name = "lblGridNamePostfix";
            lblGridNamePostfix.Size = new System.Drawing.Size(100, 15);
            lblGridNamePostfix.TabIndex = 6;
            lblGridNamePostfix.Text = "Grid name postfix";
            // 
            // btnRemove
            // 
            btnRemove.Anchor = System.Windows.Forms.AnchorStyles.Top;
            btnRemove.Location = new System.Drawing.Point(306, 140);
            btnRemove.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new System.Drawing.Size(33, 27);
            btnRemove.TabIndex = 4;
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += BtnRemove_Click;
            // 
            // tbGridNamePrefix
            // 
            tbGridNamePrefix.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            tbGridNamePrefix.Location = new System.Drawing.Point(171, 435);
            tbGridNamePrefix.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tbGridNamePrefix.Name = "tbGridNamePrefix";
            tbGridNamePrefix.Size = new System.Drawing.Size(128, 23);
            tbGridNamePrefix.TabIndex = 5;
            // 
            // cbX
            // 
            cbX.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            cbX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbX.FormattingEnabled = true;
            cbX.Location = new System.Drawing.Point(516, 464);
            cbX.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cbX.Name = "cbX";
            cbX.Size = new System.Drawing.Size(128, 23);
            cbX.TabIndex = 9;
            // 
            // lblSelectGridLook
            // 
            lblSelectGridLook.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            lblSelectGridLook.AutoSize = true;
            lblSelectGridLook.Location = new System.Drawing.Point(3, 408);
            lblSelectGridLook.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblSelectGridLook.Name = "lblSelectGridLook";
            lblSelectGridLook.Size = new System.Drawing.Size(97, 15);
            lblSelectGridLook.TabIndex = 1;
            lblSelectGridLook.Text = "Select a grid look";
            // 
            // cbSelectGridLook
            // 
            cbSelectGridLook.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            cbSelectGridLook.FormattingEnabled = true;
            cbSelectGridLook.Location = new System.Drawing.Point(454, 405);
            cbSelectGridLook.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cbSelectGridLook.Name = "cbSelectGridLook";
            cbSelectGridLook.Size = new System.Drawing.Size(191, 23);
            cbSelectGridLook.TabIndex = 3;
            // 
            // btnAddAll
            // 
            btnAddAll.Anchor = System.Windows.Forms.AnchorStyles.Top;
            btnAddAll.Location = new System.Drawing.Point(306, 106);
            btnAddAll.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnAddAll.Name = "btnAddAll";
            btnAddAll.Size = new System.Drawing.Size(33, 27);
            btnAddAll.TabIndex = 3;
            btnAddAll.UseVisualStyleBackColor = true;
            btnAddAll.Click += BtnAddAll_Click;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new System.Drawing.Point(33, 10);
            lblStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new System.Drawing.Size(0, 15);
            lblStatus.TabIndex = 0;
            // 
            // pbCheck
            // 
            pbCheck.Location = new System.Drawing.Point(7, 9);
            pbCheck.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pbCheck.Name = "pbCheck";
            pbCheck.OriginalSize = new System.Drawing.Size(100, 50);
            pbCheck.RepositioningAndResizingControlsOnResize = false;
            pbCheck.Size = new System.Drawing.Size(19, 18);
            pbCheck.TabIndex = 2;
            pbCheck.TabStop = false;
            // 
            // lblGridNamePrefix
            // 
            lblGridNamePrefix.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            lblGridNamePrefix.AutoSize = true;
            lblGridNamePrefix.Location = new System.Drawing.Point(3, 438);
            lblGridNamePrefix.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblGridNamePrefix.Name = "lblGridNamePrefix";
            lblGridNamePrefix.Size = new System.Drawing.Size(94, 15);
            lblGridNamePrefix.TabIndex = 4;
            lblGridNamePrefix.Text = "Grid name prefix";
            // 
            // btnAutoCreate
            // 
            btnAutoCreate.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnAutoCreate.DialogResult = System.Windows.Forms.DialogResult.OK;
            btnAutoCreate.Enabled = false;
            btnAutoCreate.Location = new System.Drawing.Point(463, 5);
            btnAutoCreate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnAutoCreate.Name = "btnAutoCreate";
            btnAutoCreate.Size = new System.Drawing.Size(88, 27);
            btnAutoCreate.TabIndex = 1;
            btnAutoCreate.Text = "Auto create";
            btnAutoCreate.UseVisualStyleBackColor = true;
            btnAutoCreate.Click += BtnAutoCreate_Click;
            // 
            // chkCreateSequences
            // 
            chkCreateSequences.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            chkCreateSequences.AutoSize = true;
            chkCreateSequences.Checked = true;
            chkCreateSequences.CheckState = System.Windows.Forms.CheckState.Checked;
            chkCreateSequences.Location = new System.Drawing.Point(6, 469);
            chkCreateSequences.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            chkCreateSequences.MaximumSize = new System.Drawing.Size(321, 20);
            chkCreateSequences.Name = "chkCreateSequences";
            chkCreateSequences.Size = new System.Drawing.Size(230, 19);
            chkCreateSequences.TabIndex = 8;
            chkCreateSequences.Tag = "";
            chkCreateSequences.Text = "Create a sequence from every x-th grid";
            chkCreateSequences.UseVisualStyleBackColor = true;
            // 
            // chRightHeader
            // 
            chRightHeader.Width = 252;
            // 
            // lvRightSide
            // 
            lvRightSide.AlternatingColorEven = System.Drawing.Color.LightBlue;
            lvRightSide.AlternatingColorOdd = System.Drawing.SystemColors.Window;
            lvRightSide.AlternatingColorsAreInUse = true;
            lvRightSide.AlternatingPairColorEven = System.Drawing.Color.LightSeaGreen;
            lvRightSide.AlternatingPairColorOdd = System.Drawing.Color.CadetBlue;
            lvRightSide.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            lvRightSide.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { chRightHeader });
            lvRightSide.CompactView = false;
            lvRightSide.EnsureLastItemIsVisible = false;
            lvRightSide.FirstItemIsGray = false;
            lvRightSide.FullRowSelect = true;
            lvRightSide.Location = new System.Drawing.Point(345, 8);
            lvRightSide.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            lvRightSide.Name = "lvRightSide";
            lvRightSide.OwnerDraw = true;
            lvRightSide.ReadonlyCheckboxes = false;
            lvRightSide.SameItemsColorEven = System.Drawing.Color.DarkOrange;
            lvRightSide.SameItemsColorOdd = System.Drawing.Color.LightSalmon;
            lvRightSide.Size = new System.Drawing.Size(298, 394);
            lvRightSide.SmallImageList = ilImages;
            lvRightSide.TabIndex = 1;
            lvRightSide.UseCompatibleStateImageBehavior = false;
            lvRightSide.View = System.Windows.Forms.View.Details;
            // 
            // ilImages
            // 
            ilImages.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            ilImages.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("ilImages.ImageStream");
            ilImages.TransparentColor = System.Drawing.Color.Transparent;
            ilImages.Images.SetKeyName(0, "cam 0.ico");
            ilImages.Images.SetKeyName(1, "tick.ico");
            ilImages.Images.SetKeyName(2, "del.ico");
            // 
            // pLists
            // 
            pLists.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            pLists.Controls.Add(lvRightSide);
            pLists.Controls.Add(lvLeftSide);
            pLists.Controls.Add(btnAddAll);
            pLists.Controls.Add(btnRemoveAll);
            pLists.Controls.Add(btnAdd);
            pLists.Controls.Add(btnRemove);
            pLists.Location = new System.Drawing.Point(0, -8);
            pLists.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pLists.Name = "pLists";
            pLists.Size = new System.Drawing.Size(649, 406);
            pLists.TabIndex = 0;
            // 
            // lvLeftSide
            // 
            lvLeftSide.AlternatingColorEven = System.Drawing.Color.LightBlue;
            lvLeftSide.AlternatingColorOdd = System.Drawing.SystemColors.Window;
            lvLeftSide.AlternatingColorsAreInUse = true;
            lvLeftSide.AlternatingPairColorEven = System.Drawing.Color.LightSeaGreen;
            lvLeftSide.AlternatingPairColorOdd = System.Drawing.Color.CadetBlue;
            lvLeftSide.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            lvLeftSide.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { chLeftHeader });
            lvLeftSide.CompactView = false;
            lvLeftSide.EnsureLastItemIsVisible = false;
            lvLeftSide.FirstItemIsGray = false;
            lvLeftSide.FullRowSelect = true;
            lvLeftSide.Location = new System.Drawing.Point(1, 8);
            lvLeftSide.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            lvLeftSide.Name = "lvLeftSide";
            lvLeftSide.OwnerDraw = true;
            lvLeftSide.ReadonlyCheckboxes = false;
            lvLeftSide.SameItemsColorEven = System.Drawing.Color.DarkOrange;
            lvLeftSide.SameItemsColorOdd = System.Drawing.Color.LightSalmon;
            lvLeftSide.Size = new System.Drawing.Size(298, 394);
            lvLeftSide.SmallImageList = ilImages;
            lvLeftSide.TabIndex = 0;
            lvLeftSide.UseCompatibleStateImageBehavior = false;
            lvLeftSide.View = System.Windows.Forms.View.Details;
            // 
            // btnClose
            // 
            btnClose.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            btnClose.Location = new System.Drawing.Point(558, 5);
            btnClose.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnClose.Name = "btnClose";
            btnClose.Size = new System.Drawing.Size(88, 27);
            btnClose.TabIndex = 2;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += BtnCancel_Click;
            // 
            // pFooter
            // 
            pFooter.Controls.Add(lblStatus);
            pFooter.Controls.Add(pbCheck);
            pFooter.Controls.Add(btnClose);
            pFooter.Controls.Add(btnAutoCreate);
            pFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            pFooter.Location = new System.Drawing.Point(0, 518);
            pFooter.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pFooter.Name = "pFooter";
            pFooter.Size = new System.Drawing.Size(649, 36);
            pFooter.TabIndex = 14;
            // 
            // pControl
            // 
            pControl.Controls.Add(tblblSequenceNamePostfix);
            pControl.Controls.Add(lblSequenceNamePostfix);
            pControl.Controls.Add(tbSequenceNamePrefix);
            pControl.Controls.Add(lblSequenceNamePrefix);
            pControl.Controls.Add(tbGridNamePostfix);
            pControl.Controls.Add(lblGridNamePostfix);
            pControl.Controls.Add(tbGridNamePrefix);
            pControl.Controls.Add(lblGridNamePrefix);
            pControl.Controls.Add(cbX);
            pControl.Controls.Add(lblSelectGridLook);
            pControl.Controls.Add(cbSelectGridLook);
            pControl.Controls.Add(chkCreateSequences);
            pControl.Controls.Add(pLists);
            pControl.Controls.Add(pFooter);
            pControl.Dock = System.Windows.Forms.DockStyle.Fill;
            pControl.Location = new System.Drawing.Point(4, 19);
            pControl.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pControl.Name = "pControl";
            pControl.Size = new System.Drawing.Size(649, 554);
            pControl.TabIndex = 0;
            // 
            // gbMain
            // 
            gbMain.Controls.Add(pControl);
            gbMain.Dock = System.Windows.Forms.DockStyle.Fill;
            gbMain.Location = new System.Drawing.Point(0, 0);
            gbMain.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbMain.Name = "gbMain";
            gbMain.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbMain.Size = new System.Drawing.Size(657, 576);
            gbMain.TabIndex = 1;
            gbMain.TabStop = false;
            // 
            // AutoCreateWizard
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(657, 576);
            Controls.Add(gbMain);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MinimumSize = new System.Drawing.Size(664, 559);
            Name = "AutoCreateWizard";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Auto create wizard";
            Shown += AutoCreateWizard_Shown;
            ((System.ComponentModel.ISupportInitialize)pbCheck).EndInit();
            pLists.ResumeLayout(false);
            pFooter.ResumeLayout(false);
            pFooter.PerformLayout();
            pControl.ResumeLayout(false);
            pControl.PerformLayout();
            gbMain.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.ColumnHeader chLeftHeader;
        private System.Windows.Forms.Button btnRemoveAll;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox tblblSequenceNamePostfix;
        private System.Windows.Forms.Label lblSequenceNamePostfix;
        private System.Windows.Forms.TextBox tbSequenceNamePrefix;
        private System.Windows.Forms.Label lblSequenceNamePrefix;
        private System.Windows.Forms.TextBox tbGridNamePostfix;
        private System.Windows.Forms.Label lblGridNamePostfix;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.TextBox tbGridNamePrefix;
        private System.Windows.Forms.ComboBox cbX;
        private System.Windows.Forms.Label lblSelectGridLook;
        private System.Windows.Forms.ComboBox cbSelectGridLook;
        private System.Windows.Forms.Button btnAddAll;
        private System.Windows.Forms.Label lblStatus;
        private Mtf.Controls.MtfPictureBox pbCheck;
        private System.Windows.Forms.Label lblGridNamePrefix;
        private System.Windows.Forms.Button btnAutoCreate;
        private System.Windows.Forms.CheckBox chkCreateSequences;
        private System.Windows.Forms.ColumnHeader chRightHeader;
        private Mtf.Controls.MtfListView lvRightSide;
        private System.Windows.Forms.ImageList ilImages;
        private System.Windows.Forms.Panel pLists;
        private Mtf.Controls.MtfListView lvLeftSide;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel pFooter;
        private System.Windows.Forms.Panel pControl;
        private System.Windows.Forms.GroupBox gbMain;
    }
}