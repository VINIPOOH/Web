﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BLL.dto
{
    public class CityDto
    {


        public CityDto(string name)
        {
            Name = name;
        }

        public CityDto()
        {
        }

        public CityDto(int id, string name, ICollection<StreetDto> streets)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        [Required] public string Name { get; set; }
    }
}