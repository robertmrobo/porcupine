using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using Porcupine.Robert.Mrobo.Api.Features.Shared;
using Porcupine.Robert.Mrobo.Api.Features.Shared.Constants;
using Porcupine.Robert.Mrobo.IAM.Users.GetUser;

namespace Porcupine.Robert.Mrobo.Api.Features.IAM.Users.GetUser;

/// <summary>
/// Represents a controller responsible for getting a user.
/// </summary>
[OpenApiTag(OpenApiTagConstants.Users)]
public class GetUserController : ApiControllerBase
{
    /// <summary>
    /// Gets a user by its Id.
    /// </summary>
    /// <param name="id">The Id of the user to get.</param>
    /// <returns>The user with the given Id.</returns>
    /// <response code="200">The user with the given Id.</response>
    /// <response code="404">No user with the given Id was found.</response>
    [HttpGet("users/{id:int}")]
    [ProducesResponseType(typeof(GetUserResult), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GetUserResult>> GetUser([FromRoute] int id)
    {
        var user = await Mediator.Send(new GetUserQuery { Id = id });

        if (user is null)
        {
            return NotFound();
        }

        return Ok(Mapper.Map<GetUserResult>(user));
    }
}