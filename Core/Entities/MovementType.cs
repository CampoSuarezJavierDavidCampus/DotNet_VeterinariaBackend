namespace Core.Entities;

public class MovementType: BaseEntityWithIntId{
    public string Description { get; set; } = null!;

    public ICollection<MovementMedicine> MovementMedicines { get; set; } = new HashSet<MovementMedicine>();
}