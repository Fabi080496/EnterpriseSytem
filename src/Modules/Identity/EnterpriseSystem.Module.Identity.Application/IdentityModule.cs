using Microsoft.Extensions.DependencyInjection;

namespace EnterpriseSystem.Module.Identity.Application
{
    public static class IdentityModule
    {
        public static IServiceCollection AddOrdersModule(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<OrdersDbContext>(options =>
                options.UseNpgsql(connectionString));

            services.AddMediatR(typeof(IdentityModule).Assembly);

            return services;
        }
    }
}
