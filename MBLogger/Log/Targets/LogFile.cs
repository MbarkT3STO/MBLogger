using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using MBLogger.Enums;
using MBLogger.Log.Abstract_Operations;
using MBLogger.Log.Builders;
using MBLogger.Log.Options;
using Newtonsoft.Json;

namespace MBLogger.Log.Targets
{
    /// <summary>
    /// To log into a file
    /// </summary>
    internal class LogFile:LogMiddleOps,ILogBase
    {


        private readonly LogFileOptions _logFileOptions;
        

        public LogFile(LogFileOptions logFileOptions)
        {
            _logFileOptions = logFileOptions;
            LogFileBuilder.BuildOne(logFileOptions);
        }




        #region Public Methods



        /// <inheritdoc />
        public void Information(string messageTemplate)
        {
            //Write the log
            LogInformation(messageTemplate);
        }


        /// <inheritdoc />
        public void Warning(string messageTemplate)
        {
            //Write the log
            LogWarning(messageTemplate);
        }


        /// <inheritdoc />
        public void Error(string messageTemplate)
        {
            //Write the log
            LogError(messageTemplate);
        }


        /// <inheritdoc />
        public void Verbose(string messageTemplate)
        {
            //Write the log
            LogVerbose(messageTemplate);
        }


        /// <inheritdoc />
        public void Fatal(string messageTemplate)
        {
            //Write the log
            LogFatal(messageTemplate);
        }


        /// <inheritdoc />
        public void Clear()
        {
            // Clear the old log
            ClearLog();
        }

        #endregion



        #region Middle methods

        /// <inheritdoc />
        protected override void LogInformation(string messageTemplate)
        {
            //Build the new log object
            var logOptions = BuildLog(LogLevel.Information, DateTime.Now, messageTemplate);

            //Write the log in the targeted format
            WriteLog(logOptions);

        }


        /// <inheritdoc />
        protected override void LogWarning(string messageTemplate)
        {
            //Build the new log object
            var logOptions = BuildLog(LogLevel.Warning, DateTime.Now, messageTemplate);

            //Write the log in the targeted format
            WriteLog(logOptions);

        }


        /// <inheritdoc />
        protected override void LogError(string messageTemplate)
        {
            //Build the new log object
            var logOptions = BuildLog(LogLevel.Error, DateTime.Now, messageTemplate);

            //Write the log in the targeted format
            WriteLog(logOptions);

        } 
        

        /// <inheritdoc />
        protected override void LogVerbose(string messageTemplate)
        {
            //Build the new log object
            var logOptions = BuildLog(LogLevel.Verbose, DateTime.Now, messageTemplate);

            //Write the log in the targeted format
            WriteLog(logOptions);

        } 
        

        /// <inheritdoc />
        protected override void LogFatal(string messageTemplate)
        {
            //Build the new log object
            var logOptions = BuildLog(LogLevel.Fatal, DateTime.Now, messageTemplate);

            //Write the log in the targeted format
            WriteLog(logOptions);

        }


        /// <inheritdoc />
        protected override void WriteLog(ILogOptions logOptions)
        {
            switch (_logFileOptions.FileFormat)
            {
                case LogFileFormat.Text:
                    LogToTextFile(logOptions);
                    break;
                case LogFileFormat.Json:
                    LogToJsonFile(logOptions);
                    break;
                case LogFileFormat.Xml:
                    LogToXmlFile(logOptions);
                    break;
            }
        }


        /// <inheritdoc />
        protected override void ClearLog()
        {
            // Delete the old file
            File.Delete(_logFileOptions.Path);

            // Build new one
            LogFileBuilder.BuildOne(_logFileOptions);
        }

        #endregion



        #region Logging Methods


        /// <summary>
        /// Write a new log line/object into a text file
        /// </summary>
        /// <param name="logOptions">The log object that implement <b><see cref="ILogOptions"/></b></param>
        private void LogToTextFile(ILogOptions logOptions)
        {

            string newLogLine =
                $"[{logOptions.LogLevel}] [{logOptions.DateTime}] [{logOptions.MessageTemplate}]";

            File.AppendAllText(_logFileOptions.Path,
                               newLogLine + Environment.NewLine);

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
            var oldLogAsObjects =
                JsonConvert.DeserializeObject<List<LogOptions>>(oldLogAsString) ??
                new List<LogOptions>();

            //Add the new log object to the old ones
            oldLogAsObjects.Add(new LogOptions()
                                {
                                    LogLevel        = logOptions.LogLevel,
                                    DateTime        = logOptions.DateTime,
                                    MessageTemplate = logOptions.MessageTemplate
                                });

            //Serialize the log objects collecion to JSON format
            var logAsJson =
                JsonConvert.SerializeObject(oldLogAsObjects,
                                            Formatting.Indented);

            //Save the log objects into the file
            File.WriteAllText(_logFileOptions.Path,
                              logAsJson);
                                        
        }


        /// <summary>
        /// Write a new log object into an Xml file
        /// </summary>
        /// <param name="logOptions">The log object that implement <b><see cref="ILogOptions"/></b></param>
        private  void LogToXmlFile(ILogOptions logOptions)
        {

            if (LogFileBuilder.IsFileExists(_logFileOptions.Path))
            {
                // Load the created xml log file
                var xDoc = XDocument.Load(_logFileOptions.Path);

                // Build the new log as Xml Element
                var logElement =
                    new XElement("Log",
                                 new XAttribute(nameof(logOptions.LogLevel),
                                                logOptions.LogLevel),
                                 new XAttribute(nameof(logOptions.DateTime),
                                                logOptions.DateTime
                                                       .ToString("MM/dd/yyyy hh:mm:ss.fff")),
                                 new XAttribute(nameof(logOptions.MessageTemplate),
                                                logOptions.MessageTemplate));

                // Add and save the log element to the log xml file
                xDoc.Root?.Add(logElement);
                xDoc.Save(_logFileOptions.Path);
            }
            else
            {
                // If the xml log file not created yet this method will recall itself
                LogToXmlFile(logOptions);
            }

        }



        #endregion



    }
}
