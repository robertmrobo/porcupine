namespace Porcupine.Robert.Mrobo.Api.Features.IAM.Groups.AddUsers;

/// <summary>
/// Represents a model to add users to a group.
/// </summary>
public record AddUsersRequestModel
{
    /// <summary>
    /// Gets or sets the user Ids.
    /// </summary>
    public IEnumerable<int> UserIds { get; set; } = new List<int>();
}