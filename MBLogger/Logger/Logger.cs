﻿using System;
using System.Collections.Generic;
using System.Text;
using MBLogger.Factory;
using MBLogger.Logger.Enums;
using Serilog;

namespace MBLogger.Logger
{ 
    public class Logger
    {
        public string LogfFilePath { get; set; }

        private ILogger   _logger;
        private LogTarget _logTarget;
        private LogFileFormat _logFileFormat;
        private string _logFilePath;

        public Logger(LogTarget logTarget, LogFileFormat logFileFormat, string logfFilePath = null)
        {
            SetProperties(logTarget, logFileFormat, logfFilePath);

            BuildInstance();
        }


        private Void SetProperties(LogTarget logTarget, LogFileFormat fileFormat, string logfFilePath)
        {
            _logTarget     = logTarget;
            _logFileFormat = fileFormat;
            _logFilePath   = logfFilePath;
        }



        #region Private instance building methods


        private ILogger BuildInstance()
        {
            ILogger logger = null;

            switch (_logTarget)
            {
                case LogTarget.Console:
                    logger = BuildConsoleLogger();
                    break;
                case LogTarget.File:
                    logger = BuildFileLogger();
                    break;
            }

            return logger;
        }


        private ILogger BuildFileLogger()
        {
            ILogger logger = null;

            SetLogFilePath();

            switch (_logFileFormat)
            {
                case LogFileFormat.Text:
                    logger = SeriLoggerFactory.GetInstanceForTextFile(_logFilePath);
                    break; 
                case LogFileFormat.Json:
                    logger = SeriLoggerFactory.GetInstanceForJsonFile(_logFilePath);
                    break;
            }

            return logger;
        }

        private ILogger BuildConsoleLogger() => SeriLoggerFactory.GetInstanceForConsole();



        private void SetLogFilePath() =>
            LogfFilePath = _logFilePath + (_logFileFormat is LogFileFormat.Text ? ".txt" : ".json");

        #endregion



        #region Private LOGGIN methods

        public void Log()
        {

        }

        #endregion



    }
}