namespace UpgradeCodeGenerator
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblSecretCode = new Label();
            btnGenerate = new Button();
            tbSecretCode = new TextBox();
            rtbResult = new RichTextBox();
            lblExpiryMinutes = new Label();
            nudExpiryMinutes = new NumericUpDown();
            cbLiveViewEdition = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)nudExpiryMinutes).BeginInit();
            SuspendLayout();
            // 
            // lblSecretCode
            // 
            lblSecretCode.AutoSize = true;
            lblSecretCode.Location = new Point(12, 9);
            lblSecretCode.Name = "lblSecretCode";
            lblSecretCode.Size = new Size(70, 15);
            lblSecretCode.TabIndex = 0;
            lblSecretCode.Text = "Secret Code";
            // 
            // btnGenerate
            // 
            btnGenerate.Location = new Point(139, 56);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(75, 23);
            btnGenerate.TabIndex = 1;
            btnGenerate.Text = "Generate";
            btnGenerate.UseVisualStyleBackColor = true;
            btnGenerate.Click += BtnGenerate_Click;
            // 
            // tbSecretCode
            // 
            tbSecretCode.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbSecretCode.Location = new Point(12, 27);
            tbSecretCode.Name = "tbSecretCode";
            tbSecretCode.Size = new Size(332, 23);
            tbSecretCode.TabIndex = 2;
            // 
            // rtbResult
            // 
            rtbResult.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            rtbResult.Location = new Point(12, 85);
            rtbResult.Name = "rtbResult";
            rtbResult.ReadOnly = true;
            rtbResult.Size = new Size(424, 133);
            rtbResult.TabIndex = 3;
            rtbResult.Text = "";
            // 
            // lblExpiryMinutes
            // 
            lblExpiryMinutes.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblExpiryMinutes.AutoSize = true;
            lblExpiryMinutes.Location = new Point(352, 9);
            lblExpiryMinutes.Name = "lblExpiryMinutes";
            lblExpiryMinutes.Size = new Size(84, 15);
            lblExpiryMinutes.TabIndex = 4;
            lblExpiryMinutes.Text = "Expiry Minutes";
            // 
            // nudExpiryMinutes
            // 
            nudExpiryMinutes.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            nudExpiryMinutes.Location = new Point(352, 28);
            nudExpiryMinutes.Minimum = new decimal(new int[] { 5, 0, 0, 0 });
            nudExpiryMinutes.Name = "nudExpiryMinutes";
            nudExpiryMinutes.Size = new Size(84, 23);
            nudExpiryMinutes.TabIndex = 5;
            nudExpiryMinutes.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // cbLiveViewEdition
            // 
            cbLiveViewEdition.FormattingEnabled = true;
            cbLiveViewEdition.Location = new Point(12, 56);
            cbLiveViewEdition.Name = "cbLiveViewEdition";
            cbLiveViewEdition.Size = new Size(121, 23);
            cbLiveViewEdition.TabIndex = 6;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(448, 230);
            Controls.Add(cbLiveViewEdition);
            Controls.Add(nudExpiryMinutes);
            Controls.Add(lblExpiryMinutes);
            Controls.Add(rtbResult);
            Controls.Add(tbSecretCode);
            Controls.Add(btnGenerate);
            Controls.Add(lblSecretCode);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LiveView Upgrade Code Generator";
            ((System.ComponentModel.ISupportInitialize)nudExpiryMinutes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblSecretCode;
        private Button btnGenerate;
        private TextBox tbSecretCode;
        private RichTextBox rtbResult;
        private Label lblExpiryMinutes;
        private NumericUpDown nudExpiryMinutes;
        private ComboBox cbLiveViewEdition;
    }
}
