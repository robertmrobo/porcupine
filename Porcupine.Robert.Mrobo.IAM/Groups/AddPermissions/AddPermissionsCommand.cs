using MediatR;

namespace Porcupine.Robert.Mrobo.IAM.Groups.AddPermissions;

public record AddPermissionsCommand : IRequest
{
    public int GroupId { get; init; }

    public IEnumerable<int> PermissionIds { get; init; } = new List<int>();
}