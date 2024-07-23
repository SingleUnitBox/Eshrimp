using Eshrimp.Modules.Tanks.Domain.Entities;
using Eshrimp.Modules.Tanks.Domain.Repositories;
using Eshrimp.Shared.Abstractions.Kernel.Types;
using Microsoft.EntityFrameworkCore;

namespace Eshrimp.Modules.Tanks.Infrastructure.EF.Repositories
{
    internal sealed class PostgresTankRepository : ITankRepository
    {
        private readonly DbSet<Tank> _tanks;
        private readonly TanksDbContext _dbContext;

        public PostgresTankRepository(TanksDbContext dbContext)
        {
            _tanks = dbContext.Tanks;
            _dbContext = dbContext;
        }

        public async Task AddSTankAsync(Tank tank)
        {
            await _tanks.AddAsync(tank);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateTankAsync(Tank tank)
        {
            _tanks.Update(tank);
            await _dbContext.SaveChangesAsync();
        }

        public Task<Tank> GetTankAsync(AggregateId tankId)
            => _tanks
                .Include(t => t.Shrimps)
                .SingleOrDefaultAsync(t => t.Id == tankId);

        public async Task<IEnumerable<Tank>> GetTanksAsync()
            => await _tanks.ToListAsync();
    }
}
