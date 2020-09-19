using Activity1Part3.Services.Utility;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Activity1Part3.Controllers
{
    public class TestLoggingService1Controller : Controller
    {
        private ILogger logger;

        public TestLoggingService1Controller(ILogger iLog)
        {
            this.logger = iLog;
        }

        // GET: TestLoggingService1
        public string Index()
        {
            Debug.WriteLine("LOGGING INDEX METHOD");
            //return View();
            logger.Info("Testing first return");
            return "Completed first test";
        }
    }
}