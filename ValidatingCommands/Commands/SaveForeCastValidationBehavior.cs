using MediatR;
using ValidatingCommands.DataService;

namespace ValidatingCommands.Commands
{
    //public class SaveForeCastValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    //    where TRequest : IRequest<TResponse>
    public class SaveForeCastValidationBehavior : IPipelineBehavior<SaveForecast.Command, Unit>
    {
        private readonly IDataService _dataService;

        public SaveForeCastValidationBehavior(IDataService dataService)
        {
            _dataService = dataService;
        }

        public async Task<Unit> Handle(SaveForecast.Command request, RequestHandlerDelegate<Unit> next, CancellationToken cancellationToken)
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

            return await next();
        }
    }
}
