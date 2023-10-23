using System.ComponentModel.DataAnnotations;

namespace SaphyreProject.Shared.Models;

public class User
{
    public Guid Userid { get; set; } = Guid.NewGuid();
    
    [Required]
    [StringLength(20, ErrorMessage = "Username is too long.")]
    public string Username { get; set; } = null!;
    
    [Required]
    public string Email { get; set; } = null!;
    
    [Required]
    public string Name { get; set; } = null!;
}