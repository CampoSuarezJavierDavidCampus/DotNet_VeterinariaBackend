namespace Core.Interfaces;
public interface IUnitOfWork{
    
    IAppointmentRepository Appointments { get; }
    IBreedRepository Breeds { get; }
    IKindRepository Kinds { get; }
    ILaboratoryRepository Laboratories { get; }
    IMedicalTreatmentRepository MedicalTreatments { get; }
    IMedicineRepository Medicines { get; }
    IMovementMedicineDetailRepository MovementMedicineDetails { get; }
    IMovementMedicineRepository MovementMedicines { get; }
    IMovementTypeRepository MovementTypes { get; }
    IOwnerRepository Owners { get; }
    IPetRepository Pets { get; }
    IRoleRepository Roles { get; }
    ISupplierRepository Suppliers { get; }
    IUserRepository Users { get; }
    IVeterinarianRepository Veterinarians { get; }
    Task<int> SaveAsync();
}