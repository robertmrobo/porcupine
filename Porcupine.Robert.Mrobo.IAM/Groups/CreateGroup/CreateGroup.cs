using MediatR;
using Microsoft.EntityFrameworkCore;
using Porcupine.Robert.Mrobo.IAM.Groups.Models;
using Porcupine.Robert.Mrobo.IAM.Persistence;

namespace Porcupine.Robert.Mrobo.IAM.Groups.CreateGroup;

public record CreateGroupCommand : IRequest<Group>
{
    public string Name { get; init; } = string.Empty;
    
    public string Description { get; init; } = string.Empty;

    public List<int> PermissionsIds { get; init; } = new();
}

public class CreateGroupCommandHandler : IRequestHandler<CreateGroupCommand, Group>
{
    private readonly IamDbContext _dbContext;

    public CreateGroupCommandHandler(IamDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Group> Handle(CreateGroupCommand request, CancellationToken cancellationToken)
    {
        var groupPermissions = new HashSet<int>(request.PermissionsIds);
        
        var permissions = await _dbContext.Permissions
            .Where(p => groupPermissions.Contains(p.Id))
            .ToListAsync(cancellationToken);
        
        var group = new Group
        {
            Name = request.Name,
            Description = request.Description,
            Permissions = permissions.ToHashSet()
        };
        
        _dbContext.Groups.Add(group);
        
        await _dbContext.SaveChangesAsync(cancellationToken);

        return group;
    }
}