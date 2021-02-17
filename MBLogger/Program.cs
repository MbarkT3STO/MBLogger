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

            var lg = new Logger.Logger(LogTarget.File, "LOG.txt", LogFileFormat.Text);
            lg.Information("xxx");

            //List<Log> lg = new List<Log>()
            //               {
            //                   new Log() {Label = "xxx", LogLevel = LogLevel.Error, LogMessage = "messagexxxxx"}
            //               };

            //var json = JsonConvert.SerializeObject(lg.ToArray());
            //File.WriteAllText("xxxx.json", json);

       
            Console.WriteLine("Hello World!");

            Console.ReadKey();
        }
        

    }

}
