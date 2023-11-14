using System.Net;
using Shouldly;

namespace Porcupine.Robert.Mrobo.Api.Integration.Tests.Features.IAM.Groups;

public class GetGroupsControllerTests : IClassFixture<CustomWebApplicationFactory>
{
    private readonly CustomWebApplicationFactory _factory;

    public GetGroupsControllerTests(CustomWebApplicationFactory factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task GetGroups_ShouldReturnOk()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.GetAsync("/api/v1/groups");

        // Assert
        response.StatusCode.ShouldBe(HttpStatusCode.OK);
    }
}