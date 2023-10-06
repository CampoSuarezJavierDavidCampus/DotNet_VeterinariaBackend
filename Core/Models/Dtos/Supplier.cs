using System.ComponentModel.DataAnnotations;

namespace Core.Models.Dtos;

public class SupplierDto{
    [Required]
    public string Name { get; set; } = null!;
    [Required]
    public string Address { get; set; } = null!;
    [Required]
    public int PhoneNumber { get; set; }
}