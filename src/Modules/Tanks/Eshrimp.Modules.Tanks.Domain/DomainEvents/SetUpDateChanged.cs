using Eshrimp.Shared.Abstractions.Kernel;
using Eshrimp.Shared.Abstractions.Kernel.Types;

namespace Eshrimp.Modules.Tanks.Domain.DomainEvents
{
    public record SetUpDateChanged(AggregateId Id, Date SetUpDate) : IDomainEvent;
}
