using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlowOut.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            // Create the viewbag string
            ViewBag.CallSupport = "Please call Support at <strong><u>801-555-1212</u></strong>. Thank you!";
            return View();
        }

        public ActionResult Email(string name, string email)
        {
            // Create the viewbag string
            ViewBag.Result = "Thanks, " + name + ". The company will send an email to " + email + ".";

            // Return the view
            return View();
        }       
    }
}