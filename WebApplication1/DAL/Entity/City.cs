﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entity
{
    public class City
    {
        public City(string name)
        {
            Name = name;
        }

        public City()
        {
            Streets = new List<Street>();
        }

        public int Id { get; set; }
        [Required] public string Name { get; set; }
        public ICollection<Street> Streets { get; set; }
    }
}