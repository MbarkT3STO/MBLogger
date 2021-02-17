using MBLogger.Logger.Enums;

namespace MBLogger.Logger
{
    public interface ILog
    {
        string Label { get; set; }
        LogType LogType { get; set; }
        string LogMessage { get; set; }

    }
}