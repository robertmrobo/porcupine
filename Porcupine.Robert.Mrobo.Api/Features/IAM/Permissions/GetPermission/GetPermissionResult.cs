namespace Porcupine.Robert.Mrobo.Api.Features.IAM.Permissions.GetPermission;

/// <summary>
/// Gets a Permission by its Id.
/// </summary>
public record GetPermissionResult
{
    public int Id { get; init; }
    
    public string Name { get; init; } = string.Empty;
    
    public string Description { get; init; } = string.Empty;
}