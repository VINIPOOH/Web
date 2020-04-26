﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.model
{
    public class HouseModel
    {

        public HouseModel()
        {
        }

        public HouseModel(int id, int houseNumber, ICollection<ApartmentModel> apartments, int streetId)
        {
            Id = id;
            HouseNumber = houseNumber;
            StreetId = streetId;
        }

        public int Id { get; set; }
        [Required] public int HouseNumber { get; set; }
        public int StreetId { get; set; }
    }
}