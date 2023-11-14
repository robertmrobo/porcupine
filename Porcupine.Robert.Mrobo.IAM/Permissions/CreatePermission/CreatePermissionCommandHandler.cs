using MediatR;
using Porcupine.Robert.Mrobo.IAM.Permissions.Models;
using Porcupine.Robert.Mrobo.IAM.Persistence;

namespace Porcupine.Robert.Mrobo.IAM.Permissions.CreatePermission;

public class CreatePermissionCommandHandler : IRequestHandler<CreatePermissionCommand, Permission>
{
    private readonly IamDbContext _dbContext;

    public CreatePermissionCommandHandler(IamDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Permission> Handle(CreatePermissionCommand request, CancellationToken cancellationToken)
    {
        var permission = new Permission
        {
            Name = request.Name,
            Description = request.Description
        };
        
        _dbContext.Permissions.Add(permission);
        
        await _dbContext.SaveChangesAsync(cancellationToken);

        return permission;
    }
}