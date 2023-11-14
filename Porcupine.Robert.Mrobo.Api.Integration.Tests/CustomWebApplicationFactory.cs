using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Porcupine.Robert.Mrobo.IAM.Groups.Models;
using Porcupine.Robert.Mrobo.IAM.Persistence;
using Porcupine.Robert.Mrobo.IAM.Users.Models;

namespace Porcupine.Robert.Mrobo.Api.Integration.Tests;

public class CustomWebApplicationFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            // Replace the database with an in-memory database for testing
            var serviceProvider = services
                .SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<IamDbContext>));

            if (serviceProvider != null)
            {
                services.Remove(serviceProvider);
            }

            services.AddDbContext<IamDbContext>(options =>
            {
                options.UseInMemoryDatabase("InMemoryDbForTesting");
            });

            var sp = services.BuildServiceProvider();

            using (var scope = sp.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<IamDbContext>();

                db.Database.EnsureCreated();

                try
                {
                    db.Groups.AddRange(CreateGroups());
                    db.Users.AddRange(CreateUsers());

                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        });
    }

    private static IEnumerable<User> CreateUsers()
    {
        var users = new List<User>();
        for(var i = 1; i < 6; i++)
        {
            users.Add(new User
            {
                Id = i,
                Name = $"Test User {i}"
            });
        }

        return users;
    }
    
    private static IEnumerable<Group> CreateGroups()
    {
        var groups = new List<Group>();
        for(var i = 1; i < 6; i++)
        {
            groups.Add(new Group
            {
                Id = i,
                Name = $"Test Group {i}"
            });
        }

        return groups;
    }
}