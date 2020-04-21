using System.Collections.Generic;

namespace WebApplication1.Dto
{
    public class House
    {
        private int id{ get; set; }
        private int HouseNumber{ get; set; }
        private List<Apartment> apartments{ get; set; }
        public Street Street{ get; set; }
    }
}