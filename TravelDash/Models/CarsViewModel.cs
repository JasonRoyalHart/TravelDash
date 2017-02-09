using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelDash.Models
{
    public class CarsViewModel
    {
        private ApplicationDbContext _context;

        public CarsViewModel()
        {
            _context = new ApplicationDbContext();
        }


        [Required]
        [Display(Name = "Pickup")]
        public string Pickup { get; set; }

        [Required]
        [Display(Name = "Pick up Date")]
        public string PickUpDtae { get; set; }

        [Required]
        [Display(Name = "Drop Off Date")]
        public string DropOffDate { get; set; }


        public ApplicationUser ApplicationUser { get; set; }
        public CarModel Cars { get; set; }
        public IEnumerable<TempCars> TempCars { get; set; }
    }
}