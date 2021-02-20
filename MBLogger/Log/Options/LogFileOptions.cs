using MBLogger.Enums;

namespace MBLogger.Log.Options
{
    internal interface ILogFileOptions
    {
        string        Path       { get; init; }
        LogFileFormat FileFormat { get; init; }
    }

    class LogFileOptions : ILogFileOptions
    {
        public string Path { get; init; }
        public LogFileFormat FileFormat { get; init; }
    }
}
