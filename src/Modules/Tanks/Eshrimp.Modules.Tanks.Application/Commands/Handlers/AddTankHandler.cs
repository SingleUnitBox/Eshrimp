using Eshrimp.Modules.Tanks.Application.Exceptions;
using Eshrimp.Modules.Tanks.Domain.Entities;
using Eshrimp.Modules.Tanks.Domain.Repositories;
using Eshrimp.Shared.Abstractions.Commands;
using Eshrimp.Shared.Abstractions.Time;

namespace Eshrimp.Modules.Tanks.Application.Commands.Handlers
{
    internal sealed class AddTankHandler : ICommandHandler<AddTank>
    {
        private readonly ITankRepository _tankRepository;
        private readonly IClock _clock;

        public AddTankHandler(ITankRepository tankRepository,
            IClock clock)
        {
            _tankRepository = tankRepository;
            _clock = clock;
        }

        public async Task HandleAsync(AddTank command)
        {
            var tank = await _tankRepository.GetTankAsync(command.Id);
            if (tank is not null)
            {
                throw new TankAlreadyExistsException(command.Id);
            }

            tank = Tank.Create(command.Id, command.setUpDate, _clock.Current());
            await _tankRepository.AddTankAsync(tank);
        }
    }
}
