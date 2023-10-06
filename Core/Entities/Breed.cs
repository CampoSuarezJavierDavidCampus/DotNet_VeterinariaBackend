namespace Core.Entities;

public class Breed: BaseEntityWithIntId{
    public string Name { get; set; } = null!;
    public int KindId { get; set; }
    public Kind Kind { get; set; } = null!;

    public ICollection<Pet> Pets { get; set; } = new HashSet<Pet>();
}