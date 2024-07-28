using Eshrimp.Shared.Abstractions.Messaging;

namespace Eshrimp.Shared.Infrastructure.Messaging.Dispatchers
{
    public interface IAsyncMessageDispatcher
    {
        Task PublishAsync<TMessage>(TMessage message) where TMessage : class, IMessage;
    }
}
