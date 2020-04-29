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
        public static DirectoryProcessingCode OrganizeAudioFile(string outputDirectory, AudioFile myAudioFile) {
            try
            {
                string fileName = GetFileName(myAudioFile);
                if (Directory.Exists(outputDirectory))
                {
                    string artistPath = outputDirectory + @"\" + myAudioFile.audioFileArtist;
                    string albumPath = artistPath + @"\" + myAudioFile.audioFileAlbum;

                    if (!Directory.Exists(artistPath)) 
                    {
                        Directory.CreateDirectory(artistPath);
                    }

                    if (!Directory.Exists(albumPath))
                    {
                        Directory.CreateDirectory(albumPath);
                        CopyFile(albumPath, myAudioFile, fileName);
                        return DirectoryProcessingCode.SUCCESS;

                    }
                    else 
                    {
                        var albumDirectoryFiles = Directory.EnumerateFiles(albumPath, "*.*", SearchOption.AllDirectories)
                            .Where(s => s.EndsWith(".mp3") || s.EndsWith(".m4b"));

                        if (albumDirectoryFiles.Count() == 0)
                        {
                            CopyFile(albumPath, myAudioFile, fileName);
                            return DirectoryProcessingCode.SUCCESS;
                        }
                        else 
                        {
                            Boolean duplicate = false;
                            foreach (var path in albumDirectoryFiles) {
                                if (path.Contains(fileName))
                                {
                                    duplicate = true;
                                }
                            }

                            if (!duplicate)
                            {
                                CopyFile(albumPath, myAudioFile, fileName);
                                return DirectoryProcessingCode.SUCCESS;
                            }
                            else 
                            {
                                return DirectoryProcessingCode.ALBUM_FILE_ALREADY_EXISTS;
                            }
                        }
                    }
                }
                else 
                {
                    return DirectoryProcessingCode.OUTPUT_FOLDER_DOES_NOT_EXISTS;  
                }
            }
            catch (Exception ex)
            {
                return DirectoryProcessingCode.EXCEPTION_ERROR;
            }
        }

        private static void CopyFile(string albumPath, AudioFile myAudioFile, string fileName) {
            string origin = myAudioFile.audioFilePath;
            string destination = albumPath + @"\" + fileName;
            File.Copy(origin, destination, false);
        }

        private static string GetFileName(AudioFile myAudioFile) 
        {
            string[] parts = myAudioFile.audioFilePath.Split('\\');
            return parts[parts.Length - 1];
        }
    }
}
