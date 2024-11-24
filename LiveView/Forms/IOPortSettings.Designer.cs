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
            comboBox6 = new System.Windows.Forms.ComboBox();
            label3 = new System.Windows.Forms.Label();
            comboBox3 = new System.Windows.Forms.ComboBox();
            checkBox1 = new System.Windows.Forms.CheckBox();
            listViewNF2 = new Mtf.Controls.MtfListView();
            columnHeader10 = new System.Windows.Forms.ColumnHeader();
            columnHeader6 = new System.Windows.Forms.ColumnHeader();
            columnHeader7 = new System.Windows.Forms.ColumnHeader();
            columnHeader8 = new System.Windows.Forms.ColumnHeader();
            contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(components);
            deleteRulesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            label1 = new System.Windows.Forms.Label();
            comboBox4 = new System.Windows.Forms.ComboBox();
            button1 = new System.Windows.Forms.Button();
            label2 = new System.Windows.Forms.Label();
            comboBox2 = new System.Windows.Forms.ComboBox();
            comboBox5 = new System.Windows.Forms.ComboBox();
            comboBox1 = new System.Windows.Forms.ComboBox();
            panel2 = new System.Windows.Forms.Panel();
            groupBox1 = new System.Windows.Forms.GroupBox();
            changeFriendlyNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(components);
            columnHeader5 = new System.Windows.Forms.ColumnHeader();
            columnHeader4 = new System.Windows.Forms.ColumnHeader();
            columnHeader3 = new System.Windows.Forms.ColumnHeader();
            columnHeader2 = new System.Windows.Forms.ColumnHeader();
            columnHeader1 = new System.Windows.Forms.ColumnHeader();
            columnHeader9 = new System.Windows.Forms.ColumnHeader();
            listViewNF1 = new Mtf.Controls.MtfListView();
            panel1 = new System.Windows.Forms.Panel();
            contextMenuStrip2.SuspendLayout();
            panel2.SuspendLayout();
            groupBox1.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            panel1.SuspendLayout();
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
            // comboBox6
            // 
            comboBox6.FormattingEnabled = true;
            comboBox6.Location = new System.Drawing.Point(77, 18);
            comboBox6.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            comboBox6.Name = "comboBox6";
            comboBox6.Size = new System.Drawing.Size(34, 23);
            comboBox6.TabIndex = 11;
            comboBox6.Visible = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(4, 28);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(62, 15);
            label3.TabIndex = 10;
            label3.Text = "I/O Device";
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new System.Drawing.Point(436, 18);
            comboBox3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new System.Drawing.Size(108, 23);
            comboBox3.TabIndex = 7;
            comboBox3.Visible = false;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new System.Drawing.Point(552, 48);
            checkBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new System.Drawing.Size(97, 19);
            checkBox1.TabIndex = 6;
            checkBox1.Text = "Zero signaled";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // listViewNF2
            // 
            listViewNF2.AlternatingColorEven = System.Drawing.Color.LightBlue;
            listViewNF2.AlternatingColorOdd = System.Drawing.SystemColors.Window;
            listViewNF2.AlternatingColorsAreInUse = true;
            listViewNF2.AlternatingPairColorEven = System.Drawing.Color.LightSeaGreen;
            listViewNF2.AlternatingPairColorOdd = System.Drawing.Color.CadetBlue;
            listViewNF2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            listViewNF2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeader10, columnHeader6, columnHeader7, columnHeader8 });
            listViewNF2.CompactView = false;
            listViewNF2.ContextMenuStrip = contextMenuStrip2;
            listViewNF2.EnsureLastItemIsVisible = false;
            listViewNF2.FirstItemIsGray = false;
            listViewNF2.FullRowSelect = true;
            listViewNF2.Location = new System.Drawing.Point(4, 77);
            listViewNF2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            listViewNF2.Name = "listViewNF2";
            listViewNF2.OwnerDraw = true;
            listViewNF2.ReadonlyCheckboxes = false;
            listViewNF2.SameItemsColorEven = System.Drawing.Color.DarkOrange;
            listViewNF2.SameItemsColorOdd = System.Drawing.Color.LightSalmon;
            listViewNF2.Size = new System.Drawing.Size(907, 151);
            listViewNF2.TabIndex = 5;
            listViewNF2.UseCompatibleStateImageBehavior = false;
            listViewNF2.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader10
            // 
            columnHeader10.Text = "I/O Device";
            columnHeader10.Width = 102;
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "Output I/O port";
            columnHeader6.Width = 183;
            // 
            // columnHeader7
            // 
            columnHeader7.Text = "Operation or event";
            columnHeader7.Width = 184;
            // 
            // columnHeader8
            // 
            columnHeader8.Text = "Zero signaled";
            columnHeader8.Width = 81;
            // 
            // contextMenuStrip2
            // 
            contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { deleteRulesToolStripMenuItem });
            contextMenuStrip2.Name = "contextMenuStrip2";
            contextMenuStrip2.Size = new System.Drawing.Size(136, 26);
            // 
            // deleteRulesToolStripMenuItem
            // 
            deleteRulesToolStripMenuItem.Name = "deleteRulesToolStripMenuItem";
            deleteRulesToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            deleteRulesToolStripMenuItem.Text = "Delete rules";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(122, 28);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(90, 15);
            label1.TabIndex = 2;
            label1.Text = "Output I/O port";
            // 
            // comboBox4
            // 
            comboBox4.FormattingEnabled = true;
            comboBox4.Location = new System.Drawing.Point(222, 18);
            comboBox4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            comboBox4.Name = "comboBox4";
            comboBox4.Size = new System.Drawing.Size(108, 23);
            comboBox4.TabIndex = 8;
            comboBox4.Visible = false;
            // 
            // button1
            // 
            button1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            button1.Location = new System.Drawing.Point(736, 42);
            button1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(164, 27);
            button1.TabIndex = 4;
            button1.Text = "Add to rules";
            button1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(334, 28);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(106, 15);
            label2.TabIndex = 3;
            label2.Text = "Operation or event";
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new System.Drawing.Point(122, 46);
            comboBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new System.Drawing.Size(207, 23);
            comboBox2.TabIndex = 1;
            // 
            // comboBox5
            // 
            comboBox5.FormattingEnabled = true;
            comboBox5.Location = new System.Drawing.Point(4, 46);
            comboBox5.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            comboBox5.Name = "comboBox5";
            comboBox5.Size = new System.Drawing.Size(108, 23);
            comboBox5.TabIndex = 9;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new System.Drawing.Point(337, 46);
            comboBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new System.Drawing.Size(207, 23);
            comboBox1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(groupBox1);
            panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            panel2.Location = new System.Drawing.Point(0, 285);
            panel2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(915, 232);
            panel2.TabIndex = 4;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(comboBox6);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(comboBox5);
            groupBox1.Controls.Add(comboBox4);
            groupBox1.Controls.Add(comboBox3);
            groupBox1.Controls.Add(checkBox1);
            groupBox1.Controls.Add(listViewNF2);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(comboBox2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(comboBox1);
            groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            groupBox1.Location = new System.Drawing.Point(0, 0);
            groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox1.Size = new System.Drawing.Size(915, 232);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "I/O port rules";
            // 
            // changeFriendlyNameToolStripMenuItem
            // 
            changeFriendlyNameToolStripMenuItem.Name = "changeFriendlyNameToolStripMenuItem";
            changeFriendlyNameToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            changeFriendlyNameToolStripMenuItem.Text = "Change settings";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { changeFriendlyNameToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new System.Drawing.Size(160, 26);
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Minimum trigger time";
            columnHeader5.Width = 107;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Maximum signals per day";
            columnHeader4.Width = 131;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Friendly name";
            columnHeader3.Width = 150;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Port name";
            columnHeader2.Width = 150;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Port number";
            columnHeader1.Width = 70;
            // 
            // columnHeader9
            // 
            columnHeader9.Text = "I/O device";
            columnHeader9.Width = 99;
            // 
            // listViewNF1
            // 
            listViewNF1.AlternatingColorEven = System.Drawing.Color.LightBlue;
            listViewNF1.AlternatingColorOdd = System.Drawing.SystemColors.Window;
            listViewNF1.AlternatingColorsAreInUse = true;
            listViewNF1.AlternatingPairColorEven = System.Drawing.Color.LightSeaGreen;
            listViewNF1.AlternatingPairColorOdd = System.Drawing.Color.CadetBlue;
            listViewNF1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeader9, columnHeader1, columnHeader2, columnHeader3, columnHeader4, columnHeader5 });
            listViewNF1.CompactView = false;
            listViewNF1.ContextMenuStrip = contextMenuStrip1;
            listViewNF1.Dock = System.Windows.Forms.DockStyle.Fill;
            listViewNF1.EnsureLastItemIsVisible = false;
            listViewNF1.FirstItemIsGray = false;
            listViewNF1.FullRowSelect = true;
            listViewNF1.Location = new System.Drawing.Point(0, 0);
            listViewNF1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            listViewNF1.MultiSelect = false;
            listViewNF1.Name = "listViewNF1";
            listViewNF1.OwnerDraw = true;
            listViewNF1.ReadonlyCheckboxes = false;
            listViewNF1.SameItemsColorEven = System.Drawing.Color.DarkOrange;
            listViewNF1.SameItemsColorOdd = System.Drawing.Color.LightSalmon;
            listViewNF1.Size = new System.Drawing.Size(915, 285);
            listViewNF1.TabIndex = 0;
            listViewNF1.UseCompatibleStateImageBehavior = false;
            listViewNF1.View = System.Windows.Forms.View.Details;
            // 
            // panel1
            // 
            panel1.Controls.Add(listViewNF1);
            panel1.Dock = System.Windows.Forms.DockStyle.Top;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(915, 285);
            panel1.TabIndex = 3;
            // 
            // IOPortSettings
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(915, 517);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(pMain);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "IOPortSettings";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "I/O ports' settings";
            contextMenuStrip2.ResumeLayout(false);
            panel2.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            contextMenuStrip1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pMain;
        private System.Windows.Forms.ComboBox comboBox6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.CheckBox checkBox1;
        private Mtf.Controls.MtfListView listViewNF2;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem deleteRulesToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox5;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStripMenuItem changeFriendlyNameToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private Mtf.Controls.MtfListView listViewNF1;
        private System.Windows.Forms.Panel panel1;
    }
}