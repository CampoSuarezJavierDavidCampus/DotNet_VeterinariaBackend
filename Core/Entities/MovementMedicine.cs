namespace Core.Entities;

public class MovementMedicine: BaseEntityWithIntId{
    public int Quantity { get; set; }
    public DateTime Date { get; set; }

    public int MovementTypeId { get; set; }
    public MovementType MovementType { get; set; } = null!;

    
    public ICollection<MovementMedicineDetail> MovementMedicineDetails { get; set; } = new HashSet<MovementMedicineDetail>();
}