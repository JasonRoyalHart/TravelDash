﻿using Newtonsoft.Json.Linq;
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
    public class HotelController : Controller
    {
        private ApplicationDbContext _context;

        public HotelController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult HotelsIndex()
        {
            var currentUserName = User.Identity.Name;
            var currentUser = _context.Users.FirstOrDefault(m => m.UserName == currentUserName);
            var currentLocation = _context.TripModels.FirstOrDefault(m => m.UserId == currentUser.Email);
            ViewBag.Location = currentLocation.Destination;
            ViewBag.User = currentUser.Email;
            var restList = _context.TempHotels;
            var viewModel = new HotelViewModel()
            {
                TempHotels = restList
            };
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult HotelsIndex(HotelViewModel Model, FormCollection collection)
        {
            List<int> Ids = new List<int>();
            foreach (var item in _context.TempHotels)
            {
                Ids.Add(item.ID);
            }
            for (int i = 0; i < 100; i++)
            {
                var tempBox = "checkBox" + i.ToString();
                if (!string.IsNullOrEmpty(collection[tempBox]))
                {
                    var tempRest = _context.TempHotels.Find(Ids[i]);
                    var temper = new HotelModel()
                    {
                        UserId = tempRest.UserId,
                        property_code = tempRest.property_code,
                        address = tempRest.address,
                        total_price = tempRest.total_price,
                        property_name = tempRest.property_name
                    };
                    _context.HotelModel.Add(temper);
                    _context.SaveChanges();
                    
                }
            }
            return RedirectToAction("Index", "Dashboard");
        }
        public ActionResult HotelSearchResult(HotelViewModel model)
        {
            var currentUserName = User.Identity.Name;
            var currentUser = _context.Users.FirstOrDefault(m => m.UserName == currentUserName);
            string City = model.City;
            string CheckIn = model.CheckIn;
            string CheckOut = model.CheckOut;
            string Distance = model.Distance;
            string Results = model.ResultNumber;
            string api = "bG7HZQsZILLmjpOhLihxd9K4CMGGJsWG";
            string URL = "https://api.sandbox.amadeus.com/v1.2/hotels/search-airport?apikey=" + api;
            URL += "&location=" + City;
            URL += "&check_in=" + CheckIn;
            URL += "&check_out=" + CheckOut;
            URL += "&radius=" + Distance;
            URL += "&number_of_results=" + Results;
            WebRequest request = WebRequest.Create(URL);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            JObject responseFromServer = JObject.Parse(reader.ReadToEnd());
            _context.TempHotels.RemoveRange(_context.TempHotels);
            _context.SaveChanges();
            for (int i = 0; i < Int32.Parse(Results); i++)
            {
                var hotel = new TempHotels()
                {
                    UserId = currentUser.Email,
                    property_name = responseFromServer["results"][i]["property_name"].ToString(),
                    property_code = responseFromServer["results"][i]["property_code"].ToString(),
                    //              property_code = responseFromServer["results"][0]["property_code"].ToString(),
                    address = responseFromServer["results"][i]["address"]["line1"].ToString(),
                    total_price = responseFromServer["results"][i]["total_price"]["amount"].ToString()
                };
                _context.TempHotels.Add(hotel);
                _context.SaveChanges();
            }
            return RedirectToAction("HotelsIndex", "Hotel");
        }
    }
}