using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MBLogger.Logger.Enums;

namespace MBLogger
{
    interface ILogOptions
    { 
        DateTime DateTime { get; set; }
        LogLevel LogLevel { get; set; }
        string MessageTemplate { get; set; }
    }
}
