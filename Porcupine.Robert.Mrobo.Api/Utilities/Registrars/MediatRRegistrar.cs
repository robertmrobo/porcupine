using Porcupine.Robert.Mrobo.IAM.Groups.CreateGroup;
using Porcupine.Robert.Mrobo.Shared;

namespace Porcupine.Robert.Mrobo.Api.Utilities.Registrars;

public class MediatRRegistrar : IRegistrar
{
    public void RegisterServices(WebApplicationBuilder builder)
    {
        builder.Services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
            cfg.RegisterServicesFromAssembly(typeof(CreateGroupCommand).Assembly);
        });
    }
}