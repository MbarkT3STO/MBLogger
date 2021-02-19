using System;
using System.Diagnostics;
using MBLogger.Builders;
using MBLogger.Enums;
using MBLogger.Logger;

namespace MBLogger.Log
{
    class LogDebug:LogOperations,ILogBase
    {



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
        protected override void WriteLog(ILogOptions logOptions)
        {
            Debug.WriteLine($"[{logOptions.LogLevel}], [{logOptions.DateTime}], [{logOptions.MessageTemplate}]");
        }


    }
}
