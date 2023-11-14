using MediatR;
using Porcupine.Robert.Mrobo.IAM.Users.Models;

namespace Porcupine.Robert.Mrobo.IAM.Users.GetUser;

public record GetUserQuery : IRequest<User?>
{
    public int Id { get; set; }
}