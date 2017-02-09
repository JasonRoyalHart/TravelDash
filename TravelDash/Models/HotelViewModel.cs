using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelDash.Models
{
    public class HotelViewModel
    {
        private ApplicationDbContext _context;

        public HotelViewModel()
        {
            _context = new ApplicationDbContext();
        }
        public ApplicationUser ApplicationUser { get; set; }
        public HotelModel Hotels { get; set; }
        public IEnumerable<TempHotels> TempHotels { get; set; }

    }
}