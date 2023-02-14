using MediatR;

namespace ValidatingCommands.Commands.Helpers;

public interface IValidator<ICommand>
{
    Task Validate(ICommand request);
}

