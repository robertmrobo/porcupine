using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using Porcupine.Robert.Mrobo.Api.Features.Shared;
using Porcupine.Robert.Mrobo.Api.Features.Shared.Constants;
using Porcupine.Robert.Mrobo.IAM.Groups.AddPermissions;

namespace Porcupine.Robert.Mrobo.Api.Features.IAM.Groups.AddPermissions;

/// <summary>
/// Represents a controller responsible for adding permissions to a group.
/// </summary>
[OpenApiTag(OpenApiTagConstants.Groups)]
public class AddPermissionsController : ApiControllerBase
{
    /// <summary>
    /// Adds permissions to a group.
    /// </summary>
    /// <param name="id">Group Id</param>
    /// <param name="model">A model to add permissions to a group.</param>
    /// <returns></returns>
    [HttpPost("groups/{id:int}/permissions")]
    public async Task<ActionResult> AddPermissions(int id, [FromBody] AddPermissionsRequestModel model)
    {
        await Mediator.Send(new AddPermissionsCommand
        {
            GroupId = id,
            PermissionIds = model.PermissionIds
        });

        return Ok();
    }
}