namespace Porcupine.Robert.Mrobo.IAM.Groups.GetGroupsCounts;

public record GroupUsersCountDto
{
    public int GroupId { get; init; }
    public string GroupName { get; init; }
    public int UserCount { get; init; }
}