using API.Base;
using API.Models;
using API.Repositories.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class SupplierController : BaseController<Supplier, SupplierRepository>
    {
        public SupplierController(SupplierRepository repository) : base(repository)
        {
        }
    }
}
