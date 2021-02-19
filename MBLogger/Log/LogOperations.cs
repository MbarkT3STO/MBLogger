namespace MBLogger.Log
{
    abstract class LogOperations
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
        /// Write the new log
        /// </summary>
        /// <param name="logOptions">The log options object that impliment <b><see cref="ILogOptions"/></b></param>
        protected abstract void WriteLog(ILogOptions       logOptions);
    }
}
