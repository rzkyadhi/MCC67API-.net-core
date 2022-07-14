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
        [HttpPost]
        public ActionResult Login(User user)
        {
            var result = accountRepository.Post(user.Email, user.Password);
            /*var roles = new List<string>();
            foreach (var role in result.Role)
            {
                roles.Add(role.Name);
            }
            var jwt = new JwtService(config);
            var token = jwt.GenerateSecurityToken(result.Email, roles.ToString());

            return Ok(new
            {
                status = 200,
                message = "Account Validated",
                data = result,
                token = token,
            });*/

            // cara pintas
            var claims = new List<Claim>();

            if (result != null)
            {
                claims.Add(new Claim("Email", result.Email));
                foreach (var item in result.Role)
                {
                    claims.Add(new Claim("roles", item.Name));
                }
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JwtConfig:secret"]));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
                var token = new
                    JwtSecurityToken(
                    config["JwtConfig:Issuer"],
                    config["JwtConfig:Audience"],
                    claims,
                    expires: DateTime.UtcNow.AddMinutes(60),
                    signingCredentials: signIn
                    );
                var idToken = new JwtSecurityTokenHandler().WriteToken(token);

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
