using Eshrimp.Shared.Abstractions.Modules;

namespace Eshrimp.Shared.Infrastructure.Modules
{
    public class ModuleClient : IModuleClient
    {
        private readonly IModuleRegistry _moduleRegistry;

        public ModuleClient(IModuleRegistry moduleRegistry)
        {
            _moduleRegistry = moduleRegistry;
        }

        public async Task PublishAsync(object message)
        {
            if (message == null)
            {
                return;
            }

            var registrations = _moduleRegistry.GetBroadcastRegistrations(message.GetType().Name);
            foreach (var reg in registrations)
            {
                var action = reg.Action;
            }
        }
    }
}
