using System;
using System.Collections.Generic;
using AutoMapper;
using BLL.dto;
using DAL.Entity;

namespace BLL.mapers
{
    public class UserCastomMaper
    {
        public static User mapDtoToUser(UserDto dto, IMapper mp)
        {
            User toReturn = mp.Map<User>(dto);  
            return toReturn;
        }

        public static UserDto mapUserToDto(User item, IMapper mp)
        {
            UserDto toReturn = new UserDto {BornDate=item.BornDate,  FIO=item.FIO, UserId=item.UserId};
            List<ApartmentDto> toAdd = new List<ApartmentDto>();
            
            return toReturn;
        }
    }
}