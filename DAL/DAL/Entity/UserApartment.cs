﻿using System.Collections.Generic;

namespace WebApplication1.Dto
{
    public class UserApartment
    {
        public int Id { get; set; }
        public User User{ get; set; }
        public Apartment Apartment{ get; set; }
    }
}