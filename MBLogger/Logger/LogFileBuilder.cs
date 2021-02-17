using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace MBLogger.Logger
{
    class LogFileBuilder
    {


        public static Task BuildLogFile(LogFileOptions logFileOptions)
        {
            return Task.Factory.StartNew(() =>
                                         {
                                             using var stream = new StreamWriter(logFileOptions.Path);
                                         });
        }

    }
}
