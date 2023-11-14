using MediatR;
using Porcupine.Robert.Mrobo.IAM.Users.Models;

namespace Porcupine.Robert.Mrobo.IAM.Users.GetUsers;

public record GetUsersQuery : IRequest<List<User>>;