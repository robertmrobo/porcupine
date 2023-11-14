namespace Porcupine.Robert.Mrobo.Portal.IAM.Groups.Models;

public record GroupUsersCount
{
    public int GroupId { get; init; }
    
    public string GroupName { get; init; }
    
    public int UserCount { get; init; }
}