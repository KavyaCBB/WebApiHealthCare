using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiHealthCare.Repository;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiHealthCare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LabTestController : ControllerBase
    {

        private string token;
        //private IConfiguration _config;
        private readonly ILabTestRepo _testsRepo;
        public LabTestController(ILabTestRepo testResultsRepo)
        {

            _testsRepo = testResultsRepo;
        }

        


        [HttpGet]
        public async Task<IActionResult> GetAllTests()
        {

            try
            {
                IActionResult respone = Unauthorized();

                var test = await _testsRepo.GetAllTests();
                if (test != null)
                {
                    respone = Ok(test);
                }
                return respone;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
