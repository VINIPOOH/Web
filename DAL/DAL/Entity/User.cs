using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Dto
{
    public class User
    {
        public int UserId { get; set; }
        [Required]
        public string FIO { get; set; }
        [Required]
        public DateTime BornDate { get; set; }
        public List<UserApartment> UserApartments { get; set; }
    }
}