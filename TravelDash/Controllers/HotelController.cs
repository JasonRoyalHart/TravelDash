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
            return View(ViewBag);
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult HotelsIndex()
        //{
        //    return View();
        //}
        public ActionResult HotelSearchResult()
        {
            var currentUserName = User.Identity.Name;
            var currentUser = _context.Users.FirstOrDefault(m => m.UserName == currentUserName);
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
            JObject responseFromServer = JObject.Parse(reader.ReadToEnd());
            var hotel = new TempHotels()
            {
                UserId = currentUser.Email,
                property_name = responseFromServer["results"][0]["property_name"].ToString(),
                property_code = "Test",
                //              property_code = responseFromServer["results"][0]["property_code"].ToString(),
                address = responseFromServer["results"][0]["address"]["line1"].ToString(),
                total_price = responseFromServer["results"][0]["total_price"]["amount"].ToString()
            };
            List<TempHotels> hotels = _context.TempHotels.ToList();


            _context.TempHotels.RemoveRange(_context.TempHotels);

            _context.SaveChanges();
            _context.TempHotels.Add(hotel);
            _context.SaveChanges();

            return RedirectToAction("HotelsIndex", "Hotel");

        }
    }

}