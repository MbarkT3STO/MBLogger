using System;
using System.Threading.Tasks;
using MBLogger.Enums;
using MBLogger.Log;
using MBLogger.Log.Abstract_Operations;
using MBLogger.Log.Options;
using MBLogger.Log.Targets;

namespace MBLogger.Logger
{
    /// <summary>
    /// The logging middleware
    /// </summary>
    public class Logger:LogMiddleOps,ILogBase
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



        #region Public methods


        /// <inheritdoc/>
        public void Information(string messageTemplate)
        {
            LogInformation(messageTemplate);
        }

        public Task InformationAsync(string messageTemplate)
        {
            return Task.Factory.StartNew(() => LogInformation(messageTemplate));
        }


        /// <inheritdoc/>
        public void Warning(string messageTemplate)
        {
            LogWarning(messageTemplate);
        }
        public Task WarningAsync(string messageTemplate)
        {
            return Task.Factory.StartNew(() => LogWarning(messageTemplate));
        }


        /// <inheritdoc/>
        public void Error(string messageTemplate)
        {
            LogError(messageTemplate);
        }
        public Task ErrorAsync(string messageTemplate)
        {
            return Task.Factory.StartNew(() => LogError(messageTemplate));
        }


        /// <inheritdoc/>
        public void Verbose(string messageTemplate)
        {
            LogVerbose(messageTemplate);
        }
        public Task VerboseAsync(string messageTemplate)
        {
            return Task.Factory.StartNew(() => LogVerbose(messageTemplate));
        }

        /// <inheritdoc/>
        public void Fatal(string messageTemplate)
        {
            LogFatal(messageTemplate);
        }
        public Task FatalAsync(string messageTemplate)
        {
            return Task.Factory.StartNew(() => LogFatal(messageTemplate));
        }

        /// <inheritdoc/>
        public void Clear()
        {
            ClearLog();
        }
        public Task ClearAsync()
        {
            return Task.Factory.StartNew(ClearLog);
        }

        #endregion



        #region Middle Methods


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


        protected override void LogInformation(string messageTemplate)
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

        protected override void LogWarning(string messageTemplate)
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

        protected override void LogError(string messageTemplate)
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

        protected override void LogVerbose(string messageTemplate)
        {
            switch (_loggerConfigurations.LogTarget)
            {
                case LogTarget.File:
                    _logFile.Verbose(messageTemplate);
                    break;
                case LogTarget.Console:
                    _logConsole.Verbose(messageTemplate);
                    break;  
                case LogTarget.Debug:
                    _logDebug.Verbose(messageTemplate);
                    break;
            }
        }

        protected override void LogFatal(string messageTemplate)
        {
            switch (_loggerConfigurations.LogTarget)
            {
                case LogTarget.File:
                    _logFile.Fatal(messageTemplate);
                    break;
                case LogTarget.Console:
                    _logConsole.Fatal(messageTemplate);
                    break;  
                case LogTarget.Debug:
                    _logDebug.Fatal(messageTemplate);
                    break;
            }
        }

        protected override void ClearLog()
        {
            switch (_loggerConfigurations.LogTarget)
            {
                case LogTarget.File:
                    _logFile.Clear();
                    break;

                case LogTarget.Console:
                    _logConsole.Clear();
                    break;
                case LogTarget.Debug:
                    _logDebug.Clear();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        #endregion



    }
}
