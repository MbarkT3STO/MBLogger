using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using MBLogger.Logger.Enums;

namespace MBLogger.Logger
{
    static class LogFileBuilder
    {

        /// <summary>
        /// Create a new file to logged into
        /// </summary>
        /// <param name="logFileOptions">The file options</param>
        /// <returns></returns>
        public static Task BuildLogFile(LogFileOptions logFileOptions)
        {
            return Task.Factory.StartNew(() =>
                                         {
                                             if (!File.Exists(logFileOptions.Path))
                                             {
                                                 switch (logFileOptions.FileFormat)
                                                 {
                                                     case LogFileFormat.Text: BuildTextLogFile(logFileOptions.Path);
                                                         break; 
                                                     case LogFileFormat.Json: BuildTextLogFile(logFileOptions.Path);
                                                         break;
                                                 }
                                             }
                                         });
        }


        /// <summary>
        /// Build a new <b>Text</b> file
        /// </summary>
        /// <param name="path">The file name/path</param>
        /// <returns></returns>
        private static Task BuildTextLogFile(string path)
        {
            return Task.Factory.StartNew(() =>
                                         {
                                             using var stream = new StreamWriter(path);
                                         });
        }


        /// <summary>
        /// Build a new <b>Json</b> file
        /// </summary>
        /// <param name="path">The file name/path</param>
        /// <returns></returns>
        private static Task BuildJsonLogFile(string path)
        {
            return Task.Factory.StartNew(() =>
                                         {
                                             using var stream = new StreamWriter(path);
                                         });
        }

    }
}
