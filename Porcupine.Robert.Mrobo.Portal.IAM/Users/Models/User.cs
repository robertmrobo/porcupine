using System.ComponentModel.DataAnnotations;

namespace Porcupine.Robert.Mrobo.Portal.IAM.Users.Models;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    
    public string ProfileImage { get; set; } = string.Empty;
    
    public HashSet<Group> Groups { get; set; } = new();
}

public record CreateOrEditUserModel
{
    [Required]
    [MinLength(3)]
    public string Name { get; set; } = string.Empty;
    
    public string ProfileImage { get; set; } = string.Empty;

    [Required]
    public IEnumerable<SelectableGroup> Groups { get; set; } = new List<SelectableGroup>();
}

public class SelectableGroup 
{
    public int Id { get; set; }
    
    public string Name { get; set; } = string.Empty;
    
    public string Description { get; set; } = string.Empty;

    public bool Selected { get; set; }
}