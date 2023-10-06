namespace Core.Entities;

public class Appointment: BaseEntityWithIntId{
    public DateTime Date { get; set; }    
    public string Reason { get; set; } = null!;

    public int PetId { get; set; }
    public Pet Pet { get; set; } = null!;

    public int VeterinarianId { get; set; }
    public Veterinarian Veterinarian { get; set; } = null!;

    public ICollection<MedicalTreatment> MedicalTreatments { get; set; } = new HashSet<MedicalTreatment>();
}