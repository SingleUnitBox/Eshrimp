using Eshrimp.Modules.Tanks.Domain.Entities;
using Eshrimp.Shared.Abstractions.Kernel.Types;

namespace Eshrimp.Modules.Tanks.Domain.Repositories
{
    public interface ITankRepository
    {
        Task AddTankAsync(Tank tank);
        Task UpdateTankAsync(Tank tank);
        Task<Tank> GetTankAsync(AggregateId tankId);
        Task<IEnumerable<Tank>> GetTanksAsync();
    }
}
