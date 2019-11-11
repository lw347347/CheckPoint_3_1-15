using BlowOut.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlowOut.Controllers
{
    public class RentalsController : Controller
    {
        // Create a list of all our instruments
        public static List<Instrument> listOfInstruments = new List<Instrument>() {
            new Instrument() { InstrumentID = 1, Name = "Trumpet", Location = 
                "~/Content/Images/Trumpet.jpg", NewPrice = 55, UsedPrice = 25 },
            new Instrument() { InstrumentID = 1, Name = "Trombone", Location =
                "~/Content/Images/Trombone.jpg", NewPrice = 60, UsedPrice = 35 },
            new Instrument() { InstrumentID = 1, Name = "Tuba", Location =
                "~/Content/Images/Tuba.jpg", NewPrice = 70, UsedPrice = 50 },
            new Instrument() { InstrumentID = 1, Name = "Flute", Location =
                "~/Content/Images/Flute.jpg", NewPrice = 40, UsedPrice = 25 },
            new Instrument() { InstrumentID = 1, Name = "Clarinet", Location =
                "~/Content/Images/Clarinet.jpg", NewPrice = 35, UsedPrice = 27 },
            new Instrument() { InstrumentID = 1, Name = "Saxophone", Location =
                "~/Content/Images/Saxophone.jpg", NewPrice = 42, UsedPrice = 30 }
        };

        // GET: Rentals
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Rent(string Name)
        {
            // Find the specific instrument 
            int index = listOfInstruments.FindIndex(x => x.Name == Name);

            // Create the reference to the right image
            ViewBag.Location = "../Content/Images/" + Name + ".jpg";

            // Return the view with the right object
            return View(listOfInstruments[index]);
        }
    }
}