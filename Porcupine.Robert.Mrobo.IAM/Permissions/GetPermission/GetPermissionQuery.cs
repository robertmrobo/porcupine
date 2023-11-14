using MediatR;
using Porcupine.Robert.Mrobo.IAM.Permissions.Models;

namespace Porcupine.Robert.Mrobo.IAM.Permissions.GetPermission;

public record GetPermissionQuery : IRequest<Permission?>
{
    public int Id { get; set; }
}