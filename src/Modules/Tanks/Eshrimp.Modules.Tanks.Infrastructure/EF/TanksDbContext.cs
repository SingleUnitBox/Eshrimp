using Eshrimp.Modules.Tanks.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Eshrimp.Modules.Tanks.Infrastructure.EF
{
    internal sealed class TanksDbContext : DbContext
    {
        public DbSet<Tank> Tanks { get; set; }

        public TanksDbContext(DbContextOptions<TanksDbContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            modelBuilder.HasDefaultSchema("tanks");
        }
    }
}
