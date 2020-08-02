using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using WebApiHealthCare.Data;
using WebApiHealthCare.Repository;

namespace WebApiHealthCare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private string token;
        private IConfiguration _config;
        private readonly ILoginRepo _loginRepo;
        public LoginController(IConfiguration config, ILoginRepo loginRepo)
        {
            _config = config;
            _loginRepo = loginRepo;
        }
        [HttpGet]
        public  IActionResult Login(string userName, string pass)
        {

            //UserModel login = new UserModel();
            //login.UserName = userName;
            //login.Password = pass;
            // var user = AuthenticateUser(login);
            IActionResult respone = Unauthorized();

            var user =  _loginRepo.GetUserByDetails(userName, pass);
            if (user != null)
            {
                var tokenStr = GenerateJSONWebToken(user);
                token = tokenStr;
                respone = Ok(new { token = tokenStr });

            }
            return respone;
        }

        private Login AuthenticateUser(Login login)
        {
            Login user = null;
            //for demo using static data
            if (login.Name == "kavya" && login.Password == "123")
            {
                user = new Login { Name = "kavya", Password = "123", Email = "k@k.com" };

            }
            return user;

        }

        private string GenerateJSONWebToken(Login user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:key"]));  //
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {

                new Claim(ClaimTypes.Name, user.Name),
                 new Claim(ClaimTypes.Email, user.Email),
                new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())

            };

            var token = new JwtSecurityToken(issuer: _config["Jwt:Issuer"],
              audience: _config["Jwt:Issuer"],
              claims: claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);


        }


        //tosend token through postman for headers : Authorization => Bearer<token>

        [Authorize]
        [HttpPost("Post")]
        public string post()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            IList<Claim> claim = identity.Claims.ToList();
            var username = claim[0].Value;
            return "welcome : " + username;

        }

        [Authorize]
        [HttpGet("Get")]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

    }
}