using Eshrimp.Shared.Abstractions.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Eshrimp.Shared.Infrastructure.Exceptions
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
		private readonly IExceptionCompositionRoot _responseMapper;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(IExceptionCompositionRoot responseMapper,
            ILogger<ErrorHandlingMiddleware> logger)
        {
            _responseMapper = responseMapper;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
			try
			{
				await next(context);
			}
			catch (Exception ex)
			{
                _logger.LogError(ex, ex.Message);
                await HandleAsync(context, ex);
			}
        }

        private async Task HandleAsync(HttpContext context, Exception ex)
        {
            var response = _responseMapper.Map(ex);
            context.Response.StatusCode = (int)(response?.StatusCode ?? HttpStatusCode.InternalServerError);
            if (response is null)
            {
                return;
            }

            await context.Response.WriteAsJsonAsync(response);
        }
    }
}
