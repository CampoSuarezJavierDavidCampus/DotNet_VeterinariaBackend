using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;
public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>{
    public void Configure(EntityTypeBuilder<Appointment> builder){
        builder.ToTable("Cita");
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id)
            .IsRequired()
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
            .HasColumnName("Id_Cita");

        builder.Property(x => x.Date)
            .IsRequired()
            .HasColumnName("Fecha");
        
        builder.Property(x => x.Reason)
            .IsRequired()
            .HasColumnName("Motivo")
            .HasMaxLength(100);

        
        builder.Property(x => x.VeterinarianId)
            .IsRequired()
            .HasColumnName("ID_VeterinarioFk");
        
        builder.Property(x => x.PetId)
            .IsRequired()
            .HasColumnName("ID_MascotaFk");
        
        builder.HasOne(x => x.Pet)
            .WithMany(x => x.Appointments)
            .HasForeignKey(x => x.PetId);
        
        builder.HasOne(x => x.Veterinarian)
            .WithMany(x => x.Appointments)
            .HasForeignKey(x => x.VeterinarianId);   

        
        builder.HasData(
            GetData(50)
        );           
    }

   

    private static IEnumerable<Appointment> GetData(int numberoFItems){
        string[] razones = {
                "vacunacion",
                "infeccion",
                "terapia",
                "vision"
        };
        Random random = new();
        List<Appointment> data = new();
        for (int i = 1; i < numberoFItems; i++){
            
            data.Add(new(){
                Id = i,
                Date = DateTime.Now.AddDays(- random.Next(1,365)).AddHours(random.Next(-2, 5)),
                Reason = razones[random.Next(0,3)],
                PetId = random.Next(1,6),
                VeterinarianId = random.Next(1,3)
            });
        }

        return data;
    }
}