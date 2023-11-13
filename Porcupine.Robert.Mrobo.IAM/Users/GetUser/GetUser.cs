using MediatR;
using Microsoft.EntityFrameworkCore;
using Porcupine.Robert.Mrobo.IAM.Persistence;
using Porcupine.Robert.Mrobo.IAM.Users.Models;

namespace Porcupine.Robert.Mrobo.IAM.Users.GetUser;

public record GetUserQuery : IRequest<User?>
{
    public int Id { get; set; }
}

public class GetUserQueryHandler : IRequestHandler<GetUserQuery, User?>
{
    private readonly IamDbContext _dbContext;

    public GetUserQueryHandler(IamDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<User?> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        return await _dbContext.Users.Include(u => u.Groups)
            .FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);
    }
}