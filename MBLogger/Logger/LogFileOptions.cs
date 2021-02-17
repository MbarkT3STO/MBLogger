using System;
using System.Collections.Generic;
using System.Text;
using MBLogger.Logger.Enums;

namespace MBLogger.Logger
{
    class LogFileOptions
    {
        public string Path { get; set; }
        public LogFileFormat FileFormat { get; set; }
    }
}
