using Eshrimp.Modules.Tanks.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eshrimp.Modules.Tanks.Infrastructure.EF.Configuration
{
    public class TankConfiguration : IEntityTypeConfiguration<Tank>
    {
        public void Configure(EntityTypeBuilder<Tank> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id)
                .HasConversion(t => t.Value, v => new(v));
            builder.Property(t => t.SetUpDate)
                .HasConversion(d => d.Value, value => new(value));
            builder.HasMany(t => t.Shrimps)
                .WithOne(s => s.Tank);
            builder.Property(t => t.Version)
                .IsConcurrencyToken();
        }
    }
}
