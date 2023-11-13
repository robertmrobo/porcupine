using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using Porcupine.Robert.Mrobo.Api.Features.IAM.Groups.GetGroup;
using Porcupine.Robert.Mrobo.Api.Features.IAM.Groups.GetGroups;
using Porcupine.Robert.Mrobo.Api.Features.Shared;
using Porcupine.Robert.Mrobo.Api.Features.Shared.Constants;
using Porcupine.Robert.Mrobo.IAM.Groups.CreateGroup;

namespace Porcupine.Robert.Mrobo.Api.Features.IAM.Groups.CreateGroup;

/// <summary>
/// Represents a controller responsible for creating a new Group.
/// </summary>
[OpenApiTag(OpenApiTagConstants.Groups)]
public class CreateGroupController : ApiControllerBase
{
    /// <summary>
    /// Creates a Group
    /// </summary>
    /// <param name="model">A model to create a Group.</param>
    /// <returns></returns>
    [HttpPost("groups")]
    public async Task<ActionResult> Create([FromBody] CreateGroupRequestModel model)
    {
        var group = await Mediator.Send(new CreateGroupCommand
        {
            Name = model.Name,
            Description = model.Description,
            PermissionsIds = model.PermissionsIds
        });

        var routeValues = new
        {
            action = nameof(GetGroupController.GetGroup),
            controller = nameof(GetGroupController).Replace("Controller", string.Empty),
            id = group.Id
        };
        
        return CreatedAtRoute(routeValues, Mapper.Map<GetGroupResult>(group));
    }
}