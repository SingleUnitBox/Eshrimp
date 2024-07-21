using Eshrimp.Modules.Tanks.Infrastructure.EF;
using Eshrimp.Modules.Tanks.Infrastructure.Exceptions;
using Eshrimp.Shared.Infrastructure.Postgres;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Eshrimp.Modules.Tanks.Api")]
namespace Eshrimp.Modules.Tanks.Infrastructure
{
    internal static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddErrorHandling();
            services.AddPostgres<TanksDbContext>(configuration);

            return services;
        }
    }
}
