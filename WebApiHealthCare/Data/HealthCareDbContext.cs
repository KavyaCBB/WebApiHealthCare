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
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Staffs> Staffs { get; set; }
        public DbSet<TestResults> TestResults { get; set; }
    }
}
