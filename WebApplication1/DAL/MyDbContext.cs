﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using DAL.Entity;
 using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

 namespace WebApplication1.Dal
{
    public class MyDbContext : IdentityDbContext
    {
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<House> Houses { get; set; }
        public DbSet<Street> Streets { get; set; }
        public DbSet<User> Users { get; set; }

        public MyDbContext() : base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var conectionString = "server=localhost;database=labweb;uid=root;pwd=root;";
            optionsBuilder.UseMySql(conectionString);
            base.OnConfiguring(optionsBuilder);
        }

    }
}