using Eshrimp.Modules.Tanks.Application.DTO;
using Eshrimp.Modules.Tanks.Application.Exceptions;
using Eshrimp.Modules.Tanks.Application.Mappings;
using Eshrimp.Modules.Tanks.Application.Queries;
using Eshrimp.Modules.Tanks.Domain.Entities;
using Eshrimp.Shared.Abstractions.Queries;
using Microsoft.EntityFrameworkCore;

namespace Eshrimp.Modules.Tanks.Infrastructure.EF.Queries.Handlers
{
    internal sealed class GetTankHandler : IQueryHandler<GetTank, TankDto>
    {
        private readonly DbSet<Tank> _tanks;

        public GetTankHandler(TanksDbContext dbContext)
        {
            _tanks = dbContext.Tanks;
        }

        public async Task<TankDto> HandleAsync(GetTank query)
        {
            var tank = await _tanks
                .AsNoTracking()
                .Include(t => t.Shrimps)
                .SingleOrDefaultAsync(t => t.Id == query.Id);
            if (tank is null)
            {
                throw new TankNotFoundException(query.Id);
            }

            return tank.AsDto();
        }
    }
}
