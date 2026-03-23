using EnterpriseSystem.Module.Organization.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseSystem.Module.Organization.Infrastructure.Persistence
{
    public class CompanyDbContext : DbContext
    {
        public CompanyDbContext(DbContextOptions<CompanyDbContext> options)
            : base(options) { }

        public DbSet<Company> Companies => Set<Company>();
        public DbSet<User> Users => Set<User>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("user");
            modelBuilder.Entity<Company>().ToTable("company");

            modelBuilder.HasDefaultSchema("organization");

            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(CompanyDbContext).Assembly);
        }



    }
}