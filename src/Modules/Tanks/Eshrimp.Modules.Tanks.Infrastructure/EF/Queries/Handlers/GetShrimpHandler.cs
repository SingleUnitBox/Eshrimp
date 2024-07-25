using Eshrimp.Modules.Tanks.Application.DTO;
using Eshrimp.Modules.Tanks.Application.Mappings;
using Eshrimp.Modules.Tanks.Application.Queries;
using Eshrimp.Modules.Tanks.Domain.Entities;
using Eshrimp.Shared.Abstractions.Queries;
using Microsoft.EntityFrameworkCore;

namespace Eshrimp.Modules.Tanks.Infrastructure.EF.Queries.Handlers
{
    internal class GetShrimpHandler : IQueryHandler<GetShrimp, ShrimpDetailsDto>
    {
        private readonly DbSet<Shrimp> _shrimps;

        public GetShrimpHandler(TanksDbContext dbContext)
        {
            _shrimps = dbContext.Shrimps;
        }

        public async Task<ShrimpDetailsDto> HandleAsync(GetShrimp query)
        {
            var shrimp = await _shrimps
                .AsNoTracking()
                .Include(s => s.Tank)
                .SingleOrDefaultAsync(s => s.Id == query.Id);

            return shrimp?.AsDetailsDto();
        }
    }
}
