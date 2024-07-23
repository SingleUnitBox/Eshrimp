using Eshrimp.Modules.Tanks.Domain.Exceptions;
using Eshrimp.Modules.Tanks.Domain.Types;

namespace Eshrimp.Modules.Tanks.Domain.ValueObjects
{
    public class Species
    {
        public string Value { get; private set; }

        public Species(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new EmptyShrimpSpeciesException();
            }

            if (!SpeciesTypes.GetTypes().Contains(value.ToLowerInvariant()))
            {
                throw new InvalidShrimpSpeciesException(value);
            }

            Value = value.ToLowerInvariant();
        }

        public static implicit operator Species(string value) => new Species(value);
    }
}
