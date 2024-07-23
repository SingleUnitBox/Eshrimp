using Eshrimp.Modules.Tanks.Infrastructure.EF;
using Eshrimp.Modules.Tanks.Infrastructure.Exceptions;
using Eshrimp.Shared.Infrastructure.Postgres;
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
            services.AddTanksPostgres();

            return services;
        }
    }
}
