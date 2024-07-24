using Eshrimp.Modules.Tanks.Domain.Entities;

namespace Eshrimp.Modules.Tanks.Application.DTO
{
    public class TankDto
    {
        public Guid Id { get; set; }
        public string SetUpDate { get; set; }
        public IEnumerable<ShrimpDto> Shrimps { get; set; }
    }
}
