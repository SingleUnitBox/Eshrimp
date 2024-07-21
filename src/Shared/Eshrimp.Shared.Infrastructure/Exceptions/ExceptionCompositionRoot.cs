using Eshrimp.Shared.Abstractions.Exceptions;
using Microsoft.Extensions.DependencyInjection;

namespace Eshrimp.Shared.Infrastructure.Exceptions
{
    public class ExceptionCompositionRoot : IExceptionCompositionRoot
    {
        private readonly IServiceProvider _serviceProvider;

        public ExceptionCompositionRoot(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public ExceptionResponse Map(Exception exception)
        {
            using var scope = _serviceProvider.CreateScope();
            {
                var exceptionMappers = scope.ServiceProvider
                    .GetServices<IExceptionToResponseMapper>().ToArray();
                var nonDefaultMappers = exceptionMappers
                    .Where(m => m is not EshrimpExceptionToResponseMapper);
                var result = nonDefaultMappers.Select(m => m.Map(exception))
                    .SingleOrDefault(r => r is not null);
                if (result is not null)
                {
                    return result;
                }

                var defaultMapper = exceptionMappers.SingleOrDefault(m => m is EshrimpExceptionToResponseMapper);
                
                return defaultMapper?.Map(exception);
            }
            
        }
    }
}
