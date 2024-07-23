using Eshrimp.Shared.Abstractions.Kernel.Types;

namespace Eshrimp.Modules.Tanks.Domain.ValueObjects
{
    public class ShrimpId : TypeId
    {
        public ShrimpId(Guid value) : base(value)
        {
            
        }

        public static implicit operator ShrimpId(Guid value) => new(value);
        public static implicit operator Guid(ShrimpId id) => id.Value;
    }
}
