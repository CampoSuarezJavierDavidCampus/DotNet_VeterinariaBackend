namespace Core.Entities;

public class Medicine: BaseEntityWithIntId{
    public string Name { get; set; } = null!;
    public int Stock { get; set; }
    public float Price { get; set; }

    public int LaboratoryId { get; set; }
    public Laboratory Laboratory { get; set; } = null!;

    public IEnumerable<Supplier> Suppliers { get; set; } = new HashSet<Supplier>();
    public IEnumerable<MedicationsSuppliers> MedicationsSuppliers { get; set; } = new HashSet<MedicationsSuppliers>();

    public ICollection<MedicalTreatment> MedicalTreatments { get; set; } = new HashSet<MedicalTreatment>();

    public ICollection<MovementMedicineDetail> MovementMedicineDetails { get; set; } = new HashSet<MovementMedicineDetail>();
}