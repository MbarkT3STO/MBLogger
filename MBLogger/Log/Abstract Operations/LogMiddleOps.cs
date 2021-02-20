using MBLogger.Log.Options;

namespace MBLogger.Log.Abstract_Operations
{
    /// <summary>
    /// Private log's middle operations
    /// </summary>
    public abstract class LogMiddleOps
    {
        /// <summary>
        /// Configure and log new <b>Information</b>
        /// </summary>
        /// <param name="messageTemplate">Content to be written</param>
        protected abstract void LogInformation(string messageTemplate);

        /// <summary>
        /// Configure and log new <b>Warning</b>
        /// </summary>
        /// <param name="messageTemplate">Content to be written</param>
        protected abstract void LogWarning(string     messageTemplate);

        /// <summary>
        /// Configure and log new <b>Error</b>
        /// </summary>
        /// <param name="messageTemplate">Content to be written</param>
        protected abstract void LogError(string       messageTemplate);

        /// <summary>
        /// Configure and log new <b>Verbose</b>
        /// </summary>
        /// <param name="messageTemplate">Content to be written</param>
        protected abstract void LogVerbose(string messageTemplate);
        
        /// <summary>
        /// Configure and log new <b>Fatal</b>
        /// </summary>
        /// <param name="messageTemplate">Content to be written</param>
        protected abstract void LogFatal(string messageTemplate);


        /// <summary>
        /// Write the new log
        /// </summary>
        /// <param name="logOptions">The log options object that impliment <b><see cref="ILogOptions"/></b></param>
        protected virtual void WriteLog(ILogOptions       logOptions){}

        /// <summary>
        /// Clear all old logs
        /// </summary>
        protected abstract void ClearLog();



    }
}
