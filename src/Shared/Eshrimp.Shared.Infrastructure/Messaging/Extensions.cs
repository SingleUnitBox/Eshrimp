using Eshrimp.Shared.Abstractions.Messaging;
using Eshrimp.Shared.Infrastructure.Messaging.Brokers;
using Microsoft.Extensions.DependencyInjection;

namespace Eshrimp.Shared.Infrastructure.Messaging
{
    internal static class Extensions
    {
        public static IServiceCollection AddMessaging(this IServiceCollection services)
        {
            services.AddSingleton<IMessageBroker, InMemoryMessageBroker>();

            return services;
        }
    }
}
