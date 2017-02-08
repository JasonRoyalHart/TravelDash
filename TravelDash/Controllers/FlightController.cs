using System;
using System.Collections.Generic;
using System.Linq;
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
            return View();
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult FlightsIndex(model)
        //{
        //    return View();
        //}
    }
}