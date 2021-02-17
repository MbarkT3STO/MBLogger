using System;
using System.Collections.Generic;
using System.Text;

namespace MBLogger.Logger
{
    interface ILogBase
    {
        void Information(string logMessage);
        void Warning(string     logMessage);
        void Error(string       logMessage);
    }
}
