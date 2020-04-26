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
    public class UserController : ControllerBase
    {
        private readonly IGenericService<UserDto> service;
        private readonly IMapper mapper;

        public UserController(IMapper mapper, IGenericService<UserDto> service)
        {
            this.service = service;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("api/user")]
        public virtual IEnumerable<UserModel> GetItems()
        {
            IEnumerable<UserDto> dto = service.GetAll();
            IEnumerable<UserModel> model = mapper.Map<IEnumerable<UserModel>>(dto);
            return model;
        }

        [HttpPost]
        [Route("api/user_id")]
        public virtual IActionResult GetItem([FromBody] int id)
        {
            UserDto dto = service.GetById(id);

            if (dto == null)
            {
                return BadRequest();
            }

            UserModel model = mapper.Map<UserModel>(dto);
            return Ok(model);
        }

        [HttpPost]
        [Route("api/user")]
        public IActionResult CreateItem([FromBody]UserModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            UserDto dto = mapper.Map<UserDto>(model);

            service.Create(dto);

            return Ok();
        }

        [HttpPut]
        [Route("api/user")]
        public virtual IActionResult UpdateItem([FromBody]UserModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            UserDto dto = mapper.Map<UserDto>(model);

            service.Update(dto);

            return Ok();
        }

        [HttpDelete]
        [Route("api/user")]
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