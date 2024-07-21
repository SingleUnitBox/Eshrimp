using Microsoft.Extensions.DependencyInjection;

namespace Eshrimp.Shared.Infrastructure.Exceptions
{
    internal static class Extensions
    {
        public static IServiceCollection AddErrorHandling(this IServiceCollection services)
        {
            return services;
        }
    }
}
