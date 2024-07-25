using Eshrimp.Shared.Abstractions.Events;

namespace Eshrimp.Modules.Store.Application.Events.External
{
    public record ShrimpAdded(Guid ShrimpId) : IEvent;
}
