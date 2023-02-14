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

builder.Services.AddTransient<IValidator<SaveForecast.Command>, SaveForecastValidator>();
builder.Services.AddMediatR(typeof(Program));

//If you want the validation to occur on evey request, use this.
//builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

builder.Services.AddTransient<IPipelineBehavior<SaveForecast.Command, Unit>, ValidationBehavior<SaveForecast.Command, Unit>>();

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
