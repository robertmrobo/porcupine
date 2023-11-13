using System.Reflection;
using Porcupine.Robert.Mrobo.Shared;
using Swashbuckle.AspNetCore.SwaggerGen;
using OpenApiInfo = Microsoft.OpenApi.Models.OpenApiInfo;

namespace Porcupine.Robert.Mrobo.Api.Utilities.Registrars;

public class SwaggerRegistrar : IRegistrar
{
    public void RegisterServices(WebApplicationBuilder builder)
    {
        builder.Services.AddOpenApiDocument(document =>
        {
            document.Title = "Porcupine Web Api";
        });

        builder.Services.AddEndpointsApiExplorer()
            .AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Porcupine.Robert.Mrobo.API",
                });

                x.DocInclusionPredicate((name, api) => !string.IsNullOrEmpty(api.GroupName));

                x.TagActionsBy(api => new List<string>
                {
                    api.GroupName ?? string.Empty
                });
                
                AddSwaggerDocumentation(x);
            });
    }
    
    private static void AddSwaggerDocumentation(SwaggerGenOptions o)
    {
        var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        o.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
    }
}