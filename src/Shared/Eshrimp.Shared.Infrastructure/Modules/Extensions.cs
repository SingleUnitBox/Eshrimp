using Eshrimp.Shared.Abstractions.Events;
using Eshrimp.Shared.Abstractions.Modules;
using Eshrimp.Shared.Infrastructure.Events;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace Eshrimp.Shared.Infrastructure.Modules
{
    internal static class Extensions
    {
        public static IHostBuilder ConfigureModules(this IHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureAppConfiguration((ctx, cfg) =>
            {
                foreach (var settings in GetSettings("*"))
                {
                    cfg.AddJsonFile(settings);
                }

                foreach (var setting in GetSettings($"*.{ctx.HostingEnvironment.EnvironmentName}"))
                {
                    cfg.AddJsonFile(setting);
                }

                IEnumerable<string> GetSettings(string pattern) =>
                    Directory.EnumerateFiles(
                        ctx.HostingEnvironment.ContentRootPath, $"module.{pattern}.json", SearchOption.AllDirectories);
            });

            return hostBuilder;
        }

        public static IServiceCollection AddModuleRequests(this IServiceCollection services,
            IEnumerable<Assembly> assemblies)
        {
            services.AddSingleton<IModuleSerializer, JsonModuleSerializer>();
            services.AddSingleton<IModuleClient, ModuleClient>();
            services.AddModuleRegistry(assemblies);

            return services;
        }

        private static void AddModuleRegistry(this IServiceCollection services, IEnumerable<Assembly> assemblies)
        {
            var registry = new ModuleRegistry();
            var types = assemblies
                .SelectMany(a => a.GetTypes())
                .ToArray();
            var eventTypes = types
                .Where(t => t.IsClass && typeof(IEvent).IsAssignableFrom(t))
                .ToArray();

            services.AddSingleton<IModuleRegistry>(sp =>
            {
                var eventDispatcher = sp.GetRequiredService<IEventDispatcher>();
                var eventDispatcherType = eventDispatcher.GetType();

                foreach (var eventType in eventTypes)
                {
                    registry.AddBroadcastRegistration(eventType, @event =>
                    (Task)eventDispatcherType
                        .GetMethod(nameof(eventDispatcher.DispatchAsync))
                        ?.MakeGenericMethod(eventType)
                        .Invoke(eventDispatcher, new[] { @event }));
                }

                return registry;
            });
        }
    }   
}
