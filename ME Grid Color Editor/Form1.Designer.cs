namespace ME_Grid_Color_Editor
{
    partial class Form1
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
            this.fileButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.affectedBlockCount = new System.Windows.Forms.ListBox();
            this.fileColorPanel = new System.Windows.Forms.Panel();
            this.selectedColorGroupBox = new System.Windows.Forms.GroupBox();
            this.affectedBlockNames = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.pendingColorPanel = new System.Windows.Forms.Panel();
            this.pendingColorLabel = new System.Windows.Forms.Label();
            this.buttonReplace = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.selectedColorGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.pendingColorPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // fileButton
            // 
            this.fileButton.Location = new System.Drawing.Point(12, 12);
            this.fileButton.Name = "fileButton";
            this.fileButton.Size = new System.Drawing.Size(506, 23);
            this.fileButton.TabIndex = 0;
            this.fileButton.Text = "Select file";
            this.fileButton.UseVisualStyleBackColor = true;
            this.fileButton.Click += new System.EventHandler(this.fileButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Blueprint (*.sbc)|*.sbc";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // affectedBlockCount
            // 
            this.affectedBlockCount.FormattingEnabled = true;
            this.affectedBlockCount.Location = new System.Drawing.Point(0, 15);
            this.affectedBlockCount.Name = "affectedBlockCount";
            this.affectedBlockCount.Size = new System.Drawing.Size(250, 238);
            this.affectedBlockCount.TabIndex = 1;
            this.affectedBlockCount.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // fileColorPanel
            // 
            this.fileColorPanel.Location = new System.Drawing.Point(6, 19);
            this.fileColorPanel.Name = "fileColorPanel";
            this.fileColorPanel.Size = new System.Drawing.Size(494, 54);
            this.fileColorPanel.TabIndex = 2;
            // 
            // selectedColorGroupBox
            // 
            this.selectedColorGroupBox.Controls.Add(this.fileColorPanel);
            this.selectedColorGroupBox.Location = new System.Drawing.Point(12, 297);
            this.selectedColorGroupBox.Name = "selectedColorGroupBox";
            this.selectedColorGroupBox.Size = new System.Drawing.Size(506, 84);
            this.selectedColorGroupBox.TabIndex = 3;
            this.selectedColorGroupBox.TabStop = false;
            this.selectedColorGroupBox.Text = "File Color";
            // 
            // affectedBlockNames
            // 
            this.affectedBlockNames.FormattingEnabled = true;
            this.affectedBlockNames.Location = new System.Drawing.Point(0, 15);
            this.affectedBlockNames.Name = "affectedBlockNames";
            this.affectedBlockNames.Size = new System.Drawing.Size(250, 238);
            this.affectedBlockNames.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.affectedBlockCount);
            this.groupBox1.Location = new System.Drawing.Point(12, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(250, 250);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Affected block groups";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.affectedBlockNames);
            this.groupBox2.Location = new System.Drawing.Point(268, 41);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(250, 250);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Affected block subtypes";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.pendingColorPanel);
            this.groupBox3.Location = new System.Drawing.Point(12, 387);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(506, 84);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Replace by";
            // 
            // pendingColorPanel
            // 
            this.pendingColorPanel.Controls.Add(this.pendingColorLabel);
            this.pendingColorPanel.Location = new System.Drawing.Point(6, 19);
            this.pendingColorPanel.Name = "pendingColorPanel";
            this.pendingColorPanel.Size = new System.Drawing.Size(494, 54);
            this.pendingColorPanel.TabIndex = 2;
            this.pendingColorPanel.Click += new System.EventHandler(this.pendingColor_Click);
            // 
            // pendingColorLabel
            // 
            this.pendingColorLabel.AutoSize = true;
            this.pendingColorLabel.Location = new System.Drawing.Point(173, 22);
            this.pendingColorLabel.Name = "pendingColorLabel";
            this.pendingColorLabel.Size = new System.Drawing.Size(156, 13);
            this.pendingColorLabel.TabIndex = 0;
            this.pendingColorLabel.Text = "Click here to pick required color";
            this.pendingColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.pendingColorLabel.Click += new System.EventHandler(this.pendingColorLabel_Click);
            // 
            // buttonReplace
            // 
            this.buttonReplace.Location = new System.Drawing.Point(12, 477);
            this.buttonReplace.Name = "buttonReplace";
            this.buttonReplace.Size = new System.Drawing.Size(506, 23);
            this.buttonReplace.TabIndex = 7;
            this.buttonReplace.Text = "Replace color";
            this.buttonReplace.UseVisualStyleBackColor = true;
            this.buttonReplace.Click += new System.EventHandler(this.buttonReplace_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 501);
            this.Controls.Add(this.buttonReplace);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.selectedColorGroupBox);
            this.Controls.Add(this.fileButton);
            this.Name = "Form1";
            this.Text = "ME Blueprint Colorizer";
            this.MouseEnter += new System.EventHandler(this.Form1_MouseEnter);
            this.selectedColorGroupBox.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.pendingColorPanel.ResumeLayout(false);
            this.pendingColorPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button fileButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ListBox affectedBlockCount;
        private System.Windows.Forms.Panel fileColorPanel;
        private System.Windows.Forms.GroupBox selectedColorGroupBox;
        private System.Windows.Forms.ListBox affectedBlockNames;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel pendingColorPanel;
        private System.Windows.Forms.Button buttonReplace;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label pendingColorLabel;
    }
}

