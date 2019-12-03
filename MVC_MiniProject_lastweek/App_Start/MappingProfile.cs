using AutoMapper;
using MVC_MiniProject_lastweek.dtos;
using MVC_MiniProject_lastweek.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_MiniProject_lastweek.App_Start
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>();
            Mapper.CreateMap<Movie, MoviesDto>();
            Mapper.CreateMap<MoviesDto, Movie>();
            Mapper.CreateMap<MembershipType,MembershipTypeDto>();
            Mapper.CreateMap<Genre, GenreDto>();
        }
    }
}