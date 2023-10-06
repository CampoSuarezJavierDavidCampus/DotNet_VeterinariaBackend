using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories;
public class UnitOfWork : IUnitOfWork, IDisposable{
    private bool _Dispose = false;
    private readonly ApiContext _Context;

    private IRoleRepository? _Role;
    private IUserRepository? _User;
    private IAppointmentRepository? _Appointment;
    private IBreedRepository? _Breed;
    private IKindRepository? _Kind;
    private ILaboratoryRepository? _Laboratory;
    private IMedicalTreatmentRepository? _MedicalTreatment;
    private IMedicineRepository? _Medicine;
    private IMovementMedicineDetailRepository? _MovementMedicineDetail;
    private IMovementMedicineRepository? _MovementMedicine;
    private IMovementTypeRepository? _MovementType;
    private IOwnerRepository? _Owner;
    private IPetRepository? _Pet;
    private ISupplierRepository? _Supplier;
    private IVeterinarianRepository? _Veterinarian;
    
    public UnitOfWork(ApiContext ctx) => _Context = ctx;



    public IRoleRepository Roles => _Role ??= new RoleRepository(_Context);

    public IUserRepository Users => _User ??= new UserRepository(_Context);

    public IAppointmentRepository Appointments => _Appointment ??= new AppointmentRepository(_Context);

    public IBreedRepository Breeds => _Breed ??= new BreedRepository(_Context);

    public IKindRepository Kinds => _Kind ??= new KindRepository(_Context);

    public ILaboratoryRepository Laboratories => _Laboratory ??= new LaboratoryRepository(_Context);

    public IMedicalTreatmentRepository MedicalTreatments => _MedicalTreatment ??= new MedicalTreatmentRepository(_Context);

    public IMedicineRepository Medicines => _Medicine ??= new MedicineRepository(_Context);

    public IMovementMedicineDetailRepository MovementMedicineDetails => _MovementMedicineDetail ??= new MovementMedicineDetailRepository(_Context);

    public IMovementMedicineRepository MovementMedicines => _MovementMedicine ??= new MovementMedicineRepository(_Context);

    public IMovementTypeRepository MovementTypes => _MovementType ??= new MovementTypeRepository(_Context);

    public IOwnerRepository Owners => _Owner ??= new OwnerRepository(_Context);

    public IPetRepository Pets => _Pet ??= new PetRepository(_Context);

    public ISupplierRepository Suppliers => _Supplier ??= new SupplierRepository(_Context);

    public IVeterinarianRepository Veterinarians => _Veterinarian ??= new VeterinarianRepository(_Context);

    public void Dispose(){
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public void Dispose(bool disposing){
        if(!_Dispose){
            if(disposing){
                _Context.Dispose();
            }
            _Dispose = true;
        }
        
    }

    public async Task<int> SaveAsync()=> await _Context.SaveChangesAsync();
}
