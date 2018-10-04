using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MoFaimWebService.Helpers;
using MoFaimWebService.Services;

namespace MoFaimWebService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MenuItemsController : Controller
    {
        private IMenuItemsService _menuItemsService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public MenuItemsController(
            IMenuItemsService menuItemsService,
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _menuItemsService = menuItemsService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [HttpGet("{restaurantId}")]
        public IActionResult FindMenuItemsByRestaurant(int restaurantId)
        {
            return Ok(_menuItemsService.FindByRestaurant(restaurantId));
        }
    }
}