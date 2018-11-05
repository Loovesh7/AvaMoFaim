using System;
using System.Collections.Generic;
using System.Text;

namespace MoFaim.Models
{
    public class MenuItems
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Detail { get; set; }
        public int RestaurantId { get; set; }

        public MenuItems(string name, double price, string detail)
        {
            this.Detail = detail;
            this.Name = name;
            this.Price = price;
        }
    }
}
