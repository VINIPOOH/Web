using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Intarfaces
{
    public interface IMapper<Entity, Dto>
    {
        Dto mapEntityToDto(Entity entity);
        Entity MapDtoToEntity(Dto dto);
    }
}
