using System.Collections.Generic;

namespace WebApplication1.Dto
{
    public class Street
    {
        public int Id { get; set; }
        //public City City { get; set; }
        public List<House> Houses{ get; set; }
    }
}