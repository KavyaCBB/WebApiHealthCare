using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiHealthCare.Data;

namespace WebApiHealthCare.Repository
{
    public interface IRolesRepo
    {
        Task<int> AddRoles(Roles role);
        Task<List<Roles>> GetAllRoles();
        Task<int> UpdateRoles(Roles role);
    }
}
