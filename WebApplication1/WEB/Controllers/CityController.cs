using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.dto;
using BLL.Intarfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WEB.Models;


namespace WEB.Controllers
{
    public class CityController : Controller
    {
        
        private readonly IGenericService<CityDto> service;
        private readonly IMapper mapper;

        public CityController(IMapper mapper, IGenericService<CityDto> service)
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
            IEnumerable<CityDto> cityDtos = service.GetAll();
            foreach (var city in service.GetAll())
            {
                if (city.Name.Equals(model.SityName))
                {
                    ViewData["CityWhichUserLooking"] = city.ToString();
                    return View();
                }
            }
            return View();            
        }
    }
}