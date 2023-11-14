namespace Porcupine.Robert.Mrobo.Api.Features.IAM.Users.EditUser;

/// <summary>
/// Edit user request model.
/// </summary>
public record EditUserRequestModel
{
    public string Name { get; init; } = string.Empty;

    public string ProfileImage { get; init; } = string.Empty;

    public IEnumerable<int> Groups { get; init; } = new List<int>();
}