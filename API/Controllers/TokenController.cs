using API.Models;
using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private IConfiguration config;
        private User user;

        public TokenController(IConfiguration config, User user)
        {
            this.config = config;
            this.user = user;
        }

        [HttpGet]
        public string GetRandomToken(string email = "rizky.nugroho@mii.co.id")
        {
            var jwt = new JwtService(config);
            var token = jwt.GenerateSecurityToken(email); ;
            return token;
        }
    }
}
