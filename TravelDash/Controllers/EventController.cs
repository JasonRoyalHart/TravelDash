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
        //public ActionResult SearchEvents()
        //{




        //    // Create a request for the URL.   
        //    WebRequest request = WebRequest.Create(
        //      "http://www.contoso.com/default.html");
        //    // If required by the server, set the credentials.  
        //    request.Credentials = CredentialCache.DefaultCredentials;

        //    WebResponse response = request.GetResponse();

        //    Stream dataStream = response.GetResponseStream();
        //    // Open the stream using a StreamReader for easy access.  
        //    StreamReader reader = new StreamReader(dataStream);
        //    // Read the content.  
        //    string responseFromServer = reader.ReadToEnd();
        //    // Display the content.  
        //    Console.WriteLine(responseFromServer);
        //    // Clean up the streams and the response.  
        //    reader.Close();
        //    response.Close();
        //}

    }
}