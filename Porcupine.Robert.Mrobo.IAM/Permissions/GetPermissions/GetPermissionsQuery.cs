using MediatR;
using Porcupine.Robert.Mrobo.IAM.Permissions.Models;

namespace Porcupine.Robert.Mrobo.IAM.Permissions.GetPermissions;

public record GetPermissionsQuery : IRequest<List<Permission>>;