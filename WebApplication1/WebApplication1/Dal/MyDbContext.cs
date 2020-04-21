using Microsoft.EntityFrameworkCore;
using WebApplication1.Dto;

namespace WebApplication1.Dal
{
    public class MyDbContext : DbContext
    {
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<City> Cities{ get; set; }
        public DbSet<Country> Countries{ get; set; }
        public DbSet<House> Houses{ get; set; }
        public DbSet<Street> Streets{ get; set; }
        public DbSet<User> DbSet{ get; set; }

        public MyDbContext() : base()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var conectionString = "server=localhost;database=labdb;uid=root;pwd=root;";
            optionsBuilder.UseMySql(conectionString);
            base.OnConfiguring(optionsBuilder);
        }
    }
}