using System.Collections.Generic;

namespace WebApplication1.Dto
{
    public class House
    {
        public int Id { get; set; }
        public int HouseNumber{ get; set; }
        public List<Apartment> Apartments{ get; set; }
       // public Street Street{ get; set; }
    }
}