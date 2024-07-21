using Eshrimp.Modules.Tanks.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Eshrimp.Modules.Tanks.Api
{
    public static class Extensions
    {
        public static IServiceCollection AddTanks(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddInfrastructure(configuration);

            return services;
        }
    }
}
