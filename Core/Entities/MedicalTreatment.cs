namespace Core.Entities;

public class MedicalTreatment: BaseEntityWithIntId{
    public string Dose { get; set; } = null!;
    public DateTime DateAdministration { get; set; }
    public string Observation { get; set; } = null!;

    public int MedicineId { get; set; }
    public Medicine Medicine { get; set; } = null!;

    public int AppointmentId { get; set; }
    public Appointment Appointment { get; set; } = null!;
    
}