using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;
public class LaboratoryConfiguration : IEntityTypeConfiguration<Laboratory>{
    public void Configure(EntityTypeBuilder<Laboratory> builder){
        builder.ToTable("Laboratorio");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .IsRequired()
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
            .HasColumnName("ID_LaboratorioPK");                
        
        builder.Property(x => x.Name)
            .IsRequired()
            .HasColumnName("Nombre")
            .HasMaxLength(50);
        
        builder.Property(x => x.Address)
            .IsRequired()
            .HasColumnName("Direccion")
            .HasMaxLength(100);
        
        builder.Property(x => x.PhoneNumber)
            .IsRequired()
            .HasColumnName("Telefono")
            .HasMaxLength(50);

        builder.HasData(
            new{
                Id = 1,
                Name = "Genfar",
                Address = "centro comercial unicó",
                PhoneNumber = 123
            },
            new{
                Id = 2,
                Name = "MK",
                Address = "los alamos",
                PhoneNumber = 456
            },
            new{
                Id = 3,
                Name = "La Santé",
                Address = "Avenida siempre viva",
                PhoneNumber = 789
            }
        );
    }
}