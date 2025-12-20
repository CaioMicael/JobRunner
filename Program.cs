using JobRunner.ExternalApis.RandomUserGenerator;
using JobRunner.Services;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;

// Configura o Serilog
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
    .MinimumLevel.Override("System", LogEventLevel.Warning)
    .WriteTo.File(
        path: Path.Combine(AppContext.BaseDirectory, "Infrastructure", "Logging", "app.txt"),
        rollingInterval: RollingInterval.Day
    )
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Substitui o pipeline de logging
builder.Host.UseSerilog();

builder.Services.AddScoped<JobRunnerService>();
builder.Services.AddScoped<RandomUserGeneratorClient>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGet("/randomUserGenerator", (JobRunnerService job) =>
{
    return job.Run();
});

app.Run();
