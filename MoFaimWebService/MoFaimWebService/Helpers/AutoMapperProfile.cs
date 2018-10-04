using AutoMapper;
using MoFaimWebService.Dtos;
using MoFaimWebService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoFaimWebService.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<UserRatingDto, UserRating>();
        }
    }
}
