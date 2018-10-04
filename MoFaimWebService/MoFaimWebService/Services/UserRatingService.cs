using MoFaimWebService.Dtos;
using MoFaimWebService.Entities;
using MoFaimWebService.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoFaimWebService.Services
{
    public interface IUserRatingService
    {
        IEnumerable<UserRating> GetAll();
        bool RateRestaurant(UserRating userRating);

    }

    public class UserRatingService : IUserRatingService
    {
        private DataContext _context;

        public UserRatingService(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<UserRating> GetAll()
        {
            return _context.UserRating;
        }

        public bool RateRestaurant(UserRating userRating)
        {
            // validation
            if (userRating.Rating == 0.0)
                throw new AppException("Rating is required");

            User user = _context.Users.Find(userRating.UserId);
            if(user == null)
                throw new AppException("User does not exist");
            
            Restaurants restaurants = _context.Restaurants.Find(userRating.RestaurantId);
            if (restaurants == null)
                throw new AppException("Restaurant does not exist");

            UserRating checkUserRating = _context.UserRating.Find(userRating.UserId, userRating.RestaurantId);
            if (checkUserRating != null)
            {
                checkUserRating.Rating = userRating.Rating;       
            }
            else
            {
                _context.UserRating.Add(userRating);
            }

            List<double> ratings = _context.UserRating.Where(x => x.RestaurantId == restaurants.Id)
                .Select(u => u.Rating).ToList();

            restaurants.Rating = ratings.Sum()/ratings.Count();

            _context.SaveChanges();
            return true;
        }

    }
}
