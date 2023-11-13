using Porcupine.Robert.Mrobo.IAM.Groups.Models;

namespace Porcupine.Robert.Mrobo.IAM.Users.Models;

public class User
{
    public int Id { get; set; }
    
    public string Name { get; set; } = string.Empty;
    
    public string ProfileImage { get; set; } = string.Empty;
    
    public HashSet<Group>? Groups { get; set; } = new();
}