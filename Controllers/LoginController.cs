using Activity1Part3.Models;
using Activity1Part3.Services.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Activity1Part3.Controllers
{
    public class LoginController : Controller
    {
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
            if(!ModelState.IsValid)
            {
                return View("Login");
            }

            SecurityService service = new SecurityService();
            bool results = service.Authenticate(model);

            if(results)
            {
                return View("LoginPassed");
            }
            else
            {
                return View("LoginFailed");
            }
            //return "Here " + model.Username + " and " + model.Password;
        }
    }
}