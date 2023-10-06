using System.ComponentModel.DataAnnotations;

namespace Core.Models.Dtos;
public class AppointmentWithPetDto{
    [Required]
    public string Date { get; set; } = null!;  
    [Required]
    public string Reason { get; set; } = null!;
    [Required]
    public string Pet { get; set; }= null!;    
    [Required]
    public string Veterinarian { get; set; } = null!;
}
