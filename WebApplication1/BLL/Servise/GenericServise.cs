using System.Collections.Generic;
using ComputerNet.DAL.Repositories;
using WebApplication1.Dto;

namespace BLL.Servise
{
    public class GenericServise<Entity> where Entity : class
    {
        protected UnitOfWork UnitOfWork;

        IEnumerable<Entity> GetAll()
        {
            return UnitOfWork.Set<Entity>().Get();
        }
        void Create(Entity entity)
        {
            UnitOfWork.Set<Entity>().Create(entity);
        }

        void Delete(Entity entity)
        {
            UnitOfWork.Set<Entity>().Delete(entity);
        }

        void Update(Entity entity)
        {
            UnitOfWork.Set<Entity>().Update(entity);
        }
    }
}