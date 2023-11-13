using Microsoft.EntityFrameworkCore;
using Porcupine.Robert.Mrobo.IAM.Persistence;
using Porcupine.Robert.Mrobo.Shared;

namespace Porcupine.Robert.Mrobo.Api.Utilities.Registrars;

public class DatabaseRegistrar : IRegistrar
{
    public void RegisterServices(WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<IamDbContext>(opt => 
            opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
    }
}