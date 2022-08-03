using API.Base;
using API.Context;
using API.Models;
using API.Repositories.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "Manager")]
    [ApiController]
    public class ProductController : BaseController<Product, ProductRepository>
    {
        ProductRepository repository;

        public ProductController(ProductRepository repository) : base(repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Get All Product List.
        /// </summary>
        /// <returns>A list of product</returns>
        /// <response code="200">Returns the list of product</response>
        /// <response code="400">If the product is null</response>
        [HttpGet]
        public ActionResult<List<Product>> Get()
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
        }
    }
}
