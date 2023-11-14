using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using Porcupine.Robert.Mrobo.Api.Features.IAM.Users.GetUser;
using Porcupine.Robert.Mrobo.Api.Features.Shared;
using Porcupine.Robert.Mrobo.Api.Features.Shared.Constants;
using Porcupine.Robert.Mrobo.IAM.Users.EditUser;

namespace Porcupine.Robert.Mrobo.Api.Features.IAM.Users.EditUser;

/// <summary>
/// Request model for editing a user.
/// </summary>
[OpenApiTag(OpenApiTagConstants.Users)]
public class EditUserController : ApiControllerBase
{
    /// <summary>
    /// Edits a user.
    /// </summary>
    /// <param name="id">User id</param>
    /// <param name="model">A model to edit a user.</param>
    /// <returns></returns>
    [HttpPut("users/{id}")]
    public async Task<ActionResult> Edit(int id, [FromBody] EditUserRequestModel model)
    {
        var user = await Mediator.Send(new EditUserCommand
        {
            Id = id,
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

        return AcceptedAtRoute(routeValues, Mapper.Map<GetUserResult>(user));
    }
}