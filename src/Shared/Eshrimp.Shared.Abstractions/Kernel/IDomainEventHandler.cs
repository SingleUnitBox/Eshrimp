namespace Eshrimp.Shared.Abstractions.Kernel
{
    public interface IDomainEventHandler<in TDomainEvent> where TDomainEvent : class, IDomainEvent
    {
        Task HandleAsync(TDomainEvent domainEvent);
    }
}
