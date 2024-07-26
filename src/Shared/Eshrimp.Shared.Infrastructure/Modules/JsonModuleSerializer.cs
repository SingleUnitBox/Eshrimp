using System.Text;
using System.Text.Json;

namespace Eshrimp.Shared.Infrastructure.Modules
{
    internal sealed class JsonModuleSerializer : IModuleSerializer
    {
        public static readonly JsonSerializerOptions SerializerOptions = new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true,
        };

        public object Deserialize(byte[] message, Type receiverType)
            => JsonSerializer.Deserialize(Encoding.UTF8.GetString(message), receiverType, SerializerOptions);

        public T Deserialize<T>(byte[] message)
            => JsonSerializer.Deserialize<T>(Encoding.UTF8.GetString(message), SerializerOptions);

        public byte[] Serialize(object message)
            => Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message, SerializerOptions));
    }
}
