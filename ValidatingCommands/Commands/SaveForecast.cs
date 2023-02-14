using MediatR;
using ValidatingCommands.Commands.Helpers;
using ValidatingCommands.DataService;

namespace ValidatingCommands.Commands;

public class SaveForecast
{
    public record Command(WeatherForecast WeatherForecast) : ICommand<Unit>;

    public class Handler : IRequestHandler<Command, Unit>
    {
        private readonly IDataService _dataService;

        public Handler(IDataService dataService)
        {
            _dataService = dataService;
        }

        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            await _dataService.SaveForecast(request.WeatherForecast);

            return Unit.Value;
        }
    }
}
