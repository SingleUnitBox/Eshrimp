using Eshrimp.Shared.Infrastructure.Api;
using Eshrimp.Shared.Infrastructure.Exceptions;
using Eshrimp.Shared.Infrastructure.Postgres;
using Eshrimp.Shared.Infrastructure.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Eshrimp.Bootstrapper")]
[assembly: InternalsVisibleTo("Eshrimp.Modules.Tanks.Infrastructure")]
namespace Eshrimp.Shared.Infrastructure
{
    internal static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddControllers()
                .ConfigureApplicationPartManager(manager =>
                {
                    manager.FeatureProviders.Add(new InternalControllerFeatureProvider());
                });

            services.AddErrorHandling();
            services.AddPostgres();
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
