using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System;
using Pointers_CMS.Repository.A_Repository;
using Pointers_CMS.Models;

namespace Pointers_CMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginRepository _loginRepository;
        private readonly IConfiguration _config;

        //Construction injection
        public LoginController(ILoginRepository loginRepository, IConfiguration config)
        {
            _loginRepository = loginRepository;
            _config = config;

        }

        //Get a User

        private LoginUsers AuthenticateUser(string username, string password)
        {
            LoginUsers user = _loginRepository.validateUser(username, password);

            if (user != null)
            {
                return user;
            }
            return null;
        }

        //Generate Json web token
        private string GenerateJSONWebToken(LoginUsers user)
        {
            //security key
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            //Generate Token
            var token = new JwtSecurityToken(_config["Jwt:Issuer"], null, expires: DateTime.Now.AddMinutes(20), signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpGet("{username}/{password}")]
        public IActionResult userLogin(string username, string password)
        {
            IActionResult response = Unauthorized();

            //Authenticate the user by passing username, password
            LoginUsers dbLogin = AuthenticateUser(username, password);

            if (dbLogin != null)
            {
                var tokenString = GenerateJSONWebToken(dbLogin);
                response = Ok(new
                {
                    userName = dbLogin.UserName,
                    userPassword = dbLogin.Password,
                    rId = dbLogin.RoleId,
                    token = tokenString
                });
            }
            return response;
        }

    }
}
