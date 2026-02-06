using EnterpriseSystem.Module.Identity.Domain.Domain;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseSystem.Module.Identity.Infraestructure.Persistence
{
    public class IdentityDbContext : DbContext
    {
        public IdentityDbContext(DbContextOptions<IdentityDbContext> options)
            : base(options) { }

        public DbSet<User> Users => Set<User>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(IdentityDbContext).Assembly);
        }


    }
}
