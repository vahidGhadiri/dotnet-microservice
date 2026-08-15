namespace BuildingBlocks.CQRS.Command;

using MediatR;

public interface ICommand : ICommand<Unit>
{
}

public interface ICommand<out TResponse> : IRequest<TResponse>
{
}