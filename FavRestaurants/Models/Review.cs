using System.Collections.Generic;

namespace FavRestaurants.Models
{
    public class Review
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public int ReviewId { get; set; }

        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
    }

}