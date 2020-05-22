using System;
using System.Collections.Generic;
using System.Text;
using NLog;

namespace WebApiLogger
{
    public class LoggerWebApi : ILoggerWebApi
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();

        public void LogError(string message)
        {
            logger.Error(message);
        }

        public void LogInfo(string message)
        {
            logger.Info(message);
        }
    }
}
