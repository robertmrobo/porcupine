using Porcupine.Robert.Mrobo.Portal.IAM.Groups.Models;
using Porcupine.Robert.Mrobo.Portal.IAM.Groups.Pages;

namespace Porcupine.Robert.Mrobo.Portal.IAM.Users.Models;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    
    public string ProfileImage { get; set; } = string.Empty;
    
    public HashSet<Group> Groups { get; set; } = new();
}