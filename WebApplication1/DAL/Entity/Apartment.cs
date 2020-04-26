﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entity
{
    public class Apartment
    {
        public Apartment()
        {
            UserApartments = new List<UserApartment>();
        }

        public int ApartmentId { get; set; }
        [Required] public int ApartmentNumber { get; set; }
        [Required] public int ApartmentSpace { get; set; }
        
        public int HouseId{ get; set; }
        public virtual House House{ get; set; }
        public List<UserApartment> UserApartments { get; set; }
    }
}