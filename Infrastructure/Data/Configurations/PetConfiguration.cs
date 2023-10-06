using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;
public class PetConfiguration : IEntityTypeConfiguration<Pet>{
    public void Configure(EntityTypeBuilder<Pet> builder){
        builder.ToTable("Mascota");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .IsRequired()
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
            .HasColumnName("ID_MascotaPK");
        
        builder.Property(x => x.OwnerId)
            .IsRequired()
            .HasColumnName("ID_PropietarioFK");
        
        builder.Property(x => x.Breed)
            .IsRequired()
            .HasColumnName("ID_RazaFK");
        
        builder.Property(x => x.Name)
            .IsRequired()
            .HasColumnName("Nombre")
            .HasMaxLength(50);
        
        builder.Property(x => x.Birthdate)
            .IsRequired()
            .HasColumnName("FechaNacimiento");
        
        builder.HasOne(x => x.Owner)
            .WithMany(x => x.Pets)
            .HasForeignKey(x => x.OwnerId);
        
        builder.HasOne(x => x.Breed)
            .WithMany(x => x.Pets)
            .HasForeignKey(x => x.BreedId);
                        
    }
}