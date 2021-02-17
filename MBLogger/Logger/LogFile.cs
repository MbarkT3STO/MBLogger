using System;
using System.Collections.Generic;
using System.Text;
using MBLogger.Logger.Enums;

namespace MBLogger.Logger
{
    class LogFile:ILogBase
    {
        private LogFileOptions _logFileOptions;


        public LogFile(LogFileOptions logFileOptions)
        {
            _logFileOptions = logFileOptions;

            LogFileBuilder.BuildLogFile(logFileOptions);
        }


        public void Information(string logMessage)
        {
            throw new NotImplementedException();
        }

        public void Warning(string     logMessage)
        {
            throw new NotImplementedException();
        }

        public void Error(string       logMessage)
        {
            throw new NotImplementedException();
        }


        private void ReformatInformationAndLog(string logText, LogType logType)
        {

        }


        private void LogToFile()
        {

        }
    }
}
