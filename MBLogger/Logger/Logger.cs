using System;
using System.Collections.Generic;
using System.Text;
using MBLogger.Factory;
using MBLogger.Logger.Enums;


namespace MBLogger.Logger
{
    /// <summary>
    /// The logging middleware
    /// </summary>
    public class Logger:ILogBase
    {

        private ILogBase _logFile;

        public Logger(LogTarget logTarget, string logFilePath = null, LogFileFormat logFileFormat = LogFileFormat.None)
        {
            SetLogTarget(logTarget, logFilePath, logFileFormat);
        }

        /// <summary>
        /// Write a new <b>Information</b> log
        /// </summary>
        /// <param name="messageTemplate">Content to be written</param>
        public void Information(string messageTemplate)
        {
            _logFile.Information(messageTemplate);
        }

        /// <summary>
        /// Write a new <b>Warning</b> log
        /// </summary>
        /// <param name="messageTemplate">Content to be written</param>
        public void Warning(string messageTemplate)
        {
            _logFile.Warning(messageTemplate);
        }

        /// <summary>
        /// Write a new <b>Error</b> log
        /// </summary>
        /// <param name="messageTemplate">Content to be written</param>
        public void Error(string messageTemplate)
        {
            _logFile.Error(messageTemplate);
        }



        #region Private Methods

        /// <summary>
        /// Set and configure the Log Target
        /// </summary>
        /// <param name="logTarget">The log target</param>
        /// <param name="logFilePath">If the log target a file type, set the path</param>
        /// <param name="logFileFormat">The targeted file format</param>
        private void SetLogTarget(LogTarget logTarget, string logFilePath = null, LogFileFormat logFileFormat = LogFileFormat.None)
        {
            switch (logTarget)
            {
                case LogTarget.File:
                    _logFile = new LogFile(new LogFileOptions()
                                           {
                                               Path       = logFilePath,
                                               FileFormat = logFileFormat
                                           });
                    break;
            }
        }

        #endregion
    }
}
