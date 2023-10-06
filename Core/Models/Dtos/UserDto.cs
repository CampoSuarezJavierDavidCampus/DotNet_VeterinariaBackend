using System.ComponentModel.DataAnnotations;

namespace Core.Models.Dtos;
public class UserDto{
    [Required(ErrorMessage = "Username is required")]
    public string UserName { get; set; } = null!;
}
