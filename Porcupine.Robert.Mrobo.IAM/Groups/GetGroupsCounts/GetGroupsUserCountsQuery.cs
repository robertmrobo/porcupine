using MediatR;

namespace Porcupine.Robert.Mrobo.IAM.Groups.GetGroupsCounts;

public record GetGroupsUserCountsQuery : IRequest<List<GroupUsersCountDto>>;