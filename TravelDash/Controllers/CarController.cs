using System;
using System.Collections.Generic;
using System.Linq;
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
            return View();
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult CarsIndex()
        //{
        //    return View();
        //}
    }
}