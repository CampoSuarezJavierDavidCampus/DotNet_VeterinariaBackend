using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;
public class MovementTypeConfiguration : IEntityTypeConfiguration<MovementType>{
    public void Configure(EntityTypeBuilder<MovementType> builder){
        builder.ToTable("TipoMovimiento");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .IsRequired()
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
            .HasColumnName("ID_TipoFK");
        
        builder.Property(x => x.Description)
            .IsRequired()
            .HasColumnName("Descripcion")
            .HasMaxLength(50);
    }
}