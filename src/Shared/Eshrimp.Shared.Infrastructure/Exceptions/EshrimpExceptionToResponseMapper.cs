using Eshrimp.Shared.Abstractions.Exceptions;
using Humanizer;
using Microsoft.AspNetCore.Http;
using System.Collections.Concurrent;
using System.Net;

namespace Eshrimp.Shared.Infrastructure.Exceptions
{
    public class EshrimpExceptionToResponseMapper : IExceptionToResponseMapper
    {
        private static readonly ConcurrentDictionary<Type, string> Codes = new();
        internal record Error(string Code, string Message);
        internal record ErrorsResponse(params Error[] errors);

        public ExceptionResponse Map(Exception exception)
        {
            var response = exception switch
            {
                EshrimpException => new ExceptionResponse(
                    new ErrorsResponse(new Error(GetErrorCode(exception), exception.Message)), HttpStatusCode.BadRequest),
                _ => new ExceptionResponse(
                    new ErrorsResponse(new Error("error", "There was an error.")), HttpStatusCode.InternalServerError)
            };

            return response;
        }

        private static string GetErrorCode(object exception)
        {
            var exceptionType = exception.GetType();
            var code = exceptionType.Name.Replace("Exception", string.Empty).Underscore();

            return Codes.GetOrAdd(exceptionType, code);
        }
    }
}
