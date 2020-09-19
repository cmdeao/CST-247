using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Activity1Part3.Services.Utility
{
    public class MyLogger1 : ILogger
    {
        private static MyLogger1 _instance;
        private static Logger logger;

        private MyLogger1()
        {

        }

        public static MyLogger1 GetInstance()
        {
            if(_instance == null)
            {
                _instance = new MyLogger1();
            }
            return _instance;
        }

        private Logger GetLogger(string logger)
        {
            if(MyLogger1.logger == null)
            {
                MyLogger1.logger = LogManager.GetLogger(logger);
            }
            return MyLogger1.logger;
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