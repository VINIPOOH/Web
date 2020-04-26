using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.model;
using AutoMapper;
using BLL.dto;
using BLL.Intarfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CitiesController : ControllerBase
    {
        private readonly IGenericService<CityDto> service;
        private readonly IMapper mapper;

        public CitiesController(IMapper mapper, IGenericService<CityDto> service)
        {
            this.service = service;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route ("api/city")]
        public virtual IEnumerable<CityModel> GetItems()
        {
            IEnumerable<CityDto> dto = service.GetAll();
            IEnumerable<CityModel> model = mapper.Map<IEnumerable<CityModel>>(dto);
            return model;
        }

        [HttpPost]
        [Route("api/city_id")]
        public virtual IActionResult GetItem([FromBody] int id)
        {
            CityDto dto = service.GetById(id);

            if (dto == null)
            {
                return BadRequest();
            }

            CityModel model = mapper.Map<CityModel>(dto);
            return Ok(model);
        }

        [HttpPost]
        [Route("api/city")]
        public IActionResult CreateItem([FromBody]CityModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            CityDto dto = mapper.Map<CityDto>(model);

            service.Create(dto);

            return Ok();
        }

        [HttpPut]
        [Route("api/city")]
        public virtual IActionResult UpdateItem([FromBody]CityModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            CityDto dto = mapper.Map<CityDto>(model);

            service.Update(dto);

            return Ok();
        }

        [HttpDelete]
        [Route("api/city")]
        public virtual IActionResult DeleteItem([FromBody] int id)
        {
            if (service.GetById(id) == null)
            {
                return BadRequest();
            }

            service.Delete(id);

            return Ok();
        }
    }
}