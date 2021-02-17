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

        public void Information(string logMessage)
        {
            _logFile.Information(logMessage);
        }

        public void Warning(string logMessage)
        {
            _logFile.Warning(logMessage);

        }

        public void Error(string logMessage)
        {
            _logFile.Error(logMessage);

        }
    }
}
