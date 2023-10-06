using System.ComponentModel.DataAnnotations;

namespace Core.Models.Dtos;
public class AppointmentDto{
    [Required]
    public DateTime Date { get; set; }    
    [Required]
    public string Reason { get; set; } = null!;
    [Required]
    public int PetId { get; set; }    
    [Required]
    public int VeterinarianId { get; set; }  
}