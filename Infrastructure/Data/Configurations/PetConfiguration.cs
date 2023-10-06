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
        
        builder.Property(x => x.BreedId)
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

        builder.HasData(
            //-Propietario 1
            new{
                Id = 1,
                Name = "Barnie",
                Birthdate = DateTime.Now.AddMonths(-15030),
                OwnerId = 1,
                BreedId = 6
            },
            //-Propietario 2
            new{
                Id = 2,
                Name = "Kus",
                Birthdate = DateTime.Now.AddDays(-30),
                OwnerId = 2,
                BreedId = 7
            },
            new{
                Id = 3,
                Name = "Draco",
                Birthdate = DateTime.Now.AddDays(-130),
                OwnerId = 2,
                BreedId = 2
            },
            new{
                Id = 4,
                Name = "Picote",
                Birthdate = DateTime.Now.AddDays(-10),
                OwnerId = 2,
                BreedId = 8
            },
            //propietario 3
            new{
                Id = 5,
                Name = "Aquiles",
                Birthdate = DateTime.Now.AddMonths(-24),
                OwnerId = 3,
                BreedId = 1
            },
            new{
                Id = 6,
                Name = "Peter",
                Birthdate = DateTime.Now.AddDays(-5),
                OwnerId = 3,
                BreedId = 5
            }
        );
    }
}