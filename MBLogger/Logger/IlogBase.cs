using System;
using System.Collections.Generic;
using System.Text;

namespace MBLogger.Logger
{
    interface ILogBase
    {
        void Information(string messageTemplate);
        void Warning(string     messageTemplate);
        void Error(string       messageTemplate);
    }
}
