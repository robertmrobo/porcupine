using MediatR;
using Microsoft.EntityFrameworkCore;
using Porcupine.Robert.Mrobo.IAM.Persistence;
using Porcupine.Robert.Mrobo.IAM.Users.Models;

namespace Porcupine.Robert.Mrobo.IAM.Users.GetUsers;

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