using Convey;
using Convey.MessageBrokers.RabbitMQ;
using Eshrimp.Shared.Abstractions.Modules;

namespace Eshrimp.Bootstrapper
{
    internal static class Extensions
    {
        public static IServiceCollection RegisterModules(this IServiceCollection services,
            IEnumerable<IModule> modules)
        {
            foreach (var module in modules)
            {
                module.RegisterModule(services);
            }

            var serviceProvider = services.BuildServiceProvider();
            using var scope = serviceProvider.CreateScope();
            {
                var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
                logger.LogInformation($"Modules: {string.Join(", ", modules.Select(m => m.Name))}");
            }

            return services;
        }

        public static IApplicationBuilder UseModules(this IApplicationBuilder app,
            IEnumerable<IModule> modules)
        {
            foreach (var module in modules)
            {
                module.UseModule(app);
            }
            app.UseConvey();
            app.UseRabbitMq();

            return app;
        }
    }
}
