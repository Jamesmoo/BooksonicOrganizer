using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using System.IO;


namespace BooksonicOrganizer
{
    public class AudioFile 
    {
        public string audioFilePath {get; }
        public string audioFileArtist { get; }
        public string audioFileTitle{ get; }
        public string audioFileAlbum { get; }
        public TagLib.File audioFileObj { get; }

        public AudioFile(string filePath, TagLib.File myFile) {
            audioFileObj = myFile;
            audioFilePath = filePath;
            Boolean changesMade = false;
            LogFile.AppendActionLog("Starting ID3 Tag process..");

            string[] filePerformers = new[] { CleanValueString(audioFileObj.Tag.FirstPerformer) };
            if (filePerformers.Length > 0) {
                if (!audioFileObj.Tag.FirstPerformer.Equals(filePerformers[0])) {
                    audioFileObj.Tag.Performers = filePerformers;
                    changesMade = true;
                }
                audioFileArtist = filePerformers[0];
            }

            if (!string.IsNullOrEmpty(audioFileObj.Tag.Title)) {
                audioFileTitle = CleanValueString(audioFileObj.Tag.Title);
                if (!audioFileObj.Tag.Title.Equals(audioFileTitle)) {
                    audioFileObj.Tag.Title = audioFileTitle;
                    changesMade = true;
                }
            }

            if (!string.IsNullOrEmpty(audioFileObj.Tag.Album)) {
                audioFileAlbum = CleanValueString(audioFileObj.Tag.Album);
                if (!audioFileObj.Tag.Album.Equals(audioFileAlbum)) {
                    audioFileObj.Tag.Album = audioFileAlbum;
                    changesMade = true;
                }
            }

            if (changesMade) {
                audioFileObj.Save();
                LogFile.AppendActionLog("Changes Saved");
                LogFile.AppendActionLog("Artist Now: '" + audioFileObj.Tag.Performers[0] + "'");
                LogFile.AppendActionLog("Title Now: '" + audioFileObj.Tag.Title + "'");
                LogFile.AppendActionLog("Album Now: '" + audioFileObj.Tag.Album + "'");
            }
        }

        private string CleanValueString(string myValue) {
            LogFile.AppendActionLog("Cleaning value from : '" + myValue + "'");
            myValue = myValue.Trim();
            
            //change encoding to UTF-8
            byte[] bytes = Encoding.Default.GetBytes(myValue);
            myValue = Encoding.UTF8.GetString(bytes);

            //replace 2 or more whitespaces with a single whitespace
            RegexOptions options = RegexOptions.None;
            Regex regex = new Regex("[ ]{2,}", options);
            myValue = regex.Replace(myValue, " ");


            char[] folderNameNotAllowedChard = new char[] { '\\', '/', ':', '*', '?', '"', '<', '>','\r', '\t', '\n' };
            char[] invalidFileNameChars = Path.GetInvalidFileNameChars();

            string[] temp = myValue.Split(folderNameNotAllowedChard, StringSplitOptions.RemoveEmptyEntries);
            myValue = String.Join("\n", temp);

            temp = myValue.Split(invalidFileNameChars, StringSplitOptions.RemoveEmptyEntries);
            myValue = String.Join("\n", temp);

            LogFile.AppendActionLog("Cleaning value to :'" + myValue + "'");
            return myValue;
        }
    }
}
