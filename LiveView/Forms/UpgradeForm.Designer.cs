namespace LiveView.Forms
{
    partial class UpgradeForm
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
            gbMain = new System.Windows.Forms.GroupBox();
            rtbUpgradeCode = new System.Windows.Forms.RichTextBox();
            lblUpgradeCode = new System.Windows.Forms.Label();
            lblSecretCode = new System.Windows.Forms.Label();
            btnUpgrade = new System.Windows.Forms.Button();

/* Unmerged change from project 'LiveView (net9.0-windows)'
Before:
            textBox1 = new System.Windows.Forms.TextBox();
            gbMain.SuspendLayout();
After:
            tbSecretCode = new System.Windows.Forms.TextBox();
            gbMain.SuspendLayout();
*/
            tbSecretCode = new System.Windows.Forms.TextBox();
            gbMain.SuspendLayout();
            SuspendLayout();
            // 
            // gbMain
            // 
            gbMain.Controls.Add(tbSecretCode);
            gbMain.Controls.Add(rtbUpgradeCode);
            gbMain.Controls.Add(lblUpgradeCode);
            gbMain.Controls.Add(lblSecretCode);
            gbMain.Controls.Add(btnUpgrade);
            gbMain.Dock = System.Windows.Forms.DockStyle.Fill;
            gbMain.Location = new System.Drawing.Point(0, 0);
            gbMain.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbMain.Name = "gbMain";
            gbMain.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gbMain.Size = new System.Drawing.Size(341, 173);
            gbMain.TabIndex = 1;
            gbMain.TabStop = false;
            // 
            // rtbUpgradeCode
            // 
            rtbUpgradeCode.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            rtbUpgradeCode.Location = new System.Drawing.Point(7, 82);
            rtbUpgradeCode.Name = "rtbUpgradeCode";
            rtbUpgradeCode.Size = new System.Drawing.Size(319, 47);
            rtbUpgradeCode.TabIndex = 7;
            rtbUpgradeCode.Text = "";
            // 
            // lblUpgradeCode
            // 
            lblUpgradeCode.AutoSize = true;
            lblUpgradeCode.Location = new System.Drawing.Point(7, 64);
            lblUpgradeCode.Name = "lblUpgradeCode";
            lblUpgradeCode.Size = new System.Drawing.Size(81, 15);
            lblUpgradeCode.TabIndex = 6;
            lblUpgradeCode.Text = "Upgrade code";
            // 
            // lblSecretCode
            // 
            lblSecretCode.AutoSize = true;
            lblSecretCode.Location = new System.Drawing.Point(7, 19);
            lblSecretCode.Name = "lblSecretCode";
            lblSecretCode.Size = new System.Drawing.Size(68, 15);
            lblSecretCode.TabIndex = 5;
            lblSecretCode.Text = "Secret code";
            // 
            // btnUpgrade
            // 
            btnUpgrade.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnUpgrade.DialogResult = System.Windows.Forms.DialogResult.OK;
            btnUpgrade.Location = new System.Drawing.Point(239, 135);
            btnUpgrade.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnUpgrade.Name = "btnUpgrade";
            btnUpgrade.Size = new System.Drawing.Size(88, 27);
            btnUpgrade.TabIndex = 4;
            btnUpgrade.Text = "Upgrade";
            btnUpgrade.UseVisualStyleBackColor = true;
            btnUpgrade.Click += BtnUpgrade_Click;
            // 
            // tbSecretCode
            // 
            tbSecretCode.Location = new System.Drawing.Point(7, 37);
            tbSecretCode.Name = "tbSecretCode";
            tbSecretCode.Size = new System.Drawing.Size(319, 23);

/* Unmerged change from project 'LiveView (net9.0-windows)'
Before:
            textBox1.Location = new System.Drawing.Point(7, 22);
            textBox1.Name = "textBox1";
            textBox1.Size = new System.Drawing.Size(319, 23);
            textBox1.TabIndex = 8;
            // 
After:
            tbSecretCode.Location = new System.Drawing.Point(7, 22);
            tbSecretCode.Name = "textBox1";
            tbSecretCode.Size = new System.Drawing.Size(319, 23);
            tbSecretCode.TabIndex = 8;
            // 
*/
            tbSecretCode.TabIndex = 8;
            // 
            // UpgradeForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(341, 173);
            Controls.Add(gbMain);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "UpgradeForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Upgrade";
            Shown += EnterPass_Shown;
            gbMain.ResumeLayout(false);
            gbMain.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox gbMain;
        private System.Windows.Forms.Button btnUpgrade;
        private System.Windows.Forms.Label lblSecretCode;
        private System.Windows.Forms.RichTextBox rtbUpgradeCode;
        private System.Windows.Forms.Label lblUpgradeCode;
        private System.Windows.Forms.TextBox tbSecretCode;
    }
}