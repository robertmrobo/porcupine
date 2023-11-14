namespace Porcupine.Robert.Mrobo.Portal.IAM.Permissions.Models;

public record CreateEditPermissionModel
{
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
}