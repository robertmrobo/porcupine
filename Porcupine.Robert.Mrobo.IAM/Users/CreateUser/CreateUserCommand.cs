using MediatR;
using Porcupine.Robert.Mrobo.IAM.Users.Models;

namespace Porcupine.Robert.Mrobo.IAM.Users.CreateUser;

public record CreateUserCommand : IRequest<User>
{
    public string Name { get; init; } = string.Empty;

    public string ProfileImage { get; init; } = string.Empty;

    public IEnumerable<int> Groups { get; init; } = new List<int>();
}