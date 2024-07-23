using Eshrimp.Shared.Abstractions.Exceptions;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

namespace Eshrimp.Modules.Tanks.Infrastructure.Exceptions
{
    internal static class Extensions
    {
        public static IServiceCollection AddErrorHandling(this IServiceCollection services)
        {
            //services.AddSingleton<IExceptionToResponseMapper, TanksExceptionToResponseMapper>();

            return services;
        }
    }
}
