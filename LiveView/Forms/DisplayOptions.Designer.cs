namespace LiveView.Forms
{
    partial class DisplayOptions
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
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(DisplayOptions));
            pMain = new System.Windows.Forms.Panel();
            btn_ResetDisplays = new System.Windows.Forms.Button();
            gb_FullscreenViewBehavior = new System.Windows.Forms.GroupBox();
            p_Right = new System.Windows.Forms.Panel();
            lbl_OpenFromSequenceWindow = new System.Windows.Forms.Label();
            rb_ShowOnControlCentersSelectedDisplay_2 = new System.Windows.Forms.RadioButton();
            rb_ShowOnFullscreenDisplay_2 = new System.Windows.Forms.RadioButton();
            p_Left = new System.Windows.Forms.Panel();
            lbl_OpenFromControlCenter = new System.Windows.Forms.Label();
            rb_ShowOnFullscreenDisplay = new System.Windows.Forms.RadioButton();
            rb_ShowOnControlCentersSelectedDisplay = new System.Windows.Forms.RadioButton();
            btn_Identify = new System.Windows.Forms.Button();
            lbl = new System.Windows.Forms.Label();
            btn_Cancel = new System.Windows.Forms.Button();
            btn_Save = new System.Windows.Forms.Button();
            gb_FullscreenDisplay = new System.Windows.Forms.GroupBox();
            p_FullscreenDisplay = new System.Windows.Forms.Panel();
            gb_FunctionChooser = new System.Windows.Forms.GroupBox();
            p_FunctionChooser = new System.Windows.Forms.Panel();
            pMain.SuspendLayout();
            gb_FullscreenViewBehavior.SuspendLayout();
            p_Right.SuspendLayout();
            p_Left.SuspendLayout();
            gb_FullscreenDisplay.SuspendLayout();
            gb_FunctionChooser.SuspendLayout();
            SuspendLayout();
            // 
            // pMain
            // 
            pMain.Controls.Add(btn_ResetDisplays);
            pMain.Controls.Add(gb_FullscreenViewBehavior);
            pMain.Controls.Add(btn_Identify);
            pMain.Controls.Add(lbl);
            pMain.Controls.Add(btn_Cancel);
            pMain.Controls.Add(btn_Save);
            pMain.Controls.Add(gb_FullscreenDisplay);
            pMain.Controls.Add(gb_FunctionChooser);
            pMain.Dock = System.Windows.Forms.DockStyle.Fill;
            pMain.Location = new System.Drawing.Point(0, 0);
            pMain.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pMain.Name = "pMain";
            pMain.Size = new System.Drawing.Size(630, 558);
            pMain.TabIndex = 0;
            // 
            // btn_ResetDisplays
            // 
            btn_ResetDisplays.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btn_ResetDisplays.Location = new System.Drawing.Point(0, 531);
            btn_ResetDisplays.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_ResetDisplays.Name = "btn_ResetDisplays";
            btn_ResetDisplays.Size = new System.Drawing.Size(190, 27);
            btn_ResetDisplays.TabIndex = 15;
            btn_ResetDisplays.Text = "Reset displays";
            btn_ResetDisplays.UseVisualStyleBackColor = true;
            // 
            // gb_FullscreenViewBehavior
            // 
            gb_FullscreenViewBehavior.Controls.Add(p_Right);
            gb_FullscreenViewBehavior.Controls.Add(p_Left);
            gb_FullscreenViewBehavior.Dock = System.Windows.Forms.DockStyle.Top;
            gb_FullscreenViewBehavior.Location = new System.Drawing.Point(0, 424);
            gb_FullscreenViewBehavior.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gb_FullscreenViewBehavior.Name = "gb_FullscreenViewBehavior";
            gb_FullscreenViewBehavior.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gb_FullscreenViewBehavior.Size = new System.Drawing.Size(630, 96);
            gb_FullscreenViewBehavior.TabIndex = 10;
            gb_FullscreenViewBehavior.TabStop = false;
            gb_FullscreenViewBehavior.Text = "Behavior of opening full screen view";
            // 
            // p_Right
            // 
            p_Right.Controls.Add(lbl_OpenFromSequenceWindow);
            p_Right.Controls.Add(rb_ShowOnControlCentersSelectedDisplay_2);
            p_Right.Controls.Add(rb_ShowOnFullscreenDisplay_2);
            p_Right.Dock = System.Windows.Forms.DockStyle.Fill;
            p_Right.Location = new System.Drawing.Point(316, 19);
            p_Right.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            p_Right.Name = "p_Right";
            p_Right.Size = new System.Drawing.Size(310, 74);
            p_Right.TabIndex = 1;
            // 
            // lbl_OpenFromSequenceWindow
            // 
            lbl_OpenFromSequenceWindow.AutoSize = true;
            lbl_OpenFromSequenceWindow.Location = new System.Drawing.Point(5, 5);
            lbl_OpenFromSequenceWindow.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_OpenFromSequenceWindow.Name = "lbl_OpenFromSequenceWindow";
            lbl_OpenFromSequenceWindow.Size = new System.Drawing.Size(163, 15);
            lbl_OpenFromSequenceWindow.TabIndex = 0;
            lbl_OpenFromSequenceWindow.Text = "Open from sequence window";
            // 
            // rb_ShowOnControlCentersSelectedDisplay_2
            // 
            rb_ShowOnControlCentersSelectedDisplay_2.AutoSize = true;
            rb_ShowOnControlCentersSelectedDisplay_2.Checked = true;
            rb_ShowOnControlCentersSelectedDisplay_2.Location = new System.Drawing.Point(8, 23);
            rb_ShowOnControlCentersSelectedDisplay_2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            rb_ShowOnControlCentersSelectedDisplay_2.Name = "rb_ShowOnControlCentersSelectedDisplay_2";
            rb_ShowOnControlCentersSelectedDisplay_2.Size = new System.Drawing.Size(242, 19);
            rb_ShowOnControlCentersSelectedDisplay_2.TabIndex = 1;
            rb_ShowOnControlCentersSelectedDisplay_2.TabStop = true;
            rb_ShowOnControlCentersSelectedDisplay_2.Text = "Show on control center's selected display";
            rb_ShowOnControlCentersSelectedDisplay_2.UseVisualStyleBackColor = true;
            // 
            // rb_ShowOnFullscreenDisplay_2
            // 
            rb_ShowOnFullscreenDisplay_2.AutoSize = true;
            rb_ShowOnFullscreenDisplay_2.Location = new System.Drawing.Point(8, 50);
            rb_ShowOnFullscreenDisplay_2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            rb_ShowOnFullscreenDisplay_2.Name = "rb_ShowOnFullscreenDisplay_2";
            rb_ShowOnFullscreenDisplay_2.Size = new System.Drawing.Size(168, 19);
            rb_ShowOnFullscreenDisplay_2.TabIndex = 2;
            rb_ShowOnFullscreenDisplay_2.Text = "Show on full screen display";
            rb_ShowOnFullscreenDisplay_2.UseVisualStyleBackColor = true;
            // 
            // p_Left
            // 
            p_Left.Controls.Add(lbl_OpenFromControlCenter);
            p_Left.Controls.Add(rb_ShowOnFullscreenDisplay);
            p_Left.Controls.Add(rb_ShowOnControlCentersSelectedDisplay);
            p_Left.Dock = System.Windows.Forms.DockStyle.Left;
            p_Left.Location = new System.Drawing.Point(4, 19);
            p_Left.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            p_Left.Name = "p_Left";
            p_Left.Size = new System.Drawing.Size(312, 74);
            p_Left.TabIndex = 0;
            // 
            // lbl_OpenFromControlCenter
            // 
            lbl_OpenFromControlCenter.AutoSize = true;
            lbl_OpenFromControlCenter.Location = new System.Drawing.Point(5, 5);
            lbl_OpenFromControlCenter.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl_OpenFromControlCenter.Name = "lbl_OpenFromControlCenter";
            lbl_OpenFromControlCenter.Size = new System.Drawing.Size(142, 15);
            lbl_OpenFromControlCenter.TabIndex = 0;
            lbl_OpenFromControlCenter.Text = "Open from control center";
            // 
            // rb_ShowOnFullscreenDisplay
            // 
            rb_ShowOnFullscreenDisplay.AutoSize = true;
            rb_ShowOnFullscreenDisplay.Checked = true;
            rb_ShowOnFullscreenDisplay.Location = new System.Drawing.Point(8, 50);
            rb_ShowOnFullscreenDisplay.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            rb_ShowOnFullscreenDisplay.Name = "rb_ShowOnFullscreenDisplay";
            rb_ShowOnFullscreenDisplay.Size = new System.Drawing.Size(168, 19);
            rb_ShowOnFullscreenDisplay.TabIndex = 2;
            rb_ShowOnFullscreenDisplay.TabStop = true;
            rb_ShowOnFullscreenDisplay.Text = "Show on full screen display";
            rb_ShowOnFullscreenDisplay.UseVisualStyleBackColor = true;
            // 
            // rb_ShowOnControlCentersSelectedDisplay
            // 
            rb_ShowOnControlCentersSelectedDisplay.AutoSize = true;
            rb_ShowOnControlCentersSelectedDisplay.Location = new System.Drawing.Point(8, 23);
            rb_ShowOnControlCentersSelectedDisplay.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            rb_ShowOnControlCentersSelectedDisplay.Name = "rb_ShowOnControlCentersSelectedDisplay";
            rb_ShowOnControlCentersSelectedDisplay.Size = new System.Drawing.Size(242, 19);
            rb_ShowOnControlCentersSelectedDisplay.TabIndex = 1;
            rb_ShowOnControlCentersSelectedDisplay.Text = "Show on control center's selected display";
            rb_ShowOnControlCentersSelectedDisplay.UseVisualStyleBackColor = true;
            // 
            // btn_Identify
            // 
            btn_Identify.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btn_Identify.Location = new System.Drawing.Point(354, 531);
            btn_Identify.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_Identify.Name = "btn_Identify";
            btn_Identify.Size = new System.Drawing.Size(88, 27);
            btn_Identify.TabIndex = 12;
            btn_Identify.Text = "Identify";
            btn_Identify.UseVisualStyleBackColor = true;
            // 
            // lbl
            // 
            lbl.AutoSize = true;
            lbl.Location = new System.Drawing.Point(0, 537);
            lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lbl.Name = "lbl";
            lbl.Size = new System.Drawing.Size(0, 15);
            lbl.TabIndex = 11;
            lbl.Visible = false;
            // 
            // btn_Cancel
            // 
            btn_Cancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            btn_Cancel.Location = new System.Drawing.Point(542, 531);
            btn_Cancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_Cancel.Name = "btn_Cancel";
            btn_Cancel.Size = new System.Drawing.Size(88, 27);
            btn_Cancel.TabIndex = 14;
            btn_Cancel.Text = "Cancel";
            btn_Cancel.UseVisualStyleBackColor = true;
            // 
            // btn_Save
            // 
            btn_Save.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btn_Save.DialogResult = System.Windows.Forms.DialogResult.OK;
            btn_Save.Location = new System.Drawing.Point(448, 531);
            btn_Save.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btn_Save.Name = "btn_Save";
            btn_Save.Size = new System.Drawing.Size(88, 27);
            btn_Save.TabIndex = 13;
            btn_Save.Text = "Save";
            btn_Save.UseVisualStyleBackColor = true;
            // 
            // gb_FullscreenDisplay
            // 
            gb_FullscreenDisplay.Controls.Add(p_FullscreenDisplay);
            gb_FullscreenDisplay.Dock = System.Windows.Forms.DockStyle.Top;
            gb_FullscreenDisplay.Location = new System.Drawing.Point(0, 212);
            gb_FullscreenDisplay.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gb_FullscreenDisplay.Name = "gb_FullscreenDisplay";
            gb_FullscreenDisplay.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gb_FullscreenDisplay.Size = new System.Drawing.Size(630, 212);
            gb_FullscreenDisplay.TabIndex = 9;
            gb_FullscreenDisplay.TabStop = false;
            gb_FullscreenDisplay.Text = "Full screen display";
            // 
            // p_FullscreenDisplay
            // 
            p_FullscreenDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            p_FullscreenDisplay.Location = new System.Drawing.Point(4, 19);
            p_FullscreenDisplay.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            p_FullscreenDisplay.Name = "p_FullscreenDisplay";
            p_FullscreenDisplay.Size = new System.Drawing.Size(622, 190);
            p_FullscreenDisplay.TabIndex = 0;
            // 
            // gb_FunctionChooser
            // 
            gb_FunctionChooser.Controls.Add(p_FunctionChooser);
            gb_FunctionChooser.Dock = System.Windows.Forms.DockStyle.Top;
            gb_FunctionChooser.Location = new System.Drawing.Point(0, 0);
            gb_FunctionChooser.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gb_FunctionChooser.Name = "gb_FunctionChooser";
            gb_FunctionChooser.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gb_FunctionChooser.Size = new System.Drawing.Size(630, 212);
            gb_FunctionChooser.TabIndex = 8;
            gb_FunctionChooser.TabStop = false;
            gb_FunctionChooser.Text = "Function chooser";
            // 
            // p_FunctionChooser
            // 
            p_FunctionChooser.Dock = System.Windows.Forms.DockStyle.Fill;
            p_FunctionChooser.Location = new System.Drawing.Point(4, 19);
            p_FunctionChooser.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            p_FunctionChooser.Name = "p_FunctionChooser";
            p_FunctionChooser.Size = new System.Drawing.Size(622, 190);
            p_FunctionChooser.TabIndex = 0;
            // 
            // DisplayOptions
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(630, 558);
            Controls.Add(pMain);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "DisplayOptions";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Display options";
            TopMost = true;
            pMain.ResumeLayout(false);
            pMain.PerformLayout();
            gb_FullscreenViewBehavior.ResumeLayout(false);
            p_Right.ResumeLayout(false);
            p_Right.PerformLayout();
            p_Left.ResumeLayout(false);
            p_Left.PerformLayout();
            gb_FullscreenDisplay.ResumeLayout(false);
            gb_FunctionChooser.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pMain;
        private System.Windows.Forms.Button btn_ResetDisplays;
        private System.Windows.Forms.GroupBox gb_FullscreenViewBehavior;
        private System.Windows.Forms.Panel p_Right;
        private System.Windows.Forms.Label lbl_OpenFromSequenceWindow;
        private System.Windows.Forms.RadioButton rb_ShowOnControlCentersSelectedDisplay_2;
        private System.Windows.Forms.RadioButton rb_ShowOnFullscreenDisplay_2;
        private System.Windows.Forms.Panel p_Left;
        private System.Windows.Forms.Label lbl_OpenFromControlCenter;
        private System.Windows.Forms.RadioButton rb_ShowOnFullscreenDisplay;
        private System.Windows.Forms.RadioButton rb_ShowOnControlCentersSelectedDisplay;
        private System.Windows.Forms.Button btn_Identify;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.GroupBox gb_FullscreenDisplay;
        private System.Windows.Forms.Panel p_FullscreenDisplay;
        private System.Windows.Forms.GroupBox gb_FunctionChooser;
        private System.Windows.Forms.Panel p_FunctionChooser;
    }
}