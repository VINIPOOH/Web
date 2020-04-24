using System.Linq;
using WebApplication1.Dto;

namespace BLL.Servise
{
    public class HouseServise : GenericServise<House>
    {
        House GetById(int id)
        {
            return base.UnitOfWork.houses.Get(a=>a.Id==id).FirstOrDefault();
        }
    }
}