using MediatR;
using Porcupine.Robert.Mrobo.IAM.Permissions.Models;

namespace Porcupine.Robert.Mrobo.IAM.Permissions.CreatePermission;

public record CreatePermissionCommand : IRequest<Permission>
{
    public string Name { get; init; } = string.Empty;
    
    public string Description { get; init; } = string.Empty;
}