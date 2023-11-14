using Porcupine.Robert.Mrobo.Shared.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.RegisterServices(typeof(Program));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi3(settings =>
    {
        settings.DocumentTitle = "Porcupine Web Api";
    });
}

app.UseHttpsRedirection();

app.UseCors("Allow Client App");

app.UseAuthorization();

app.MapControllers();

app.Run();

namespace Porcupine.Robert.Mrobo.Api
{
    /// <summary>
    /// Assembly marker code. To help with the discovery of this assembly by the Integration Tests project.
    /// </summary>
    public partial class Program { }
}