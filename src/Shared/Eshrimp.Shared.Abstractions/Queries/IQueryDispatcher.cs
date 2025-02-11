﻿namespace Eshrimp.Shared.Abstractions.Queries
{
    public interface IQueryDispatcher
    {
        //Task<TResult> QueryAsync<TQuery, TResult>(TQuery query)
        //    where TQuery : class, IQuery<TResult>;

        Task<TResult> QueryAsync<TResult>(IQuery<TResult> query);
    }
}
