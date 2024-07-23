using Eshrimp.Shared.Abstractions.Exceptions;
using Eshrimp.Shared.Abstractions.Kernel.Types;

namespace Eshrimp.Modules.Tanks.Domain.Exceptions
{
    public class CannotAddShrimpToUncycledTankException : EshrimpException
    {
        public DateTime SafeDate { get; }
        public CannotAddShrimpToUncycledTankException(Date safeDate)
            : base($"Shrimp cannot be added to uncycled tank. It is safe to add on/after '{safeDate.Value.ToShortDateString()}'")
        {
            SafeDate = safeDate;
        }
    }
}
