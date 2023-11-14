using AutoMapper;
using Porcupine.Robert.Mrobo.Shared;

namespace Porcupine.Robert.Mrobo.Api.Utilities.MappingProfiles;

public class AutoMapperRegistrar : IRegistrar
{
    public void RegisterServices(WebApplicationBuilder builder)
    {
        var mapper = new MapperConfiguration(c =>
        {
            c.AddProfile(new MapperProfile());
        }).CreateMapper();
        
        builder.Services.AddSingleton(mapper);
    }
}