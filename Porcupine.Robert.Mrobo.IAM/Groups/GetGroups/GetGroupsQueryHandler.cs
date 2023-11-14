using MediatR;
using Microsoft.EntityFrameworkCore;
using Porcupine.Robert.Mrobo.IAM.Groups.Models;
using Porcupine.Robert.Mrobo.IAM.Persistence;

namespace Porcupine.Robert.Mrobo.IAM.Groups.GetGroups;

public class GetGroupsQueryHandler : IRequestHandler<GetGroupsQuery, List<Group>>
{
    private readonly IamDbContext _dbContext;

    public GetGroupsQueryHandler(IamDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Group>> Handle(GetGroupsQuery request, CancellationToken cancellationToken)
    {
        return await _dbContext.Groups.Include(g => g.Permissions).ToListAsync(cancellationToken);
    }
}