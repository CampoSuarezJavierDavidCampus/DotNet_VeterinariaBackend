namespace Core.Entities;

public class Pet: BaseEntityWithIntId{    
    public string Name { get; set; } = null!;
    public DateTime Birthdate { get; set; }

    public int OwnerId { get; set; }
    public Owner Owner { get; set; } = null!;

    public int BreedId { get; set; }
    public Breed Breed { get; set; } = null!;    

    public ICollection<Appointment> Appointments { get; set; } = new HashSet<Appointment>();
}