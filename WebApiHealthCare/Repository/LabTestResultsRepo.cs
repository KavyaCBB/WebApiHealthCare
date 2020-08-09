using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApiHealthCare.Data;

namespace WebApiHealthCare.Repository
{
    public class LabTestResultsRepo: ILabTestResultsRepo
    {
        private readonly HealthCareDbContext _healthCareDbContext;
        public LabTestResultsRepo(HealthCareDbContext healthCareDbContext)
        {
            _healthCareDbContext = healthCareDbContext;
        }


        public async Task<int> AddTestResults(LabTestResults testResults)
        {
            try
            {
                if (_healthCareDbContext != null)
                {
                    await _healthCareDbContext.LabTestResults.AddAsync(testResults);
                    await _healthCareDbContext.SaveChangesAsync();

                    return testResults.TestResultsId;
                }

                return -1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<LabTestResults>> GetAllTestResults()
        {
            if (_healthCareDbContext != null)
            {
                return await _healthCareDbContext.LabTestResults.ToListAsync();
            }

            return null;
        }

    }
}
