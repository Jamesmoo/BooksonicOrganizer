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
            var fileEntries = Directory.EnumerateFiles(targetDirectory, "*.*", SearchOption.AllDirectories)
                 .Where(s => s.EndsWith(".mp3") || s.EndsWith(".m4b"));

            this.processingTextBox.AppendText("*** Starting ***\r\n");

            ArrayList authorList = new ArrayList();
            ArrayList albumList = new ArrayList();

            int currentCount = 1;
            int totalCount = fileEntries.Count();
            
            foreach (var filePath in fileEntries) {
                TagLib.File audioFile = TagLib.File.Create(filePath);
                AudioFile myFile = new AudioFile(filePath, audioFile);

                this.processingTextBox.AppendText("---------------------------------\r\n");
                this.processingTextBox.AppendText("File " + currentCount + " of " + totalCount + "\r\n");
                this.processingTextBox.AppendText("File Name: " + filePath + "\r\n");
                
                string fileTitle = audioFile.Tag.Title.ToString();
                this.processingTextBox.AppendText("Title: " + fileTitle + "\r\n");

                string fileAlbum = audioFile.Tag.Album.ToString();
                this.processingTextBox.AppendText("Album: " + fileAlbum + "\r\n");

                string fileArtist = audioFile.Tag.Performers[0];
                this.processingTextBox.AppendText("Artist: " + fileArtist + "\r\n");

                //clean up the file attributes
                

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
