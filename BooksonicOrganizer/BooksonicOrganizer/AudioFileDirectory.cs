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
                    string artistPath = outputDirectory + @"\" + myAudioFile.audioFileArtist;
                    string albumPath = artistPath + @"\" + myAudioFile.audioFileAlbum;
                    LogFile.AppendActionLog("Artist Path Directory: " + artistPath);
                    LogFile.AppendActionLog("Artist Path Directory: " + albumPath);

                    if (!Directory.Exists(artistPath)) {
                        LogFile.AppendActionLog("Artist path does not exist");
                        Directory.CreateDirectory(artistPath);
                    }

                    if (!Directory.Exists(albumPath)) {
                        LogFile.AppendActionLog("Album path does not exist");
                        Directory.CreateDirectory(albumPath);
                    }

                    string[] parts = myAudioFile.audioFilePath.Split('\\');
                    string fileName = parts[parts.Length - 1];
                    LogFile.AppendActionLog("File Name: " + fileName);

                    string origin = myAudioFile.audioFilePath;
                    string destination = albumPath + @"\" + fileName;
                    File.Copy(origin, destination, false);
                    LogFile.AppendActionLog("Copied file from: " + origin);
                    LogFile.AppendActionLog("Copied file to: " + destination);
                }
                else 
                {
                    LogFile.AppendActionLog("ERROR: output folder does not exist");
                    Console.WriteLine("ERROR: output folder does not exist");
                    success = false;  
                }
            }
            catch (Exception ex)
            {
                LogFile.AppendActionLog("EXCEPTION: " + ex);
                Console.WriteLine(ex);
                success = false;
            }
            return success;
        }
    }
}
