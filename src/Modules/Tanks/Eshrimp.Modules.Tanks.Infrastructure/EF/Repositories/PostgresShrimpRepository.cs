using Eshrimp.Modules.Tanks.Domain.Entities;
using Eshrimp.Modules.Tanks.Domain.Repositories;
using Eshrimp.Modules.Tanks.Domain.ValueObjects;
using Eshrimp.Shared.Abstractions.Kernel.Types;
using Microsoft.EntityFrameworkCore;

namespace Eshrimp.Modules.Tanks.Infrastructure.EF.Repositories
{
    internal sealed class PostgresShrimpRepository : IShrimpRepository
    {
        private readonly DbSet<Shrimp> _shrimps;
        private readonly TanksDbContext _dbContext;

        public PostgresShrimpRepository(TanksDbContext dbContext)
        {
            _shrimps = dbContext.Shrimps;
            _dbContext = dbContext;
        }

        public async Task AddShrimpAsync(Shrimp shrimp)
        {
            await _shrimps.AddAsync(shrimp);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateShrimpAsync(Shrimp shrimp)
        {
             _shrimps.Update(shrimp);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Shrimp> GetShrimpAsync(ShrimpId shrimpId)
             => await _shrimps
                .Include(s => s.Tank)
                .SingleOrDefaultAsync(s => s.Id == shrimpId);

        public async Task<IEnumerable<Shrimp>> GetShrimpsByTankAsync(AggregateId tankId)
        {
            var shrimps = await _shrimps
                .Include(s => s.Tank)
                .Where(s => s.Tank.Id == tankId)
                .ToListAsync();

            return shrimps;
        }
    }
}
