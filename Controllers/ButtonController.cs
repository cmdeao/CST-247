using Activity2Part1.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Activity2Part1.Controllers
{
    public class ButtonController : Controller
    {
        public static List<ButtonModel> buttons = new List<ButtonModel>();
        // GET: Button
        public ActionResult Index()
        {
            for(int i = 0; i < 2; i++)
            {
                buttons.Add(new ButtonModel(true));
            }

            return View("Button", buttons);
        }

        public ActionResult OnButtonClick(string mine)
        {
            int value = Int32.Parse(mine);

            if(value == 1)
            {
                buttons[0].State = !buttons[0].State;
            }
            else
            {
                buttons[1].State = !buttons[1].State;
            }

            return View("Button", buttons);
        }
    }
}