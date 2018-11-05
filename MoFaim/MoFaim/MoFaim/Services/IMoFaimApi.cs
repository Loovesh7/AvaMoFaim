using MoFaim.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MoFaim.Services
{
    interface IMoFaimApi
    {
        [Post("/Users/authenticate")]
        Task<ApiResponse<AuthenticateUser>> ValidateUser([Body] UserDTO userDTO);

        [Post("/Users/register")]
        Task<ApiResponse<AuthenticateUser>> RegisterUser([Body] UserDTO userDTO);

        [Get("/Restaurants")]
        Task<ApiResponse<IEnumerable<Restaurants>>> GetRestaurants([Header("Authorization")] string authorization);

        [Get("/MenuItems")]
        Task<ApiResponse<IEnumerable<MenuItems>>> GetMenuItems([Header("Authorization")] string authorization);

        [Get("/Users")]
        Task<ApiResponse<IEnumerable<UserDTO>>> GetUsers([Header("Authorization")] string authorization);

        [Post("/UserRating")]
        Task<ApiResponse<bool>> RateRestaurant([Body] UserRatingDto userRatingDto);

        [Get("/Values")]
        Task<string[]> TestApi();
        
    }
}
