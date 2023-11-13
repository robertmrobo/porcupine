using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using Porcupine.Robert.Mrobo.Api.Features.IAM.Permissions.GetPermission;
using Porcupine.Robert.Mrobo.Api.Features.Shared;
using Porcupine.Robert.Mrobo.Api.Features.Shared.Constants;
using Porcupine.Robert.Mrobo.IAM.Permissions.CreatePermission;

namespace Porcupine.Robert.Mrobo.Api.Features.IAM.Permissions.CreatePermission;

/// <summary>
/// Represents the controller responsible for creating a permission.
/// </summary>
[OpenApiTag(OpenApiTagConstants.Permissions)]
public class CreatePermissionController : ApiControllerBase
{
    /// <summary>
    /// Creates a new permission.
    /// </summary>
    /// <param name="model">The model to create a permission.</param>
    /// <returns></returns>
    [HttpPost("permissions")]
    public async Task<IActionResult> CreatePermission([FromBody] CreatePermissionRequestModel model)
    {
        var permission = await Mediator.Send(new CreatePermissionCommand()
        {
            Name = model.Name,
            Description = model.Description
        });

        var routeValues = new
        {
            action = nameof(GetPermissionController.GetGroup),
            controller = nameof(GetPermissionController).Replace("Controller", string.Empty),
            id = permission.Id
        };
        
        return CreatedAtRoute(routeValues, Mapper.Map<GetPermissionResult>(permission));
    }
}