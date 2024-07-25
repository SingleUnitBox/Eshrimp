using Eshrimp.Modules.Tanks.Application.Events;
using Eshrimp.Modules.Tanks.Application.Exceptions;
using Eshrimp.Modules.Tanks.Domain.Entities;
using Eshrimp.Modules.Tanks.Domain.Repositories;
using Eshrimp.Shared.Abstractions.Commands;
using Eshrimp.Shared.Abstractions.Events;

namespace Eshrimp.Modules.Tanks.Application.Commands.Handlers
{
    internal sealed class AddShrimpHandler : ICommandHandler<AddShrimp>
    {
        private readonly IShrimpRepository _shrimpRepository;
        private readonly ITankRepository _tankRepository;
        private readonly IEventDispatcher _eventDispatcher;

        public AddShrimpHandler(IShrimpRepository shrimpRepository,
            ITankRepository tankRepository,
            IEventDispatcher eventDispatcher)
        {
            _shrimpRepository = shrimpRepository;
            _tankRepository = tankRepository;
            _eventDispatcher = eventDispatcher;
        }

        public async Task HandleAsync(AddShrimp command)
        {
            var shrimp = await _shrimpRepository.GetShrimpAsync(command.Id);
            if (shrimp is not null)
            {
                throw new ShrimpAlreadyExistsException(command.Id);
            }

            shrimp = Shrimp.Create(command.Id, command.Name, command.Species);
            if (command.TankId.HasValue)
            {
                var tank = await _tankRepository.GetTankAsync(command.TankId.Value);
                if (tank is null)
                {
                    throw new TankNotFoundException(command.TankId.Value);
                }

                shrimp.AssignTank(tank);
            }

            await _shrimpRepository.AddShrimpAsync(shrimp);
            await _eventDispatcher.DispatchAsync(new ShrimpAdded(shrimp.Id));
        }
    }
}
