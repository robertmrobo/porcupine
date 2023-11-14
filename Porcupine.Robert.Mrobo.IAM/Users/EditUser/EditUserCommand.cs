using MediatR;
using Porcupine.Robert.Mrobo.IAM.Users.Models;

namespace Porcupine.Robert.Mrobo.IAM.Users.EditUser;

public record EditUserCommand : IRequest<User>
{
    public int Id { get; init; }

    public string Name { get; init; } = string.Empty;

    public string ProfileImage { get; init; } = string.Empty;

    public IEnumerable<int> Groups { get; init; } = new List<int>();
}