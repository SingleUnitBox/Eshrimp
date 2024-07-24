using Eshrimp.Shared.Abstractions.Commands;

namespace Eshrimp.Modules.Tanks.Application.Commands
{
    internal record AddTank(DateTime setUpDate) : ICommand
    {
        public Guid Id => Guid.NewGuid();
    }
}
