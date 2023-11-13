using FluentValidation;
using Porcupine.Robert.Mrobo.Shared;

namespace Porcupine.Robert.Mrobo.Api.Utilities.Registrars;

public class ValidatorRegistrar : IRegistrar
{
    public void RegisterServices(WebApplicationBuilder builder)
    {
        builder.Services.AddValidatorsFromAssemblyContaining<Program>();
    }
}