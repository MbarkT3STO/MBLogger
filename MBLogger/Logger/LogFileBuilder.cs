using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using MBLogger.Logger.Enums;

namespace MBLogger.Logger
{
    class LogFileBuilder
    {


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

        private static Task BuildTextLogFile(string path)
        {
            return Task.Factory.StartNew(() =>
                                         {
                                             using var stream = new StreamWriter(path);
                                         });
        }

        private static Task BuildJsonLogFile(string path)
        {
            return Task.Factory.StartNew(() =>
                                         {
                                             using var stream = new StreamWriter(path);
                                         });
        }

    }
}
