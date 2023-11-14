using System.Text;
using System.Text.Json;
using Porcupine.Robert.Mrobo.Api.Features.IAM.Users.CreateUser;
using Porcupine.Robert.Mrobo.Api.Features.IAM.Users.GetUser;
using Shouldly;

namespace Porcupine.Robert.Mrobo.Api.Integration.Tests.Features.IAM.Users
{
    public class CreateUserControllerTests : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly HttpClient _client;

        public CreateUserControllerTests(CustomWebApplicationFactory factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task CreateUserController_ShouldCreateUser()
        {
            // Arrange
            var createUserRequestModel = new CreateUserRequestModel
            {
                Name = "TestUser",
                ProfileImage = "test_image.jpg",
                Groups = new List<int> { 1 } // Replace with actual group ids
            };

            var jsonContent = new StringContent(JsonSerializer.Serialize(createUserRequestModel, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            }), Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync("/api/v1/users", jsonContent);

            // Assert
            response.EnsureSuccessStatusCode();
            
            response.StatusCode.ShouldBe(System.Net.HttpStatusCode.Created);
            
            var responseContent = await response.Content.ReadAsStringAsync();
            var createdUser = JsonSerializer.Deserialize<GetUserResult>(responseContent);

            createdUser.ShouldNotBeNull();
        }
    }
}