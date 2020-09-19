using Activity1Part3.Services.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;

namespace Activity1Part3.Controllers
{
    public class TestLoggingService2Controller : Controller
    {
        [Unity.Dependency]
        public ILogger logger { get; set; }

        // GET: TestLoggingService2
        public string Index()
        {
            //return View();
            logger.Info("TestLoggingService2 controller test response");
            return "Test Response LoggingService2";
        }
    }
}