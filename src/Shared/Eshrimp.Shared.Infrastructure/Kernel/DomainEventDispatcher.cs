using Eshrimp.Shared.Abstractions.Kernel;
using Microsoft.Extensions.DependencyInjection;

namespace Eshrimp.Shared.Infrastructure.Kernel
{
    internal sealed class DomainEventDispatcher : IDomainEventDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public DomainEventDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task DispatchAsync(params IDomainEvent[] domainEvents)
        {
            using var scope = _serviceProvider.CreateScope();
            {
                foreach (var domainEvent in domainEvents)
                {
                    var domainEventHandlerType = typeof(IDomainEventHandler<>)
                        .MakeGenericType(domainEvent.GetType());
                    var domainEventHandlers = scope.ServiceProvider.GetServices(domainEventHandlerType);

                    var tasks = domainEventHandlers.Select(h =>
                        (Task)domainEventHandlerType
                        .GetMethod(nameof(IDomainEventHandler<IDomainEvent>.HandleAsync))
                        ?.Invoke(h, new[] { domainEvent }));

                    await Task.WhenAll(tasks);
                }
            }
        }
    }
}
