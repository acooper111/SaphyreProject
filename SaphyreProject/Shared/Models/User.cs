namespace SaphyreProject.Shared.Models;

public class User
{
    public Guid Userid { get; set; } = Guid.NewGuid();
    public string Username { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Name { get; set; } = null!;
}