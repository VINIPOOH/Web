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
    public class StreetController : ControllerBase
    {
        private readonly IGenericService<StreetDto> service;
        private readonly IMapper mapper;

        public StreetController(IMapper mapper, IGenericService<StreetDto> service)
        {
            this.service = service;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route ("api/street")]
        public virtual IEnumerable<StreetModel> GetItems()
        {
            IEnumerable<StreetDto> dto = service.GetAll();
            IEnumerable<StreetModel> model = mapper.Map<IEnumerable<StreetModel>>(dto);
            return model;
        }

        [HttpPost]
        [Route("api/street_id")]
        public virtual IActionResult GetItem([FromBody] int id)
        {
            StreetDto dto = service.GetById(id);

            if (dto == null)
            {
                return BadRequest();
            }

            StreetModel model = mapper.Map<StreetModel>(dto);
            return Ok(model);
        }

        [HttpPost]
        [Route("api/street")]
        public IActionResult CreateItem([FromBody]StreetModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            StreetDto dto = mapper.Map<StreetDto>(model);

            service.Create(dto);

            return Ok();
        }

        [HttpPut]
        [Route("api/street")]
        public virtual IActionResult UpdateItem([FromBody]StreetModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            StreetDto dto = mapper.Map<StreetDto>(model);

            service.Update(dto);

            return Ok();
        }

        [HttpDelete]
        [Route("api/street")]
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