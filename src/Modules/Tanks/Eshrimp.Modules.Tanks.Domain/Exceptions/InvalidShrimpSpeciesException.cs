using Eshrimp.Modules.Tanks.Domain.Types;
using Eshrimp.Shared.Abstractions.Exceptions;

namespace Eshrimp.Modules.Tanks.Domain.Exceptions
{
    public class InvalidShrimpSpeciesException : EshrimpException
    {
        public string Species { get; }
        public InvalidShrimpSpeciesException(string species)
            : base($"Shrimp species of '{species}' is invalid. Valid are - {GetValidSpecies()}.")
        {
            Species = species;
        }

        private static string GetValidSpecies()
            => string.Join(", ", SpeciesTypes.GetTypes());
    }
}
