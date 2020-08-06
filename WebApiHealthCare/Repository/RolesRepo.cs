using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApiHealthCare.Data;

namespace WebApiHealthCare.Repository
{
    public class RolesRepo: IRolesRepo
    {
        private readonly HealthCareDbContext _healthCareDbContext;
        public RolesRepo(HealthCareDbContext healthCareDbContext)
        {
            _healthCareDbContext = healthCareDbContext;
        }

        public async Task<int> AddRoles(Roles role)
        {
            try
            {
                        if (_healthCareDbContext != null)
                    {
                        await _healthCareDbContext.Roles.AddAsync(role);
                        await _healthCareDbContext.SaveChangesAsync();

                        return role.RoleId;
                    }

            return -1;
             }
            catch(Exception ex)
            {
                throw ex;
                }
        }

        public async Task<List<Roles>> GetAllRoles()
        {
            if (_healthCareDbContext != null)
            {
                return await _healthCareDbContext.Roles.ToListAsync();
            }

            return null;
        }
        public async Task<int> UpdateRoles(Roles role)
        {
            if (_healthCareDbContext != null)
            {
                _healthCareDbContext.Roles.Update(role);
                return  await _healthCareDbContext.SaveChangesAsync(); 
            }
            return -1;
        }

        

    }
}
