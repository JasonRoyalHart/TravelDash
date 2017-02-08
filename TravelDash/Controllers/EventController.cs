using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelDash.Models;

namespace TravelDash.Controllers
{
    public class EventController : Controller
    {
        private ApplicationDbContext _context;

        public  EventController()
        {
            _context = new ApplicationDbContext();
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
    }
}