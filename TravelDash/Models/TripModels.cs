using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelDash.Models
{
    public class TripModels
    { 
        [Key]
        public int ID { get; set; }
        public string UserId { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Destination { get; set; }
        public string Home { get; set; }
    }
}