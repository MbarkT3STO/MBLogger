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


        public void Information(string logMessage)
        {
            var logOptions = new LogOptions()
                             {
                                 LogLevel        = LogLevel.Information,
                                 DateTime        = DateTime.Now,
                                 MessageTemplate = logMessage
                             };
            
            ReformatInformationAndLog(logOptions);
        }

        public void Warning(string     logMessage)
        {
            throw new NotImplementedException();
        }

        public void Error(string       logMessage)
        {
            throw new NotImplementedException();
        }


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

        private void LogToTextFile(ILogOptions logOptions)
        {
            string NewLogLine = $"{logOptions.LogLevel} {logOptions.DateTime} {logOptions.MessageTemplate}";
            File.AppendAllText(_logFileOptions.Path, NewLogLine + Environment.NewLine);
        }
        private void LogToJsonFile(ILogOptions logOptions)
        {
            List<ILogOptions> logOptionsList = new List<ILogOptions>()
                                               {
                                                   new LogOptions
                                                   {
                                                       LogLevel        = logOptions.LogLevel,
                                                       DateTime        = logOptions.DateTime,
                                                       MessageTemplate = logOptions.MessageTemplate
                                                   }
                                               };

            var logAsJson = JsonConvert.SerializeObject(logOptionsList, Formatting.Indented);

            File.AppendAllText(_logFileOptions.Path, logAsJson);

        }
    }
}
