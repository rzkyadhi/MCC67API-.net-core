﻿using API.Base;
using API.Models;
using API.Repositories.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "Staff")]
    [ApiController]
    public class SupplierController : BaseController<Supplier, SupplierRepository>
    {
        SupplierRepository repository;

        public SupplierController(SupplierRepository repository) : base(repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Get All Supplier List.
        /// </summary>
        /// <returns>A list of product</returns>
        /// <response code="200">Returns the list of supplier</response>
        /// <response code="400">If the supplier is null</response>
        [HttpGet]
        public ActionResult<List<Supplier>> Get()
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
