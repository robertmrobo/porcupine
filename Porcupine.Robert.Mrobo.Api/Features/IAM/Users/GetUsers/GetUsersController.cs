using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using Porcupine.Robert.Mrobo.Api.Features.IAM.Users.GetUser;
using Porcupine.Robert.Mrobo.Api.Features.Shared;
using Porcupine.Robert.Mrobo.Api.Features.Shared.Constants;
using Porcupine.Robert.Mrobo.IAM.Users.GetUsers;

namespace Porcupine.Robert.Mrobo.Api.Features.IAM.Users.GetUsers;

/// <summary>
/// Represents a controller responsible for getting all users.
/// </summary>
[OpenApiTag(OpenApiTagConstants.Users)]
public class GetUsersController : ApiControllerBase
{
    /// <summary>
    /// Gets all users.
    /// </summary>
    /// <returns>All users.</returns>
    /// <response code="200">All users.</response>
    [HttpGet("users")]
    [ProducesResponseType(typeof(IEnumerable<GetUserResult>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<GetUserResult>>> GetUsers()
    {
        var users = await Mediator.Send(new GetUsersQuery());
        var usersResult = Mapper.Map<IEnumerable<GetUserResult>>(users);
        return Ok(usersResult);
    }
}