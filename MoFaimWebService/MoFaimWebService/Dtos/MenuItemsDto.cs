using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoFaimWebService.Dtos
{
    public class MenuItemsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Detail { get; set; }
        public int RestaurantId { get; set; }
    }
}
