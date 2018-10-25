using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MoFaimWebService.Entities
{
    public class UserRating
    {
        [Key]
        [ForeignKey("User")]
        public int UserId { get; set; }
        [Key]
        [ForeignKey("Restaurants")]
        public int RestaurantId { get; set; }
        public double Rating { get; set; }
    }
}
