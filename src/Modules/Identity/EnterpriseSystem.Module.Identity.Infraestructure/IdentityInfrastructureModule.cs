using EnterpriseSystem.Module.Identity.Domain.Interfaces;
using EnterpriseSystem.Module.Identity.Infraestructure.Jwt;
using EnterpriseSystem.Module.Identity.Infraestructure.Persistence;
using EnterpriseSystem.Module.Identity.Infraestructure.Persistence.Repository;
using EnterpriseSystem.Module.Identity.Infraestructure.Security;
using EnterpriseSystem.Shared.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EnterpriseSystem.Module.Identity.Infraestructure
{
    public static class IdentityInfrastructureModule
    {
        public static IServiceCollection AddIdentityInfrastructure( this IServiceCollection services,string connectionString)
        {
            services.AddDbContext<IdentityDbContext>(options =>
                options.UseNpgsql(connectionString));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();

            return services;
        }
    }
}
