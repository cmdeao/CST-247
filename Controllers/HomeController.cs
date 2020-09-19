/*Cameron Deao
 * CST-247
 * James Sinevar
 * 9/18/2020 */

using Benchmark___Bible_Verse.Models;
using Benchmark___Bible_Verse.Services.Business;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Benchmark___Bible_Verse.Services.Utility;

namespace Benchmark___Bible_Verse.Controllers
{
    public class HomeController : Controller
    {
        //Home page method.
        // GET: Home
        public ActionResult Index()
        {
            VerseLogger.GetInstance().Debug("Launched application");
            return View("HomeView");
        }

        //Hyperlink method for accessing search page.
        public ActionResult SearchVersePage()
        {
            return View("SearchVerse");
        }

        //ActionResult method fires from RadioButtons within the home view.
        [HttpPost]
        public ActionResult GetPageChoice(FormCollection choice)
        {
            //Result string is initialized based on RadioButton selection.
            string result = choice["Selection"].ToString();

            //Switch case is used to determine the appropriate response.
            switch(result)
            {
                case "Insertion":
                    VerseLogger.GetInstance().Debug("Entering InsertVerse View");
                    return View("InsertVerse");

                case "Search":
                    VerseLogger.GetInstance().Debug("Entering SearchVerse View");
                    return View("SearchVerse");
            }
            return View("HomeView");
        }

        //ActionResult for Html.BeginForm for inserting a verse.
        [HttpPost]
        public ActionResult InsertVerse(BibleVerse verse)
        {
            VerseLogger.GetInstance().Debug("Entered InsertVerse() Method");
            //Checks if the model is valid.
            if(ModelState.IsValid)
            {
                //Instance of the service is created.
                VerseService service = new VerseService();
                //If verse insertion results in true, HomeView is returned.
                if (service.InsertVerse(verse))
                {
                    return View("HomeView");
                }
                //If verse insertiong results in false, error is displayed.
                else 
                {
                    ModelState.AddModelError(string.Empty, "This verse already exists");
                    return View("InsertVerse");
                }
            }
            //Showcasing error message if entry fields are empty.
            ModelState.AddModelError(string.Empty, "Missing Fields!");
            return View("InsertVerse");
        }

        //ActionResult method for searching verse.
        [HttpPost]
        public ActionResult SearchVerse(BibleVerse verse)
        {
            VerseLogger.GetInstance().Debug("Entered SearchVerse() Method");
            VerseService service = new VerseService();
            //Verse object is created.
            BibleVerse found = new BibleVerse();
            //Created verse object is passed into service.
            found = service.FindVerse(verse);

            //If created verse object returns null an error is displayed.
            if(found == null)
            {
                ModelState.AddModelError(string.Empty, "No verse was found.");
                return View("SearchVerse");
            }

            //If created verse object is populated from the database
            //SearchResult view is returned and passes verse object into view.
            return View("SearchResult", found);
        }
    }
}