using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelDash.Models
{
    public class TempRestaurants
    {
        [Key]
        public int ID { get; set; }
        public object Restaurant { get; set; }
        public string UserId { get; set; }
    }
}