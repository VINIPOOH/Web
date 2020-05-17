using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BLL.Intarfaces
{
    public interface IGenericService<TEntityDTO, TEntity> : IDisposable
    {
        void Create(TEntityDTO item);
        TEntityDTO GetById(int id);
        IEnumerable<TEntityDTO> GetAll();
        void Update(TEntityDTO itemToUpdate);
        void Delete(int id);

        IEnumerable<TEntityDTO> findAllWithFilter(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);
    }
}
