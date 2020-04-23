﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Dto
{
    public class Apartment
    {
        public int ApartmentId { get; set; }
        [Required] public int ApartmentNumber { get; set; }
        [Required] public int ApartmentSpace { get; set; }
        public List<UserApartment> UserApartments { get; set; }
    }
}