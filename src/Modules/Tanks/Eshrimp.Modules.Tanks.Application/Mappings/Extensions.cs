using Eshrimp.Modules.Tanks.Application.DTO;
using Eshrimp.Modules.Tanks.Domain.Entities;

namespace Eshrimp.Modules.Tanks.Application.Mappings
{
    public static class Extensions
    {
        public static TankDetailsDto AsDetailsDto(this Tank tank)
            => new TankDetailsDto
            {
                Id = tank.Id,
                SetUpDate = tank.SetUpDate.Value.ToShortDateString(),
                Shrimps = tank.Shrimps?.Select(s => s.AsDto())
            };

        public static TankDto AsDto(this Tank tank)
            => new TankDto
            {
                Id = tank.Id,
                SetUpDate = tank.SetUpDate.Value.ToShortDateString()
            };

        public static ShrimpDetailsDto AsDetailsDto(this Shrimp shrimp)
            => new ShrimpDetailsDto
            {
                Id = shrimp.Id,
                ShrimpName = shrimp.Name,
                Species = shrimp.Species,
                Tank = shrimp.Tank?.AsDto(),
            };

        public static ShrimpDto AsDto(this Shrimp shrimp)
            => new ShrimpDto
            {
                Id = shrimp.Id,
                ShrimpName = shrimp.Name,
                Species = shrimp.Species,
            };
    }
}
