using Eshrimp.Shared.Abstractions.Exceptions;

namespace Eshrimp.Modules.Tanks.Domain.Exceptions
{
    public class InvalidSetUpDateException : EshrimpException
    {
        public DateTime SetUpDate { get; }
        public InvalidSetUpDateException(DateTime setUpDate)
            : base($"Set up date '{setUpDate.ToShortDateString()}' is invalid.")
        {
            SetUpDate = setUpDate;
        }
    }
}
