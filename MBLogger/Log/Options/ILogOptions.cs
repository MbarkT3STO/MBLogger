using System;
using MBLogger.Enums;

namespace MBLogger.Log.Options
{
    public interface ILogOptions
    { 
        DateTime DateTime { get; set; }
        LogLevel LogLevel { get; set; }
        string MessageTemplate { get; set; }
    }
}
