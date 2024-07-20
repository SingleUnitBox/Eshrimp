using Microsoft.Extensions.DependencyInjection;

namespace Eshrimp.Modules.Tanks.Api
{
    public static class Extensions
    {
        public static IServiceCollection AddTanks(this IServiceCollection services)
        {
            return services;
        }
    }
}
