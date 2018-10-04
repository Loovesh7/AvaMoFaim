using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MoFaimWebService.Entities
{
    public class MenuItems
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Detail { get; set; }
        [ForeignKey("Restaurants")]
        public int RestaurantId { get; set; }
        public virtual Restaurants Restaurants { get; set; }
    }
}
