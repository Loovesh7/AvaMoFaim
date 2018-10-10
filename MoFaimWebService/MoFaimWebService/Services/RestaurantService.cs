using MoFaimWebService.Entities;
using MoFaimWebService.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
        void InsertImage(string path, int restaurantId);
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

        public void InsertImage(string path, int restaurantId)
        {
            Image image = Image.FromFile(path);
            Byte[] blob = null;
            using (var ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                blob = ms.ToArray();
            }
            Restaurants restaurant = _context.Restaurants.Find(restaurantId);

            restaurant.Logo = blob;
            _context.SaveChanges();
        }
    }
}
