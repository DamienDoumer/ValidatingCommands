using MediatR;
using ValidatingCommands.Commands.Helpers;
using ValidatingCommands.Commands;
using ValidatingCommands.DataService;
using static ValidatingCommands.Commands.SaveForecast;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IDataService, FakeDataService>();

builder.Services.AddTransient<IValidationHandler<SaveForecast.Command>, SaveForecastValidator>();
builder.Services.AddMediatR(typeof(Program));
//builder.Services.AddTransient<IPipelineBehavior<SaveForecast.Command, Unit>, SaveForeCastValidationBehavior>();
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

//builder.Services.AddTransient<SaveForecast.Handler>();
//builder.Services.AddTransient<IRequestHandler<SaveForecast.Command, Unit>,
//    CommandValidationDecorator<SaveForecast.Command, Unit>>(sp =>
//    {
//        return new CommandValidationDecorator<SaveForecast.Command, Unit>(sp.GetService<SaveForecast.Handler>(), sp.GetService<IValidationHandler<SaveForecast.Command>>());
//    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
