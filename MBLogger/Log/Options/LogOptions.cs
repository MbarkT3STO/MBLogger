using System;
using MBLogger.Enums;

namespace MBLogger.Log.Options
{
    class LogOptions:ILogOptions
    {
        public LogLevel LogLevel        { get; set; } 
        public DateTime DateTime        { get; set; }
        public string   MessageTemplate { get; set; }
    }
}
