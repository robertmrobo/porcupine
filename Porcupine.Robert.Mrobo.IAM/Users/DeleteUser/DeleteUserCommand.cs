using MediatR;

namespace Porcupine.Robert.Mrobo.IAM.Users.DeleteUser;

public record DeleteUserCommand : IRequest
{
    public int Id { get; set; }
}