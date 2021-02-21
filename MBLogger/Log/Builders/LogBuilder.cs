using System;
using MBLogger.Enums;
using MBLogger.Log.Options;

namespace MBLogger.Log.Builders
{
    public static class LogBuilder
    {
        /// <summary>
        /// Build a new <b><see cref="ILogOptions"/></b> object
        /// </summary>
        /// <param name="logLevel">The log level</param>
        /// <param name="logDateTime">The log date and time</param>
        /// <param name="messageTemplate">The log text content</param>
        /// <returns></returns>
        public static ILogOptions BuildOne(LogLevel logLevel, DateTime logDateTime , string messageTemplate)
        {
            return new LogOptions() {LogLevel = logLevel, DateTime = logDateTime, MessageTemplate = messageTemplate};
        }
    }
}
