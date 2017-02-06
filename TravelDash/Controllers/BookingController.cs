using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TravelDash.Controllers
{
    public class BookingController : Controller
    {
        // GET: Booking
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
            return View();
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult RestaurantsIndex()
        //{
        //    return View();
        //}
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
    }
}