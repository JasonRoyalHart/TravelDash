using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelDash.Models
{
    public class TripViewModel
    {
        [Required]
        [Display(Name = "Starting City")]
        public string Home { get; set; }

        [Required]
        [Display(Name = "Destination")]
        public string Destination { get; set; }

        [Required]
        [Display(Name = "Day")]
        public int DepartureDay { get; set; }

        [Required]
        [Display(Name = "Month")]
        public int DepartureMonth { get; set; }

        [Required]
        [Display(Name = "Year")]
        public int DepartureYear { get; set; }

        [Required]
        [Display(Name = "Day")]
        public int ArrivalDay { get; set; }

        [Required]
        [Display(Name = "Month")]
        public int ArrivalMonth { get; set; }

        [Required]
        [Display(Name = "Year")]
        public int ArrivalYear { get; set; }
    }
}