using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using MBLogger.Logger.Enums;
using Newtonsoft.Json;

namespace MBLogger.Logger
{
    class LogFile:ILogBase
    {


        private readonly LogFileOptions _logFileOptions;


        public LogFile(LogFileOptions logFileOptions)
        {
            _logFileOptions = logFileOptions;

            LogFileBuilder.BuildLogFile(logFileOptions);
        }


        /// <summary>
        /// Write a new <b>Information</b> log
        /// </summary>
        /// <param name="logMessage">Content to be written</param>
        public void Information(string logMessage)
        {
            //Build the new log object
            var logOptions = new LogOptions()
                             {
                                 LogLevel        = LogLevel.Information,
                                 DateTime        = DateTime.Now,
                                 MessageTemplate = logMessage
                             };
            
            //Write the log
            ReformatInformationAndLog(logOptions);
        }


        /// <summary>
        /// Write a new <b>Warning</b> log
        /// </summary>
        /// <param name="logMessage">Content to be written</param>
        public void Warning(string     logMessage)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Write a new <b>Error</b> log
        /// </summary>
        /// <param name="logMessage">Content to be written</param>
        public void Error(string       logMessage)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Configure the <b>Information</b> log target and call the responsible for write it
        /// </summary>
        /// <param name="logOptions">The log object that implement <b><see cref="ILogOptions"/></b></param>
        private void ReformatInformationAndLog(ILogOptions logOptions)
        {
            switch (_logFileOptions.FileFormat)
            {
                case LogFileFormat.Text: LogToTextFile(logOptions);
                    break;
                case LogFileFormat.Json: LogToJsonFile(logOptions);
                    break;
            }
        }

        /// <summary>
        /// Write a new log line/object into a text file
        /// </summary>
        /// <param name="logOptions">The log object that implement <b><see cref="ILogOptions"/></b></param>
        private void LogToTextFile(ILogOptions logOptions)
        {
            string newLogLine = $"{logOptions.LogLevel} {logOptions.DateTime} {logOptions.MessageTemplate}";
            File.AppendAllText(_logFileOptions.Path, newLogLine + Environment.NewLine);
        }

        /// <summary>
        /// Write a new log object into a Json file
        /// </summary>
        /// <param name="logOptions">The log object that implement <b><see cref="ILogOptions"/></b></param>
        private void LogToJsonFile(ILogOptions logOptions)
        {

            string oldLogAsString  = File.ReadAllText(_logFileOptions.Path);
            var oldLogAsObjects = JsonConvert.DeserializeObject<List<LogOptions>>(oldLogAsString) ?? new List<LogOptions>();

            //Add the new log object to the old ones
            oldLogAsObjects.Add(new LogOptions()
                                    {
                                        LogLevel        = logOptions.LogLevel,
                                        DateTime        = logOptions.DateTime,
                                        MessageTemplate = logOptions.MessageTemplate
                                    });

            //Serialize the log objects collecion to JSON format
            var logAsJson = JsonConvert.SerializeObject(oldLogAsObjects, Formatting.Indented);

            //Save the log objects into the file
            File.WriteAllText(_logFileOptions.Path, logAsJson);

        }
    }
}
