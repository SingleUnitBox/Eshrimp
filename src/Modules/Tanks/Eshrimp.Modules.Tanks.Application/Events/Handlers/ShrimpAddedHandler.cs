using Eshrimp.Shared.Abstractions.Events;

namespace Eshrimp.Modules.Tanks.Application.Events.Handlers
{
    internal class ShrimpAddedHandler : IEventHandler<ShrimpAdded>
    {
        public Task HandleAsync(ShrimpAdded @event)
        {
            Console.WriteLine($"Added shrimp with id '{@event.ShrimpId}' in 'tanks-module'.");
            return Task.CompletedTask;
        }
    }
}
