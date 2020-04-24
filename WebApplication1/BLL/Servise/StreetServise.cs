using System.Linq;
using WebApplication1.Dto;

namespace BLL.Servise
{
    public class StreetServise: GenericServise<Street>
    {
        Street GetById(int id)
        {
            return base.UnitOfWork.streets.Get(a=>a.Id==id).FirstOrDefault();
        }
    }
}