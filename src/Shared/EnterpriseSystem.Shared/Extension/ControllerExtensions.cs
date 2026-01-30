using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace EnterpriseSystem.Shared.Extension
{
    public static class ControllerExtensions
    {
        public static IServiceCollection AddControllersWithAssemblies(
            this IServiceCollection services,
            params Assembly[] assemblies)
        {
            var mvcBuilder = services.AddControllers();

            foreach (var assembly in assemblies)
            {
                mvcBuilder.AddApplicationPart(assembly);
            }

            return services;
        }
    }
}
