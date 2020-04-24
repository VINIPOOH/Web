﻿using System.Collections.Generic;
using System.Linq;
using ComputerNet.DAL.Repositories;
 using WebApplication1.Dal;
 using WebApplication1.Dto;

namespace BLL.Servise
{
    public class ApartmentServise :GenericServise<Apartment>
    {
        Apartment GetById(int id)
        {
            return base.UnitOfWork.apartments.Get(a=>a.ApartmentId==id).FirstOrDefault();
        }
    }
}