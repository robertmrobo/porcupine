using MediatR;
using Porcupine.Robert.Mrobo.IAM.Groups.Models;

namespace Porcupine.Robert.Mrobo.IAM.Groups.CreateGroup;

public record CreateGroupCommand : IRequest<Group>
{
    public string Name { get; init; } = string.Empty;
    
    public string Description { get; init; } = string.Empty;

    public List<int> PermissionsIds { get; init; } = new();
}