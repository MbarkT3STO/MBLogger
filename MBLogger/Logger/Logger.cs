using System;
using System.Collections.Generic;
using System.Text;
using MBLogger.Factory;
using MBLogger.Logger.Enums;


namespace MBLogger.Logger
{
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
        /// <param name="logMessage">Content to be written</param>
        public void Information(string logMessage)
        {
            _logFile.Information(logMessage);
        }

        /// <summary>
        /// Write a new <b>Warning</b> log
        /// </summary>
        /// <param name="logMessage">Content to be written</param>
        public void Warning(string logMessage)
        {
            _logFile.Warning(logMessage);
        }

        /// <summary>
        /// Write a new <b>Error</b> log
        /// </summary>
        /// <param name="logMessage">Content to be written</param>
        public void Error(string logMessage)
        {
            _logFile.Error(logMessage);
        }



        #region Private Methods

        /// <summary>
        /// Set and configure the Log Target
        /// </summary>
        /// <param name="logTarget">The log target</param>
        /// <param name="logFilePath">If the log target a file type set the path</param>
        /// <param name="logFileFormat"></param>
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
