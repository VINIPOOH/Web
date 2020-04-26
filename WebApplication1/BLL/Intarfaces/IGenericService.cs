using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Intarfaces
{
    public interface IGenericService<TEntityDTO> : IDisposable
    {
        void Create(TEntityDTO item);
        TEntityDTO GetById(int id);
        IEnumerable<TEntityDTO> GetAll();
        void Update(TEntityDTO itemToUpdate);
        void Delete(int id);
    }
}
