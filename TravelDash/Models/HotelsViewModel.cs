using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelDash.Models
{
    public class HotelsViewModel
    {
        private ApplicationDbContext _context;

        public HotelsViewModel()
        {
            _context = new ApplicationDbContext();
        }
        public ApplicationUser ApplicationUser { get; set; }
        public HotelModel Hotels { get; set; }
        public IEnumerable<TempHotels> TempRestaurants { get; set; }

    }
}