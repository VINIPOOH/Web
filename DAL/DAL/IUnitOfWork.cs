using ComputerNet.DAL.Repositories;
using System;
 using WebApplication1.Dto;

 namespace ComputerNet.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        GenericRepository<Apartment> Apartments { get; }
        GenericRepository<City> Cites { get; }
        GenericRepository<House> Houses { get; }
        GenericRepository<Street> Streets { get; }
        GenericRepository<User> Users { get; }

        void Save();

        GenericRepository<T> Set<T>() where T : class;
    }
}
