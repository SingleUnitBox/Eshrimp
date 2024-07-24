using Eshrimp.Shared.Abstractions.Exceptions;

namespace Eshrimp.Modules.Tanks.Application.Exceptions
{
    public class TankAlreadyExistsException : EshrimpException
    {
        public Guid Id { get; }
        public TankAlreadyExistsException(Guid id)
            : base($"Tank with id '{id}' already exists.")
        {
            Id = id;
        }
    }
}
