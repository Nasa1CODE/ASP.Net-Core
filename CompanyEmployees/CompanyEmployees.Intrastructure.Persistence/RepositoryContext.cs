using CompanyEmployees.Core.Domain.Entities;
using CompanyEmployees.Intrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace CompanyEmployees.Intrastructure.Persistence
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
        }

        public DbSet<Company>? Companies { get; set; }
        public DbSet<Company>? Employees { get; set; }
    }
}
