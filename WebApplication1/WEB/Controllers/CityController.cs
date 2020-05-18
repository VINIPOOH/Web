using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.dto;
using BLL.Intarfaces;
using DAL.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WEB.Models;


namespace WEB.Controllers
{
    [Authorize]
    public class CityController : Controller
    {
        
        private readonly IGenericService<CityDto, City> service;
        private readonly IGenericService<StreetDto, Street> streetServise;
        private readonly IMapper mapper;

        public CityController(IGenericService<CityDto, City> service, IGenericService<StreetDto, Street> streetServise, IMapper mapper)
        {
            this.service = service;
            this.streetServise = streetServise;
            this.mapper = mapper;
        }


        [HttpGet]
        public IActionResult City()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> City(CityPageModel model )
        {
            string toReturn = "";
            IEnumerable < CityDto > result = null;
            if (model.SityName!=null)
            {
                result= service.findAllWithFilter(city => city.Name.Equals(model.SityName));
                return ActionResult(result, toReturn);
            }

            if (model.StreatName!=null)
            {
                ViewData["CityWhichUserLooking"] = service.GetById(streetServise.findAllWithFilter(street => street.Name.Equals(model.StreatName)).First().CityId).ToString();

                return View();  
            }

            if (model.AmountSreets>=0)
            {
                result= service.findAllWithFilter(city => city.Streets.Count==model.AmountSreets);
                return ActionResult(result, toReturn);
            }

            return ActionResult(result, toReturn);
        }

        private IActionResult ActionResult(IEnumerable<CityDto> result, string toReturn)
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