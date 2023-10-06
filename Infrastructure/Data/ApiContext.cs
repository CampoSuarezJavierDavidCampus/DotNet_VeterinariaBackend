using System.Reflection;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;
public class ApiContext: DbContext{
    public ApiContext(DbContextOptions<ApiContext> opts):base(opts) { }

    
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Breed> Breeds { get; set; }
    public DbSet<Kind> Kinds { get; set; }
    public DbSet<Laboratory> Laboratories { get; set; }
    public DbSet<MedicalTreatment> MedicalTreatments { get; set; }
    public DbSet<Medicine> Medicines { get; set; }
    public DbSet<MovementMedicine> MovementMedicines { get; set; }
    public DbSet<MovementMedicineDetail> MovementMedicineDetails { get; set; }
    public DbSet<MovementType> MovementTypes { get; set; }
    public DbSet<Owner> Owners { get; set; }
    public DbSet<Pet> Pets { get; set; }    
    public DbSet<Role> Roles { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Veterinarian> Veterinarians { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder){
        base.OnModelCreating(modelBuilder);
		modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
	}
}
