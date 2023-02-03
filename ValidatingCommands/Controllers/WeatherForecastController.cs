using MediatR;
using Microsoft.AspNetCore.Mvc;
using ValidatingCommands.Commands;
using ValidatingCommands.DataService;

namespace ValidatingCommands.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IMediator _mediator;
        private readonly IDataService _dataService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, 
            IMediator mediator, IDataService dataService)
        {
            _logger = logger;
            _mediator = mediator;
            _dataService = dataService;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            return await _dataService.ReadForecast();
        }

        [HttpPost(Name = "SaveForecast")]
        public async Task<IActionResult> SaveForecast([FromBody] WeatherForecast weatherForecast)
        {
            await _mediator.Send(new SaveForecast.Command(weatherForecast));
            return Ok();
        }
    }
}