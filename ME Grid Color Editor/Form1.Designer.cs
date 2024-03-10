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
            this.selectedColorGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            this.selectedColorGroupBox.Size = new System.Drawing.Size(506, 89);
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
            this.groupBox2.Text = "Affected block names";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 436);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.selectedColorGroupBox);
            this.Controls.Add(this.fileButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.selectedColorGroupBox.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
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
    }
}

