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
    public class ApartmensController : ControllerBase
    {
        private readonly IGenericService<ApartmentDto> service;
        private readonly IMapper mapper;

        public ApartmensController(IMapper mapper, IGenericService<ApartmentDto> service)
        {
            this.service = service;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("api/apartment")]
        public virtual IEnumerable<ApartmentModel> GetItems()
        {
            IEnumerable<ApartmentDto> dto = service.GetAll();
            IEnumerable<ApartmentModel> model = mapper.Map<IEnumerable<ApartmentModel>>(dto);
            return model;
        }

        [HttpPost]
        [Route("api/apartment_id")]
        public virtual IActionResult GetItem([FromBody] int id)
        {
            ApartmentDto dto = service.GetById(id);

            if (dto == null)
            {
                return BadRequest();
            }

            ApartmentModel model = mapper.Map<ApartmentModel>(dto);
            return Ok(model);
        }

        [HttpPost]
        [Route("api/apartment")]
        public IActionResult CreateItem([FromBody]ApartmentModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ApartmentDto dto = mapper.Map<ApartmentDto>(model);

            service.Create(dto);

            return Ok();
        }

        [HttpPut]
        [Route("api/apartment")]
        public virtual IActionResult UpdateItem([FromBody]ApartmentModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ApartmentDto dto = mapper.Map<ApartmentDto>(model);

            service.Update(dto);

            return Ok();
        }

        [HttpDelete]
        [Route("api/apartment")]
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