namespace Core.Entities;

public class MovementMedicineDetail{
    public float Price { get; set; }
    public int Quantity { get; set; }
    
    public int MedicineId { get; set; }
    public Medicine Medicine { get; set; } = null!;

    public int MovementMedicineId { get; set; }
    public MovementMedicine MovementMedicine { get; set; } = null!;    
}