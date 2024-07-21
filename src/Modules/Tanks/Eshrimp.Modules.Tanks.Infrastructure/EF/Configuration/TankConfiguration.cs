using Eshrimp.Modules.Tanks.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eshrimp.Modules.Tanks.Infrastructure.EF.Configuration
{
    public class TankConfiguration : IEntityTypeConfiguration<Tank>
    {
        public void Configure(EntityTypeBuilder<Tank> builder)
        {
            
        }
    }
}
