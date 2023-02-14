using MediatR;
using ValidatingCommands.Commands.Helpers;
using ValidatingCommands.DataService;

namespace ValidatingCommands.Commands;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : ICommand<TResponse>
{
    private readonly IValidator<TRequest> _validationHandler;

    public ValidationBehavior(IValidator<TRequest> validationHandler)
    {
        _validationHandler = validationHandler;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        await _validationHandler.Validate(request);
        return await next();
    }
}