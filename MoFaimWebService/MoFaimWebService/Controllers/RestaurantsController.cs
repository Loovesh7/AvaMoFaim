using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MoFaimWebService.Entities;
using MoFaimWebService.Helpers;
using MoFaimWebService.Services;

namespace MoFaimWebService.Controllers
{
   
    [ApiController]
    [Route("[controller]")]
    public class RestaurantsController : Controller
    {
        private IRestaurantService _restaurantService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public RestaurantsController(
            IRestaurantService restaurantService,
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _restaurantService = restaurantService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var restaurants = _restaurantService.GetAll();
            return Ok(restaurants);
        }
    }
}