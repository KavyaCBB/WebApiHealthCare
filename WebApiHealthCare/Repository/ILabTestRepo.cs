using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiHealthCare.Data;

namespace WebApiHealthCare.Repository
{
    public interface ILabTestRepo
    {
        Task<int> AddTest(LabTests tests);
        Task<List<LabTests>> GetAllTests();
    }
}
