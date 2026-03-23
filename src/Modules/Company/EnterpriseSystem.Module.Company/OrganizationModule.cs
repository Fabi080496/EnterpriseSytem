using EnterpriseSystem.Module.Organization.Domain.Interfaces;
using EnterpriseSystem.Module.Organization.Domain.Interfaces.Security;
using EnterpriseSystem.Module.Organization.Infraestructure.Jwt;
using EnterpriseSystem.Module.Organization.Infraestructure.Persistence.Repository;
using EnterpriseSystem.Module.Organization.Infraestructure.Security;
using EnterpriseSystem.Module.Organization.Infrastructure.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EnterpriseSystem.Module.Organization
{
    public static class OrganizationModule
    {
        public static IServiceCollection AddOrganizationModule(this IServiceCollection services, IConfiguration configuration)
        {

            // Add services to the container.

            // 1. Api Endpoint services


            // 2. Application Use Case services

            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();


            // 3. Data - Infrastructure services

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<CompanyDbContext>(options =>
                options.UseNpgsql(connectionString));


            services.AddScoped<IUserRepository, UserRepository>();

            return services;

        }

        public static IApplicationBuilder UseOrganizationModule (this IApplicationBuilder app)
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
