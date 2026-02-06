using EnterpriseSystem.Module.Identity.Domain.Interfaces;
using EnterpriseSystem.Module.Identity.Infraestructure.Persistence;
using EnterpriseSystem.Module.Identity.Infraestructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EnterpriseSystem.Module.Identity.Application
{
    public static class IdentityModule
    {
        public static IServiceCollection AddIdentityModule(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<IdentityDbContext>(options => options.UseNpgsql(connectionString));

            services.AddScoped<IUserRepository, UserRepository>();


            return services;
        }
    }
}
