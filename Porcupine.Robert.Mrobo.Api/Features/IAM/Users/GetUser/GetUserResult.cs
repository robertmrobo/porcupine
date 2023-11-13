using Porcupine.Robert.Mrobo.Api.Features.IAM.Groups.GetGroups;

namespace Porcupine.Robert.Mrobo.Api.Features.IAM.Users.GetUser;

/// <summary>
/// Get user result.
/// </summary>
public record GetUserResult
{
    public int Id { get; init; }

    public string Name { get; init; } = string.Empty;

    public string ProfileImage { get; init; } = string.Empty;

    public IEnumerable<GetGroupResult>? Groups { get; init; }
}