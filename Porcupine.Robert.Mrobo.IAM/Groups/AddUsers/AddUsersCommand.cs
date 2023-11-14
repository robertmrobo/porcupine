using MediatR;

namespace Porcupine.Robert.Mrobo.IAM.Groups.AddUsers;

public record AddUsersCommand : IRequest
{
    public int GroupId { get; init; }
    
    public IEnumerable<int> UserIds { get; init; } = new List<int>();
}