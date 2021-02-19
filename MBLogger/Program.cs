using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json.Serialization;
using MBLogger.Logger;
using MBLogger.Logger.Enums;
using Newtonsoft.Json;
using static MBLogger.Logger.LogFileBuilder;


namespace MBLogger
{
    class Program
    {
        
        static void Main(string[] args)
        {

            var lg = new Logger.Logger(LogTarget.File, "LOG.xml", LogFileFormat.Xml);
            lg.Information("This is Info");
            lg.Warning("This is warning");
            lg.Error("This is Error");

       
            Console.WriteLine("Hello World!");

            Console.ReadKey();
        }
        

    }

}
