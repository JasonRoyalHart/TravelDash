using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TravelDash.Models;

namespace TravelDash.Controllers
{
    public class FlightController : Controller
    {
        private ApplicationDbContext _context;

        public FlightController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Flight
        public ActionResult FlightsIndex()
        {
            var currentUserName = User.Identity.Name;
            var currentUser = _context.Users.FirstOrDefault(m => m.UserName == currentUserName);
            var currentLocation = _context.TripModels.FirstOrDefault(m => m.UserId == currentUser.Email);
            ViewBag.Location = currentLocation.Destination;
            ViewBag.User = currentUser.Email;
            var restList = _context.TempPlanes;
            var viewModel = new FlightViewModel()
            {
                TempPlanes = restList
            };

            return View(viewModel);
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult FlightsIndex(model)
        //{
        //    return View();
        //}
        public ActionResult PlaneSearchResult(FlightViewModel model)
        {
            var currentUserName = User.Identity.Name;
            var currentUser = _context.Users.FirstOrDefault(m => m.UserName == currentUserName);
            string destination = model.Destination;
            string origin = model.Origin;
            string inbound = model.Inbound;
            string outbound = model.Outbound;
            string results = model.NumberOfResults;
            string api = "bG7HZQsZILLmjpOhLihxd9K4CMGGJsWG";
            string URL = "http://api.sandbox.amadeus.com/v1.2/flights/low-fare-search?";
            URL += "origin=" + origin;
            URL += "&destination=" + destination;
            URL += "&departure_date=" + outbound;
            URL += "&return_date=" + inbound;
            URL += "&number_of_results=" + results;
            URL += "&apikey=" + api;
            WebRequest request = WebRequest.Create(URL);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            JObject responseFromServer = JObject.Parse(reader.ReadToEnd());
            _context.TempPlanes.RemoveRange(_context.TempPlanes);
            _context.SaveChanges();
            for (int i = 0; i < responseFromServer["results"].Count(); i++)
            {
                var plane = new TempPlanes()
                {

                    //I DONT KNOW WHERE TO BEGIN PARSING THROUGH THIS RETURN

                    //UserId = currentUser.Email,
                    //InboundAirline =  ,
                    //InboundDeparture = ,
                    //OutboundAirline = ,
                    //OutboundDeparture = ,
                };
                _context.TempPlanes.Add(plane);
                _context.SaveChanges();
            }

            return RedirectToAction("FlightsIndex", "Flight");
        }
    }
}