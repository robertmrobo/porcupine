using MediatR;
using Microsoft.EntityFrameworkCore;
using Porcupine.Robert.Mrobo.IAM.Persistence;

namespace Porcupine.Robert.Mrobo.IAM.Groups.GetGroupsCounts;

public class GetGroupUsersCountsQueryHandler : IRequestHandler<GetGroupsUserCountsQuery,List<GroupUsersCountDto>>
{
    private readonly IamDbContext _dbContext;
    
    public GetGroupUsersCountsQueryHandler(IamDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<GroupUsersCountDto>> Handle(GetGroupsUserCountsQuery request, CancellationToken cancellationToken)
    {
        var groupUserCounts = await _dbContext.Groups
            .Select(group => new GroupUsersCountDto
            {
                GroupId = group.Id,
                GroupName = group.Name,
                UserCount = group.Users.Count
            })
            .ToListAsync(cancellationToken: cancellationToken);
        
        return groupUserCounts;
    }
}