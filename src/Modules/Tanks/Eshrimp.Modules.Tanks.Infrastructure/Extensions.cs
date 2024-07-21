using Eshrimp.Modules.Tanks.Infrastructure.Exceptions;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Eshrimp.Modules.Tanks.Api")]
namespace Eshrimp.Modules.Tanks.Infrastructure
{
    internal static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddErrorHandling();

            return services;
        }
    }
}
