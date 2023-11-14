using System.Net;
using System.Text;
using System.Text.Json;
using Porcupine.Robert.Mrobo.Api.Features.IAM.Users.EditUser;
using Shouldly;

namespace Porcupine.Robert.Mrobo.Api.Integration.Tests.Features.IAM.Users;

public class EditUserControllerTests : IClassFixture<CustomWebApplicationFactory>
{
    private readonly CustomWebApplicationFactory _factory;

    public EditUserControllerTests(CustomWebApplicationFactory factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task EditUser_ShouldReturnOk()
    {
        // Arrange
        var client = _factory.CreateClient();
        var editUserRequestModel = new EditUserRequestModel
        {
            Name = "TestUser",
            ProfileImage = "test_image.jpg",
            Groups = new List<int> { 1 } // Replace with actual group ids
        };
        var content = new StringContent(JsonSerializer.Serialize(editUserRequestModel), Encoding.UTF8, "application/json");

        // Act
        var response = await client.PutAsync("/api/v1/users/3", content);

        // Assert
        response.StatusCode.ShouldBe(HttpStatusCode.Accepted);
    }
}