using System.ComponentModel.DataAnnotations;

namespace Core.Models.Dtos;
public class UserSignup: UserLoggin{
    [EmailAddress]
    [Required(ErrorMessage = "Email is required")]
    public string? Email { get; set; }
}
