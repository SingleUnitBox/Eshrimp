using Eshrimp.Shared.Abstractions.Exceptions;
using Eshrimp.Shared.Infrastructure.Exceptions;
using System.Net;

namespace Eshrimp.Modules.Tanks.Infrastructure.Exceptions
{
    internal class TanksExceptionToResponseMapper : IExceptionToResponseMapper
    {
        public ExceptionResponse Map(Exception exception)
        {
            var response = exception switch
            {
                _ => new ExceptionResponse(new Errors(new Error("error", "There was an error in Tanks Module.")), HttpStatusCode.InternalServerError)
            };

            return response;
        }
    }
}
