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
        public string DepartureDay { get; set; }

        [Required]
        [Display(Name = "Month")]
        public string DepartureMonth { get; set; }

        [Required]
        [Display(Name = "Year")]
        public string DepartureYear { get; set; }

        [Required]
        [Display(Name = "Day")]
        public string ArrivalDay { get; set; }

        [Required]
        [Display(Name = "Month")]
        public string ArrivalMonth { get; set; }

        [Required]
        [Display(Name = "Year")]
        public string ArrivalYear { get; set; }

    }
}