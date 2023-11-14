using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using Porcupine.Robert.Mrobo.Api.Features.Shared;
using Porcupine.Robert.Mrobo.Api.Features.Shared.Constants;
using Porcupine.Robert.Mrobo.IAM.Groups.GetGroupsCounts;

namespace Porcupine.Robert.Mrobo.Api.Features.IAM.Groups.GetGroup;

/// <summary>
/// Represents a controller responsible for getting a count of users per group.
/// </summary>
[OpenApiTag(OpenApiTagConstants.Groups)]
public class GetGroupsCountsController : ApiControllerBase
{
    /// <summary>
    /// Gets a count of users per group.
    /// </summary>
    /// <returns>A count of users per group.</returns>
    /// <response code="200">A count of users per group.</response>
    [HttpGet("groups/users/count")]
    [ProducesResponseType(typeof(GroupUsersCountResult), StatusCodes.Status200OK)]
    [OpenApiTag(OpenApiTagConstants.Groups)]
    public async Task<ActionResult<GroupUsersCountResult>> GetGroup()
    {
        var group = await Mediator.Send(new GetGroupsUserCountsQuery());

        return Ok(Mapper.Map<List<GroupUsersCountResult>>(group));
    }
}