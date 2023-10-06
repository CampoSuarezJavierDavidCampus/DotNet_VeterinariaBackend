namespace Core.Entities;

public class Supplier: BaseEntityWithIntId{
    public string Name { get; set; } = null!;
    public string Address { get; set; } = null!;
    public int PhoneNumber { get; set; }

    public IEnumerable<Medicine> Medicines { get; set; } = new HashSet<Medicine>();
    public IEnumerable<MedicationsSuppliers> MedicationsSuppliers { get; set; } = new HashSet<MedicationsSuppliers>();
}