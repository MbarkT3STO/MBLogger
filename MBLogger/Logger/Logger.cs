using System;
using System.Diagnostics;
using System.Threading.Tasks;
using MBLogger.Enums;
using MBLogger.Log;

namespace MBLogger.Logger
{
    /// <summary>
    /// The logging middleware
    /// </summary>
    public class Logger:ILogBase
    {

        private readonly ILoggerConfigurations _loggerConfigurations;

        private ILogBase _logFile;
        private ILogBase _logConsole;
        private ILogBase _logDebug;


        #region Constructors

        public Logger(LogTarget logTarget, string logFilePath, LogFileFormat logFileFormat)
        {
            _loggerConfigurations = new LoggerConfigurations
                                    {
                                        LogTarget     = logTarget,
                                        LogFilePath   = logFilePath,
                                        LogFileFormat = logFileFormat
                                    };
            ConfigureLogTarget();
        }


        public Logger(LogTarget logTarget)
        {
            _loggerConfigurations = new LoggerConfigurations
                                    {
                                        LogTarget     = logTarget,
                                        LogFilePath = null,
                                        LogFileFormat = LogFileFormat.None
                                    };
            ConfigureLogTarget();
        }

        #endregion


        /// <inheritdoc/>
        public void Information(string messageTemplate)
        {
            LogInformation(messageTemplate);
        } 

        public Task InformationAsync(string messageTemplate)
        {
            return Task.Factory.StartNew(() =>
                                         {
                                             LogInformation(messageTemplate);
                                         });
        }


        /// <inheritdoc/>
        public void Warning(string messageTemplate)
        {
            LogWarning(messageTemplate);
        } 
        public Task WarningAsync(string messageTemplate)
        {
            return Task.Factory.StartNew(() =>
                                         {
                                             LogWarning(messageTemplate);
                                         });
        }


        /// <inheritdoc/>
        public void Error(string messageTemplate)
        {
            LogError(messageTemplate);
        } 
        public Task ErrorAsync(string messageTemplate)
        {
            return Task.Factory.StartNew(() =>
                                         {
                                             LogError(messageTemplate);
                                         });
        }








        #region Private Methods


        /// <summary>
        /// Set and configure the Log Target
        /// </summary>
        private void ConfigureLogTarget()
        {
            switch (_loggerConfigurations.LogTarget)
            {
                case LogTarget.File:
                    _logFile = new LogFile(new LogFileOptions
                                           {
                                               Path       = _loggerConfigurations.LogFilePath,
                                               FileFormat = _loggerConfigurations.LogFileFormat
                                           });
                    break;
                case LogTarget.Console:
                    _logConsole = new LogConsole();
                    break;  
                case LogTarget.Debug:
                    _logDebug = new LogDebug();
                    break;
            }
        }


        private void LogInformation(string messageTemplate)
        {
            switch (_loggerConfigurations.LogTarget)
            {
                case LogTarget.File:
                    _logFile.Information(messageTemplate);
                    break;
                case LogTarget.Console:
                    _logConsole.Information(messageTemplate);
                    break;
                case LogTarget.Debug:
                    _logDebug.Information(messageTemplate);
                    break;
            }
        }  
        
        private void LogWarning(string messageTemplate)
        {
            switch (_loggerConfigurations.LogTarget)
            {
                case LogTarget.File:
                    _logFile.Warning(messageTemplate);
                    break;
                case LogTarget.Console:
                    _logConsole.Warning(messageTemplate);
                    break;  
                case LogTarget.Debug:
                    _logDebug.Warning(messageTemplate);
                    break;
            }
        }

        private void LogError(string messageTemplate)
        {
            switch (_loggerConfigurations.LogTarget)
            {
                case LogTarget.File:
                    _logFile.Error(messageTemplate);
                    break;
                case LogTarget.Console:
                    _logConsole.Error(messageTemplate);
                    break;  
                case LogTarget.Debug:
                    _logDebug.Error(messageTemplate);
                    break;
            }
        }

        #endregion
    }
}
