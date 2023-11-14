namespace Porcupine.Robert.Mrobo.Api.Features.IAM.Groups.GetGroup;

/// <summary>
/// Group users count result.
/// </summary>
public record GroupUsersCountResult
{
    public int GroupId { get; init; }
    
    public string GroupName { get; init; }
    
    public int UserCount { get; init; }
}