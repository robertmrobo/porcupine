using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using Porcupine.Robert.Mrobo.Api.Features.Shared;
using Porcupine.Robert.Mrobo.Api.Features.Shared.Constants;
using Porcupine.Robert.Mrobo.IAM.Groups.GetGroups;

namespace Porcupine.Robert.Mrobo.Api.Features.IAM.Groups.GetGroups;

/// <summary>
/// Represents a controller responsible for getting all groups.
/// </summary>
[OpenApiTag(OpenApiTagConstants.Groups)]
public class GetGroupsController : ApiControllerBase
{
    /// <summary>
    /// Gets all Groups.
    /// </summary>
    /// <returns>All Groups.</returns>
    /// <response code="200">All Groups.</response>
    [HttpGet("groups")]
    [ProducesResponseType(typeof(IEnumerable<GetGroupResult>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<GetGroupResult>>> GetGroups()
    {
        var groups = await Mediator.Send(new GetGroupsQuery());
        var groupsResult = Mapper.Map<IEnumerable<GetGroupResult>>(groups);
        return Ok(groupsResult);
    }
}