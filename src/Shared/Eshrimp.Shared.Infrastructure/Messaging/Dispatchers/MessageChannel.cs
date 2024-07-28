using Eshrimp.Shared.Abstractions.Messaging;
using System.Threading.Channels;

namespace Eshrimp.Shared.Infrastructure.Messaging.Dispatchers
{
    internal sealed class MessageChannel : IMessageChannel
    {
        private readonly Channel<IMessage> _messages = Channel.CreateUnbounded<IMessage>();

        public ChannelWriter<IMessage> Writer => _messages.Writer;
        public ChannelReader<IMessage> Reader => _messages.Reader;
    }
}
