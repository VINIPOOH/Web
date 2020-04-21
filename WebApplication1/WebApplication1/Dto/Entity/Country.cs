using System.Collections.Generic;

namespace WebApplication1.Dto
{
    public class Country
    {
        private int id{ get; set; }
        private List<City> cities{ get; set; }
    }
}