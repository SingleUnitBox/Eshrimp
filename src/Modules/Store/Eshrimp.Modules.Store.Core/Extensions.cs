using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Eshrimp.Modules.Store.Api")]
namespace Eshrimp.Modules.Store.Domain
{
    internal static class Extensions
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            return services;
        }
    }
}
