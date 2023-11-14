using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using Porcupine.Robert.Mrobo.Api.Features.Shared;
using Porcupine.Robert.Mrobo.Api.Features.Shared.Constants;
using Porcupine.Robert.Mrobo.IAM.Groups.DeleteGroup;

namespace Porcupine.Robert.Mrobo.Api.Features.IAM.Groups.DeleteGroup;

/// <summary>
/// Request model for deleting a group.
/// </summary>
[OpenApiTag(OpenApiTagConstants.Groups)]
public class DeleteGroupController : ApiControllerBase
{
    /// <summary>
    /// Deletes a group.
    /// </summary>
    /// <param name="id">Group id</param>
    /// <returns></returns>
    [HttpDelete("groups/{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await Mediator.Send(new DeleteGroupCommand
        {
            Id = id
        });

        return NoContent();
    }
}