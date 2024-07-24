using Eshrimp.Shared.Abstractions.Queries;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Eshrimp.Shared.Infrastructure.Queries
{
    internal static class Extensions
    {
        public static IServiceCollection AddQueries(this IServiceCollection services,
            IEnumerable<Assembly> assemblies)
        {
            services.AddSingleton<IQueryDispatcher, QueryDispatcher>();
            services.Scan(a => a.FromAssemblies(assemblies)
                .AddClasses(c => c.AssignableTo(typeof(IQueryHandler<,>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            return services;
        }
    }
}
