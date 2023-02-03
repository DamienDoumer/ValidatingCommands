using MediatR;

namespace ValidatingCommands.Commands.Helpers;

//REf: https://codeopinion.com/validating-commands/

public interface IValidationHandler<IRequest>
{
    Task Validate(IRequest request);
}

