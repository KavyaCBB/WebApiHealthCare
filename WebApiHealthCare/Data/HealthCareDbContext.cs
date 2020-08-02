using System;
using Microsoft.EntityFrameworkCore;

namespace WebApiHealthCare.Data
{
    public class HealthCareDbContext: DbContext
    {
        public HealthCareDbContext(DbContextOptions options):base(options)
        {
        }

        public DbSet<Login> Login { get; set; }
    }
}
