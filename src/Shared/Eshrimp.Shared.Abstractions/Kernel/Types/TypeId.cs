namespace Eshrimp.Shared.Abstractions.Kernel.Types
{
    public abstract class TypeId : IEquatable<TypeId>
    {
        public Guid Value { get; }

        protected TypeId(Guid value)
        {
            Value = value;
        }

        public bool Equals(TypeId other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Value.Equals(other.Value);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (this.GetType() != obj.GetType()) return false;
            return Equals((TypeId)obj);
        }

        public override int GetHashCode()
            => Value.GetHashCode();

        public static implicit operator Guid(TypeId id) => id.Value;

        public static bool operator ==(TypeId a, TypeId b)
        {
            if (ReferenceEquals(a, b)) return true;
            if (a is not null && b is not null)
            {
                return a.Equals(b);
            }

            return false;
        }

        public static bool operator !=(TypeId a, TypeId b)
        {
            return !(a == b);
        }
    }
}
