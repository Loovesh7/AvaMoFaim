using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoFaimWebService.Entities
{
    public class UserRating
    {
        [Key]
        public int UserId { get; set; }
        [Key]
        public int RestaurantId { get; set; }
        public double Rating { get; set; }
    }
}
