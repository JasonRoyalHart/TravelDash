﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelDash.Models;

namespace TravelDash.Controllers
{
    public class DashboardController : Controller
    {
        private ApplicationDbContext _context;

        public DashboardController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var currentUserName = User.Identity.Name;
            var currentUser = _context.Users.FirstOrDefault(m => m.UserName == currentUserName);
            ViewBag.FirstName = currentUser.firstName;
            if ((_context.TripModels.FirstOrDefault(m => m.UserId == currentUser.Email)) != null)
            {
                var currentLocation = _context.TripModels.FirstOrDefault(m => m.UserId == currentUser.Email);
                ViewBag.Location = currentLocation.Destination;
                ViewBag.Status = true;
            }
            else
            {
                ViewBag.Status = false;
            }
            var hotelList = _context.HotelModel.ToList();
            var restList =_context.RestaurantModels.ToList();
            var carList = _context.CarModel.ToList();
            var flightList = _context.PlaneModel.ToList();

            var viewModel = new DashboardViewModel()
            {
                RestaurantModels = restList,
                CarModel = carList,
                PlaneModel = flightList,
                HotelModel = hotelList,
                UserId = currentUser.Email,
            };
            return View(viewModel);
        }
    }
    
}