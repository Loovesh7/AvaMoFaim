using MoFaimWebService.Entities;
using MoFaimWebService.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoFaimWebService.Services
{
    public interface IMenuItemsService
    {
        IEnumerable<MenuItems> GetAll();
        List<MenuItems> FindByRestaurant(int restaurantId);
    }

    public class MenuItemsService : IMenuItemsService
    {
        private DataContext _context;

        public MenuItemsService(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<MenuItems> GetAll()
        {
            return _context.MenuItems;
        }

        public List<MenuItems> FindByRestaurant(int restaurantId)
        {
            Restaurants restaurant = _context.Restaurants.Find(restaurantId);
            return _context.MenuItems.Where(x => x.Restaurants == restaurant).Select(u => u).ToList();
        }
    }
}
