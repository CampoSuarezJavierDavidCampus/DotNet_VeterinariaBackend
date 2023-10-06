using System.ComponentModel.DataAnnotations;

namespace Core.Models.Dtos;

public class VeterinarianDto{
    [Required]
    public string Name { get; set; } = null!;
    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;
    [Required]
    public int PhoneNumber { get; set; }
    [Required]
    public string Specialty { get; set; } = null!;
}