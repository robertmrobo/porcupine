using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using Porcupine.Robert.Mrobo.Api.Features.IAM.Users.GetUser;
using Porcupine.Robert.Mrobo.Api.Features.Shared;
using Porcupine.Robert.Mrobo.Api.Features.Shared.Constants;
using Porcupine.Robert.Mrobo.IAM.Users.CreateUser;

namespace Porcupine.Robert.Mrobo.Api.Features.IAM.Users.CreateUser;

/// <summary>
/// Represents a controller for creating a user.
/// </summary>
[OpenApiTag(OpenApiTagConstants.Users)]
public class CreateUserController : ApiControllerBase
{
    /// <summary>
    /// Creates a user.
    /// </summary>
    /// <param name="model">A model to create a user.</param>
    /// <returns></returns>
    [HttpPost("users")]
    public async Task<ActionResult> Create([FromBody] CreateUserRequestModel model)
    {
        var user = await Mediator.Send(new CreateUserCommand
        {
            Name = model.Name,
            ProfileImage = model.ProfileImage,
            Groups = model.Groups
        });
        
        var routeValues = new
        {
            action = nameof(GetUserController.GetUser),
            controller = nameof(GetUserController).Replace("Controller", string.Empty),
            id = user.Id
        };
        
        return CreatedAtRoute(routeValues, Mapper.Map<GetUserResult>(user));
    }
}