using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksonicOrganizer
{
    public static class LogFile
    {
        private static readonly string LOG_FILE_NAME = "booksonic-organizer.log";
        private static readonly string BEGIN_SEPARATOR = ("===============================");
        private static readonly string ACTION = ("> ");
        private static readonly string NEW_LINE = Environment.NewLine;

        public static void  CreateLogFile() {
            if (!File.Exists(LOG_FILE_NAME)) {
                File.Create(LOG_FILE_NAME);
            }

            try
            {
                File.AppendAllText(LOG_FILE_NAME, BEGIN_SEPARATOR + NEW_LINE);
                File.AppendAllText(LOG_FILE_NAME, "STARTED AT: " + DateTime.Now.ToString() + NEW_LINE);
            }
            catch (IOException ioe) 
            {
                Console.WriteLine("Houston, we have a mayor malfunction: {0}", ioe);
            }
        }

        public static void AppendNewFileLog(String fileName) {
            File.AppendAllText(LOG_FILE_NAME, "NEW FILE: " +  fileName + NEW_LINE);

        }

        public static void AppendActionLog(String message) {
            File.AppendAllText(LOG_FILE_NAME, ACTION + message + NEW_LINE);
        }

        public static void AppendCompletedLog() {
            File.AppendAllText(LOG_FILE_NAME, "ENDED ALL FILES AT: " + DateTime.Now.ToString() + NEW_LINE);
        }
    }
}
