using Eshrimp.Shared.Abstractions.Messaging;
using System.Threading.Channels;

namespace Eshrimp.Shared.Infrastructure.Messaging.Dispatchers
{
    internal interface IMessageChannel
    {
        ChannelWriter<IMessage> Writer { get; }
        ChannelReader<IMessage> Reader { get; }
    }
}
