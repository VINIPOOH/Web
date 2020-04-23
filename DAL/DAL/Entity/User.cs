using System.Collections.Generic;

namespace WebApplication1.Dto
{
    public class User
    {
        public int Id { get; set; }
        public List<UserApartment> UserApartments{ get; set; }
    }
}