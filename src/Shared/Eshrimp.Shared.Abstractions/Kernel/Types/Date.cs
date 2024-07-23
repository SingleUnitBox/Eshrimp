namespace Eshrimp.Shared.Abstractions.Kernel.Types
{
    public class Date
    {
        public DateTime Value { get; }

        public Date(DateTime value)
        {
            Value = value;
        }

        public static implicit operator DateTime(Date date) => date.Value;
        public static implicit operator Date(DateTime value) => new Date(value);
        public static bool operator >(Date a, Date b)
            => a.Value > b.Value;
        public static bool operator <(Date a, Date b)
            => a.Value < b.Value;
    }
}
