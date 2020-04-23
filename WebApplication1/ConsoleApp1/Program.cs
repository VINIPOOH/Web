using System;
using ComputerNet.DAL.Repositories;
using WebApplication1.Dto;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            UnitOfWork unitOfWork = new UnitOfWork();
            unitOfWork.Cites.Create(new City("Kiyv"));
            unitOfWork.Save();
        }
    }
}