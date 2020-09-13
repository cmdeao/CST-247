using Activity1Part3.Models;
using Activity1Part3.Services.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NLog;
using System.Web.Script.Serialization;
using Activity1Part3.Services.Utility;

namespace Activity1Part3.Controllers
{
    public class LoginController : Controller
    {
        //private static Logger logger = LogManager.GetLogger("myAppLoggerRules");
        private static MyLogger1 logger = MyLogger1.GetInstance();
        // GET: Login
        //[HttpGet]
        //public string Index()
        //{
        //    //return View();
        //    return @"<b>Just a test from Index</b>";
        //}

        public ActionResult Index()
        {
            return View("Login");
        }

        [HttpPost]
        public ActionResult Login(UserModel model)
        {
            logger.Info("Entering LoginController.Login()");
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Login");
                }

                SecurityService service = new SecurityService();
                bool results;
                results = service.Authenticate(model);
                logger.Info("Parameters are: " + new JavaScriptSerializer().Serialize(model));

                if (results)
                {
                    //logger.Info(“Parameters are: new JavaScriptSerializer().Serialize(model)");
                    logger.Info("Exit LoginController.Login() with login passing");
                    return View("LoginPassed");
                }
                else
                {
                    logger.Info("Exit LoginController.Login() with login failing");
                    return View("LoginFailed");
                }
            }
            catch(Exception e)
            {
                logger.Error("Exception LoginController.Login()" + e.Message);
                return View("LoginFailed");
            }
            //return "Here " + model.Username + " and " + model.Password;
        }
    }
}