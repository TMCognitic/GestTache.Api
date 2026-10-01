using Cqs.Abstractions.Results;

namespace Cqs.Abstractions.Commands;

public interface ICommandHandler<TCommand>
    where TCommand : ICommandDefinition
{
    Result Execute(TCommand command);
}

public interface ICommandHandler<TCommand, TResult>
    where TCommand : ICommandDefinition<TResult>
{
    Result<TResult> Execute(TCommand command);
}

public interface ICommandAsyncHandler<TCommand>
    where TCommand : ICommandDefinition
{
    Task<Result> ExecuteAsync(TCommand command);
}

public interface ICommandAsyncHandler<TCommand, TResult>
    where TCommand : ICommandDefinition<TResult>
{
    Task<Result<TResult>> ExecuteAsync(TCommand command);
}
