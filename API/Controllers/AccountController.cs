using API.Models;
using API.Repositories.Data;
using API.Services;
using API.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        AccountRepository accountRepository;
        private IConfiguration config;

        public AccountController(AccountRepository accountRepository, IConfiguration config)
        {
            this.accountRepository = accountRepository;
            this.config = config;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public ActionResult Login(User user)
        {
            var result = accountRepository.Post(user.Email, user.Password);
            var token = new JwtService(config);

            if (result != null)
            {
                var idToken = token.GenerateSecurityToken(result);

                return Ok(new
                {
                    status = 200,
                    message = "Account Validated",
                    data = result,
                    token = idToken,
                });
            }
            return BadRequest(new { status = 400, message = "Invalid Credentials" });

        }
    }
}
