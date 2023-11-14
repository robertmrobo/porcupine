using System.Net;
using System.Text;
using System.Text.Json;
using Porcupine.Robert.Mrobo.IAM.Groups.CreateGroup;
using Shouldly;

namespace Porcupine.Robert.Mrobo.Api.Integration.Tests.Features.IAM.Groups;

public class CreateGroupControllerTests : IClassFixture<CustomWebApplicationFactory>
{
    private readonly CustomWebApplicationFactory _factory;

    public CreateGroupControllerTests(CustomWebApplicationFactory factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task CreateGroup_ShouldReturnCreated()
    {
        // Arrange
        var client = _factory.CreateClient();
        var command = new CreateGroupCommand
        {
            Name = "Test Group",
            Description = "Test Group Description"
        };
        var content = new StringContent(JsonSerializer.Serialize(command), Encoding.UTF8, "application/json");

        // Act
        var response = await client.PostAsync("/api/v1/groups", content);

        // Assert
        response.StatusCode.ShouldBe(HttpStatusCode.Created);
    }
}