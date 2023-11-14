using MediatR;

namespace Porcupine.Robert.Mrobo.IAM.Groups.DeleteGroup;

public record DeleteGroupCommand : IRequest
{
    public int Id { get; set; }
}