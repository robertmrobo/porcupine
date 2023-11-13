using Microsoft.AspNetCore.Builder;

namespace Porcupine.Robert.Mrobo.Shared;

public interface IRegistrar
{
    void RegisterServices(WebApplicationBuilder builder);
}