namespace Porcupine.Robert.Mrobo.Api.Features.IAM.Users.CreateUser;

/// <summary>
/// Create user request model
/// </summary>
public record CreateUserRequestModel
{
    public string Name { get; init; } = string.Empty;

    public string ProfileImage { get; init; } = string.Empty;

    public IEnumerable<int> Groups { get; init; } = new List<int>();
}