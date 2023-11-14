using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using Porcupine.Robert.Mrobo.Api.Features.Shared;
using Porcupine.Robert.Mrobo.Api.Features.Shared.Constants;
using Porcupine.Robert.Mrobo.IAM.Permissions.GetPermission;

namespace Porcupine.Robert.Mrobo.Api.Features.IAM.Permissions.GetPermission;

/// <summary>
/// Represents the controller responsible for getting a permission.
/// </summary>
public class GetPermissionController : ApiControllerBase
{
    /// <summary>
    /// Gets a Permission by its Id.
    /// </summary>
    /// <param name="id">The Id of the Permission to get.</param>
    /// <returns>The Permission with the given Id.</returns>
    /// <response code="200">The Permission with the given Id.</response>
    /// <response code="404">No Permission with the given Id was found.</response>
    [HttpGet("permissions/{id:int}")]
    [ProducesResponseType(typeof(GetPermissionResult), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [OpenApiTag(OpenApiTagConstants.Permissions)]
    public async Task<ActionResult<GetPermissionResult>> GetGroup([FromRoute] int id)
    {
        var permission = await Mediator.Send(new GetPermissionQuery { Id = id });

        if (permission is null)
        {
            return NotFound();
        }

        return Ok(Mapper.Map<GetPermissionResult>(permission));
    }
}