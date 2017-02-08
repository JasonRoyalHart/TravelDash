﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelDash.Models
{
    public class TempEvents
    {
        [Key]
        public int ID { get; set; }
        public string UserId { get; set; }
        public object Event { get; set; }
    }
}