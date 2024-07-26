using Microsoft.AspNetCore.Http;

namespace Eshrimp.Shared.Infrastructure.Modules
{
    public interface IModuleSerializer
    {
        byte[] Serialize(object message);
        object Deserialize(byte[] message, Type receiverType);
        T Deserialize<T>(byte[] message);
    }
}
