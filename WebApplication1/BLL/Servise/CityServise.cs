using System.Collections.Generic;
using System.Linq;
using ComputerNet.DAL.Repositories;
using WebApplication1.Dto;

namespace BLL.Servise
{
    public class CityServise : GenericServise<City>
    {
        City GetById(int id)
        {
            return base.UnitOfWork.cites.Get(a=>a.Id==id).FirstOrDefault();
        }
    }
}