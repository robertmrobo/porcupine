using Microsoft.AspNetCore.Builder;

namespace Porcupine.Robert.Mrobo.Shared.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static void RegisterServices(this WebApplicationBuilder builder, params Type[] scanningTypes)
    {
        var regs = new List<IRegistrar>();

        foreach (var type in scanningTypes)
        {
            regs.AddRange(type.Assembly.GetTypes()
                .Where(t => t.IsAssignableTo(typeof(IRegistrar)) && t is { IsAbstract: false, IsInterface: false })
                .Select(Activator.CreateInstance)
                .Cast<IRegistrar>());
        }
        
        foreach (var registrar in regs)
        {
            registrar.RegisterServices(builder);
        }
    }
}