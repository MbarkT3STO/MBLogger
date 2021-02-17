using System;
using System.Collections.Generic;
using System.Text;
using MBLogger.Logger.Enums;

namespace MBLogger.Logger
{
    public class Log:ILog
    {
        public string Label      { get; set; }
        public LogLevel LogLevel      { get; set; }
        public string LogMessage { get; set; }
    }
}
