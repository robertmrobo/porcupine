namespace Porcupine.Robert.Mrobo.Api.Features.IAM.Groups.CreateGroup;

/// <summary>
/// Represents a model to create a new Group.
/// </summary>
public record CreateGroupRequestModel
{
    public string Name { get; init; } = string.Empty;
    
    public string Description { get; init; } = string.Empty;

    public List<int> PermissionsIds { get; init; } = new List<int>();
}