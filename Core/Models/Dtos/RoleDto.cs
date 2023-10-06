using System.ComponentModel.DataAnnotations;

namespace Core.Models.Dtos;
public class RoleDto{
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; } = null!;
}