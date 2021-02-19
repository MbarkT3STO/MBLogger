using System;
using MBLogger.Enums;
using MBLogger.Log;
using MBLogger.Logger;

namespace MBLogger.Builders
{
    static class LogBuilder
    {
        /// <summary>
        /// Build a new <b><see cref="ILogOptions"/></b> object
        /// </summary>
        /// <param name="logLevel">The log level</param>
        /// <param name="logDateTime">The log date and time</param>
        /// <param name="MessageTemplate">The log text content</param>
        /// <returns></returns>
        public static ILogOptions BuildOne(LogLevel logLevel, DateTime logDateTime , string MessageTemplate)
        {
            return new LogOptions() {LogLevel = logLevel, DateTime = DateTime.Now, MessageTemplate = MessageTemplate};
        }
    }
}
