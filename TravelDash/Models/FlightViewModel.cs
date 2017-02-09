using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelDash.Models
{
    public class FlightViewModel
    {
            private ApplicationDbContext _context;

            public FlightViewModel()
            {
                _context = new ApplicationDbContext();
            }


            [Required]
            [Display(Name = "Origin")]
            public string Origin { get; set; }

            [Required]
            [Display(Name = "Destination")]
            public string Destination { get; set; }

            [Required]
            [Display(Name = "Outbound")]
            public string Outbound { get; set; }
            [Required]
            [Display(Name = "Inbound")]
            public string Inbound { get; set; }

            [Required]
            [Display(Name = "Number of Results")]
            public string NumberOfResults { get; set; }


            public ApplicationUser ApplicationUser { get; set; }
            public PlaneModel Planes { get; set; }
            public IEnumerable<TempPlanes> TempPlanes { get; set; }
        }
    
}