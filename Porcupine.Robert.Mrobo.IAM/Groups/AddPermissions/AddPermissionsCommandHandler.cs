using MediatR;
using Microsoft.EntityFrameworkCore;
using Porcupine.Robert.Mrobo.IAM.Persistence;
using Porcupine.Robert.Mrobo.Shared.Exceptions;

namespace Porcupine.Robert.Mrobo.IAM.Groups.AddPermissions;

public class AddPermissionsCommandHandler : IRequestHandler<AddPermissionsCommand>
{
    private readonly IamDbContext _dbContext;

    public AddPermissionsCommandHandler(IamDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Handle(AddPermissionsCommand request, CancellationToken cancellationToken)
    {
        var group = await _dbContext.Groups.FindAsync(new object[] { request.GroupId }, cancellationToken);

        if (group == null)
        {
            throw new NotFoundException($"Group with id {request.GroupId} not found.");
        }

        var permissions = await _dbContext.Permissions
            .Where(p => request.PermissionIds.Contains(p.Id))
            .ToListAsync(cancellationToken);

        foreach (var permission in permissions)
        {
            group.Permissions.Add(permission);
        }

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}