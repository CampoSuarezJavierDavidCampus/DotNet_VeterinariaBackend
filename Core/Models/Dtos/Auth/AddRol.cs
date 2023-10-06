using System.ComponentModel.DataAnnotations;

namespace Core.Models.Dtos;
public class AddRol{
    [Required(ErrorMessage = "Username is required")]
    public string? UserName { get; set; }
    
    [Required(ErrorMessage = "Role is required")]
    public string RolName { get; set; } = String.Empty;    
}