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

        /// <summary>
        /// Edit an item.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /Product/1
        ///     {
        ///        "id": 1
        ///     }
        ///
        /// </remarks>
        /// <param name="id"></param>
        /// <returns>A newly created TodoItem</returns>
        /// <response code="200">Returns the id of item</response>
        /// <response code="404">If the id item is not found</response>
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

        /// <summary>
        /// Create an item.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Product
        ///     {
        ///        "name": "Item1",
        ///        "supplierId": 1
        ///     }
        ///
        /// </remarks>
        /// <param name="model"></param>
        /// <returns>A newly created TodoItem</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item requested is in bad form, etc.</response>
        // Post Method
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<int> Post(TModel model)
        {
            var data = repository.Post(model);
            if (data > 0)
                return Created(nameof(Get), new
                {
                    status = 201,
                    message = "CREATED",
                });
            return BadRequest(new
            {
                status = 400,
                message = "BAD REQUEST"
            });
        }

        /// <summary>
        /// Edit an item.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /Product
        ///     {
        ///        "id": 1,
        ///        "name": "Product1",
        ///        "supplierId": 1
        ///     }
        ///
        /// </remarks>
        /// <param name="model"></param>
        /// <returns>A newly created TodoItem</returns>
        /// <response code="200">Returns the total of edited item</response>
        /// <response code="400">If the edited item is null</response>
        // Put Method
        [HttpPut]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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

        /// <summary>
        /// Delete an item.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     DELETE /Product
        ///     {
        ///        "id": 1,
        ///        "name": "Product1",
        ///        "supplierId": 1
        ///     }
        ///
        /// </remarks>
        /// <param name="model"></param>
        /// <returns>A newly created TodoItem</returns>
        /// <response code="200">Returns the total of deleted item</response>
        /// <response code="400">If the deleted item is null</response>
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