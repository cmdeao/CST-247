using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Activity1Part3.Services.Utility
{
    public class MyLogger2 : ILogger
    {
        private Logger logger;

        private Logger GetLogger(string incLogger)
        {
            
            if (logger == null)
            {
                logger = LogManager.GetLogger(incLogger);
            }
            return logger;
        }

        public void Debug(string message)
        {
            GetLogger("myAppLoggerRules").Debug(message);
        }

        public void Error(string message)
        {
            GetLogger("myAppLoggerRules").Error(message);
        }

        public void Info(string message)
        {
            GetLogger("myAppLoggerRules").Info(message);
        }

        public void Warning(string message)
        {
            GetLogger("myAppLoggerRules").Warn(message);
        }
    }
}