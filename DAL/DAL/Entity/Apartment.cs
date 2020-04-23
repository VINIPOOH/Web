using System.Collections.Generic;

namespace WebApplication1.Dto
{
    public class Apartment
    {
        public int Id{ get; set; }
        //public House House { get; set; }
        public List<UserApartment> UserApartments{ get; set; }
    }
}