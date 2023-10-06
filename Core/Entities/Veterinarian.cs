namespace Core.Entities;

public class Veterinarian: BaseEntityWithIntId{
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public int PhoneNumber { get; set; }
    public string Specialty { get; set; } = null!;

    public ICollection<Appointment> Appointments { get; set; } = new HashSet<Appointment>();

}