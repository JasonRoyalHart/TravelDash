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
    public class RestaurantController : Controller
    {
        private ApplicationDbContext _context;


        public RestaurantController()
        {
            _context = new ApplicationDbContext();
        }
        List<object> Restaurants = new List<object>();
        // GET: Restaurant
        public ActionResult RestaurantsIndex()
        {
            var currentUserName = User.Identity.Name;
            var currentUser = _context.Users.FirstOrDefault(m => m.UserName == currentUserName);
            var currentLocation = _context.TripModels.FirstOrDefault(m => m.UserId == currentUser.Email);
            ViewBag.Location = currentLocation.Destination;
            ViewBag.User = currentUser.Email;
            RestaurantSearch();
            var restList = _context.TempRestaurants;
            var viewModel = new RestaurantsViewModel()
            {
                TempRestaurants = restList
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RestaurantsIndex(RestaurantsViewModel model)
        {
            return View();
        }
        public void RestaurantSearch()
        {
            JObject results = Search("food", "chicago");
            var currentUserName = User.Identity.Name;
            var currentUser = _context.Users.FirstOrDefault(m => m.UserName == currentUserName);
            for (int i = 0; i < 20; i++)
            {
                try
                {
                    var restaurant = new TempRestaurants()
                    {
                        UserId = currentUser.Email,
                        Phone = results["businesses"][i]["display_phone"].ToString(),
                        Name = results["businesses"][i]["name"].ToString(),
                        Category = results["businesses"][i]["categories"][0][0].ToString(),
                        ImageUrl = results["businesses"][i]["image_url"].ToString(),
                        RatingUrl = results["businesses"][i]["rating_img_url_small"].ToString(),
                        Review = results["businesses"][i]["snippet_text"].ToString(),
                        Link = results["businesses"][i]["url"].ToString()
                    };
                    _context.TempRestaurants.Add(restaurant);
                    _context.SaveChanges();
                }
                catch { }
            }
        }
        private const string CONSUMER_KEY = "-H424RZyK5jKczrI6U7TSg";
        private const string CONSUMER_SECRET = "Hr9xu-dzpsfEvYK0x6zJa6jMhJ4";
        private const string TOKEN = "_zmDBvb401h8pw7tfCIWkyuwt1nrOd0g";
        private const string TOKEN_SECRET = "oM_rtzpoZ2GG_yIqWqAvJaBWCz4";
        private const string API_HOST = "https://api.yelp.com";
        private const string SEARCH_PATH = "/v2/search/";
        private const string BUSINESS_PATH = "/v2/business/";
        private const int SEARCH_LIMIT = 20;
        private JObject PerformRequest(string baseURL, Dictionary<string, string> queryParams = null)
        {
            var query = System.Web.HttpUtility.ParseQueryString(String.Empty);

            if (queryParams == null)
            {
                queryParams = new Dictionary<string, string>();
            }

            foreach (var queryParam in queryParams)
            {
                query[queryParam.Key] = queryParam.Value;
            }

            var uriBuilder = new UriBuilder(baseURL);
            uriBuilder.Query = query.ToString();

            var request = WebRequest.Create(uriBuilder.ToString());
            request.Method = "GET";
            request.SignRequest(
                new Tokens
                {
                    ConsumerKey = CONSUMER_KEY,
                    ConsumerSecret = CONSUMER_SECRET,
                    AccessToken = TOKEN,
                    AccessTokenSecret = TOKEN_SECRET
                }
            ).WithEncryption(EncryptionMethod.HMACSHA1).InHeader();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            var stream = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            return JObject.Parse(stream.ReadToEnd());
        }
        public JObject Search(string term, string location)
        {
            string baseURL = API_HOST + SEARCH_PATH;
            var queryParams = new Dictionary<string, string>()
            {
                { "term", term },
                { "location", location },
                { "limit", SEARCH_LIMIT.ToString() }
            };
            return PerformRequest(baseURL, queryParams);
        }
    }
}