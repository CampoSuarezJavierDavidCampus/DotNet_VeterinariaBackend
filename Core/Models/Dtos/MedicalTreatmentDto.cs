using System.ComponentModel.DataAnnotations;

namespace Core.Models.Dtos;
public class MedicalTreatmentDto{
    [Required]
    public string Dose { get; set; } = null!;
    [Required]
    public DateTime DateAdministration { get; set; }
    [Required]
    public string Observation { get; set; } = null!;

    [Required]
    public int MedicineId { get; set; }
    [Required]
    public int AppointmentId { get; set; }
}