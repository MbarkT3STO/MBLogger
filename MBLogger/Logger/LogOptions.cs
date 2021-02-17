using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MBLogger.Logger.Enums;

namespace MBLogger.Logger
{
    class LogOptions:ILogOptions
    {
        public LogLevel LogLevel        { get; set; } 
        public DateTime DateTime        { get; set; }
        public string   MessageTemplate { get; set; }
    }
}
