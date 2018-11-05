using System;
using System.Collections.Generic;
using System.Text;

namespace MoFaim.Models
{
    public enum MenuItemType
    {
        Users,
        Restaurants,
        About,
        Logout
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
