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
        public ActionResult CarsIndex()
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
        [HttpPost]
        public ActionResult CarsIndex(CarsViewModel model, FormCollection collection)
        {
            List<int> Ids = new List<int>();
            foreach (var item in _context.TempCars)
            {
                Ids.Add(item.ID);
            }

            for (int i = 0; i < 100; i++)
            {
                var tempBox = "checkBox" + i.ToString();
                if (!string.IsNullOrEmpty(collection[tempBox]))
                {
                    var tempRest = _context.TempCars.Find(Ids[i]);
                    var temper = new CarModel()
                    {
                        UserId = tempRest.UserId,
                        Provider = tempRest.Provider,
                        ImageUrl = tempRest.ImageUrl,
                        Info = tempRest.Info,
                        Price = tempRest.Price
                    };

                    _context.CarModel.Add(temper);
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("Index", "Dashboard");
        }
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
            _context.TempCars.RemoveRange(_context.TempCars);
            _context.SaveChanges();
            for (int i = 0; i < responseFromServer["results"].Count(); i++)
            {
                try
                {
                    var car = new TempCars()
                    {
                        UserId = currentUser.Email,
                        Provider = responseFromServer["results"][i]["provider"]["company_name"].ToString(),
                        ImageUrl = responseFromServer["results"][i]["cars"][0]["images"][0]["url"].ToString(),
                        Info = responseFromServer["results"][i]["cars"][0]["vehicle_info"]["type"].ToString(),
                        Price = responseFromServer["results"][i]["cars"][0]["estimated_total"]["amount"].ToString()
                    };
                    _context.TempCars.Add(car);
                    _context.SaveChanges();
                }
                catch { }
            }
            return RedirectToAction("CarsIndex", "Car");
        }
    }
}