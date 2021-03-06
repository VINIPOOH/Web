﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Dto
{
    public class City
    {
        public City()
        {
            Streets = new List<Street>();
        }

        public int Id { get; set; }
        [Required] public string Name { get; set; }
        public ICollection<Street> Streets { get; set; }
    }
}