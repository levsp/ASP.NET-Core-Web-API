using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiLogger
{
    public interface ILoggerWebApi
    {
        void LogInfo(string message);
        void LogError(string message);
    }
}