using MediatR;
using Microsoft.EntityFrameworkCore;
using Porcupine.Robert.Mrobo.IAM.Permissions.Models;
using Porcupine.Robert.Mrobo.IAM.Persistence;

namespace Porcupine.Robert.Mrobo.IAM.Permissions.GetPermissions;

public class GetPermissionsQueryHandler : IRequestHandler<GetPermissionsQuery, List<Permission>>
{
    private readonly IamDbContext _dbContext;

    public GetPermissionsQueryHandler(IamDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Permission>> Handle(GetPermissionsQuery request, CancellationToken cancellationToken)
    {
        return await _dbContext.Permissions.ToListAsync(cancellationToken);
    }
}