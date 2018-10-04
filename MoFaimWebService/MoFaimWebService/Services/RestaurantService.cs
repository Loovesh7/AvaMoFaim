using MoFaimWebService.Entities;
using MoFaimWebService.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoFaimWebService.Services
{
    public interface IRestaurantService
    {
        IEnumerable<Restaurants> GetAll();
        Restaurants GetById(int id);
        Restaurants GetByName(string name);
        Restaurants GetByLocation(string location);
    }

    public class RestaurantService : IRestaurantService
    {
        private DataContext _context;

        public RestaurantService(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Restaurants> GetAll()
        {
            return _context.Restaurants;
        }

        public Restaurants GetById(int id)
        {
            return _context.Restaurants.Find(id);
        }

        public Restaurants GetByLocation(string location)
        {
            return _context.Restaurants.Find(location);
        }

        public Restaurants GetByName(string name)
        {
            return _context.Restaurants.Find(name);
        }
    }
}
