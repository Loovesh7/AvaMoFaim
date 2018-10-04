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
    public class UserRatingController : Controller
    {
        private IUserRatingService _ratingService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public UserRatingController(
            IUserRatingService ratingService,
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _ratingService = ratingService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [HttpPost]
        public IActionResult RateRestaurant([FromBody] UserRatingDto userRatingDto)
        {
            var user = _mapper.Map<UserRating>(userRatingDto);
            bool status = _ratingService.RateRestaurant(user);
            return Ok(status);
        }
    }
}