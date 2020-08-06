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
        public async Task<IActionResult> Login(string userName, string pass)
        {
            
            try
            {
                IActionResult respone = Unauthorized();

                var user = await _loginRepo.GetUserByDetails(userName, pass);
                if (user != null)
                {
                    var tokenStr = GenerateJSONWebToken(user);
                    user.Token = tokenStr;
                    //token = tokenStr;
                    respone = Ok(user);

                }
                return respone;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Login AuthenticateUser(Login login)
        {
            if (ModelState.IsValid)
            {
                Login user = null;
                //for demo using static data
                if (login.Name == "kavya" && login.Password == "123")
                {
                    user = new Login { Name = "kavya", Password = "123", Email = "k@k.com" };

                }
                return user;
            }
            return null;
        }

        private string GenerateJSONWebToken(Login user)
        {
            if (ModelState.IsValid)
            {
                try
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
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return null;
        }


        

        [Authorize]
        [HttpPost("UpdateLogin")]
        public async Task<IActionResult> UpdateLogin([FromBody] Login loginDetails)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _loginRepo.UpdateUser(loginDetails);

                    return Ok();
                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName == "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                       return NotFound();
                    }

                    return BadRequest();
                }


            }
            return BadRequest();

        }

        [HttpPost]
        [Route("AddLogin")]
        public async Task<IActionResult> AddPost([FromBody] Login model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var loginId = await _loginRepo.AddUserDetails(model);
                    if (loginId > 0)
                    {
                        return Ok(loginId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {

                    return BadRequest();
                }

            }

            return BadRequest();
        }



        #region "test purpose"
        [Authorize]  // app.UseAuthorize in startup.cs -> Configure
        [HttpGet("Get")]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        //to send token through postman for headers : Authorization => Bearer<token>

        [Authorize]
        [HttpPost("Post")]
        public string post()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            IList<Claim> claim = identity.Claims.ToList();
            var username = claim[0].Value;
            return "welcome : " + username;

        }
        #endregion
    }
}