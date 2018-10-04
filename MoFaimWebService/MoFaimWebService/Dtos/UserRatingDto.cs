using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoFaimWebService.Dtos
{
    public class UserRatingDto
    {
        public int UserId { get; set; }
        public int RestaurantId { get; set; }
        public double Rating { get; set; }

    }
}
