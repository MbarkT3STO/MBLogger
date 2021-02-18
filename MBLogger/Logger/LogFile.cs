using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using MBLogger.Logger.Builder;
using MBLogger.Logger.Enums;
using Newtonsoft.Json;

namespace MBLogger.Logger
{
    /// <summary>
    /// To log into a file
    /// </summary>
    class LogFile:ILogBase
    {


        private readonly LogFileOptions _logFileOptions;
        

        public LogFile(LogFileOptions logFileOptions)
        {
            _logFileOptions = logFileOptions;

           LogFileBuilder.BuildLogFile(logFileOptions);
        }




        #region Public Methods

        

        /// <summary>
        /// Write a new <b>Information</b> log
        /// </summary>
        /// <param name="messageTemplate">Content to be written</param>
        public void Information(string messageTemplate)
        {
            //Write the log
            LogInformation(messageTemplate);
        }


        /// <summary>
        /// Write a new <b>Warning</b> log
        /// </summary>
        /// <param name="messageTemplate">Content to be written</param>
        public void Warning(string messageTemplate)
        {
            //Write the log
            LogWarning(messageTemplate);
        }


        /// <summary>
        /// Write a new <b>Error</b> log
        /// </summary>
        /// <param name="messageTemplate">Content to be written</param>
        public void Error(string messageTemplate)
        {
            //Write the log
            LogError(messageTemplate);
        }



        #endregion




        #region Middle methods

        /// <summary>
        /// Configure and log new <b>Information</b>
        /// </summary>
        /// <param name="messageTemplate">Content to be written</param>
        private void LogInformation(string messageTemplate)
        {
            //Build the new log object
            var logOptions = LogBuilder.BuildOne(LogLevel.Information, DateTime.Now, messageTemplate);

            //Write the log in the targeted format
            SetLogFormat(logOptions);

        }
        

        /// <summary>
        /// Configure and log new <b>Warning</b>
        /// </summary>
        /// <param name="messageTemplate">Content to be written</param>
        private void LogWarning(string messageTemplate)
        {
            //Build the new log object
            var logOptions = LogBuilder.BuildOne(LogLevel.Warning, DateTime.Now, messageTemplate);

            //Write the log in the targeted format
            SetLogFormat(logOptions);

        }


        /// <summary>
        /// Configure and log new <b>Error</b>
        /// </summary>
        /// <param name="messageTemplate">Content to be written</param>
        private void LogError(string messageTemplate)
        {
            //Build the new log object
            var logOptions = LogBuilder.BuildOne(LogLevel.Error, DateTime.Now, messageTemplate);

            //Write the log in the targeted format
            SetLogFormat(logOptions);

        }



        /// <summary>
        /// Write the log into a specific file format
        /// </summary>
        /// <param name="logOptions">The log object that implement <b><see cref="ILogOptions"/></b></param>
        private void SetLogFormat(ILogOptions logOptions)
        {
            switch (_logFileOptions.FileFormat)
            {
                case LogFileFormat.Text:
                    LogToTextFile(logOptions);
                    break;
                case LogFileFormat.Json:
                    LogToJsonFile(logOptions);
                    break;
            }
        }


        #endregion




        #region Private Methods


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
            //Load the old log
            string oldLogAsString = File.ReadAllText(_logFileOptions.Path);

            //Deserialize the old log content to objects
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


        #endregion
    }
}
