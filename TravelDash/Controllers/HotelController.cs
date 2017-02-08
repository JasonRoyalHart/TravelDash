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
    public class HotelController : Controller
    {
        private ApplicationDbContext _context;

        public HotelController()
        {
            _context = new ApplicationDbContext();
        }
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
            return RedirectToAction("HotelsIndex", "Hotel");
        }
    }

}