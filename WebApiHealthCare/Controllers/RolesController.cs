using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebApiHealthCare.Data;
using WebApiHealthCare.Repository;

namespace WebApiHealthCare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private string token;
        private IConfiguration _config;
        private readonly IRolesRepo _rolesRepo;
        public RolesController( IRolesRepo rolesRepo)
        {
        
            _rolesRepo = rolesRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRoles()
        {

            try
            {
                IActionResult respone = Unauthorized();

                var roles = await _rolesRepo.GetAllRoles();
                if (roles != null)
                {
                    respone = Ok(roles);
                }
                return respone;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        //[Authorize]
        [HttpPost("UpdateRoles")]
        public async Task<IActionResult> UpdateLogin([FromBody] Roles rolesDetails)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _rolesRepo.UpdateRoles(rolesDetails);

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
        [Route("AddRoles")]
        public async Task<IActionResult> AddRoles([FromBody] Roles model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var roleId = await _rolesRepo.AddRoles(model);
                    if (roleId > 0)
                    {
                        return Ok(roleId);
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

    }
}