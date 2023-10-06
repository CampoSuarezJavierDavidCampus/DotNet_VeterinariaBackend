using System.ComponentModel.DataAnnotations;

namespace Core.Models.Dtos;
public class MedicineWithLaboratoryDto{
    [Required]
    public string Name { get; set; } = null!;
    [Required]
    public int Stock { get; set; }
    [Required]
    public float Price { get; set; }
    [Required]
    public string LaboratorioName { get; set; } = null!;
}