using BlowOut.DALL;
using BlowOut.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BlowOut.Controllers
{
    public class HomeController : Controller
    {
        // Project Description
        // This project is a rental application for a music store."
        // Authors
        // Mckay Dalling, Matthew Gardner, Parker Pixton, Landon Williams

        private RentalsContext db = new RentalsContext();

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

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            // Check if they are authorized
            if ((username == "Missouri") && (password == "ShowMe"))
            {
                // They logged in correctly so set the cookie
                FormsAuthentication.SetAuthCookie(username, false);

            } else
            {
                // They didn't log in correctly so bump them to the login page again
            }

            return RedirectToAction("UpdateData");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon(); // it will clear the session at the end of request
            return View("Index");
        }

        [Authorize]
        public ActionResult UpdateData()
        {
            // grab the model and input all the info from the database
            List<UpdateData> UpdateDatas = new List<UpdateData>();
            List<Client> Clients = db.Clients.ToList<Client>();
            List<Instrument> Instruments = db.Instruments.ToList<Instrument>();            

            foreach (Instrument instrument in Instruments)
            {
                // Reset everything
                UpdateData updateData = new UpdateData();

                // input the Instrument info
                updateData.InstrumentID = instrument.InstrumentID;
                updateData.Price = instrument.Price;
                updateData.Name = instrument.Name;
                updateData.Location = instrument.Location;
                updateData.Price = instrument.Price;
                updateData.New = instrument.New;
                updateData.ClientID = instrument.ClientID; 

                // Check if the client exists
                if (instrument.ClientID == null)
                {
                    // Do nothing
                } else
                {
                    // Grab the client with the ClientID with the instrument
                    Client client = Clients.FirstOrDefault(x => x.ClientID == instrument.ClientID);

                    // Input that info now
                    updateData.ClientID = instrument.ClientID;
                    updateData.Address = client.Address;
                    updateData.City = client.City;
                    updateData.EmailAddress = client.EmailAddress;
                    updateData.FirstName = client.FirstName;
                    updateData.LastName = client.LastName;
                    updateData.PhoneNumber = client.PhoneNumber;
                    updateData.State = client.State;
                    updateData.Zipcode = client.Zipcode;
                }                

                // Input updateData into the list
                UpdateDatas.Add(updateData);
            }

            return View(UpdateDatas);
        }
    }
}