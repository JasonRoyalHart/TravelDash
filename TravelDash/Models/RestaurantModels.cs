using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelDash.Models
{
    public class RestaurantModels
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Category { get; set; }
        public string ImageUrl { get; set; }
        public string RatingUrl { get; set; }
        public string Review { get; set; }
        public string Link { get; set; }
        public string UserId { get; set; }

    }
}