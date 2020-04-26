﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BLL.dto
{
    public class UserDto
    {
        public UserDto(int userId, string fIO, DateTime bornDate, List<ApartmentDto> userApartments)
        {
            UserId = userId;
            FIO = fIO;
            BornDate = bornDate;
        }

        public UserDto()
        {
        }

        public int UserId { get; set; }
        [Required]
        public string FIO { get; set; }
        [Required]
        public DateTime BornDate { get; set; }
    }
}