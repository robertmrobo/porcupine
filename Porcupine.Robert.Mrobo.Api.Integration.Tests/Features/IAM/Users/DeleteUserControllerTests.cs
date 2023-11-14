using System.Net;
using Shouldly;

namespace Porcupine.Robert.Mrobo.Api.Integration.Tests.Features.IAM.Users;

public class DeleteUserControllerTests : IClassFixture<CustomWebApplicationFactory>
{
    private readonly CustomWebApplicationFactory _factory;

    public DeleteUserControllerTests(CustomWebApplicationFactory factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task DeleteUser_ShouldReturnNoContent()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.DeleteAsync("/api/v1/users/4");

        // Assert
        response.StatusCode.ShouldBe(HttpStatusCode.NoContent);
    }
}