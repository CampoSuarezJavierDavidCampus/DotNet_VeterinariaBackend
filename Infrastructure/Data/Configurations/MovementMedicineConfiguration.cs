using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;
public class MovementMedicineConfiguration : IEntityTypeConfiguration<MovementMedicine>{
    public void Configure(EntityTypeBuilder<MovementMedicine> builder){
        builder.ToTable("MovimientoMedicamento");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .IsRequired()
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
            .HasColumnName("ID_MovMedPK");
        
        builder.Property(x => x.MovementTypeId)
            .IsRequired()
            .HasColumnName("ID_TipoFK");
                
        
        builder.Property(x => x.Quantity)
            .IsRequired()
            .HasColumnName("Cantidad");

        builder.Property(x => x.Date)
            .IsRequired()
            .HasColumnName("Fecha");
        
        
        builder.HasOne(x => x.MovementType)
            .WithMany(x => x.MovementMedicines)
            .HasForeignKey(x => x.MovementTypeId);   
    }
}