using Microsoft.EntityFrameworkCore;

namespace FavRestaurants.Models
{
    public class FavRestaurantsContext : DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Cuisine> Cuisines { get; set; }

        public FavRestaurantsContext(DbContextOptions options) : base(options) { }
    }
}