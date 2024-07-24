using Eshrimp.Shared.Abstractions.Commands;

namespace Eshrimp.Modules.Tanks.Application.Commands
{
    public record AddShrimp(string Name, string Species, Guid? TankId = null) : ICommand
    {
        public Guid Id { get; } = Guid.NewGuid();
    }
}
