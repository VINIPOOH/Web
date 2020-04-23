using System.Collections.Generic;

namespace WebApplication1.Dto
{
    public class City
    {
        public string SityName { get; set; }
        public int Id { get; set; }
        //public Country Country { get; set; }
        public List<Street> Streets{ get; set; }
    }
}