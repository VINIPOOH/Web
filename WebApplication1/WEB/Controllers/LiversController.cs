using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.dto;
using BLL.Intarfaces;
using DAL.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WEB.Models;


namespace WEB.Controllers
{
    public class LiversController : Controller
    {
        
        private readonly IGenericService<UserDto, User> service;
        private readonly IMapper mapper;

        public LiversController(IMapper mapper, IGenericService<UserDto, User> service)
        {
            this.service = service;
            this.mapper = mapper;
        }


        [HttpGet]
        public IActionResult Livers()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Livers(LiversPageModel model )
        {
            string toReturn = "";
            IEnumerable < UserDto > result = null;
            if (model.FIO!=null)
            {
                result= service.findAllWithFilter(user => user.FIO.Equals(model.FIO));
                if (result.Any())
                {
                    return ActionResult(result, toReturn);
                }
            }

            if (model.AmountFalts>=0)
            {
                result= service.findAllWithFilter(user => user.UserApartments.Count==model.AmountFalts);
                if (result.Any())
                {
                    return ActionResult(result, toReturn);
                }
            }
            if (model.BornDate!=null)
            {
                result= service.findAllWithFilter(user => user.BornDate==model.BornDate);
                if (result.Any())
                {
                    return ActionResult(result, toReturn);
                }
            }

            return ActionResult(result, toReturn);
        }

        private IActionResult ActionResult(IEnumerable<UserDto> result, string toReturn)
        {
            foreach (var cityDto in result)
            {
                toReturn += cityDto.ToString();
            }

            ViewData["CityWhichUserLooking"] = toReturn;
            return View();
        }
    }
}