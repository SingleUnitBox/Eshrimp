using Eshrimp.Modules.Tanks.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eshrimp.Modules.Tanks.Infrastructure.EF.Configuration
{
    public class ShrimpConfiguration : IEntityTypeConfiguration<Shrimp>
    {
        public void Configure(EntityTypeBuilder<Shrimp> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id)
                .HasConversion(s => s.Value, value => new(value));
            builder.Property(s => s.Name)
                .HasConversion(s => s.Value, value => new(value));
            builder.Property(s => s.Species)
                .HasConversion(s => s.Value, value => new(value));
            builder.HasOne(s => s.Tank)
                .WithMany(t => t.Shrimps);
        }
    }
}
