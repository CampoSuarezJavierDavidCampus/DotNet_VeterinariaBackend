using System.ComponentModel.DataAnnotations;

namespace Models.Dtos;
public class UserDto{
    [Required(ErrorMessage = "Username is required")]
    public string UserName { get; set; } = null!;
}
