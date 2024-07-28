using Eshrimp.Modules.Tanks.Application.Exceptions;
using Eshrimp.Shared.Abstractions.Events;

namespace Eshrimp.Modules.Tanks.Application.Events.Handlers
{
    internal class ShrimpAddedHandler //: IEventHandler<ShrimpAdded>
    {
        public async Task HandleAsync(ShrimpAdded @event)
        {
            //Console.WriteLine($"Added shrimp with id '{@event.ShrimpId}' in 'tanks-module'.");
            await Task.Delay(5_000);
            throw new ShrimpAlreadyExistsException(@event.ShrimpId);
            //return Task.CompletedTask;
        }
    }
}
