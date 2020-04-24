using System.Linq;
using WebApplication1.Dto;

namespace BLL.Servise
{
    public class UserServise: GenericServise<User>
    {
        User GetById(int id)
        {
            return base.UnitOfWork.users.Get(a=>a.UserId==id).FirstOrDefault();
        }
        
    }
}