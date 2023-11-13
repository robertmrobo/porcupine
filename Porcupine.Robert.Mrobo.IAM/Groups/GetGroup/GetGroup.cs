using MediatR;
using Porcupine.Robert.Mrobo.IAM.Groups.Models;
using Porcupine.Robert.Mrobo.IAM.Persistence;

namespace Porcupine.Robert.Mrobo.IAM.Groups.GetGroup;

public class GetGroupQuery : IRequest<Group?>
{
    public int Id { get; init; }
}

public class GetGroupQueryHandler : IRequestHandler<GetGroupQuery, Group?>
{
    private readonly IamDbContext _dbContext;
    
    public GetGroupQueryHandler(IamDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Group?> Handle(GetGroupQuery request, CancellationToken cancellationToken)
    {
        return await _dbContext.Groups.FindAsync(new object[] { request.Id }, cancellationToken);
    }
}