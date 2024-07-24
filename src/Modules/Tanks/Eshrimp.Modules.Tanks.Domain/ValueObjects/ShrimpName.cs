using Eshrimp.Modules.Tanks.Domain.Exceptions;
using Eshrimp.Modules.Tanks.Domain.Types;

namespace Eshrimp.Modules.Tanks.Domain.ValueObjects
{
    public class ShrimpName
    {
        public string Value { get; }

        public ShrimpName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new EmptyShrimpNameException();
            }

            if (!ShrimpNames.GetShrimpNames().Contains(value))
            {
                throw new InvalidShrimpNameException(value);
            }

            Value = value;
        }

        public static implicit operator ShrimpName(string value) => new ShrimpName(value);
        public static implicit operator string(ShrimpName name) => name.Value;
    }
}
