using Eshrimp.Shared.Abstractions.Messaging;
using Eshrimp.Shared.Infrastructure.Messaging.Brokers;
using Eshrimp.Shared.Infrastructure.Messaging.Dispatchers;
using Eshrimp.Shared.Infrastructure.Postgres;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Eshrimp.Shared.Infrastructure.Messaging
{
    internal static class Extensions
    {
        private const string SectionName = "messaging";
        public static IServiceCollection AddMessaging(this IServiceCollection services)
        {
            services.AddSingleton<IMessageBroker, MessageBroker>();
            services.AddSingleton<IAsyncMessageDispatcher, AsyncMessageDispatcher>();
            services.AddSingleton<IMessageChannel, MessageChannel>();

            var messagingOptions = services.GetOptions<MessagingOptions>(SectionName);
            services.AddSingleton(messagingOptions);
            if (messagingOptions.UseBackgroundDispatcher)
            {
                services.AddHostedService<BackgroundDispatcher>();
            }

            return services;
        }
    }
}
