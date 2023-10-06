using System.ComponentModel.DataAnnotations;

namespace Core.Models.Dtos;
public class MovementMedicineDto{
    [Required]
    public int Quantity { get; set; }
    [Required]
    public DateTime Date { get; set; }
    [Required]
    public int MovementTypeId { get; set; }   
}