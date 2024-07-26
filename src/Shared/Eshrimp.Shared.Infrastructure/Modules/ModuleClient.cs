using Eshrimp.Shared.Abstractions.Modules;

namespace Eshrimp.Shared.Infrastructure.Modules
{
    public class ModuleClient : IModuleClient
    {
        private readonly IModuleRegistry _moduleRegistry;
        private readonly IModuleSerializer _moduleSerializer;

        public ModuleClient(IModuleRegistry moduleRegistry,
            IModuleSerializer moduleSerializer)
        {
            _moduleRegistry = moduleRegistry;
            _moduleSerializer = moduleSerializer;
        }

        public async Task PublishAsync(object message)
        {
            var key = message.GetType().Name;
            var registrations = _moduleRegistry.GetBroadcastRegistrations(key);
            foreach (var reg in registrations)
            {
                var translatedMessage = TranslateType(message, reg.ReceiverType);
                var action = reg.Action;

                await action(translatedMessage);
            }
        }

        private object TranslateType(object message, Type receiverType)
            => _moduleSerializer.Deserialize(_moduleSerializer.Serialize(message), receiverType);
    }
}
