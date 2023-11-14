using MediatR;
using Porcupine.Robert.Mrobo.IAM.Groups.Models;

namespace Porcupine.Robert.Mrobo.IAM.Groups.GetGroup;

public record GetGroupQuery : IRequest<Group?>
{
    public int Id { get; init; }
}