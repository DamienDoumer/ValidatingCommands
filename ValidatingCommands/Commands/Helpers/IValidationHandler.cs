using MediatR;

namespace ValidatingCommands.Commands.Helpers;

//REf: https://codeopinion.com/validating-commands/
//REF: https://code-maze.com/cqrs-mediatr-fluentvalidation/

public interface IValidationHandler<IRequest>
{
    Task Validate(IRequest request);
}

