using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MBLogger.Enums;

namespace MBLogger.Logger
{
    /// <inheritdoc />
    class LoggerConfigurations:ILoggerConfigurations
    {
        /// <inheritdoc />
        public LogTarget     LogTarget     { get; set; }

        /// <inheritdoc />
        public string        LogFilePath   { get; set; }

        /// <inheritdoc />
        public LogFileFormat ? LogFileFormat { get; set; }
    }
}
