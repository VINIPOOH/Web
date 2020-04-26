﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BLL.dto
{
    public class ApartmentDto
    {
        public ApartmentDto()
        {
        }

        public ApartmentDto(int apartmentId, int apartmentNumber, int apartmentSpace, int houseId, List<UserDto> userApartments)
        {
            ApartmentId = apartmentId;
            ApartmentNumber = apartmentNumber;
            ApartmentSpace = apartmentSpace;
            HouseId = houseId;
        }

        public int ApartmentId { get; set; }
        [Required] public int ApartmentNumber { get; set; }
        [Required] public int ApartmentSpace { get; set; }
        
        public int HouseId{ get; set; }
    }
}