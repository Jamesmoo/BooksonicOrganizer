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
            try
            {
                //check if there is an artist folder
                if (Directory.Exists(outputDirectory))
                {
                    string artistPath = outputDirectory + @"\" + myAudioFile.audioFileArtist;
                    string albumPath = artistPath + @"\" + myAudioFile.audioFileAlbum;

                    if (!Directory.Exists(artistPath)) {
                        Directory.CreateDirectory(artistPath);
                    }

                    if (!Directory.Exists(albumPath))
                    {
                        Directory.CreateDirectory(albumPath);
                    }
                    else 
                    {
                        Console.WriteLine("ERROR - the album path exists already");
                        return false;
                    }

                    string[] parts = myAudioFile.audioFilePath.Split('\\');
                    string fileName = parts[parts.Length - 1];
             
                    string origin = myAudioFile.audioFilePath;
                    string destination = albumPath + @"\" + fileName;
                    File.Copy(origin, destination, false);
                    return true;
                }
                else 
                {
                    Console.WriteLine("ERROR: output folder does not exist");
                    return false;  
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
    }
}
