using MediatR;

namespace ValidatingCommands.Commands.Helpers;

public interface IValidationHandler<ICommand>
{
    Task Validate(ICommand request);
}

