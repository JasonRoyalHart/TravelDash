using Newtonsoft.Json.Linq;
using SimpleOAuth;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using TravelDash.Models;

namespace TravelDash.Controllers
{
    public class BookingController : Controller
    {
        private ApplicationDbContext _context;

        public BookingController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Booking
        public ActionResult TripIndex()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TripIndex(TripViewModel model)
        {
            if (ModelState.IsValid)
            {
                var departure = (model.DepartureMonth.ToString() + model.DepartureDay.ToString() + model.DepartureYear.ToString());
                var arrival = (model.ArrivalMonth.ToString() + model.ArrivalDay.ToString() + model.ArrivalYear.ToString());
                var currentUserName = User.Identity.Name;
                var currentUser = _context.Users.FirstOrDefault(m => m.UserName == currentUserName);
                var trip = new TripModels
                {
                    UserId = currentUser.Email,
                    Home = model.Home,
                    Destination = model.Destination,
                    StartDate = departure,
                    EndDate = arrival
                };
                _context.TripModels.Add(trip);
                _context.SaveChanges();
                return RedirectToAction("Index", "Dashboard");

            }
            else
            {
                return View(model);
            }
        }
        public ActionResult FlightsIndex()
        {
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult FlightsIndex(model)
        //{
        //    return View();
        //}
        public ActionResult CarsIndex()
        {
            return View();
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult CarsIndex()
        //{
        //    return View();
        //}
        public ActionResult HotelsIndex()
        {
            return View();
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult HotelsIndex()
        //{
        //    return View();
        //}
        public ActionResult RestaurantsIndex()
        {
            var currentUserName = User.Identity.Name;
            var currentUser = _context.Users.FirstOrDefault(m => m.UserName == currentUserName);
            var currentLocation = _context.TripModels.FirstOrDefault(m => m.UserId == currentUser.Email);
            ViewBag.Location = currentLocation.Destination;
            return View(ViewBag);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RestaurantsIndex(RestaurantsViewModel model)
        {
            return View();
        }

        public ActionResult RestaurantSearch()
        {
            JObject results = Search("food", "chicago");
            foreach (JProperty property in results.Properties())
                {
                    Console.WriteLine(property.Name + " - " + property.Value);
                }
            //pause it here and check out that jacked up return object//
            return RedirectToAction("RestaurantsIndex", "Booking");
        }
        public ActionResult EventsIndex()
        {
            return View();
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult EventsIndex()
        //{
        //    return View();
        //}

        public ActionResult HotelSearchResult()
        {
            string City = Request["txtCity"];
            string CheckIn = Request["txtCheckIn"];
            string CheckOut = Request["txtCheckOut"];
            string Distance = Request["txtDistance"];
            string Results = Request["txtResults"];
            string api = "bG7HZQsZILLmjpOhLihxd9K4CMGGJsWG";
            string URL = "https://api.sandbox.amadeus.com/v1.2/hotels/search-airport?apikey=" + api;
            URL += "&location=" + City;
            URL += "&check_in=" + CheckIn;
            URL += "&check_out=" + CheckOut;
            URL += "&radius=" + Distance;
            URL += "&number_of_results=" + Results;
            Console.WriteLine(URL);
            WebRequest request = WebRequest.Create(URL);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            return RedirectToAction("HotelsIndex", "Booking");
        }



        //FROM HERE DOWN IS FOR THE YELP API REQUEST//


        private const string CONSUMER_KEY = "-H424RZyK5jKczrI6U7TSg";
        private const string CONSUMER_SECRET = "Hr9xu-dzpsfEvYK0x6zJa6jMhJ4";
        private const string TOKEN = "_zmDBvb401h8pw7tfCIWkyuwt1nrOd0g";
        private const string TOKEN_SECRET = "oM_rtzpoZ2GG_yIqWqAvJaBWCz4";
        private const string API_HOST = "https://api.yelp.com";
        private const string SEARCH_PATH = "/v2/search/";
        private const string BUSINESS_PATH = "/v2/business/";
        private const int SEARCH_LIMIT = 20;
        private JObject PerformRequest(string baseURL, Dictionary<string, string> queryParams=null)
        {
            var query = System.Web.HttpUtility.ParseQueryString(String.Empty);

            if (queryParams == null)
            {
                queryParams = new Dictionary<string, string>();
            }

            foreach (var queryParam in queryParams)
            {
                query[queryParam.Key] = queryParam.Value;
            }

            var uriBuilder = new UriBuilder(baseURL);
            uriBuilder.Query = query.ToString();

            var request = WebRequest.Create(uriBuilder.ToString());
            request.Method = "GET";
            request.SignRequest(
                new Tokens {
                    ConsumerKey = CONSUMER_KEY,
                    ConsumerSecret = CONSUMER_SECRET,
                    AccessToken = TOKEN,
                    AccessTokenSecret = TOKEN_SECRET
                }
            ).WithEncryption(EncryptionMethod.HMACSHA1).InHeader();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            var stream = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            var clean = JObject.Parse(stream.ReadToEnd());
            return clean;
        }
        public JObject Search(string term, string location)
        {
            string baseURL = API_HOST + SEARCH_PATH;
            var queryParams = new Dictionary<string, string>()
            {
                { "term", term },
                { "location", location },
                { "limit", SEARCH_LIMIT.ToString() }
            };
            return PerformRequest(baseURL, queryParams);
        }
    }
}
