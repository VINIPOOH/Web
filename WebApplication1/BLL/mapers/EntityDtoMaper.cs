using AutoMapper;
using BLL.dto;
using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.mapers
{
    public class EntityDtoMaper: Profile
{
        public EntityDtoMaper()
        {
            CreateMap<City, CityDto>().ReverseMap();
            CreateMap<Street, StreetDto>().ReverseMap();
            CreateMap<House, HouseDto>().ReverseMap();
            CreateMap<Apartment, ApartmentDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();

        }
    }
}
