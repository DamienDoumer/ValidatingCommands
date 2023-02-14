using MediatR;
using static ValidatingCommands.Commands.SaveForecast;
using ValidatingCommands.DataService;

namespace ValidatingCommands.Commands.Helpers;

public class SaveForecastValidator : IValidator<SaveForecast.Command>
{
    private readonly IDataService _dataService;

    public SaveForecastValidator(IDataService dataService)
    {
        _dataService = dataService;
    }

    public async Task Validate(SaveForecast.Command request)
    {
        //(Validation logic) Checking if a similar forecast already exists first.
        var forecasts = await _dataService.ReadForecast();
        foreach (var forecast in forecasts.Select(f => f.Summary.ToLower()))
        {
            if (forecast == request.WeatherForecast.Summary.ToLower())
                throw new Exception("Similar forecast exists");
        }
        if (forecasts.Select(f => f.Summary.ToLower()).Contains(request.WeatherForecast.Summary.ToLower()))
            throw new Exception("Similar forecast exists");
    }
}
