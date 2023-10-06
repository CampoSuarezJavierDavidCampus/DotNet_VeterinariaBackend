using System.ComponentModel.DataAnnotations;

namespace Core.Models.Dtos;
public class UserDto{
    [Required(ErrorMessage = "Username is required")]
    public string UserName { get; set; } = null!;
    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;
    [Required]
    public string Password { get; set; } = null!;
    [Required]
    public string? AccessToken { get; set; } = null;
    [Required]
    public string? RefreshToken { get; set; } = null; 
}
