using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private IConfiguration config;

        public TokenController(IConfiguration config)
        {
            this.config = config;
        }

        [HttpGet]
        public string GetRandomToken()
        {
            var jwt = new JwtService(config);
            var token = jwt.GenerateSecurityToken("rizky@gmail.com");
            return token;
        }
    }
}
