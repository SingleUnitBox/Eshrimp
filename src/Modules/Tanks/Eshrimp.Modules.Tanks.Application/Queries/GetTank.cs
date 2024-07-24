using Eshrimp.Modules.Tanks.Application.DTO;
using Eshrimp.Shared.Abstractions.Queries;

namespace Eshrimp.Modules.Tanks.Application.Queries
{
    public record GetTank(Guid Id) : IQuery<TankDto>;
}
