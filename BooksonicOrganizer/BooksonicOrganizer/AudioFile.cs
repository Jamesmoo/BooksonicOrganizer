using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace BooksonicOrganizer
{
    public class AudioFile 
    {
        public string audioFilePath {get; }
        public string audioFileAuthor { get; }
        public string audioFileAlbum { get; }
        public TagLib.File audioFileObj { get; }

        public AudioFile(string filePath, TagLib.File myFile) {
            audioFileObj = myFile;
            audioFilePath = filePath;
            audioFileAuthor = CleanValueString(audioFileObj.Tag.AlbumArtists[0]);
            audioFileAlbum = CleanValueString(audioFileObj.Tag.Album);
        }

        private string CleanValueString(string myValue) {
            myValue = myValue.Trim();
            
            //change encoding to UTF-8
            byte[] bytes = Encoding.Default.GetBytes(myValue);
            myValue = Encoding.UTF8.GetString(bytes);

            //replace 2 or more whitespaces with a single whitespace
            RegexOptions options = RegexOptions.None;
            Regex regex = new Regex("[ ]{2,}", options);
            myValue = regex.Replace(myValue, " ");

            return myValue;
        }
    }
}
