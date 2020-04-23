using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Dto
{
    public class House
    {
        public House()
        {
            Apartments = new List<Apartment>();
        }

        public int Id { get; set; }
        [Required] public int HouseNumber { get; set; }
        public ICollection<Apartment> Apartments { get; set; }
        public int StreetId { get; set; }
        public virtual Street Street { get; set; }
    }
}