using Eshrimp.Modules.Tanks.Application.Exceptions;
using Eshrimp.Modules.Tanks.Domain.Entities;
using Eshrimp.Modules.Tanks.Domain.Repositories;
using Eshrimp.Shared.Abstractions.Commands;

namespace Eshrimp.Modules.Tanks.Application.Commands.Handlers
{
    internal sealed class AddShrimpHandler : ICommandHandler<AddShrimp>
    {
        private readonly IShrimpRepository _shrimpRepository;
        private readonly ITankRepository _tankRepository;

        public AddShrimpHandler(IShrimpRepository shrimpRepository,
            ITankRepository tankRepository)
        {
            _shrimpRepository = shrimpRepository;
            _tankRepository = tankRepository;
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
        }
    }
}
