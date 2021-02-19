using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json.Serialization;
using MBLogger.Enums;
using MBLogger.Logger;
using Newtonsoft.Json;
using static MBLogger.Log.LogFileBuilder;


namespace MBLogger
{
    class Program
    {
        
        static async System.Threading.Tasks.Task Main(string[] args)
        {

            // Create a logger targeting logging into file with XML format
            //var lg = new Logger.Logger(LogTarget.File, "LOG.xml", LogFileFormat.Xml);

            // Create a logger targeting logging into console
            //var lg = new Logger.Logger(LogTarget.Console);

            // Create a logger targeting logging into Debug
            var lg = new Logger.Logger(LogTarget.Debug);

            // Do logging
            await lg.InformationAsync("This is Info");
            await lg.WarningAsync("This is warning");
            await lg.ErrorAsync("This is Error");



            Console.ReadKey();
        }
        

    }

}
