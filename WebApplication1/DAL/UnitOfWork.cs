﻿using ComputerNet.DAL.Interfaces;
using DAL.Entity;
using System;
 using WebApplication1.Dal;

 namespace ComputerNet.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyDbContext context;
        public GenericRepository<Apartment> apartments;
        public GenericRepository<City> cites;
        public GenericRepository<House> houses;
        public GenericRepository<Street> streets;
        public GenericRepository<User> users;
        public GenericRepository<UserApartment> userApps;
        private bool disposed = false;

        public UnitOfWork()
        {
            context = new MyDbContext();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            disposed = true;
        }
        

        public void Save()
        {
            context.SaveChanges();
        }

        public GenericRepository<T> Set<T>() where T : class
        {
            if (typeof(T) == typeof(Apartment))
            {
                return Apartments as GenericRepository<T>;
            }

            if (typeof(T) == typeof(City))
            {
                return Cites as GenericRepository<T>;
            }

            if (typeof(T) == typeof(House))
            {
                return Houses as GenericRepository<T>;
            }

            if (typeof(T) == typeof(Street))
            {
                return Streets as GenericRepository<T>;
            }

            if (typeof(T) == typeof(User))
            {
                return Users as GenericRepository<T>;
            }
            
            if (typeof(T) == typeof(UserApartment))
            {
                return UserApps as GenericRepository<T>;
            }

            return null;
        }

        public GenericRepository<Apartment> Apartments =>
            apartments ??(apartments = new GenericRepository<Apartment>(context));

        public GenericRepository<City> Cites =>
            cites ?? (cites = new GenericRepository<City>(context));

        public GenericRepository<House> Houses=>
        houses ?? (houses = new GenericRepository<House>(context));

        public GenericRepository<Street> Streets=>
        streets ?? (streets = new GenericRepository<Street>(context));

        public GenericRepository<User> Users => 
            users??(users=new GenericRepository<User>(context));
        
        public GenericRepository<UserApartment> UserApps => 
            userApps??(userApps=new GenericRepository<UserApartment>(context));
    }
}
