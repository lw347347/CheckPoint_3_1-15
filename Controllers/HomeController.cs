using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlowOut.Controllers
{
    public class HomeController : Controller
    {
        // Project Description
            // This project is a rental application for a music store."
        // Authors
            // Mckay Dalling, Matthew Gardner, Parker Pixton, Landon Williams
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "This project is a rental application for a music store.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}