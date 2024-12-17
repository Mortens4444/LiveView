namespace LiveView.Forms
{
    partial class DisplaySettings
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(DisplaySettings));
            pMain = new System.Windows.Forms.Panel();
            btnResetDisplays = new System.Windows.Forms.Button();
            gbFullscreenViewBehavior = new System.Windows.Forms.GroupBox();
            pRight = new System.Windows.Forms.Panel();
            lblOpenFromSequenceWindow = new System.Windows.Forms.Label();
            rbShowOnControlCentersSelectedDisplay2 = new System.Windows.Forms.RadioButton();
            rbShowOnFullscreenDisplay2 = new System.Windows.Forms.RadioButton();
            pLeft = new System.Windows.Forms.Panel();
            lblOpenFromControlCenter = new System.Windows.Forms.Label();
            rbShowOnFullscreenDisplay = new System.Windows.Forms.RadioButton();
            rbShowOnControlCentersSelectedDisplay = new System.Windows.Forms.RadioButton();
            btnIdentify = new System.Windows.Forms.Button();
            btnClose = new System.Windows.Forms.Button();
            btnSave = new System.Windows.Forms.Button();
            gbFullscreenDisplay = new System.Windows.Forms.GroupBox();
            pFullscreenDisplay = new System.Windows.Forms.Panel();
            gbFunctionChooser = new System.Windows.Forms.GroupBox();
            pFunctionChooser = new System.Windows.Forms.Panel();
            pMain.SuspendLayout();
            gbFullscreenViewBehavior.SuspendLayout();
            pRight.SuspendLayout();
            pLeft.SuspendLayout();
            gbFullscreenDisplay.SuspendLayout();
            gbFunctionChooser.SuspendLayout();
            SuspendLayout();
            // 
            // pMain
            // 
            pMain.Controls.Add(btnResetDisplays);
            pMain.Controls.Add(gbFullscreenViewBehavior);
            pMain.Controls.Add(btnIdentify);
            pMain.Controls.Add(btnClose);
            pMain.Controls.Add(btnSave);
            pMain.Controls.Add(gbFullscreenDisplay);
            pMain.Controls.Add(gbFunctionChooser);
            pMain.Dock = System.Windows.Forms.DockStyle.Fill;
            pMain.Location = new System.Drawing.Point(0, 0);
            pMain.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pMain.Name = "pMain";
            pMain.Size = new System.Drawing.Size(630, 558);
            pMain.TabIndex = 0;
            // 
            // btnResetDisplays
            // 
            btnResetDisplays.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btnResetDisplays.Location = new System.Drawing.Point(5, 525);
            btnResetDisplays.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnResetDisplays.Name = "btnResetDisplays";
            btnResetDisplays.Size = new System.Drawing.Size(190, 27);
            btnResetDisplays.TabIndex = 15;
            btnResetDisplays.Text = "Reset displays";
            btnResetDisplays.UseVisualStyleBackColor = true;
            btnResetDisplays.Click += BtnResetDisplays_Click;
            // 
            // gbFullscreenViewBehavior
            // 
            gbFullscreenViewBehavior.Controls.Add(pRight);
            gbFullscreenViewBehavior.Controls.Add(pLeft);
            gbFullscreenViewBehavior.Dock = System.Windows.Forms.DockStyle.Top;
            gbFullscreenViewBehavior.Location = new System.Drawing.Point(0, 424);
            gbFullscreenViewBehavior.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbFullscreenViewBehavior.Name = "gbFullscreenViewBehavior";
            gbFullscreenViewBehavior.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbFullscreenViewBehavior.Size = new System.Drawing.Size(630, 96);
            gbFullscreenViewBehavior.TabIndex = 10;
            gbFullscreenViewBehavior.TabStop = false;
            gbFullscreenViewBehavior.Text = "Behavior of opening full screen view";
            // 
            // pRight
            // 
            pRight.Controls.Add(lblOpenFromSequenceWindow);
            pRight.Controls.Add(rbShowOnControlCentersSelectedDisplay2);
            pRight.Controls.Add(rbShowOnFullscreenDisplay2);
            pRight.Dock = System.Windows.Forms.DockStyle.Fill;
            pRight.Location = new System.Drawing.Point(316, 19);
            pRight.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pRight.Name = "pRight";
            pRight.Size = new System.Drawing.Size(310, 74);
            pRight.TabIndex = 1;
            // 
            // lblOpenFromSequenceWindow
            // 
            lblOpenFromSequenceWindow.AutoSize = true;
            lblOpenFromSequenceWindow.Location = new System.Drawing.Point(5, 5);
            lblOpenFromSequenceWindow.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblOpenFromSequenceWindow.Name = "lblOpenFromSequenceWindow";
            lblOpenFromSequenceWindow.Size = new System.Drawing.Size(163, 15);
            lblOpenFromSequenceWindow.TabIndex = 0;
            lblOpenFromSequenceWindow.Text = "Open from sequence window";
            // 
            // rbShowOnControlCentersSelectedDisplay2
            // 
            rbShowOnControlCentersSelectedDisplay2.AutoSize = true;
            rbShowOnControlCentersSelectedDisplay2.Checked = true;
            rbShowOnControlCentersSelectedDisplay2.Location = new System.Drawing.Point(8, 23);
            rbShowOnControlCentersSelectedDisplay2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            rbShowOnControlCentersSelectedDisplay2.Name = "rbShowOnControlCentersSelectedDisplay2";
            rbShowOnControlCentersSelectedDisplay2.Size = new System.Drawing.Size(242, 19);
            rbShowOnControlCentersSelectedDisplay2.TabIndex = 1;
            rbShowOnControlCentersSelectedDisplay2.TabStop = true;
            rbShowOnControlCentersSelectedDisplay2.Text = "Show on control center's selected display";
            rbShowOnControlCentersSelectedDisplay2.UseVisualStyleBackColor = true;
            // 
            // rbShowOnFullscreenDisplay2
            // 
            rbShowOnFullscreenDisplay2.AutoSize = true;
            rbShowOnFullscreenDisplay2.Location = new System.Drawing.Point(8, 50);
            rbShowOnFullscreenDisplay2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            rbShowOnFullscreenDisplay2.Name = "rbShowOnFullscreenDisplay2";
            rbShowOnFullscreenDisplay2.Size = new System.Drawing.Size(168, 19);
            rbShowOnFullscreenDisplay2.TabIndex = 2;
            rbShowOnFullscreenDisplay2.Text = "Show on full screen display";
            rbShowOnFullscreenDisplay2.UseVisualStyleBackColor = true;
            // 
            // pLeft
            // 
            pLeft.Controls.Add(lblOpenFromControlCenter);
            pLeft.Controls.Add(rbShowOnFullscreenDisplay);
            pLeft.Controls.Add(rbShowOnControlCentersSelectedDisplay);
            pLeft.Dock = System.Windows.Forms.DockStyle.Left;
            pLeft.Location = new System.Drawing.Point(4, 19);
            pLeft.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pLeft.Name = "pLeft";
            pLeft.Size = new System.Drawing.Size(312, 74);
            pLeft.TabIndex = 0;
            // 
            // lblOpenFromControlCenter
            // 
            lblOpenFromControlCenter.AutoSize = true;
            lblOpenFromControlCenter.Location = new System.Drawing.Point(5, 5);
            lblOpenFromControlCenter.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblOpenFromControlCenter.Name = "lblOpenFromControlCenter";
            lblOpenFromControlCenter.Size = new System.Drawing.Size(142, 15);
            lblOpenFromControlCenter.TabIndex = 0;
            lblOpenFromControlCenter.Text = "Open from control center";
            // 
            // rbShowOnFullscreenDisplay
            // 
            rbShowOnFullscreenDisplay.AutoSize = true;
            rbShowOnFullscreenDisplay.Checked = true;
            rbShowOnFullscreenDisplay.Location = new System.Drawing.Point(8, 50);
            rbShowOnFullscreenDisplay.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            rbShowOnFullscreenDisplay.Name = "rbShowOnFullscreenDisplay";
            rbShowOnFullscreenDisplay.Size = new System.Drawing.Size(168, 19);
            rbShowOnFullscreenDisplay.TabIndex = 2;
            rbShowOnFullscreenDisplay.TabStop = true;
            rbShowOnFullscreenDisplay.Text = "Show on full screen display";
            rbShowOnFullscreenDisplay.UseVisualStyleBackColor = true;
            // 
            // rbShowOnControlCentersSelectedDisplay
            // 
            rbShowOnControlCentersSelectedDisplay.AutoSize = true;
            rbShowOnControlCentersSelectedDisplay.Location = new System.Drawing.Point(8, 23);
            rbShowOnControlCentersSelectedDisplay.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            rbShowOnControlCentersSelectedDisplay.Name = "rbShowOnControlCentersSelectedDisplay";
            rbShowOnControlCentersSelectedDisplay.Size = new System.Drawing.Size(242, 19);
            rbShowOnControlCentersSelectedDisplay.TabIndex = 1;
            rbShowOnControlCentersSelectedDisplay.Text = "Show on control center's selected display";
            rbShowOnControlCentersSelectedDisplay.UseVisualStyleBackColor = true;
            // 
            // btnIdentify
            // 
            btnIdentify.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnIdentify.Location = new System.Drawing.Point(349, 525);
            btnIdentify.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnIdentify.Name = "btnIdentify";
            btnIdentify.Size = new System.Drawing.Size(88, 27);
            btnIdentify.TabIndex = 12;
            btnIdentify.Text = "Identify";
            btnIdentify.UseVisualStyleBackColor = true;
            btnIdentify.Click += BtnIdentify_Click;
            // 
            // btnClose
            // 
            btnClose.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            btnClose.Location = new System.Drawing.Point(537, 525);
            btnClose.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnClose.Name = "btnClose";
            btnClose.Size = new System.Drawing.Size(88, 27);
            btnClose.TabIndex = 14;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += BtnClose_Click;
            // 
            // btnSave
            // 
            btnSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            btnSave.Location = new System.Drawing.Point(443, 525);
            btnSave.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(88, 27);
            btnSave.TabIndex = 13;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += BtnSave_Click;
            // 
            // gbFullscreenDisplay
            // 
            gbFullscreenDisplay.Controls.Add(pFullscreenDisplay);
            gbFullscreenDisplay.Dock = System.Windows.Forms.DockStyle.Top;
            gbFullscreenDisplay.Location = new System.Drawing.Point(0, 212);
            gbFullscreenDisplay.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbFullscreenDisplay.Name = "gbFullscreenDisplay";
            gbFullscreenDisplay.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbFullscreenDisplay.Size = new System.Drawing.Size(630, 212);
            gbFullscreenDisplay.TabIndex = 9;
            gbFullscreenDisplay.TabStop = false;
            gbFullscreenDisplay.Text = "Full screen display";
            // 
            // pFullscreenDisplay
            // 
            pFullscreenDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            pFullscreenDisplay.Location = new System.Drawing.Point(4, 19);
            pFullscreenDisplay.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pFullscreenDisplay.Name = "pFullscreenDisplay";
            pFullscreenDisplay.Size = new System.Drawing.Size(622, 190);
            pFullscreenDisplay.TabIndex = 0;
            // 
            // gbFunctionChooser
            // 
            gbFunctionChooser.Controls.Add(pFunctionChooser);
            gbFunctionChooser.Dock = System.Windows.Forms.DockStyle.Top;
            gbFunctionChooser.Location = new System.Drawing.Point(0, 0);
            gbFunctionChooser.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbFunctionChooser.Name = "gbFunctionChooser";
            gbFunctionChooser.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbFunctionChooser.Size = new System.Drawing.Size(630, 212);
            gbFunctionChooser.TabIndex = 8;
            gbFunctionChooser.TabStop = false;
            gbFunctionChooser.Text = "Function chooser";
            // 
            // pFunctionChooser
            // 
            pFunctionChooser.Dock = System.Windows.Forms.DockStyle.Fill;
            pFunctionChooser.Location = new System.Drawing.Point(4, 19);
            pFunctionChooser.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pFunctionChooser.Name = "pFunctionChooser";
            pFunctionChooser.Size = new System.Drawing.Size(622, 190);
            pFunctionChooser.TabIndex = 0;
            // 
            // DisplaySettings
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(630, 558);
            Controls.Add(pMain);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "DisplaySettings";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Display settings";
            TopMost = true;
            Shown += DisplayOptions_Shown;
            pMain.ResumeLayout(false);
            gbFullscreenViewBehavior.ResumeLayout(false);
            pRight.ResumeLayout(false);
            pRight.PerformLayout();
            pLeft.ResumeLayout(false);
            pLeft.PerformLayout();
            gbFullscreenDisplay.ResumeLayout(false);
            gbFunctionChooser.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pMain;
        private System.Windows.Forms.Button btnResetDisplays;
        private System.Windows.Forms.GroupBox gbFullscreenViewBehavior;
        private System.Windows.Forms.Panel pRight;
        private System.Windows.Forms.Label lblOpenFromSequenceWindow;
        private System.Windows.Forms.RadioButton rbShowOnControlCentersSelectedDisplay2;
        private System.Windows.Forms.RadioButton rbShowOnFullscreenDisplay2;
        private System.Windows.Forms.Panel pLeft;
        private System.Windows.Forms.Label lblOpenFromControlCenter;
        private System.Windows.Forms.RadioButton rbShowOnFullscreenDisplay;
        private System.Windows.Forms.RadioButton rbShowOnControlCentersSelectedDisplay;
        private System.Windows.Forms.Button btnIdentify;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox gbFullscreenDisplay;
        private System.Windows.Forms.Panel pFullscreenDisplay;
        private System.Windows.Forms.GroupBox gbFunctionChooser;
        private System.Windows.Forms.Panel pFunctionChooser;
    }
}