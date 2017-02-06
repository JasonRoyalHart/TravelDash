using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelDash.Models
{
    public class RestaurantsViewModel
    {
        private ApplicationDbContext _context;

        public RestaurantsViewModel()
        {
            _context = new ApplicationDbContext();
        }
        ApplicationUser ApplicationUser { get; set; }
    }
}