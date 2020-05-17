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
    public class CityController : Controller
    {
        
        private readonly IGenericService<CityDto, City> service;
        private readonly IMapper mapper;

        public CityController(IMapper mapper, IGenericService<CityDto, City> service)
        {
            this.service = service;
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
            }

            if (model.AmountLivers>=0)
            {
                int amountsLiversWhicIsInCity;
                result= service.findAllWithFilter(city => city.Streets.Count==model.AmountLivers);
            }

            foreach (var cityDto in result)
            {
                toReturn += cityDto.ToString();
            }
            ViewData["CityWhichUserLooking"] = toReturn;
            return View();            
        }
    }
}