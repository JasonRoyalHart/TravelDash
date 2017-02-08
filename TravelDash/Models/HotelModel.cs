using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelDash.Models
{
    public class HotelModel
    {
        public string property_code { get; set; }
        public int UserId { get; set; }
        public string property_name { get; set; }
        public string address { get; set; }
        public string total_price { get; set; }
    }
}

