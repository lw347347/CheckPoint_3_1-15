using BlowOut.DALL;
using BlowOut.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlowOut.Controllers
{
    public class ClientInstrumentController : Controller
    {
        // Give access to the database
        private RentalsContext db = new RentalsContext();

        // GET: ClientInstrument
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        // This method inputs all of the values for the instrument and client
        [HttpPost]
        public ActionResult Create(ClientInstrument clientInstrument)
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

                // Now add the instrument                   
                var instrument = new Instrument()
                {
                    Name = clientInstrument.Instrument.Name,
                    Price = clientInstrument.Instrument.Price,
                    New = clientInstrument.Instrument.New,
                    Location = clientInstrument.Instrument.Location,
                    ClientID = (int)client.ClientID
                };

                db.Instruments.Add(instrument);
                db.SaveChanges();
                return View("Summary", clientInstrument);
            } else
            {
                // The model isn't valid so send everything back
                return View(clientInstrument);
            }            
        }

        public ActionResult Summary (ClientInstrument clientInstrument)
        {
            // Add the location for the picture
            ViewBag.Location = clientInstrument.Instrument.Location;

            // Create the viewbag for the result
            ViewBag.Result = "Thanks, " + clientInstrument.Client.FirstName + " for renting a " +
                clientInstrument.Instrument.Name + ". Your order number is " + clientInstrument.Client.ClientID +
                ". Your monthly payment is $" + clientInstrument.Instrument.Price + ". The total amount paid" +
                " after 18 months is " + (clientInstrument.Instrument.Price * 18) + ".";

            return View(clientInstrument);
        }
    }
}