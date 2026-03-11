using EnterpriseSystem.Module.Identity.Domain.Interfaces;
using EnterpriseSystem.Module.Identity.Infraestructure.Jwt;
using EnterpriseSystem.Module.Identity.Infraestructure.Persistence;
using EnterpriseSystem.Module.Identity.Infraestructure.Persistence.Repository;
using EnterpriseSystem.Module.Identity.Infraestructure.Security;
using EnterpriseSystem.Shared.Security;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EnterpriseSystem.Module.Identity
{
    public static class IdentityModule
    {
        public static IServiceCollection AddIndentityModule( this IServiceCollection services, IConfiguration configuration)
        {
            // Add services to the container.

            // 1. Api Endpoint services


            // 2. Application Use Case services

            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();


            // 3. Data - Infrastructure services

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddScoped<IUserRepository, UserRepository>();

            services.AddDbContext<IdentityDbContext>(options =>
                options.UseNpgsql(connectionString));
            return services;
        }
        
        public static IApplicationBuilder UseIdentityModule(this IApplicationBuilder app)
        {
            // Configure the HTTP request pipeline.

            // 1. Use Api Endpoint services

            // 2. Use Application Use Case services

            // 3. Use Data - Infrastructure services

            //app.UseMigration<BasketDbContext>();

            return app;

        }

    }
}
