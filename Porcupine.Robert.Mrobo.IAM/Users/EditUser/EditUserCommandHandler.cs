using MediatR;
using Microsoft.EntityFrameworkCore;
using Porcupine.Robert.Mrobo.IAM.Persistence;
using Porcupine.Robert.Mrobo.IAM.Users.Models;
using Porcupine.Robert.Mrobo.Shared.Exceptions;

namespace Porcupine.Robert.Mrobo.IAM.Users.EditUser;

public class EditUserCommandHandler : IRequestHandler<EditUserCommand, User>
{
    private readonly IamDbContext _context;

    public EditUserCommandHandler(IamDbContext context)
    {
        _context = context;
    }

    public async Task<User> Handle(EditUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _context.Users
            .Include(x => x.Groups)
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (user == null)
        {
            throw new NotFoundException(nameof(User), request.Id);
        }

        user.Name = request.Name;
        user.ProfileImage = request.ProfileImage;

        var groups = await _context.Groups
            .Where(x => request.Groups.Contains(x.Id))
            .ToListAsync(cancellationToken);

        user.Groups = groups.ToHashSet();
        await _context.SaveChangesAsync(cancellationToken);

        return user;
    }
}