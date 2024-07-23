using Eshrimp.Shared.Abstractions.Exceptions;

namespace Eshrimp.Modules.Tanks.Domain.Exceptions
{
    public class EmptyShrimpNameException : EshrimpException
    {
        public EmptyShrimpNameException()
            : base($"Shrimp name cannot be empty.")
        {
        }
    }
}
