namespace MBLogger.Log
{
    interface ILogBase
    { 
        /// <summary>
        /// Log a new <b>Information</b>
        /// </summary>
        /// <param name="messageTemplate"></param>
        void Information(string messageTemplate);
        /// <summary>
        /// Log a new <b>Warning</b>
        /// </summary>
        /// <param name="messageTemplate"></param>
        void Warning(string     messageTemplate);
        /// <summary>
        /// Log a new <b>Error</b>
        /// </summary>
        /// <param name="messageTemplate"></param>
        void Error(string       messageTemplate);
    }
}
