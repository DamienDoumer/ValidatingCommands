namespace ValidatingCommands.DataService
{
    public interface IDataService
    {
        Task<IEnumerable<WeatherForecast>> ReadForecast();
        Task SaveForecast(WeatherForecast forecast);
    }
}
