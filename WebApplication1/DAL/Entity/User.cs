﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entity
{
    public class User
    {
        public User()
        {
            UserApartments = new List<UserApartment>(); 
        }

        public int UserId { get; set; }
        [Required]
        public string FIO { get; set; }
        [Required]
        public DateTime BornDate { get; set; }
        public List<UserApartment> UserApartments { get; set; }
    }
}