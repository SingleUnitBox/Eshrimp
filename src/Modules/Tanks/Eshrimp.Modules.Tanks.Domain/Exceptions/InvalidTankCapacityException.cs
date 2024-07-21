using Eshrimp.Shared.Abstractions.Exceptions;

namespace Eshrimp.Modules.Tanks.Domain.Exceptions
{
    public class InvalidTankCapacityException : EshrimpException
    {
        public double Capacity { get; }
        public InvalidTankCapacityException(double capacity) 
            : base($"Tank capacity of '{capacity}' is invalid.")
        {
            Capacity = capacity;
        }
    }
}
