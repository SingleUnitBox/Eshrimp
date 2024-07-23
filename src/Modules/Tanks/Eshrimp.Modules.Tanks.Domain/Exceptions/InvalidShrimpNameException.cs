using Eshrimp.Modules.Tanks.Domain.Types;
using Eshrimp.Shared.Abstractions.Exceptions;

namespace Eshrimp.Modules.Tanks.Domain.Exceptions
{

    public class InvalidShrimpNameException : EshrimpException
    {
        public string ShrimpName { get; }

        public InvalidShrimpNameException(string shrimpName)
            : base($"Shrimp name '{shrimpName}' is invalid. Valid are - {GetShrimpNames()}.")
        {
            ShrimpName = shrimpName;
        }

        private static string GetShrimpNames()
            => string.Join(", ", ShrimpNames.GetShrimpNames());
    }
}
