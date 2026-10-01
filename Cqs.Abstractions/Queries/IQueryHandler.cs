using Cqs.Abstractions.Results;

namespace Cqs.Abstractions.Queries
{
    public interface IQueryHandler<TQuery, TResult>
        where TQuery : IQueryDefinition<TResult>
    {
        Result<TResult> Execute(TQuery query);
    }

    public interface IQueryAsyncHandler<TQuery, TResult>
        where TQuery : IQueryDefinition<TResult>
    {
        Task<Result<TResult>> ExecuteAsync(TQuery query);
    }
}
