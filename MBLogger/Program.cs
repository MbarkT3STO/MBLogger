using System;
using MBLogger.Logger.Enums;
using static MBLogger.Logger.LogFileBuilder;

namespace MBLogger
{
    class Program
    {
        
        static void Main(string[] args)
        {
            _ = BuildLogFile(null);
            //var logger = new Logger.Logger(LogTarget.File, LogFileFormat.Json, "XXXLog");

       
            Console.WriteLine("Hello World!");

            Console.ReadKey();
        }
        

    }

}
