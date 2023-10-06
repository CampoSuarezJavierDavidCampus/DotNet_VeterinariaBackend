using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;
public class MedicalTreatmentConfiguration : IEntityTypeConfiguration<MedicalTreatment>{
    public void Configure(EntityTypeBuilder<MedicalTreatment> builder){
        builder.ToTable("TratamientoMedico");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .IsRequired()
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
            .HasColumnName("ID_TratamientoPk");
        
        builder.Property(x => x.AppointmentId)
            .IsRequired()
            .HasColumnName("ID_CitaFk");
        
        builder.Property(x => x.MedicineId)
            .IsRequired()
            .HasColumnName("ID_MedicamentoFk");
        
        builder.Property(x => x.Dose)
            .IsRequired()
            .HasColumnName("Dosis")
            .HasMaxLength(100);
        
        builder.Property(x => x.DateAdministration)
            .IsRequired()
            .HasColumnName("FechaAdministracion");

        builder.Property(x => x.Observation)
            .IsRequired()
            .HasColumnName("Observaciones")
            .HasMaxLength(150);
        
        builder.HasOne(x => x.Appointment)
            .WithMany(x => x.MedicalTreatments)
            .HasForeignKey(x => x.AppointmentId);
        
        builder.HasOne(x => x.Medicine)
            .WithMany(x => x.MedicalTreatments)
            .HasForeignKey(x => x.MedicineId);                                
    }
}