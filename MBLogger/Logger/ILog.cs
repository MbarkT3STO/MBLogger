using MBLogger.Logger.Enums;

namespace MBLogger.Logger
{
    public interface ILog
    {
        string         Label      { get; set; }
        public LogType LogType    { get; set; }
        string         LogMessage { get; set; }

    }
}