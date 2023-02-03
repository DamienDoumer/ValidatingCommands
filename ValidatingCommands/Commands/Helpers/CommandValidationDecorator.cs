using MediatR;

namespace ValidatingCommands.Commands.Helpers;

public class CommandValidationDecorator<TRequest, TResponse> :
    IRequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly IRequestHandler<TRequest, TResponse> _requestHandler;
    private readonly IValidationHandler<TRequest> _validationHandler;

    public CommandValidationDecorator(IRequestHandler<TRequest, TResponse> requestHandler, IValidationHandler<TRequest> validationHandler)
    {
        _requestHandler = requestHandler;
        _validationHandler = validationHandler;
    }

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
    {
        await _validationHandler.Validate(request);
        return await _requestHandler.Handle(request, cancellationToken);
    }
}