namespace Porcupine.Robert.Mrobo.Portal.IAM.Groups.Models;

public record SelectableGroup 
{
    public int Id { get; set; }
    
    public string Name { get; set; } = string.Empty;
    
    public string Description { get; set; } = string.Empty;

    public bool Selected { get; set; }
}