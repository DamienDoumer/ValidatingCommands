namespace ValidatingCommands.DataService;

public class FakeDataService : IDataService
{
    private static readonly List<string> Summaries = new List<string>
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    public Task<IEnumerable<WeatherForecast>> ReadForecast()
    {
        return Task.FromResult(Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Count)]
        }));
    }

    public Task SaveForecast(WeatherForecast forecast)
    {
        Summaries.Add(forecast.Summary);
        return Task.CompletedTask;
    }
}
