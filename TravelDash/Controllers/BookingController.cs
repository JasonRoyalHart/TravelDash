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
    }
}
