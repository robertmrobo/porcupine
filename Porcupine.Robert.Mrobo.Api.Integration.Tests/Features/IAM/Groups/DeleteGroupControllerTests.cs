using System.Net;
using Shouldly;

namespace Porcupine.Robert.Mrobo.Api.Integration.Tests.Features.IAM.Groups;

public class DeleteGroupControllerTests : IClassFixture<CustomWebApplicationFactory>
{
    private readonly CustomWebApplicationFactory _factory;

    public DeleteGroupControllerTests(CustomWebApplicationFactory factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task DeleteGroup_ShouldReturnNoContent()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.DeleteAsync("/api/v1/groups/4");

        // Assert
        response.StatusCode.ShouldBe(HttpStatusCode.NoContent);
    }
}