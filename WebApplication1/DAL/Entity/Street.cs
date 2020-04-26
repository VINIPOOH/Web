﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entity
{
    public class Street
    {
        public Street()
        {
            Houses = new List<House>();
        }

        public int Id { get; set; }
        [Required] public string Name { get; set; }
        public ICollection<House> Houses { get; set; }
        public int CityId { get; set; }
        public virtual City City { get; set; }
    }
}