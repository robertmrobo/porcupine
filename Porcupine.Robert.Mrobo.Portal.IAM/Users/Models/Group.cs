using System.ComponentModel.DataAnnotations;

namespace Porcupine.Robert.Mrobo.Portal.IAM.Users.Models;

public class Group 
{
    public int Id { get; set; }
    
    public string Name { get; set; } = string.Empty;
    
    public string Description { get; set; } = string.Empty;

    public HashSet<User>? Users { get; set; } = new();
    
    public HashSet<Permission> Permissions { get; set; } = new();
}

public record CreateOrEditGroupModel
{
    [Required]
    [MinLength(2)]
    public string Name { get; set; } = string.Empty;
    
    [Required]
    public string Description { get; set; } = string.Empty;
    
    public HashSet<SelectablePermission> Permissions { get; set; } = new ();
}

public class SelectablePermission 
{
    public int Id { get; set; }
    
    public string Name { get; set; } = string.Empty;
    
    public string Description { get; set; } = string.Empty;

    public bool Selected { get; set; }
}