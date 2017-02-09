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
    public class CarController : Controller
    {
        private ApplicationDbContext _context;

        public CarController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Car
        public ActionResult Index()
        {
            var currentUserName = User.Identity.Name;
            var currentUser = _context.Users.FirstOrDefault(m => m.UserName == currentUserName);
            var currentLocation = _context.TripModels.FirstOrDefault(m => m.UserId == currentUser.Email);
            ViewBag.Location = currentLocation.Destination;
            ViewBag.User = currentUser.Email;
            var restList = _context.TempCars;
            var viewModel = new CarsViewModel()
            {
                TempCars = restList
            };
            return View(viewModel);
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult CarsIndex()
        //{
        //    return View();
        //}
        public ActionResult CarSearchResult(CarsViewModel model)
        {
            var currentUserName = User.Identity.Name;
            var currentUser = _context.Users.FirstOrDefault(m => m.UserName == currentUserName);
            string pickup = model.Pickup;
            string pickUpDate = model.PickUpDtae;
            string dropOffDate = model.DropOffDate;
            string api = "bG7HZQsZILLmjpOhLihxd9K4CMGGJsWG";
            string URL = "https://api.sandbox.amadeus.com/v1.2/cars/search-airport?apikey=" + api;
            URL += "&location=" + pickup;
            URL += "&pick_up=" + pickUpDate;
            URL += "&drop_off=" + dropOffDate;
            WebRequest request = WebRequest.Create(URL);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            JObject responseFromServer = JObject.Parse(reader.ReadToEnd());
            _context.TempHotels.RemoveRange(_context.TempHotels);
            _context.SaveChanges();

            // This next bit needs to be changed to store the values we want to pull from results and display per object

            //for (int i = 0; i < Int32.Parse(Results); i++)
            //{
            //    var hotel = new TempHotels()
            //    {
            //        UserId = currentUser.Email,
            //        property_name = responseFromServer["results"][i]["property_name"].ToString(),
            //        property_code = responseFromServer["results"][i]["property_code"].ToString(),
            //        //              property_code = responseFromServer["results"][0]["property_code"].ToString(),
            //        address = responseFromServer["results"][i]["address"]["line1"].ToString(),
            //        total_price = responseFromServer["results"][i]["total_price"]["amount"].ToString()
            //    };
            //    _context.TempHotels.Add(hotel);
            //    _context.SaveChanges();
            //}

            return RedirectToAction("CarsIndex", "Car");
        }
    }
}