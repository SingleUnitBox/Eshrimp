using Eshrimp.Shared.Abstractions.Events;

namespace Eshrimp.Modules.Tanks.Application.Events
{
    public record ShrimpAdded(Guid ShrimpId) : IEvent;
}
