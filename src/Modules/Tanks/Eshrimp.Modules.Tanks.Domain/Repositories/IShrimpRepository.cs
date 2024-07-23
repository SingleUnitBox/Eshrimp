using Eshrimp.Modules.Tanks.Domain.Entities;
using Eshrimp.Modules.Tanks.Domain.ValueObjects;
using Eshrimp.Shared.Abstractions.Kernel.Types;

namespace Eshrimp.Modules.Tanks.Domain.Repositories
{
    public interface IShrimpRepository
    {
        Task AddShrimpAsync(Shrimp shrimp);
        Task UpdateShrimpAsync(Shrimp shrimp);
        Task<Shrimp> GetShrimpAsync(ShrimpId shrimpId);
        Task<IEnumerable<Shrimp>> GetShrimpsByTankAsync(AggregateId tankId);
    }
}
