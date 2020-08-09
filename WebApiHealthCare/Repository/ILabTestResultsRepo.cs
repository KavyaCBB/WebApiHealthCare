using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiHealthCare.Data;

namespace WebApiHealthCare.Repository
{
    public interface ILabTestResultsRepo
    {
        Task<int> AddTestResults(LabTestResults testResults);
        Task<List<LabTestResults>> GetAllTestResults();
    }
}
