namespace Porcupine.Robert.Mrobo.Api.Features.IAM.Groups.AddPermissions;

/// <summary>
/// A model to add permissions to a group.
/// </summary>
public record AddPermissionsRequestModel
{
    /// <summary>
    /// The Ids of the permissions to add to the group.
    /// </summary>
    public IEnumerable<int> PermissionIds { get; init; } = new List<int>();
}