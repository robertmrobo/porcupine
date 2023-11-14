using MediatR;
using Porcupine.Robert.Mrobo.IAM.Permissions.Models;
using Porcupine.Robert.Mrobo.IAM.Persistence;

namespace Porcupine.Robert.Mrobo.IAM.Permissions.GetPermission;

public class GetPermissionQueryHandler : IRequestHandler<GetPermissionQuery, Permission?>
{
    private readonly IamDbContext _dbContext;

    public GetPermissionQueryHandler(IamDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Permission?> Handle(GetPermissionQuery request, CancellationToken cancellationToken)
    {
        return await _dbContext.Permissions.FindAsync(new object[] { request.Id }, cancellationToken);
    }
}