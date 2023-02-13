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
            //(Validation logic) Checking if a similar forecast already exists first.
            //var forecasts = await _dataService.ReadForecast();
            //if (forecasts.Any(f => f.Summary.ToLower() ==
            //    request.WeatherForecast.Summary.ToLower()))
            //    throw new Exception("Similar forecast exists");

            await _dataService.SaveForecast(request.WeatherForecast);

            return Unit.Value;
        }
    }
}
