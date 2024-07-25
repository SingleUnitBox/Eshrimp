using Eshrimp.Shared.Abstractions.Events;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Eshrimp.Shared.Infrastructure.Events
{
    internal static class Extensions
    {
        public static IServiceCollection AddEvents(this IServiceCollection services,
            IEnumerable<Assembly> assemblies)
        {
            services.AddSingleton<IEventDispatcher, EventDispatcher>();
            services.Scan(a => a.FromAssemblies(assemblies)
                .AddClasses(c => c.AssignableTo(typeof(IEventHandler<>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            return services;
        }
    }
}
