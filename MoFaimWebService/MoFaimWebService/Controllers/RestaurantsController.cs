using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MoFaimWebService.Dtos;
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
            IEnumerable<Restaurants> restaurants = _restaurantService.GetAll();
            if (restaurants != null)
            {
                return Ok(restaurants);
            }
            return NotFound("Empty"); 
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _restaurantService.GetById(id);
            
            return Ok(user);
        }


        [HttpPost]
        public IActionResult UploadRestaurantImage([FromBody] UploadRestaurantImageDto uploadRestaurantImage)
        {
            _restaurantService.InsertImage(uploadRestaurantImage.Path,uploadRestaurantImage.RestaurantId);
            return Ok();
        }
    }
}