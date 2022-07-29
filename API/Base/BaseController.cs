using API.Context;
using API.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<TModel, TRepository> : ControllerBase
        where TModel : class
        where TRepository : IGeneralRepository<TModel>
    {
        TRepository repository;

        public BaseController(TRepository repository)
        {
            this.repository = repository;
        }

        // Get List of Data
        /*[HttpGet]
        public ActionResult<List<TModel>> Get()
        {
            var result = repository.Get();
            if (result != null)
                return Ok(new
                {
                    status = 200,
                    message = "SUCCESS",
                    data = result
                });
            return NotFound(new
            {
                status = 404,
                message = "NOT FOUND"
            });
        }*/

        // Get By an Id Returning Model
        [HttpGet("{id}")]
        public virtual ActionResult<TModel> Get(int id)
        {
            var result = repository.Get(id);
            if (result != null)
                return Ok(new
                {
                    status = 200,
                    message = "SUCCESS",
                    data = result
                });
            return NotFound(new
            {
                status = 404,
                message = "NOT FOUND"
            });
        }

        // Post Method
        [HttpPost]
        public ActionResult<int> Post(TModel model)
        {
            var data = repository.Post(model);
            if (data > 0)
                return Ok(new
                {
                    status = 201,
                    message = "CREATED"
                });
            return BadRequest(new
            {
                status = 400,
                message = "BAD REQUEST"
            });
        }

        // Put Method
        [HttpPut]
        public ActionResult<int> Put(TModel model)
        {
            var data = repository.Put(model);
            if (data > 0)
                return Ok(new
                {
                    status = 200,
                    message = "UPDATED"
                });
            return BadRequest(new
            {
                status = 400,
                message = "BAD REQUEST"
            });
        }

        // Delete Method
        [HttpDelete]
        public ActionResult<int> Delete(TModel model)
        {
            var data = repository.Delete(model);
            if (data > 0)
                return Ok(new
                {
                    status = 200,
                    message = "DELETED"
                });
            return BadRequest(new
            {
                status = 400,
                message = "BAD REQUEST"
            });
        }
    }
}