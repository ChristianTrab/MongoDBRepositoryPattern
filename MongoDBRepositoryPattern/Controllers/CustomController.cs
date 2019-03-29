using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoCore.Dto;
using MongoCore.Entities;
using MongoServices;

namespace MongoDBRepositoryPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomController : ControllerBase
    {
        private ICustomService _customTestService;

        public CustomController(ICustomService customService)
        {
            _customTestService = customService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomEntity>>> Get()
        {
            try
            {
                var entities = await _customTestService.GetAll();
                return Ok(entities);
            }
            catch (Exception e)
            {

                throw e;
            }

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomEntity>> Get(Guid id)
        {
            try
            {
                var entity = await _customTestService.Get(id);
                return Ok(entity);
            }
            catch (Exception e)
            {

                throw e;
            }

        }


        [HttpPost]
        public async Task<ActionResult<CustomEntity>> Post([FromBody] CustomDto value)
        {
            try
            {
                var entity = await _customTestService.Create(value);

                return Ok(entity);
            }
            catch (Exception e)
            {

                throw e;
            }

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CustomEntity>> Put(Guid id, [FromBody] CustomDto value)
        {
            try
            {
                var entity = await _customTestService.Update(id, value);

                return Ok(entity);
            }
            catch (Exception e)
            {

                throw e;
            }

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                var entity = await _customTestService.Delete(id);

                return Ok();
            }
            catch (Exception e)
            {

                throw e;
            }

        }
    }
}