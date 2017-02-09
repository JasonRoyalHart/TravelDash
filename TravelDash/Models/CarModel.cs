using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelDash.Models
{
    public class CarModel
    {
        public int ID { get; set; }
        public string UserId { get; set; }
        public string Provider { get; set; }
        public string ImageUrl { get; set; }
        public string Info { get; set; }
        public string Price { get; set; }

    }
}