using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;
public class BreedConfiguration : IEntityTypeConfiguration<Breed>{
    public void Configure(EntityTypeBuilder<Breed> builder){
        builder.ToTable("Raza");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .IsRequired()
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
            .HasColumnName("ID_RazaPK");
        
        builder.Property(x => x.KindId)
            .IsRequired()
            .HasColumnName("ID_EspecieFK");
        
        builder.Property(x => x.Name)
            .IsRequired()
            .HasColumnName("Nombre")
            .HasMaxLength(50);
        
        builder.HasOne(x => x.Kind)
            .WithMany(x => x.Breeds)
            .HasForeignKey(x => x.KindId);   
    }
}

/* namespace Core.Entities;

public class Breed: BaseEntityWithIntId{
    public string Name { get; set; } = null!;
    public int KindId { get; set; }
    public Kind Kind { get; set; } = null!;

    public ICollection<Pet> Pets { get; set; } = new HashSet<Pet>();
} */