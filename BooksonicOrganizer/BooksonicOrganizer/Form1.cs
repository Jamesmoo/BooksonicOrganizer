using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//https://github.com/mono/taglib-sharp

namespace BooksonicOrganizer
{
    public partial class messageProcessingText : Form
    {
        private string sourceFolder = "";
        private string outputFolder = "";
        private Boolean processStarted = false;

        public messageProcessingText()
        {
            InitializeComponent();
        }

        //TODO: remove later
        private void label2_Click(object sender, EventArgs e)
        {

        }

        //TODO: remove later
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (!processStarted) 
            {
                if (string.IsNullOrEmpty(sourceFolder) && string.IsNullOrEmpty(outputFolder))
                {
                    this.folderMessageLabel.ForeColor = System.Drawing.Color.Red;
                    this.folderMessageLabel.Text = "Need to have a source and output folder";
                }
                else if (string.IsNullOrEmpty(sourceFolder))
                {
                    this.folderMessageLabel.ForeColor = System.Drawing.Color.Red;
                    this.folderMessageLabel.Text = "Need to have an source folder";
                }
                else if (string.IsNullOrEmpty(outputFolder))
                {
                    this.folderMessageLabel.ForeColor = System.Drawing.Color.Red;
                    this.folderMessageLabel.Text = "Need to have an output folder";
                }
                else if (sourceFolder.Equals(outputFolder)) 
                {
                    this.folderMessageLabel.ForeColor = System.Drawing.Color.Red;
                    this.folderMessageLabel.Text = "Output folder same as Source folder";
                }
                else
                {
                    processStarted = true;
                    this.processingTextBox.Text = "";
                    this.folderMessageLabel.ForeColor = System.Drawing.Color.Black;
                    this.folderMessageLabel.Text = "Processing Started";

                    var fileEntries = Directory.EnumerateFiles(sourceFolder, "*.*", SearchOption.AllDirectories)
                        .Where(s => s.EndsWith(".mp3") || s.EndsWith(".m4b"));

                    this.processingTextBox.AppendText("*** Starting ***\r\n");

                    int currentCount = 1;
                    int totalCount = fileEntries.Count();

                    this.fileProgressBar.Minimum = 1;
                    this.fileProgressBar.Maximum = totalCount;
                    //this.progressLabel.Text = "Total Files to Process: " + totalCount;

                    foreach (var filePath in fileEntries)
                    {
                        TagLib.File audioFileObj = TagLib.File.Create(filePath);
                        AudioFile myAudioFile = new AudioFile(filePath, audioFileObj);

                        this.processingTextBox.AppendText("---------------------------------\r\n");
                        this.processingTextBox.AppendText("File " + currentCount + " of " + totalCount + "\r\n");
                        this.processingTextBox.AppendText("File: " + myAudioFile.audioFilePath + "\r\n");

                        switch (AudioFileDirectory.OrganizeAudioFile(outputFolder, myAudioFile))
                        {
                            case DirectoryProcessingCode.SUCCESS:
                                this.processingTextBox.AppendText("Completed Processing File\r\n");
                                break;

                            case DirectoryProcessingCode.OUTPUT_FOLDER_DOES_NOT_EXISTS:
                                this.processingTextBox.AppendText("ERROR: Output folder does not exist\r\n");
                                break;

                            case DirectoryProcessingCode.ALBUM_FILE_ALREADY_EXISTS:
                                this.processingTextBox.AppendText("WARNING: Audiobook file already exists\r\n");
                                break;

                            case DirectoryProcessingCode.EXCEPTION_ERROR:
                                this.processingTextBox.AppendText("ERROR: Exception processing file \r\n");
                                break;
                        }

                        currentCount++;
                        this.fileProgressBar.Value = currentCount;
                    }

                    processStarted = false;
                    this.folderMessageLabel.ForeColor = System.Drawing.Color.Green;
                    this.folderMessageLabel.Text = "Processing Completed";
                }
            }
        }

        private void sourceBrowseButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                sourceFolder = folderBrowserDialog1.SelectedPath;
                this.sourceTextBox.Text = sourceFolder;
            }
        }

        private void outputBrowseButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog2 = new FolderBrowserDialog();
            if (folderBrowserDialog2.ShowDialog() == DialogResult.OK)
            {
                outputFolder = folderBrowserDialog2.SelectedPath;
                this.outputTextBox.Text = outputFolder;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void messageProcessingText_Load(object sender, EventArgs e)
        {

        }
    }
}
