using System.ComponentModel.DataAnnotations;

namespace Core.Models.Dtos;
public class MovementMedicineDetailDto{
    [Required]
    public float Price { get; set; }
    [Required]
    public int Quantity { get; set; }
    [Required]
    public int MedicineId { get; set; }
    [Required]
    public int MovementMedicineId { get; set; }
}