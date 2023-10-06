using System.ComponentModel.DataAnnotations;

namespace Core.Models.Dtos;
public class MedicineDto{
    [Required]
    public string Name { get; set; } = null!;
    [Required]
    public int Stock { get; set; }
    [Required]
    public float Price { get; set; }
    [Required]
    public int LaboratoryId { get; set; }
}