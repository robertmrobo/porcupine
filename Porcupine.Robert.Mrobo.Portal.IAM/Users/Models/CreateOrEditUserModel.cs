using System.ComponentModel.DataAnnotations;

namespace Porcupine.Robert.Mrobo.Portal.IAM.Users.Models;

public record CreateOrEditUserModel
{
    public int Id { get; set; }
    
    [Required]
    [MinLength(3)]
    public string Name { get; set; } = string.Empty;
    
    public string ProfileImage { get; set; } = string.Empty;

    [Required]
    public IEnumerable<int> Groups { get; set; } = new List<int>();
}
