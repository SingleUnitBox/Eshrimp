using Eshrimp.Shared.Abstractions.Events;
using Microsoft.Extensions.DependencyInjection;

namespace Eshrimp.Shared.Infrastructure.Events
{
    internal sealed class EventDispatcher : IEventDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public EventDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        //public async Task DispatchAsync<TEvent>(TEvent @event) where TEvent : class, IEvent
        //{
        //    using var scope = _serviceProvider.CreateScope();
        //    {
        //        var eventHandlers = scope.ServiceProvider.GetServices<IEventHandler<TEvent>>();

        //        var tasks = eventHandlers.Select(e => e.HandleAsync(@event));
        //        await Task.WhenAll(tasks);
        //    }
        //}

        public async Task DispatchAsync<TEvent>(TEvent @event) where TEvent : class, IEvent
        {
            using var scope = _serviceProvider.CreateScope();
            {
                var eventHandlerTypes1 = typeof(IEventHandler<>).MakeGenericType(typeof(TEvent));
                var eventHandlerTypes2 = typeof(IEventHandler<TEvent>);
                var eventHandlerTypes3 = typeof(IEventHandler<>).MakeGenericType(@event.GetType());

                var eventHandlers = scope.ServiceProvider.GetServices(eventHandlerTypes3);
                var tasks = new List<Task>();
                foreach (var eventHandler in eventHandlers)
                {
                    tasks.Add((Task)eventHandlerTypes1.GetMethod(nameof(IEventHandler<TEvent>.HandleAsync))
                        ?.Invoke(eventHandler, new[] { @event }));
                }

                await Task.WhenAll(tasks);
            }
        }
    }
}
