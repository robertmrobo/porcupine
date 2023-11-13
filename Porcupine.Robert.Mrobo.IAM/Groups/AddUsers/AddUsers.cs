using MediatR;
using Microsoft.EntityFrameworkCore;
using Porcupine.Robert.Mrobo.IAM.Groups.AddPermissions;
using Porcupine.Robert.Mrobo.IAM.Persistence;
using Porcupine.Robert.Mrobo.IAM.Users.Models;

namespace Porcupine.Robert.Mrobo.IAM.Groups.AddUsers;

public record AddUsersCommand : IRequest
{
    public int GroupId { get; init; }
    
    public IEnumerable<int> UserIds { get; init; } = new List<int>();
}

public class AddUsersCommandHandler : IRequestHandler<AddUsersCommand>
{
    private readonly IamDbContext _dbContext;

    public AddUsersCommandHandler(IamDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Handle(AddUsersCommand request, CancellationToken cancellationToken)
    {
        var group = await _dbContext.Groups.FindAsync(new object[] { request.GroupId }, cancellationToken);

        if (group == null)
        {
            throw new NotFoundException($"Group with id {request.GroupId} not found.");
        }

        var users = await _dbContext.Users
            .Where(u => request.UserIds.Contains(u.Id))
            .ToListAsync(cancellationToken);

        group.Users ??= new HashSet<User>();
        foreach (var user in users)
        {
            group.Users.Add(user);
        }

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}