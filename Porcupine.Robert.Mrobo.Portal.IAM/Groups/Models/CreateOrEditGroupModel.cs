using System.ComponentModel.DataAnnotations;

namespace Porcupine.Robert.Mrobo.Portal.IAM.Groups.Models;

public record CreateOrEditGroupModel
{
    public int Id { get; set; }
    
    [Required]
    [MinLength(2)]
    public string Name { get; set; } = string.Empty;
    
    [Required]
    public string Description { get; set; } = string.Empty;
    
    public IEnumerable<int> Permissions { get; set; } = new List<int>();
}