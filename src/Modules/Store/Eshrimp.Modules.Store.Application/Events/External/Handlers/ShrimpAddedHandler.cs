using Eshrimp.Shared.Abstractions.Events;

namespace Eshrimp.Modules.Store.Application.Events.External.Handlers
{
    internal sealed class ShrimpAddedHandler : IEventHandler<ShrimpAdded>
    {
        public Task HandleAsync(ShrimpAdded @event)
        {
            Console.WriteLine($"Added shrimp with id '{@event.ShrimpId}'");
            return Task.CompletedTask;
        }
    }
}
