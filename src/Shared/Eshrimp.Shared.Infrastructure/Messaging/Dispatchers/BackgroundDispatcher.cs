using Eshrimp.Shared.Abstractions.Modules;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading;

namespace Eshrimp.Shared.Infrastructure.Messaging.Dispatchers
{
    internal class BackgroundDispatcher : BackgroundService
    {
        private readonly IMessageChannel _channel;
        private readonly IModuleClient _moduleClient;
        private readonly ILogger<BackgroundDispatcher> _logger;

        public BackgroundDispatcher(IMessageChannel channel,
            IModuleClient moduleClient,
            ILogger<BackgroundDispatcher> logger)
        {
            _channel = channel;
            _moduleClient = moduleClient;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation($"Running the background dispatcher...");

            await foreach (var message in _channel.Reader.ReadAllAsync(stoppingToken))
            {
                try
                {
                    await _moduleClient.PublishAsync(message);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, ex.Message);
                }
            }

            _logger.LogInformation($"Finished running the background dispatcher.");
        }
    }
}
