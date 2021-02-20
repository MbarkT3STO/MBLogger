using System;
using System.Diagnostics;
using MBLogger.Enums;
using MBLogger.Log.Abstract_Operations;
using MBLogger.Log.Builders;
using MBLogger.Log.Options;

namespace MBLogger.Log.Targets
{
    class LogDebug:LogMiddleOps,ILogBase
    {


        #region Public methods


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
            ClearLog();
        }


        #endregion



        #region Middle methods

        /// <inheritdoc />
        protected override void LogInformation(string messageTemplate)
        {
            //Build the new log object
            var logOptions = LogBuilder.BuildOne(LogLevel.Information, DateTime.Now, messageTemplate);

            //Write the log
            WriteLog(logOptions);

        }


        /// <inheritdoc />
        protected override void LogWarning(string messageTemplate)
        {
            //Build the new log object
            var logOptions = LogBuilder.BuildOne(LogLevel.Warning, DateTime.Now, messageTemplate);

            //Write the log
            WriteLog(logOptions);

        }


        /// <inheritdoc />
        protected override void LogError(string messageTemplate)
        {
            //Build the new log object
            var logOptions = LogBuilder.BuildOne(LogLevel.Error, DateTime.Now, messageTemplate);

            //Write the log
            WriteLog(logOptions);

        }


        /// <inheritdoc />
        protected override void LogVerbose(string messageTemplate)
        {
            //Build the new log object
            var logOptions = LogBuilder.BuildOne(LogLevel.Verbose, DateTime.Now, messageTemplate);

            //Write the log
            WriteLog(logOptions);

        }


        /// <inheritdoc />
        protected override void LogFatal(string messageTemplate)
        {
            //Build the new log object
            var logOptions = LogBuilder.BuildOne(LogLevel.Fatal, DateTime.Now, messageTemplate);

            //Write the log
            WriteLog(logOptions);

        }

        #endregion



        #region Logging methods

        /// <inheritdoc />
        protected override void WriteLog(ILogOptions logOptions)
        {
            Debug.WriteLine($"[{logOptions.LogLevel}], [{logOptions.DateTime}], [{logOptions.MessageTemplate}]");
        }

        /// <inheritdoc />
        protected override void ClearLog()
        {
            Warning("Can't clear logs from Output window");
        }

        #endregion


    }
}
