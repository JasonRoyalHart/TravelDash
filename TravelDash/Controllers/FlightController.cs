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
        [HttpPost]
        public ActionResult FlightsIndex(FlightViewModel model, FormCollection collection)
        {
            List<int> Ids = new List<int>();
            foreach (var item in _context.TempPlanes)
            {
                Ids.Add(item.ID);
            }

            for (int i = 0; i < 100; i++)
            {
                var tempBox = "checkBox" + i.ToString();
                if (!string.IsNullOrEmpty(collection[tempBox]))
                {
                    var tempRest = _context.TempPlanes.Find(Ids[i]);
                    var temper = new PlaneModel()
                    {
                        UserId = tempRest.UserId,
                        InboundAirline = tempRest.InboundAirline,
                        InboundDeparture = tempRest.InboundDeparture,
                        OutboundAirline = tempRest.OutboundAirline,
                        OutboundDeparture = tempRest.OutboundDeparture
                    };
                    _context.PlaneModel.Add(temper);
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("Index", "Dashboard");
        }
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
                    UserId = currentUser.Email,
                    InboundAirline = responseFromServer["results"][i]["itineraries"][0]["inbound"]["flights"][0]["marketing_airline"].ToString(),
                    InboundDeparture = responseFromServer["results"][i]["itineraries"][0]["inbound"]["flights"][0]["departs_at"].ToString(),
                    OutboundAirline = responseFromServer["results"][i]["itineraries"][0]["outbound"]["flights"][0]["marketing_airline"].ToString(),
                    OutboundDeparture = responseFromServer["results"][i]["itineraries"][0]["outbound"]["flights"][0]["departs_at"].ToString()
                };
                _context.TempPlanes.Add(plane);
                _context.SaveChanges();
            }

            return RedirectToAction("FlightsIndex", "Flight");
        }
    }
}