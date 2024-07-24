using Eshrimp.Shared.Abstractions.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace Eshrimp.Shared.Infrastructure.Commands
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public CommandDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task DispatchAsync<TCommand>(TCommand command)
            where TCommand : class, ICommand
        {
            if (command is null)
            {
                return;
            }

            using var scope = _serviceProvider.CreateScope();
            {
                var commandHandler = scope.ServiceProvider.GetRequiredService<ICommandHandler<TCommand>>();
                await commandHandler.HandleAsync(command);
            }
        }
    }
}
