using MediatR;
using Microsoft.EntityFrameworkCore;
using Porcupine.Robert.Mrobo.IAM.Persistence;
using Porcupine.Robert.Mrobo.IAM.Users.Models;
using Porcupine.Robert.Mrobo.Shared.Exceptions;

namespace Porcupine.Robert.Mrobo.IAM.Users.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, User>
{
    private readonly IamDbContext _dbContext;
    private const string DefaultProfileImage = "https://robohash.org/porcupine.png?size=200x200&set=set1";
    private const int GuestsGroupId = 1;

    public CreateUserCommandHandler(IamDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var userGroups = new HashSet<int>(request.Groups);
        
        // If a user is a guest, he/she can only be in the Guests group
        if (userGroups.Contains(GuestsGroupId) && userGroups.Count > 1)
        {
            throw new BadRequestException("Guests can only be in the Guests group.");
        }
        
        //If no groups are specified, add the user to the Guests group
        var groups = userGroups.Any()
            ? await _dbContext.Groups
                .Where(g => userGroups.Contains(g.Id))
                .ToListAsync(cancellationToken)
            : await _dbContext.Groups
                .Where(g => g.Id == GuestsGroupId)
                .ToListAsync(cancellationToken);
        
        if (!groups.Any())
        {
            throw new NotFoundException("No groups found.");
        }

        var user = new User
        {
            Name = request.Name,
            ProfileImage = string.IsNullOrEmpty(request.ProfileImage) ? DefaultProfileImage : request.ProfileImage,
            Groups = groups.ToHashSet()
        };
        
        _dbContext.Users.Add(user);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return user;
    }
}