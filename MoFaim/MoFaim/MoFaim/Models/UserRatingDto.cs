using System;
using System.Collections.Generic;
using System.Text;

namespace MoFaim.Models
{
    public class UserRatingDto
    {
        public int UserId { get; set; }
        public int RestaurantId { get; set; }
        public double Rating { get; set; }

        public UserRatingDto(int userId,int restaurantId,double rating)
        {
            UserId = userId;
            RestaurantId = restaurantId;
            Rating = rating;
        }
    }
}
