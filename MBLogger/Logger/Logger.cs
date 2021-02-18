using System;
using System.Collections.Generic;
using System.Text;
using MBLogger.Factory;
using MBLogger.Logger.Enums;


namespace MBLogger.Logger
{
    public class Logger:ILogBase
    {

        private readonly ILogBase _logFile;

        public Logger(LogTarget logTarget, string logFilePath = null, LogFileFormat logFileFormat = LogFileFormat.None)
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

        private void SetLogTarget()
        {

        }

        #endregion
    }
}
