using Eshrimp.Shared.Abstractions.Modules;
using Eshrimp.Shared.Abstractions.Time;
using Eshrimp.Shared.Infrastructure.Api;
using Eshrimp.Shared.Infrastructure.Commands;
using Eshrimp.Shared.Infrastructure.Exceptions;
using Eshrimp.Shared.Infrastructure.Kernel;
using Eshrimp.Shared.Infrastructure.Postgres;
using Eshrimp.Shared.Infrastructure.Queries;
using Eshrimp.Shared.Infrastructure.Services;
using Eshrimp.Shared.Infrastructure.Time;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Eshrimp.Bootstrapper")]
[assembly: InternalsVisibleTo("Eshrimp.Modules.Tanks.Infrastructure")]
namespace Eshrimp.Shared.Infrastructure
{
    internal static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IList<Assembly> assemblies, IList<IModule> modules)
        {
            var disabledModules = new List<string>();
            using var serviceProvider = services.BuildServiceProvider();
            {
                var configuration = serviceProvider.GetRequiredService<IConfiguration>();
                foreach (var (key, value) in configuration.AsEnumerable())
                {
                    if (!key.Contains(":module:enabled"))
                    {
                        continue;
                    }

                    if (!bool.Parse(value))
                    {
                        disabledModules.Add(key.Split(":")[0]);
                    }
                }
            }

            services.AddControllers()
                .ConfigureApplicationPartManager(manager =>
                {
                    var removedParts = new List<ApplicationPart>();
                    foreach (var disabledModule in disabledModules)
                    {
                        var parts = manager.ApplicationParts.Where(x => x.Name.Contains(disabledModule,
                            StringComparison.InvariantCultureIgnoreCase));
                        removedParts.AddRange(parts);
                    }

                    foreach (var part in removedParts)
                    {
                        manager.ApplicationParts.Remove(part);
                    }

                    manager.FeatureProviders.Add(new InternalControllerFeatureProvider());
                });

            services.AddCommands(assemblies);
            services.AddDomainEvent(assemblies);
            services.AddErrorHandling();
            services.AddPostgres();
            services.AddQueries(assemblies);

            services.AddSingleton<IClock, ClockUtc>();
            services.AddHostedService<AppInitializer>();

            return services;
        }

        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
        {
            app.UseErrorHandling();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            return app;
        }
    }
}
