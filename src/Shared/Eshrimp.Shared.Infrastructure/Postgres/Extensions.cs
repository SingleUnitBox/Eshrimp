using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Eshrimp.Shared.Infrastructure.Postgres
{
    internal static class Extensions
    {
        public const string PostgresSection = "postgres";

        public static IServiceCollection AddPostgres(this IServiceCollection services)
        {
            var options = services.GetOptions<PostgresOptions>(PostgresSection);
            services.AddSingleton(options);
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            return services;
        }

        public static IServiceCollection AddPostgres<TDbContext>(this IServiceCollection services)
            where TDbContext : DbContext
        {
            var postgresOptions = services.GetOptions<PostgresOptions>(PostgresSection);
            services.AddDbContext<TDbContext>(options =>
            {
                options.UseNpgsql(postgresOptions.ConnectionString);
            });

            return services;
        }

        public static TOptions GetOptions<TOptions>(this IConfiguration configuration, string sectionName)
            where TOptions : class, new()
        {
            var options = new TOptions();
            var section = configuration.GetSection(sectionName);
            if (section is not null)
            {
                section.Bind(options);
            }

            return options;
        }

        public static TOptions GetOptions<TOptions>(this IServiceCollection services, string sectionName)
            where TOptions : class, new()
        {
            using var serviceProvider = services.BuildServiceProvider();
            {
                var configuration = serviceProvider.GetRequiredService<IConfiguration>();
                var options = configuration.GetOptions<TOptions>(sectionName);

                return options;
            }
        }
    }
}
