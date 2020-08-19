using Activity2Part1.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Activity2Part1.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            List<UserModel> users = new List<UserModel>();

            for(int i = 0; i < 5; i++)
            {
                UserModel user;
                user = new UserModel("test " + i.ToString(), "email " + i.ToString(), "12345678" + i.ToString());
                users.Add(user);
            }

            return View("Test", users);
        }
    }
}