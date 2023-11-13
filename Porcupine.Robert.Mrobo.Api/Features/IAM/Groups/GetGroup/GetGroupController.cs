using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using Porcupine.Robert.Mrobo.Api.Features.IAM.Groups.GetGroups;
using Porcupine.Robert.Mrobo.Api.Features.Shared;
using Porcupine.Robert.Mrobo.Api.Features.Shared.Constants;
using Porcupine.Robert.Mrobo.IAM.Groups.GetGroup;
using Porcupine.Robert.Mrobo.IAM.Groups.Models;

namespace Porcupine.Robert.Mrobo.Api.Features.IAM.Groups.GetGroup;

/// <summary>
/// Represents a controller responsible for getting a single group.
/// </summary>
public class GetGroupController : ApiControllerBase
{
    /// <summary>
    /// Gets a Group by its Id.
    /// </summary>
    /// <param name="id">The Id of the Group to get.</param>
    /// <returns>The Group with the given Id.</returns>
    /// <response code="200">The Group with the given Id.</response>
    /// <response code="404">No Group with the given Id was found.</response>
    [HttpGet("groups/{id:int}")]
    [ProducesResponseType(typeof(GetGroupResult), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [OpenApiTag(OpenApiTagConstants.Groups)]
    public async Task<ActionResult<GetGroupResult>> GetGroup([FromRoute] int id)
    {
        var group = await Mediator.Send(new GetGroupQuery { Id = id });

        if (group is null)
        {
            return NotFound();
        }

        return Ok(Mapper.Map<GetGroupResult>(group));
    }
}