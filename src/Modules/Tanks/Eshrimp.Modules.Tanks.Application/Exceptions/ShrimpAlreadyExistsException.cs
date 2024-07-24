using Eshrimp.Shared.Abstractions.Exceptions;

namespace Eshrimp.Modules.Tanks.Application.Exceptions
{
    public class ShrimpAlreadyExistsException : EshrimpException
    {
        public Guid ShrimpId { get; }
        public ShrimpAlreadyExistsException(Guid shrimpId)
            : base($"Shrimp with id '{shrimpId}' already exists.")
        {
            ShrimpId = shrimpId;
        }
    }
}
