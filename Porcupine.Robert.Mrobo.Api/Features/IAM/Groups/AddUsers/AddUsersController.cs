using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using Porcupine.Robert.Mrobo.Api.Features.Shared;
using Porcupine.Robert.Mrobo.Api.Features.Shared.Constants;
using Porcupine.Robert.Mrobo.IAM.Groups.AddUsers;

namespace Porcupine.Robert.Mrobo.Api.Features.IAM.Groups.AddUsers;

/// <summary>
/// Represents a controller responsible for adding users to a group.
/// </summary>
[OpenApiTag(OpenApiTagConstants.Groups)]
public class AddUsersController : ApiControllerBase
{
    /// <summary>
    /// Adds users to a group.
    /// </summary>
    /// <param name="id">Group Id</param>
    /// <param name="model">A model to add users to a group.</param>
    /// <returns></returns>
    [HttpPost("groups/{id:int}/users")]
    public async Task<ActionResult> AddUsers(int id, [FromBody] AddUsersRequestModel model)
    {
        await Mediator.Send(new AddUsersCommand
        {
            GroupId = id,
            UserIds = model.UserIds
        });

        return Ok();
    }
}