/*Cameron Deao
 * CST-247
 * James Sinevar
 * 9/18/2020 */

using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Benchmark___Bible_Verse.Services.Utility
{
    //Implements ILogger interface.
    public class VerseLogger : ILogger
    {
        //Global variables.
        private static VerseLogger _instance;
        private static Logger logger;

        //Creating a singleton of the logger for access.
        public static VerseLogger GetInstance()
        {
            if(_instance == null)
            {
                _instance = new VerseLogger();
            }
            return _instance;
        }

        //Getting the logger based on the passed string.
        private Logger GetLogger(string logger)
        {
            if(VerseLogger.logger == null)
            {
                VerseLogger.logger = LogManager.GetLogger(logger);
            }
            return VerseLogger.logger;
        }

        //Logging debug method.
        public void Debug(string message)
        {
            GetLogger("myAppLoggerRules").Debug(message);
        }

        //Logging error method. Exception is passed and displayed
        //alongside a message string.
        public void Error(Exception e, string message)
        {
            GetLogger("myAppLoggerRules").Error(e, message);
        }

        //Logging info method.
        public void Info(string message)
        {
            GetLogger("myAppLoggerRules").Info(message);
        }

        //Logging warning method.
        public void Warning(string message)
        {
            GetLogger("myAppLoggerRules").Warn(message);
        }
    }
}