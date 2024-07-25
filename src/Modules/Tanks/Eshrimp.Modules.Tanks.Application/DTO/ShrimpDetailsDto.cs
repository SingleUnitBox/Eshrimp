namespace Eshrimp.Modules.Tanks.Application.DTO
{
    public class ShrimpDetailsDto
    {
        public Guid Id { get; set; }
        public string ShrimpName { get; set; }
        public string Species { get; set; }
        public TankDto Tank { get; set; }
    }
}
