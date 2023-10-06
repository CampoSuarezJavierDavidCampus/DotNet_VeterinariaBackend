using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;
public class VeterinarianConfiguration : IEntityTypeConfiguration<Veterinarian>{
    public void Configure(EntityTypeBuilder<Veterinarian> builder){
        builder.ToTable("Veterinario");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .IsRequired()
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
            .HasColumnName("ID_VeterinarioPK");
        
        builder.Property(x => x.Name)
            .IsRequired()
            .HasColumnName("Nombre")
            .HasMaxLength(50);
        
        builder.Property(x => x.Email)
            .IsRequired()
            .HasColumnName("CorreoElectronico")
            .HasMaxLength(100);
        
        builder.Property(x => x.PhoneNumber)
            .IsRequired()
            .HasColumnName("Telefono");

        builder.Property(x => x.Specialty)
            .IsRequired()
            .HasColumnName("Especialidad")
            .HasMaxLength(100);
    }
}