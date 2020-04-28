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
            
            string targetDirectory = @"D:\booktest";
            string outputDirectory = @"D:\booktestout";

            var fileEntries = Directory.EnumerateFiles(targetDirectory, "*.*", SearchOption.AllDirectories)
                 .Where(s => s.EndsWith(".mp3") || s.EndsWith(".m4b"));

            this.processingTextBox.AppendText("*** Starting ***\r\n");

            ArrayList processedTitlesList = new ArrayList();

            int currentCount = 1;
            int totalCount = fileEntries.Count();

            LogFile.CreateLogFile();
            foreach (var filePath in fileEntries) {
                LogFile.AppendNewFileLog(filePath);

                TagLib.File audioTagFile = TagLib.File.Create(filePath);
                AudioFile myAudioFile = new AudioFile(filePath, audioTagFile);

                this.processingTextBox.AppendText("---------------------------------\r\n");
                this.processingTextBox.AppendText("File " + currentCount + " of " + totalCount + "\r\n");
                
                this.processingTextBox.AppendText("File:   " + myAudioFile.audioFilePath + "\r\n");
                this.processingTextBox.AppendText("Artist: " + myAudioFile.audioFileArtist + "\r\n");
                this.processingTextBox.AppendText("Title:  " + myAudioFile.audioFileTitle + "\r\n");
                this.processingTextBox.AppendText("Album:  " + myAudioFile.audioFileAlbum + "\r\n");


                if (AudioFileDirectory.OrganizeAudioFile(outputDirectory, myAudioFile))
                {
                    //in case the same title is in the folder twice but with spaces we dont want to clash
                    processedTitlesList.Add(myAudioFile.audioFileTitle);
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
