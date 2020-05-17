using AutoMapper;
using BLL.Intarfaces;
using ComputerNet.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BLL.Servise
{
    public class GenericService<TEntity, TEntityDTO> : IGenericService<TEntityDTO, TEntity>
        where TEntity : class
        where TEntityDTO : class
    {
        protected readonly IMapper mp;
        protected readonly IUnitOfWork _db;
        protected readonly IGenericRepository<TEntity> _repo;

        public GenericService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _db = unitOfWork;
            mp = mapper;
            _repo = unitOfWork.Set<TEntity>();
        }

        public virtual void Create(TEntityDTO itemDTO)
        {
            if (itemDTO == null)
            {
                return;
            }

            TEntity item = mp.Map<TEntity>(itemDTO);

            _repo.Create(item);
            _db.Save();
        }

        public virtual void Delete(int id)
        {
            _repo.Delete(id);
            _db.Save();
        }

        public virtual IEnumerable<TEntityDTO> GetAll()
        {
            IEnumerable<TEntity> items = _repo.Get();

            return mp.Map<IEnumerable<TEntityDTO>>(items);
        }

        public virtual TEntityDTO GetById(int id)
        {
            TEntity item = _repo.GetById(id);

            return mp.Map<TEntityDTO>(item);
        }

        public virtual void Update(TEntityDTO itemToUpdateDTO)
        {
            if (itemToUpdateDTO == null)
            {
                return;
            }

            TEntity itemToUpdate = mp.Map<TEntity>(itemToUpdateDTO);

            _repo.Update(itemToUpdate);
            _db.Save();
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public IEnumerable<TEntityDTO> findAllWithFilter(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            IEnumerable<TEntity> items = _repo.Get(filter, orderBy);

            return mp.Map<IEnumerable<TEntityDTO>>(items);
        }
    }
}
