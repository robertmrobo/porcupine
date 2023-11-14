using System.Net;
using Shouldly;

namespace Porcupine.Robert.Mrobo.Api.Integration.Tests.Features.IAM.Users;

public class GetUserControllerTests : IClassFixture<CustomWebApplicationFactory>
{
    private readonly CustomWebApplicationFactory _factory;

    public GetUserControllerTests(CustomWebApplicationFactory factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task GetUser_ShouldReturnOk()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.GetAsync("/api/v1/users/2");

        // Assert
        response.StatusCode.ShouldBe(HttpStatusCode.OK);
    }
}