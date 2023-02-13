using MediatR;

namespace ValidatingCommands.Commands.Helpers
{
    public interface IQuery<out TResponse> : IRequest<TResponse>
    {
    }
}
