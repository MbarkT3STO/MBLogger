using MBLogger.Log.Abstract_Operations;

namespace MBLogger.Log
{
    interface ILogBase:ILogOps
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
        /// <summary>
        /// Log a new <b>Verbose</b>
        /// </summary>
        /// <param name="messageTemplate"></param>
        void Verbose(string       messageTemplate);
        /// <summary>
        /// Log a new danger <b>fatal</b> error
        /// </summary>
        /// <param name="messageTemplate"></param>
        void Fatal(string       messageTemplate);
    }
}
