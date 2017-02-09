using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelDash.Models
{
    public class DashboardViewModel
    {
        private ApplicationDbContext _context;

        public DashboardViewModel()
        {
            _context = new ApplicationDbContext();
        }
        public ApplicationUser ApplicationUser { get; set; }

        public IEnumerable<PlaneModel> PlaneModel { get; set; }
        public IEnumerable<HotelModel> HotelModel { get; set; }
        public IEnumerable<RestaurantModels> RestaurantModels { get; set; }
        public IEnumerable<CarModel> CarModel { get; set; }
        public string UserId { get; set; }
    }
}