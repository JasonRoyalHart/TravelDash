using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TravelDash.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Everything Travel Dash can do for you.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Let us know how our app worked for you.";

            return View();
        }
        [HttpPost]
        public ActionResult Contact(string message)
        {
            ViewBag.Message = "Thanks for reviewing our app.";

            return View();
        }
    }
}