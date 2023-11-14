using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using Porcupine.Robert.Mrobo.Api.Features.Shared;
using Porcupine.Robert.Mrobo.Api.Features.Shared.Constants;
using Porcupine.Robert.Mrobo.IAM.Users.DeleteUser;

namespace Porcupine.Robert.Mrobo.Api.Features.IAM.Users.DeleteUser;

/// <summary>
/// Request model for deleting a user.
/// </summary>
[OpenApiTag(OpenApiTagConstants.Users)]
public class DeleteUserController : ApiControllerBase
{
    /// <summary>
    /// Deletes a user.
    /// </summary>
    /// <param name="id">User id</param>
    /// <returns></returns>
    [HttpDelete("users/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await Mediator.Send(new DeleteUserCommand { Id = id });
        return NoContent();
    }
}