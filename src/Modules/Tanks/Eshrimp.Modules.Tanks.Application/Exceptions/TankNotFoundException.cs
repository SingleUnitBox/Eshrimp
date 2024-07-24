using Eshrimp.Shared.Abstractions.Exceptions;

namespace Eshrimp.Modules.Tanks.Application.Exceptions
{
    public class TankNotFoundException : EshrimpException
    {
        public Guid TankId { get; }
        public TankNotFoundException(Guid tankId)
            : base($"Tank with id '{tankId}' was not found.")
        {
            TankId = tankId;
        }
    }
}
