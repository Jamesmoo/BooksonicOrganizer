namespace BooksonicOrganizer
{
    partial class messageProcessingText
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.sourceTextBox = new System.Windows.Forms.TextBox();
            this.outputTextBox = new System.Windows.Forms.TextBox();
            this.startButton = new System.Windows.Forms.Button();
            this.sourceBrowseButton = new System.Windows.Forms.Button();
            this.outputBrowseButton = new System.Windows.Forms.Button();
            this.processingTextBox = new System.Windows.Forms.TextBox();
            this.fileProgressBar = new System.Windows.Forms.ProgressBar();
            this.progressLabel = new System.Windows.Forms.Label();
            this.folderMessageLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Courier New", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(348, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "Booksonic File Organizer";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 16);
            this.label2.TabIndex = 1;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(288, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Audiobook Source Directory: ";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(18, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(278, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "Audiobook Output Directory:";
            // 
            // sourceTextBox
            // 
            this.sourceTextBox.Location = new System.Drawing.Point(303, 79);
            this.sourceTextBox.Name = "sourceTextBox";
            this.sourceTextBox.Size = new System.Drawing.Size(214, 20);
            this.sourceTextBox.TabIndex = 4;
            // 
            // outputTextBox
            // 
            this.outputTextBox.Location = new System.Drawing.Point(303, 119);
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.Size = new System.Drawing.Size(214, 20);
            this.outputTextBox.TabIndex = 5;
            // 
            // startButton
            // 
            this.startButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.startButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startButton.Location = new System.Drawing.Point(407, 188);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(192, 23);
            this.startButton.TabIndex = 6;
            this.startButton.Text = "Start Processing Files";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // sourceBrowseButton
            // 
            this.sourceBrowseButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sourceBrowseButton.Location = new System.Drawing.Point(524, 77);
            this.sourceBrowseButton.Name = "sourceBrowseButton";
            this.sourceBrowseButton.Size = new System.Drawing.Size(75, 23);
            this.sourceBrowseButton.TabIndex = 7;
            this.sourceBrowseButton.Text = "Browse";
            this.sourceBrowseButton.UseVisualStyleBackColor = true;
            this.sourceBrowseButton.Click += new System.EventHandler(this.sourceBrowseButton_Click);
            // 
            // outputBrowseButton
            // 
            this.outputBrowseButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.outputBrowseButton.Location = new System.Drawing.Point(524, 118);
            this.outputBrowseButton.Name = "outputBrowseButton";
            this.outputBrowseButton.Size = new System.Drawing.Size(75, 23);
            this.outputBrowseButton.TabIndex = 8;
            this.outputBrowseButton.Text = "Browse";
            this.outputBrowseButton.UseVisualStyleBackColor = true;
            this.outputBrowseButton.Click += new System.EventHandler(this.outputBrowseButton_Click);
            // 
            // processingTextBox
            // 
            this.processingTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.processingTextBox.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.processingTextBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.processingTextBox.Location = new System.Drawing.Point(18, 231);
            this.processingTextBox.Multiline = true;
            this.processingTextBox.Name = "processingTextBox";
            this.processingTextBox.ReadOnly = true;
            this.processingTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.processingTextBox.Size = new System.Drawing.Size(581, 191);
            this.processingTextBox.TabIndex = 9;
            // 
            // fileProgressBar
            // 
            this.fileProgressBar.Location = new System.Drawing.Point(72, 189);
            this.fileProgressBar.Name = "fileProgressBar";
            this.fileProgressBar.Size = new System.Drawing.Size(237, 23);
            this.fileProgressBar.TabIndex = 10;
            // 
            // progressLabel
            // 
            this.progressLabel.AutoSize = true;
            this.progressLabel.Location = new System.Drawing.Point(18, 193);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(51, 13);
            this.progressLabel.TabIndex = 11;
            this.progressLabel.Text = "Progress:";
            this.progressLabel.Click += new System.EventHandler(this.label5_Click);
            // 
            // folderMessageLabel
            // 
            this.folderMessageLabel.AutoSize = true;
            this.folderMessageLabel.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.folderMessageLabel.ForeColor = System.Drawing.Color.Black;
            this.folderMessageLabel.Location = new System.Drawing.Point(262, 152);
            this.folderMessageLabel.Name = "folderMessageLabel";
            this.folderMessageLabel.Size = new System.Drawing.Size(140, 15);
            this.folderMessageLabel.TabIndex = 12;
            this.folderMessageLabel.Text = "No Folders Selected";
            // 
            // messageProcessingText
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 450);
            this.Controls.Add(this.folderMessageLabel);
            this.Controls.Add(this.progressLabel);
            this.Controls.Add(this.fileProgressBar);
            this.Controls.Add(this.processingTextBox);
            this.Controls.Add(this.outputBrowseButton);
            this.Controls.Add(this.sourceBrowseButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.outputTextBox);
            this.Controls.Add(this.sourceTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "messageProcessingText";
            this.Text = "No Folders Selected";
            this.Load += new System.EventHandler(this.messageProcessingText_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox sourceTextBox;
        private System.Windows.Forms.TextBox outputTextBox;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button sourceBrowseButton;
        private System.Windows.Forms.Button outputBrowseButton;
        private System.Windows.Forms.TextBox processingTextBox;
        private System.Windows.Forms.ProgressBar fileProgressBar;
        private System.Windows.Forms.Label progressLabel;
        private System.Windows.Forms.Label folderMessageLabel;
    }
}

