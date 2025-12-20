using JobRunner.ExternalApis.RandomUserGenerator;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGet("/randomUserGenerator", () =>
{
    var teste = new RandomUserGeneratorClient();
    return teste.DoConsume();
});

app.Run();
