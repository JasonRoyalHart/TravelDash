using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required]
        [Display(Name ="City (Airport Code)")]
        public string City { get; set; }

        [Required]
        [Display(Name = "Check In Date")]
        public string CheckIn { get; set; }

        [Required]
        [Display(Name = "Check Out Date")]
        public string CheckOut { get; set; }

        [Required]
        [Display(Name = "Maximum Distance From Airport")]
        public string Distance { get; set; }

        [Required]
        [Display(Name = "Number of results")]
        public string ResultNumber { get; set; }


        public ApplicationUser ApplicationUser { get; set; }
        public HotelModel Hotels { get; set; }
        public IEnumerable<TempHotels> TempHotels { get; set; }

    }
}