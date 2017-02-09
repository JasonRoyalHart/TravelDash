using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelDash.Models
{
    public class TempPlanes
    {
        [Key]
        public int ID { get; set; }
        public string UserId { get; set; }
        public string InboundAirline { get; set; }
        public string InboundDeparture { get; set; }
        public string OutboundAirline { get; set; }
        public string OutboundDeparture { get; set; }
    }
}