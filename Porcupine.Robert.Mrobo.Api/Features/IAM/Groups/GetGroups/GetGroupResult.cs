using Porcupine.Robert.Mrobo.Api.Features.IAM.Permissions.GetPermission;

namespace Porcupine.Robert.Mrobo.Api.Features.IAM.Groups.GetGroups;

/// <summary>
/// Get group result.
/// </summary>
public record GetGroupResult
{
    public int Id { get; init; }
    
    public string Name { get; init; } = string.Empty;
    
    public string Description { get; init; } = string.Empty;
    
    public IEnumerable<GetPermissionResult>? Permissions { get; init; }
}