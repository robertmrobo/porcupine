namespace Porcupine.Robert.Mrobo.Api.Features.IAM.Permissions.CreatePermission;

/// <summary>
/// Create permission request model.
/// </summary>
public record CreatePermissionRequestModel
{
    public string Name { get; init; } = string.Empty;

    public string Description { get; init; } = string.Empty;
}