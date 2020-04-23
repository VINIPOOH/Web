using System.Collections.Generic;

namespace WebApplication1.Dto
{
    public class Country
    {
        public Country()
        {
            Cities = new List<City>();
        }

        public int Id { get; set; }
        public List<City> Cities{ get; set; }
    }
}