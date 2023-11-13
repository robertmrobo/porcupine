using Porcupine.Robert.Mrobo.Shared;

namespace Porcupine.Robert.Mrobo.Api.Utilities.Registrars;

public class MvcRegistrar : IRegistrar
{
    public void RegisterServices(WebApplicationBuilder builder)
    {
        builder.Services.AddCors(opt =>
        {
            opt.AddPolicy(name: "Allow Client App", policy =>
            {
                policy.WithOrigins("http://localhost:5265")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
        });
        
        builder.Services.AddControllers();
    }
}