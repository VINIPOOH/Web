﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BLL.dto
{
    public class HouseDto
    {

        public HouseDto()
        {
        }

        public HouseDto(int id, int houseNumber, ICollection<ApartmentDto> apartments, int streetId)
        {
            Id = id;
            HouseNumber = houseNumber;
            StreetId = streetId;
        }

        public int Id { get; set; }
        [Required] public int HouseNumber { get; set; }
        public int StreetId { get; set; }
    }
}