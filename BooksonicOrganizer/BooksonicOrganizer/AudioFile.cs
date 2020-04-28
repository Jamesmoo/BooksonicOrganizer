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
        public string audioFileAlbum { get; }

        public AudioFile(string filePath, TagLib.File myFile) {
            audioFilePath = filePath;
            audioFileArtist = CleanValueString(myFile.Tag.FirstPerformer);
            audioFileAlbum = CleanValueString(myFile.Tag.Album);
        }

        /*
         * Need to remove any characters that would be problematic when it comes to creating directories
         */
        private string CleanValueString(string myValue) {
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

            return myValue;
        }
    }
}
