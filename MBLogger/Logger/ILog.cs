using MBLogger.Logger.Enums;

namespace MBLogger.Logger
{
    public interface ILog
    {
        string         Label      { get; set; }
        public LogLevel LogLevel    { get; set; }
        string         LogMessage { get; set; }

    }
}