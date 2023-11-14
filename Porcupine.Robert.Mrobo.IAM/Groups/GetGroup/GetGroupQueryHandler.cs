using MediatR;
using Microsoft.EntityFrameworkCore;
using Porcupine.Robert.Mrobo.IAM.Groups.Models;
using Porcupine.Robert.Mrobo.IAM.Persistence;

namespace Porcupine.Robert.Mrobo.IAM.Groups.GetGroup;

public class GetGroupQueryHandler : IRequestHandler<GetGroupQuery, Group?>
{
    private readonly IamDbContext _dbContext;
    
    public GetGroupQueryHandler(IamDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Group?> Handle(GetGroupQuery request, CancellationToken cancellationToken)
    {
        return await _dbContext.Groups.Include(g => g.Permissions)
            .FirstOrDefaultAsync(g => g.Id == request.Id, cancellationToken);
    }
}