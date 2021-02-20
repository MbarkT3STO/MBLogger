using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json.Serialization;
using MBLogger.Enums;
using MBLogger.Logger;
using Newtonsoft.Json;
using static MBLogger.Log.Builders.LogFileBuilder;


namespace MBLogger
{
    class Program
    {
        
        static async System.Threading.Tasks.Task Main(string[] args)
        {

            // Create a logger targeting logging into file with XML format saved on Desktop
            var lg = new Logger.Logger(LogTarget.File, Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/LOG.xml", LogFileFormat.Xml);

            // Create a logger targeting logging into console
            //var lg = new Logger.Logger(LogTarget.Console);

            // Create a logger targeting logging into Debug
            //var lg = new Logger.Logger(LogTarget.Debug);


            // To do Clear to old logs
            //await lg.ClearAsync();

            // Do new logging
            await lg.InformationAsync("This is Information");
            await lg.WarningAsync("This is warning");
            await lg.ErrorAsync("This is Error");
            await lg.VerboseAsync("This is Verbose");
            await lg.FatalAsync("This is Fatal error");


            Console.WriteLine("Done");

            Console.ReadKey();
        }
        

    }

}
