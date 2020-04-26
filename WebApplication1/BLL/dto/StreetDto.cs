﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BLL.dto
{
    public class StreetDto
    {

        public StreetDto()
        {
        }

        public StreetDto(int id, string name, ICollection<HouseDto> houses, int cityId)
        {
            Id = id;
            Name = name;
            CityId = cityId;
        }

        public int Id { get; set; }
        [Required] public string Name { get; set; }
        public int CityId { get; set; }
    }
}