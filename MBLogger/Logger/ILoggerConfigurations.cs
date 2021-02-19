using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MBLogger.Enums;

namespace MBLogger.Logger
{
    /// <summary>
    /// The logger middlewear configurations
    /// </summary>
    interface ILoggerConfigurations
    { 
        /// <summary>
        /// Log target
        /// </summary>
       LogTarget LogTarget { get; set; }
        /// <summary>
        /// Determine the file path if the log target loggin in file
        /// </summary>
        string LogFilePath { get; set; }
        /// <summary>
        /// Determine the file format if the log target loggin in file
        /// </summary>
       LogFileFormat LogFileFormat { get; set; }
    }
}
