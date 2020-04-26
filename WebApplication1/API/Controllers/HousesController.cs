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
    public class HousesController : ControllerBase
    {
        private readonly IGenericService<HouseDto> service;
        private readonly IMapper mapper;

        public HousesController(IMapper mapper, IGenericService<HouseDto> service)
        {
            this.service = service;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("api/house")]
        public virtual IEnumerable<HouseModel> GetItems()
        {
            IEnumerable<HouseDto> dto = service.GetAll();
            IEnumerable<HouseModel> model = mapper.Map<IEnumerable<HouseModel>>(dto);
            return model;
        }

        [HttpPost]
        [Route("api/house_id")]
        public virtual IActionResult GetItem([FromBody] int id)
        {
            HouseDto dto = service.GetById(id);

            if (dto == null)
            {
                return BadRequest();
            }

            HouseModel model = mapper.Map<HouseModel>(dto);
            return Ok(model);
        }

        [HttpPost]
        [Route("api/house")]
        public IActionResult CreateItem([FromBody]HouseModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            HouseDto dto = mapper.Map<HouseDto>(model);

            service.Create(dto);

            return Ok();
        }

        [HttpPut]
        [Route("api/house")]
        public virtual IActionResult UpdateItem([FromBody]HouseModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            HouseDto dto = mapper.Map<HouseDto>(model);

            service.Update(dto);

            return Ok();
        }

        [HttpDelete]
        [Route("api/house")]
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