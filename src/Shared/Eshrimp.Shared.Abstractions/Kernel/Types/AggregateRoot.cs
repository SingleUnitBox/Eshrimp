namespace Eshrimp.Shared.Abstractions.Kernel.Types
{
    public class AggregateRoot<T>
    {
        public T Id { get; protected set; }
        public int Version { get; protected set; }
        public IEnumerable<IDomainEvent> Events => _domainEvents;

        private readonly List<IDomainEvent> _domainEvents = new();
        private bool _versionIncremented;
        
        public void AddEvent(IDomainEvent domainEvent)
        {
            if (!_versionIncremented && !_domainEvents.Any())
            {
                Version++;
            }

            _domainEvents.Add(domainEvent);
            _versionIncremented = true;

        }

        protected void IncrementVersion()
        {
            if (_versionIncremented) 
            {
                return;
            }

            Version++;
            _versionIncremented = true;
        }

        public void ClearEvents() => _domainEvents.Clear();
    }

    public abstract class AggregateRoot : AggregateRoot<AggregateId>
    {

    }
}
