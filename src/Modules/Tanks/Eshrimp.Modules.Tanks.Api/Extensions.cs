using Eshrimp.Modules.Tanks.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Eshrimp.Modules.Tanks.Api
{
    public static class Extensions
    {
        public static IServiceCollection AddTanks(this IServiceCollection services)
        {
            services.AddInfrastructure();

            return services;
        }
    }
}
