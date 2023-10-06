namespace Core.Entities;

public class Laboratory: BaseEntityWithIntId{
    public string Name { get; set; } = null!;
    public string Address { get; set; } = null!;
    public int PhoneNumber { get; set; }

    public ICollection<Medicine> Medicines { get; set; } = new HashSet<Medicine>();
}