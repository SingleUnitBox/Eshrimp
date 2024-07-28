using Convey.MessageBrokers;
using Eshrimp.Shared.Abstractions.Messaging;
using Eshrimp.Shared.Abstractions.Modules;
using Eshrimp.Shared.Infrastructure.Messaging.Dispatchers;
using Microsoft.Extensions.Logging;

namespace Eshrimp.Shared.Infrastructure.Messaging.Brokers
{
    public class MessageBroker : IMessageBroker
    {
        private readonly IModuleClient _moduleClient;
        private readonly ILogger<MessageBroker> _logger;
        private readonly IAsyncMessageDispatcher _asyncMessageDispatcher;
        private readonly MessagingOptions _messagingOptions;
        private readonly IBusPublisher _busPublisher;

        public MessageBroker(IModuleClient moduleClient,
            ILogger<MessageBroker> logger,
            IAsyncMessageDispatcher asyncMessageDispatcher,
            MessagingOptions messagingOptions,
            IBusPublisher busPublisher)
        {
            _moduleClient = moduleClient;
            _logger = logger;
            _asyncMessageDispatcher = asyncMessageDispatcher;
            _messagingOptions = messagingOptions;
            _busPublisher = busPublisher;
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
                    await _busPublisher.PublishAsync(message);
                    if (_messagingOptions.UseBackgroundDispatcher)
                    {
                        await _asyncMessageDispatcher.PublishAsync(message);
                        continue;
                    }
                    tasks.Add(_moduleClient.PublishAsync(message));
                    _logger.LogInformation($"Publishing message: {message.GetType().Name}");
                }
            }
            await Task.WhenAll(tasks);
        }
    }
}
