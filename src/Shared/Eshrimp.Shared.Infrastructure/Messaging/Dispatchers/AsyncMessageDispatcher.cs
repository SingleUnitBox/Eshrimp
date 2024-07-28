using Eshrimp.Shared.Abstractions.Messaging;

namespace Eshrimp.Shared.Infrastructure.Messaging.Dispatchers
{
    internal class AsyncMessageDispatcher : IAsyncMessageDispatcher
    {
        private readonly IMessageChannel _channel;

        public AsyncMessageDispatcher(IMessageChannel channel)
        {
            _channel = channel;
        }

        public async Task PublishAsync<TMessage>(TMessage message) where TMessage : class, IMessage
            => await _channel.Writer.WriteAsync(message);       
    }
}
