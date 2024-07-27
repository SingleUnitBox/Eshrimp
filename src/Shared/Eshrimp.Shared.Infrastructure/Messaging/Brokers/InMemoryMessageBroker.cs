using Eshrimp.Shared.Abstractions.Messaging;
using Eshrimp.Shared.Abstractions.Modules;
using Microsoft.Extensions.Logging;

namespace Eshrimp.Shared.Infrastructure.Messaging.Brokers
{
    public class InMemoryMessageBroker : IMessageBroker
    {
        private readonly IModuleClient _moduleClient;
        private readonly ILogger<InMemoryMessageBroker> _logger;

        public InMemoryMessageBroker(IModuleClient moduleClient,
            ILogger<InMemoryMessageBroker> logger)
        {
            _moduleClient = moduleClient;
            _logger = logger;
        }

        public async Task PublishAsync(params IMessage[] messages)
        {
            if (messages is null && !messages.Any())
            {
                return;
            }

            messages = messages.Where(m => m is not null).ToArray();
            if (!messages.Any())
            {
                return;
            }

            var tasks = new List<Task>();
            foreach (var  message in messages)
            {
                if (message is not null)
                {
                    tasks.Add(_moduleClient.PublishAsync(message));
                    _logger.LogInformation($"Publishing message: {message.GetType().Name}");
                }
            }
            await Task.WhenAll(tasks);
        }
    }
}
