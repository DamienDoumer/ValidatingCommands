using MediatR;

namespace ValidatingCommands.Commands.Helpers
{
    public interface ICommand<out TResponse> : IRequest<TResponse>
    {
    }
}
