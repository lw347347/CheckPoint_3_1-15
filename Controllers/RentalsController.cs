using BlowOut.DALL;
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
        // Give access to the database
        private RentalsContext db = new RentalsContext();

        // Create a list of all our instruments
        public static List<Instrument> listOfInstruments = new List<Instrument>() {
            // New
            new Instrument() { InstrumentID = 1, Name = "Trumpet", Location = 
                "~/Content/Images/Trumpet.jpg", Price = 55, New = true },
            new Instrument() { InstrumentID = 2, Name = "Trombone", Location =
                "~/Content/Images/Trombone.jpg", Price = 60, New = true },
            new Instrument() { InstrumentID = 3, Name = "Tuba", Location =
                "~/Content/Images/Tuba.jpg", Price = 70, New = true },
            new Instrument() { InstrumentID = 4, Name = "Flute", Location =
                "~/Content/Images/Flute.jpg", Price = 40, New = true },
            new Instrument() { InstrumentID = 6, Name = "Clarinet", Location =
                "~/Content/Images/Clarinet.jpg", Price = 35, New = true },
            new Instrument() { InstrumentID = 7, Name = "Saxophone", Location =
                "~/Content/Images/Saxophone.jpg", Price = 42, New = true },

            // Used
            new Instrument() { InstrumentID = 8, Name = "Trumpet", Location =
                "~/Content/Images/Trumpet.jpg", New = false, Price = 25 },
            new Instrument() { InstrumentID = 9, Name = "Trombone", Location =
                "~/Content/Images/Trombone.jpg", New = false, Price = 35 },
            new Instrument() { InstrumentID = 10, Name = "Tuba", Location =
                "~/Content/Images/Tuba.jpg", New = false, Price = 50 },
            new Instrument() { InstrumentID = 11, Name = "Flute", Location =
                "~/Content/Images/Flute.jpg", New = false, Price = 25 },
            new Instrument() { InstrumentID = 12, Name = "Clarinet", Location =
                "~/Content/Images/Clarinet.jpg", New = false, Price = 27 },
            new Instrument() { InstrumentID = 13, Name = "Saxophone", Location =
                "~/Content/Images/Saxophone.jpg", New = false, Price = 30 }
        };

        // GET: Rentals
        public ActionResult Index()
        {
            return View(listOfInstruments);
        }

        public ActionResult NewOrUsed(string Name)
        {
            // Find the specific instruments
            List<Instrument> listOfUsedOrNew = listOfInstruments.Where(x =>
                x.Name.Equals(Name)).ToList();

            // Send that list to the view
            return View(listOfUsedOrNew);
        }

        public ActionResult Rent(int id)
        {
            // Find the specific instrument 
            int index = listOfInstruments.FindIndex(x => x.InstrumentID == id);

            // Create the ClientInstrument model and add the right instrument to it
            ClientInstrument clientInstrument = new ClientInstrument();
            clientInstrument.Instrument = listOfInstruments[index];

            // Create the reference to the right image
            ViewBag.Location = clientInstrument.Instrument.Name + ".jpg";

            // Add the location to the model
            clientInstrument.Instrument.Location = ViewBag.Location;

            // Return the view for the Create clientInstrument form
            return View("~/Views/ClientInstrument/Create.cshtml", clientInstrument);
        }

        // This method inputs all of the values for the instrument and client
        [HttpPost]
        public ActionResult Rent(ClientInstrument clientInstrument)
        {
            // Check if the model is valid
            if (ModelState.IsValid)
            {
                // It's valid
                // Add the client first
                var client = new Client()
                {
                    FirstName = clientInstrument.Client.FirstName,
                    LastName = clientInstrument.Client.LastName,
                    Address = clientInstrument.Client.Address,
                    City = clientInstrument.Client.City,
                    State = clientInstrument.Client.State,
                    Zipcode = clientInstrument.Client.Zipcode,
                    EmailAddress = clientInstrument.Client.EmailAddress,
                    PhoneNumber = clientInstrument.Client.PhoneNumber
                };

                db.Clients.Add(client);
                db.SaveChanges();

                // Grab the last added clientID
                var clientID = db.Clients.OrderByDescending(x => x.ClientID).FirstOrDefault().ClientID;

                // Now add the instrument                   
                var instrument = new Instrument()
                {
                    Name = clientInstrument.Instrument.Name,
                    Price = clientInstrument.Instrument.Price,
                    New = clientInstrument.Instrument.New,
                    Location = clientInstrument.Instrument.Location,
                    ClientID = clientID
                };

                db.Instruments.Add(instrument);
                db.SaveChanges();

                // Add the clientInstrument to the tempdata
                clientInstrument.Instrument = instrument;
                clientInstrument.Client = client;

                TempData["clientInstrument"] = clientInstrument;

                return RedirectToAction("Summary");
            }
            else
            {
                // The model isn't valid so send everything back
                return View("~/Views/ClientInstrument/Create.cshtml", clientInstrument);
            }
        }

        // This is the summary page 
        public ActionResult Summary()
        {
            // Make the clientInstrument from the tempdata
            ClientInstrument clientInstrument = (ClientInstrument)TempData["clientInstrument"];

            // Create the viewbag for the result
            ViewBag.Result = "Thanks, " + clientInstrument.Client.FirstName + " for renting a " +
                clientInstrument.Instrument.Name + ". Your order number is " + clientInstrument.Instrument.ClientID +
                ". Your monthly payment is $" + clientInstrument.Instrument.Price + ". The total amount paid" +
                " after 18 months is $" + (clientInstrument.Instrument.Price * 18) + ".";

            return View(clientInstrument);
        }
    }
}