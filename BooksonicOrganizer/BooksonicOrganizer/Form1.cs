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

            string targetDirectory = @"F:\Audiobooks-OrganizedSingleFolder";
            string outputDirectory = @"F:\Audiobooks-Booksonic";

            //string targetDirectory = @"F:\TestSource";
            //string outputDirectory = @"F:\TestOut";

            var fileEntries = Directory.EnumerateFiles(targetDirectory, "*.*", SearchOption.AllDirectories)
                 .Where(s => s.EndsWith(".mp3") || s.EndsWith(".m4b"));

            this.processingTextBox.AppendText("*** Starting ***\r\n");

            int currentCount = 1;
            int totalCount = fileEntries.Count();

            foreach (var filePath in fileEntries) {
                TagLib.File audioFileObj = TagLib.File.Create(filePath);
                AudioFile myAudioFile = new AudioFile(filePath, audioFileObj);

                this.processingTextBox.AppendText("---------------------------------\r\n");
                this.processingTextBox.AppendText("File " + currentCount + " of " + totalCount + "\r\n");
                this.processingTextBox.AppendText("File: " + myAudioFile.audioFilePath + "\r\n");

                if (AudioFileDirectory.OrganizeAudioFile(outputDirectory, myAudioFile))
                {
                    this.processingTextBox.AppendText("Completed Processing File\r\n");
                }
                else 
                {
                    this.processingTextBox.AppendText("ERROR PROCESSING FILE\r\n");
                }
                
                currentCount++;
            }
        }

        private void sourceBrowseButton_Click(object sender, EventArgs e)
        {

        }

        private void outputBrowseButton_Click(object sender, EventArgs e)
        {

        }
    }
}
