namespace Core.Entities;

public class Kind: BaseEntityWithIntId{
    public string Name { get; set; } = null!;
    public ICollection<Breed> Breeds { get; set; } = new HashSet<Breed>();
}