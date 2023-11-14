using MediatR;
using Porcupine.Robert.Mrobo.IAM.Groups.Models;

namespace Porcupine.Robert.Mrobo.IAM.Groups.GetGroups;

public record GetGroupsQuery : IRequest<List<Group>>;