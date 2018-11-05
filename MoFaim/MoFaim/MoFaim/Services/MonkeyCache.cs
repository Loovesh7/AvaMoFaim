using MoFaim.Models;
using MonkeyCache.SQLite;
using MvvmHelpers;
using Refit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MoFaim.Services
{
    class MonkeyCache
    {
        public static string url = "https://mofaimwebserviceaavs.azurewebsites.net/";

        public static string restaurantsKey = "restaurants";

        public static string menuItemsKey = "menuItems";

        public static string usersKey = "users";

        public async static Task<IEnumerable<Restaurants>> GetRestaurantsAsync()
        {
            string token = (string)App.Current.Properties["jwtToken"];
            var moFaimApi = RestService.For<IMoFaimApi>(url);

            if (!Barrel.Current.IsExpired(key: restaurantsKey))
            {
                return Barrel.Current.Get<IEnumerable<Restaurants>>(key: restaurantsKey);
            }

            var result = await moFaimApi.GetRestaurants(token);

            IEnumerable<Restaurants> restaurants = null;

            if (result.IsSuccessStatusCode)
            {
                restaurants = result.Content;
                Barrel.Current.Add(key: restaurantsKey, data: restaurants, expireIn: TimeSpan.FromDays(4));
                Console.WriteLine("----Test----" + Barrel.Current.Get<IEnumerable<Restaurants>>(key: restaurantsKey));
            }
            Console.WriteLine("----Call Restosss*****NEW---------------------------");
            return Barrel.Current.Get<IEnumerable<Restaurants>>(key: restaurantsKey);
        }

        public async static Task<IEnumerable<MenuItems>> GetMenuItemsAsync()
        {
            string token = (string)App.Current.Properties["jwtToken"];
            var moFaimApi = RestService.For<IMoFaimApi>(url);

            if (!Barrel.Current.IsExpired(key: menuItemsKey))
            {
                return Barrel.Current.Get<IEnumerable<MenuItems>>(key: menuItemsKey);
            }

            var result = await moFaimApi.GetMenuItems(token);

            IEnumerable<MenuItems> menuItems = null;

            if (result.IsSuccessStatusCode)
            {
                menuItems = result.Content;
                Barrel.Current.Add(key: menuItemsKey, data: menuItems, expireIn: TimeSpan.FromDays(4));
                Console.WriteLine("----Test----" + Barrel.Current.Get<IEnumerable<MenuItems>>(key: menuItemsKey));
            }
            else
            {
                Console.WriteLine("*****************Menu Items----ERROR" +token);
            }

            return Barrel.Current.Get<IEnumerable<MenuItems>>(key: menuItemsKey);
        }

        public static async Task<List<MenuItems>> GetMenuItemsByRestaurantIdAsync(int restaurantId)
        {
            bool refresh = true;
            int count = 0;
            List<MenuItems> restaurantMenus = new List<MenuItems>();
            while (refresh && count < 2)
            {
                if (!Barrel.Current.IsExpired(key: menuItemsKey))
                {
                    IEnumerable<MenuItems> menuItems = Barrel.Current.Get<IEnumerable<MenuItems>>(key: menuItemsKey);
                    
                    foreach (MenuItems m in menuItems)
                    {
                        if (m.RestaurantId == restaurantId)
                        {
                            restaurantMenus.Add(m);
                        }
                    }
                    return restaurantMenus;
                }
                else
                {
                    Console.WriteLine("*****************GetMenuItemsByRestaurantId-----ELSE");
                    await GetMenuItemsAsync();
                    count++;
                }
            }
            return restaurantMenus;
        }

        public async static Task<IEnumerable<UserDTO>> GetUsersAsync()
        {
            string token = (string)App.Current.Properties["jwtToken"];
            var moFaimApi = RestService.For<IMoFaimApi>(url);

            if (!Barrel.Current.IsExpired(key: menuItemsKey))
            {
                return Barrel.Current.Get<IEnumerable<UserDTO>>(key: usersKey);
            }

            var result = await moFaimApi.GetUsers(token);
            IEnumerable<UserDTO> users = null;

            if (result.IsSuccessStatusCode)
            {
                users = result.Content;
                Barrel.Current.Add(key: usersKey, data: users, expireIn: TimeSpan.FromDays(4));
                Console.WriteLine("----Test----" + Barrel.Current.Get<IEnumerable<UserDTO>>(key: usersKey));
            }
            else
            {
                Console.WriteLine("*****************Users---ERROR" + token);
            }

            return Barrel.Current.Get<IEnumerable<UserDTO>>(key: usersKey);
        }

        public async static Task<bool> RateRestaurantAsync(UserRatingDto userRatingDto)
        {

            Console.WriteLine("DTO*********************************  " + userRatingDto.UserId+"   " +userRatingDto.RestaurantId+ "   " + userRatingDto.Rating);
            string token = (string)App.Current.Properties["jwtToken"];
            var moFaimApi = RestService.For<IMoFaimApi>(url);
            bool response = false;

            var result = await moFaimApi.RateRestaurant(userRatingDto);

            Console.WriteLine("Rating*********************************  " + result.Content);

            if (result.IsSuccessStatusCode)
            {
                response = result.Content;
            }
            return response;
        }

    }
}
