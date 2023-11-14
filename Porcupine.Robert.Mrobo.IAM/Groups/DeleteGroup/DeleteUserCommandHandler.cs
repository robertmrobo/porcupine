using MediatR;
using Microsoft.EntityFrameworkCore;
using Porcupine.Robert.Mrobo.IAM.Groups.Models;
using Porcupine.Robert.Mrobo.IAM.Persistence;
using Porcupine.Robert.Mrobo.Shared.Exceptions;

namespace Porcupine.Robert.Mrobo.IAM.Groups.DeleteGroup;

public class DeleteUserCommandHandler : IRequestHandler<DeleteGroupCommand>
{
    private readonly IamDbContext _context;

    public DeleteUserCommandHandler(IamDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteGroupCommand request, CancellationToken cancellationToken)
    {
        var group = await _context.Groups
            .Include(x => x.Users)
            .Include(x => x.Permissions)
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (group == null)
        {
            throw new NotFoundException(nameof(Group), request.Id);
        }

        _context.Groups.Remove(group);

        await _context.SaveChangesAsync(cancellationToken);
    }
}