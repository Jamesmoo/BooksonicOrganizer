using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksonicOrganizer
{
    public static class AudioFileDirectory
    {
        public static Boolean OrganizeAudioFile(string outputDirectory, AudioFile myAudioFile) {
            Boolean success = true;
            try
            {
                //check if there is an artist folder
                if (Directory.Exists(outputDirectory))
                {
                    String artistPath = outputDirectory + @"\" + myAudioFile.audioFileArtist;
                    String albumPath = artistPath + @"\" + myAudioFile.audioFileAlbum;

                    if (!Directory.Exists(artistPath)) {
                        Directory.CreateDirectory(artistPath);
                    }

                    if (!Directory.Exists(albumPath)) {
                        Directory.CreateDirectory(albumPath);
                    }

                    String[] parts = myAudioFile.audioFilePath.Split('\\');
                    String fileName = parts[parts.Length - 1];
                    File.Copy(myAudioFile.audioFilePath, albumPath + @"\" + fileName, false);
                }
                else 
                {
                    Console.WriteLine("ERROR: output folder does not exist");
                    success = false;  
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                success = false;
            }
            return success;
        }
    }
}
