using Eshrimp.Modules.Tanks.Domain.Repositories;
using Eshrimp.Modules.Tanks.Infrastructure.EF.Repositories;
using Eshrimp.Shared.Infrastructure.Postgres;
using Microsoft.Extensions.DependencyInjection;

namespace Eshrimp.Modules.Tanks.Infrastructure.EF
{
    internal static class Extensions
    {
        public static IServiceCollection AddTanksPostgres(this IServiceCollection services)
        {
            services.AddPostgres<TanksDbContext>();
            services.AddScoped<IShrimpRepository, PostgresShrimpRepository>();
            services.AddScoped<ITankRepository, PostgresTankRepository>();

            return services;
        }
    }
}
