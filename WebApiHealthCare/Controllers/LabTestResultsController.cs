using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiHealthCare.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiHealthCare.Controllers
{
    [Route("api/[controller]")]
    public class LabTestResultsController : Controller
    {
        private string token;
        //private IConfiguration _config;
        private readonly ILabTestResultsRepo _labtestResultsRepo;
        public LabTestResultsController(ILabTestResultsRepo labtestResultsRepo)
        {

            _labtestResultsRepo = labtestResultsRepo;
        }



        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> GetAllLabTestResults()
        {
            try
            {
                IActionResult respone = Unauthorized();

                var test = await _labtestResultsRepo.GetAllTestResults();
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
