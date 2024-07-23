using Eshrimp.Shared.Abstractions.Time;

namespace Eshrimp.Shared.Infrastructure.Time
{
    public class ClockUtc : IClock
    {
        public DateTime Current() => DateTime.UtcNow;
    }
}
