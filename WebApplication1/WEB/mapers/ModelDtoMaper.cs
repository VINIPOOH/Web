using AutoMapper;
using BLL.dto;
using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WEB.Models;

namespace WEB.mapers
{
    public class ModelDtoMaper: Profile
{
        public ModelDtoMaper()
        {
            CreateMap<CityModel, CityDto>().ReverseMap();
            CreateMap<StreetModel, StreetDto>().ReverseMap();
            CreateMap<HouseModel, HouseDto>().ReverseMap();
            CreateMap<ApartmentModel, ApartmentDto>().ReverseMap();
            CreateMap<UserModel, UserDto>().ReverseMap();

            CreateMap<City, CityDto>().ReverseMap();
            CreateMap<Street, StreetDto>().ReverseMap();
            CreateMap<House, HouseDto>().ReverseMap();
            CreateMap<Apartment, ApartmentDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<UserApartment, UserAppartmenDto>().ReverseMap();
            
            

        }
    }
}
///////
///
///  CreateMap<CityModel, CityDto>().ReverseMap();
//CreateMap<StreetModel, StreetDto>().ReverseMap();
//CreateMap<HouseModel, HouseDto>().ReverseMap();
//CreateMap<ApartmentModel, ApartmentDto>().ReverseMap();
//CreateMap<UserModel, UserDto>().ReverseMap();
//
//CreateMap<City, CityDto>().ForMember(cityDto => cityDto.Streets, s => s.MapFrom(sity => sity.Streets)).ReverseMap();
//CreateMap<Street, StreetDto>().ForMember(p => p.Houses, s => s.MapFrom(d => d.Houses)).ReverseMap();
//CreateMap<House, HouseDto>().ForMember(p => p.Apartments, s => s.MapFrom(d => d.Apartments)).ReverseMap();
//CreateMap<Apartment, ApartmentDto>().ForMember(p => p.Users, s => s.MapFrom(d => d.UserApartments.Select(f => f.User).ToList()));
//CreateMap<User, UserDto>().ForMember(p => p.Apartments, s => s.MapFrom(d => d.UserApartments.Select(f => f.Apartment).ToList()));
//
//CreateMap<ApartmentDto, Apartment>().ForMember(apartment => apartment.UserApartments, Options => Options.MapFrom(apartmentDto => apartmentDto.Users.Select(UserDto => new UserApartment() { ApartmentId = apartmentDto.ApartmentId, UserId = UserDto.UserId })));
//CreateMap<UserDto, User>().ForMember(p => p.UserApartments, s => s.MapFrom(d => d.Apartments.Select(f => new UserApartment() { ApartmentId = f.ApartmentId, UserId = d.UserId })));

