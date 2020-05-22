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
    public class LiversAddController : Controller
    {
        
        private readonly IGenericService<UserDto, User> service;
        private readonly IGenericService<ApartmentDto, Apartment> serviceAps;
        private readonly IGenericService<UserAppartmenDto, UserApartment> serviceUserAps;

        private readonly IMapper mapper;
        private int minMetersOnLiver=9;

        public LiversAddController(IGenericService<UserDto, User> service, IGenericService<ApartmentDto, Apartment> serviceAps, IGenericService<UserAppartmenDto, UserApartment> serviceUserAps, IMapper mapper)
        {
            this.service = service;
            this.serviceAps = serviceAps;
            this.serviceUserAps = serviceUserAps;
            this.mapper = mapper;
        }


        [HttpGet]
        public IActionResult LiversAdd()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LiversAdd(AddUserToFlateModel model )
        {
            string toReturn = "";
            IEnumerable<ApartmentDto> app = serviceAps.findAllWithFilter(apartment => apartment.ApartmentId == model.FlatId);
            
            int a= app.Count();
            ApartmentDto appp = app.First();
            IEnumerable < UserAppartmenDto > result = serviceUserAps.findAllWithFilter(apartment => apartment.ApartmentId==model.FlatId );

            if (appp.ApartmentSpace/(result.Count()+1)> minMetersOnLiver )
            {
                UserAppartmenDto toSave = new UserAppartmenDto();
                toSave.ApartmentId = model.FlatId;
                toSave.UserId = model.UserID;
                serviceUserAps.Create(toSave);
                toReturn = "saved";
                ViewData["CityWhichUserLooking"] = toReturn;
                return View();
            }

            toReturn = "notEnogfPlace";

            ViewData["CityWhichUserLooking"] = toReturn;
            return View();
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