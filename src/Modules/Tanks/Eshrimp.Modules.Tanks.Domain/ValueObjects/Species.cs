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

            if (!SpeciesTypes.GetTypes().Contains(value))
            {
                throw new InvalidShrimpSpeciesException(value);
            }

            Value = value;
        }

        public static implicit operator Species(string value) => new Species(value);
        public static implicit operator string(Species species) => species.Value;
    }
}
