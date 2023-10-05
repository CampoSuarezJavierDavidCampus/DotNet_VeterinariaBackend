using System.ComponentModel.DataAnnotations;

namespace Models.Dtos;
public class RoleDto{
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; } = null!;
}