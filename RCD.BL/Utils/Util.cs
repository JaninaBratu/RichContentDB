using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;

namespace RCD.BL.Utils
{
    public class Util
    {
        /// <summary>
        /// Get the file extension
        /// </summary>
        /// <param name="fileNameWithExtension">Files name with the extension</param>
        /// <param name="withDot">A parameter that determines whether the extension returns with or without dot</param>
        /// <returns></returns>
        public static String GetFileExtension(String fileNameWithExtension, bool withDot = false) {

            if(withDot)
            {
                return Path.GetExtension(fileNameWithExtension);
            }

            return Path.GetExtension(fileNameWithExtension).Trim('.');
        }

        //Write message in the log file
        public static void Log(string message)
        {
            try
            {
                string _message = String.Format("{0} {1}", message, Environment.NewLine);
                File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "logFile.txt", _message);
            }
            catch (Exception)
            {
                throw;

            }
        }

        
    }

}
