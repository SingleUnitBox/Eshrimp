using Eshrimp.Shared.Abstractions.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace Eshrimp.Shared.Infrastructure.Queries
{
    internal sealed class QueryDispatcher : IQueryDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public QueryDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        //public async Task<TResult> QueryAsync<TQuery, TResult>(TQuery query)
        //    where TQuery : class, IQuery<TResult>
        //{           
        //    using var scope = _serviceProvider.CreateScope();
        //    {
        //        var queryHandlerType = typeof(IQueryHandler<TQuery, TResult>);
        //        var queryHandler = scope.ServiceProvider.GetRequiredService(queryHandlerType);
        //        return await (Task<TResult>)queryHandlerType
        //            .GetMethod(nameof(IQueryHandler<TQuery, TResult>.HandleAsync))
        //            ?.Invoke(queryHandler, new[] { query });
        //    }
        //}

        public async Task<TResult> QueryAsync<TResult>(IQuery<TResult> query)
        {
            using var scope = _serviceProvider.CreateScope();
            {
                var queryHandlerType = typeof(IQueryHandler<,>)
                    .MakeGenericType(query.GetType(), typeof(TResult));
                var queryHandler = scope.ServiceProvider.GetRequiredService(queryHandlerType);

                return await (Task<TResult>)queryHandlerType
                    .GetMethod(nameof(IQueryHandler<IQuery<TResult>, TResult>.HandleAsync))
                    ?.Invoke(queryHandler, new[] { query });
            }
        }
    }
}
