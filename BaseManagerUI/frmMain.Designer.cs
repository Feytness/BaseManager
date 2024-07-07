namespace BaseManagerUI
{
    partial class frmMain
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
            splitContainer1 = new SplitContainer();
            groupBox2 = new GroupBox();
            txtLog = new TextBox();
            groupBox1 = new GroupBox();
            txtInput = new TextBox();
            groupBox3 = new GroupBox();
            txtMap = new TextBox();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(groupBox2);
            splitContainer1.Panel1.Controls.Add(groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(groupBox3);
            splitContainer1.Size = new Size(930, 473);
            splitContainer1.SplitterDistance = 310;
            splitContainer1.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtLog);
            groupBox2.Location = new Point(3, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(304, 402);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Log";
            // 
            // txtLog
            // 
            txtLog.AcceptsReturn = true;
            txtLog.BackColor = Color.Black;
            txtLog.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtLog.ForeColor = SystemColors.Info;
            txtLog.Location = new Point(6, 22);
            txtLog.Multiline = true;
            txtLog.Name = "txtLog";
            txtLog.ReadOnly = true;
            txtLog.ScrollBars = ScrollBars.Vertical;
            txtLog.Size = new Size(298, 374);
            txtLog.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtInput);
            groupBox1.Location = new Point(3, 411);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(304, 55);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Input";
            // 
            // txtInput
            // 
            txtInput.BackColor = SystemColors.WindowText;
            txtInput.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtInput.ForeColor = SystemColors.Window;
            txtInput.Location = new Point(0, 22);
            txtInput.Name = "txtInput";
            txtInput.Size = new Size(298, 22);
            txtInput.TabIndex = 1;
            txtInput.KeyDown += txtInput_Input;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(txtMap);
            groupBox3.Location = new Point(3, 3);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(601, 463);
            groupBox3.TabIndex = 1;
            groupBox3.TabStop = false;
            groupBox3.Text = "Map";
            // 
            // txtMap
            // 
            txtMap.AcceptsReturn = true;
            txtMap.BackColor = SystemColors.MenuText;
            txtMap.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtMap.ForeColor = SystemColors.Window;
            txtMap.Location = new Point(6, 23);
            txtMap.Multiline = true;
            txtMap.Name = "txtMap";
            txtMap.ReadOnly = true;
            txtMap.ScrollBars = ScrollBars.Both;
            txtMap.Size = new Size(589, 429);
            txtMap.TabIndex = 0;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(930, 473);
            Controls.Add(splitContainer1);
            Name = "frmMain";
            Text = "frmMain";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private TextBox txtLog;
        private TextBox txtInput;
        private TextBox txtMap;
        private GroupBox groupBox2;
        private GroupBox groupBox1;
        private GroupBox groupBox3;
    }
}