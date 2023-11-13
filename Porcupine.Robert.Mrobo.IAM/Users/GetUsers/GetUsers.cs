using MediatR;
using Microsoft.EntityFrameworkCore;
using Porcupine.Robert.Mrobo.IAM.Persistence;
using Porcupine.Robert.Mrobo.IAM.Users.Models;

namespace Porcupine.Robert.Mrobo.IAM.Users.GetUsers;

public record GetUsersQuery : IRequest<List<User>>;

public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, List<User>>
{
    private readonly IamDbContext _dbContext;

    public GetUsersQueryHandler(IamDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<User>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        return await _dbContext.Users.Include(u => u.Groups).ToListAsync(cancellationToken);
    }
}