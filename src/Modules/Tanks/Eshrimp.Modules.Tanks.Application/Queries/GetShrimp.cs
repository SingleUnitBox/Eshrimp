using Eshrimp.Modules.Tanks.Application.DTO;
using Eshrimp.Shared.Abstractions.Queries;

namespace Eshrimp.Modules.Tanks.Application.Queries
{
    public record GetShrimp(Guid Id) : IQuery<ShrimpDto>;
}
