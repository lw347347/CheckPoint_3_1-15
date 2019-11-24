using BlowOut.Models;
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

            GMailer.GmailUsername = "is403.group.1.15@gmail.com";
            // THIS MUST BE AN APP SPECIFIC PASSWORD, you must set up 2 step factor authentication
            GMailer.GmailPassword = "rqmptdkijstrwrbu";

            GMailer mailer = new GMailer();
            mailer.ToEmail = email;
            mailer.Subject = "IS403 Group 1-15";
            mailer.Body = "Thanks, " + name + ", for contacting us.";
            mailer.IsHtml = true;
            mailer.Send();

            // Return the view
            return View();
        }
    }
}