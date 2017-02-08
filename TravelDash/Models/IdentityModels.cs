using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TravelDash.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<TripModels> TripModels { get; set; }
        public DbSet<CarModel> CarModel { get; set; }
        public DbSet<EventModel> EventModel { get; set;}
        public DbSet<HotelModel> HotelModel { get; set; }
        public DbSet<PlaneModel> PlaneModel { get ; set; }
        public DbSet<RestaurantModels> RestaurantModels { get; set; }
        public DbSet<TempCars> TempCars { get; set; }
        public DbSet<TempEvents> TempEvents { get; set; }
        public DbSet<TempHotels> TempHotels { get; set; }
        public DbSet<TempPlanes> TempPlanes { get; set; }
        public DbSet<TempRestaurants> TempRestaurants { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}