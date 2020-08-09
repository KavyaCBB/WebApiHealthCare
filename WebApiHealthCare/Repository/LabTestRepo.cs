using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApiHealthCare.Data;

namespace WebApiHealthCare.Repository
{
    public class LabTestRepo : ILabTestRepo
    {
        private readonly HealthCareDbContext _healthCareDbContext;
        public LabTestRepo(HealthCareDbContext healthCareDbContext)
        {
            _healthCareDbContext = healthCareDbContext;
        }

        public async Task<int> AddTest(LabTests tests)
        {
            try
            {
                if (_healthCareDbContext != null)
                {
                    await _healthCareDbContext.LabTests.AddAsync(tests);
                    await _healthCareDbContext.SaveChangesAsync();

                    return tests.TestId;
                }

                return -1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<LabTests>> GetAllTests()
        {
            if (_healthCareDbContext != null)
            {
                return await _healthCareDbContext.LabTests.ToListAsync();
            }

            return null;
        }


        

    }
}
