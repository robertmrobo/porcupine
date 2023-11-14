namespace Porcupine.Robert.Mrobo.Portal.IAM.Permissions.Models;

public record SelectablePermission 
{
    public int Id { get; set; }
    
    public string Name { get; set; } = string.Empty;
    
    public string Description { get; set; } = string.Empty;

    public bool Selected { get; set; }
}