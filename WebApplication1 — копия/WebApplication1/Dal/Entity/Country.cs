using System.Collections.Generic;

namespace WebApplication1.Dto
{
    public class Country
    {
        public int Id { get; set; }
        public List<City> Cities{ get; set; }
    }
}