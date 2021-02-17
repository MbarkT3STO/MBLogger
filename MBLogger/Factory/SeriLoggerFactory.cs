using System;
using System.Collections.Generic;
using System.Text;
using Serilog;
using Serilog.Formatting.Json;

namespace MBLogger.Factory
{
    public static class SeriLoggerFactory
    {

        public static ILogger GetInstanceForTextFile(string filePath)
        {
            return new LoggerConfiguration().WriteTo.File(filePath).CreateLogger();
        }
        
        public static ILogger GetInstanceForJsonFile(string filePath)
        {
            return new LoggerConfiguration().WriteTo.File(new JsonFormatter(), filePath).CreateLogger();
        }
        
        public static ILogger GetInstanceForConsole()
        {
            return new LoggerConfiguration().WriteTo.Console().CreateLogger();
        }



    }
}
