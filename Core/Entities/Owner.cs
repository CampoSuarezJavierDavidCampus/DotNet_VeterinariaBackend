namespace Core.Entities;

public class Owner: BaseEntityWithIntId{
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public int PhoneNumber { get; set; }

    public ICollection<Pet> Pets { get; set; } = new HashSet<Pet>();
}