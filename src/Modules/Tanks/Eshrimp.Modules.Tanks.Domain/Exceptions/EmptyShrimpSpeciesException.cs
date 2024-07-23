using Eshrimp.Shared.Abstractions.Exceptions;

namespace Eshrimp.Modules.Tanks.Domain.Exceptions
{
    public class EmptyShrimpSpeciesException : EshrimpException
    {
        public EmptyShrimpSpeciesException()
            : base($"Shrimp species cannot be empty.")
        {
        }
    }
}
