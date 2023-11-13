using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using Porcupine.Robert.Mrobo.Api.Features.IAM.Permissions.GetPermission;
using Porcupine.Robert.Mrobo.Api.Features.Shared;
using Porcupine.Robert.Mrobo.Api.Features.Shared.Constants;
using Porcupine.Robert.Mrobo.IAM.Permissions.GetPermissions;

namespace Porcupine.Robert.Mrobo.Api.Features.IAM.Permissions.GetPermissions;

/// <summary>
/// Represents the controller responsible for getting permissions.
/// </summary>
public class GetPermissionsController : ApiControllerBase
{
    /// <summary>
    /// Gets all Permissions.
    /// </summary>
    /// <returns>All Permissions.</returns>
    /// <response code="200">All Permissions.</response>
    [HttpGet("permissions")]
    [ProducesResponseType(typeof(IEnumerable<GetPermissionResult>), StatusCodes.Status200OK)]
    [OpenApiTag(OpenApiTagConstants.Permissions)]
    public async Task<ActionResult<IEnumerable<GetPermissionResult>>> GetGroups()
    {
        var groups = await Mediator.Send(new GetPermissionsQuery());
        var groupsResult = Mapper.Map<IEnumerable<GetPermissionResult>>(groups);
        return Ok(groupsResult);
    }
}